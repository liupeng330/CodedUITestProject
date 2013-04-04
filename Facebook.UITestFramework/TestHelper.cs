using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AdSage.Concert.Core.ProxySetting;
using AdSage.Concert.Facebook.Api;
using AdSage.Concert.Facebook.Api.Rest;
using AdSage.Concert.Facebook.Api.Schema.Model;
using AdSage.Concert.Facebook.Api.Session;
using AdSage.Concert.Facebook.FacebookManagementObjects;
using AdSage.Concert.Facebook.Share;
using AdSage.Concert.Shell.ProxySetting;
using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Facebook.UITestFramework.Enums;
using Facebook.UITestFramework.Object;
using Facebook.UITestFramework.UIMaps.UIMap1Classes;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facebook.UITestFramework
{
    public class TestHelper
    {
        public TestHelper(TestBase testBase)
        {
            this.testBase = testBase;
        }

        private TestBase testBase;
        private const int BatchCount = 10;
        private const int MaxThreads = 2;
        private readonly Semaphore pool = new Semaphore(MaxThreads, MaxThreads);

        public Ads FacebookServices
        {
            get
            {
                if (this.facebookServices == null)
                {
                    facebookServices = GetAdsInstance();
                }
                return this.facebookServices;
            }
        }
        private Ads facebookServices;

        private Ads GetAdsInstance()
        {
            string applicationKey = ConfigurationManager.AppSettings["ApplicationKey"];
            DesktopSession destopSession = new DesktopSession(applicationKey, false);
            destopSession.AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            destopSession.ApplicationID = ConfigurationManager.AppSettings["ApplicationID"];
            destopSession.ApplicationSecret = ConfigurationManager.AppSettings["ApplicationSecret"];
            destopSession.CompressHttp = false;
            destopSession.Email = ConfigurationManager.AppSettings["Email"];
            destopSession.Password = ConfigurationManager.AppSettings["Password"];
            destopSession.SessionExpires = false;
            destopSession.UseGraphAuth = true;
            destopSession.UserId = long.Parse(ConfigurationManager.AppSettings["UserId"]);
            destopSession.RequiredPermissions = new List<AdSage.Concert.Facebook.Api.Session.Enums.ExtendedPermissions>();
            destopSession.RequiredPermissions.Add(AdSage.Concert.Facebook.Api.Session.Enums.ExtendedPermissions.ads_management);
            destopSession.RequiredPermissions.Add(AdSage.Concert.Facebook.Api.Session.Enums.ExtendedPermissions.offline_access);

            AdSage.Concert.Facebook.Api.Rest.Ads ads = new AdSage.Concert.Facebook.Api.Rest.Ads(destopSession);
            ProxySettingService.Default.Provider = new ProxySettingProvider();
            //ProxySettingService.Default.Provider.SaveProxy(new ProxySetting(
            //    "http://" + ConfigurationManager.AppSettings["ProxyAddress"],
            //    int.Parse(ConfigurationManager.AppSettings["ProxyPort"]),
            //    true));
            return ads;
        }

        public long CreateCampaignsApi(Facebook.UITestFramework.Object.Campaign addingCampaignObject)
        {
            Dictionary<string, string> campaignSpecs = new Dictionary<string, string>();
            campaignSpecs.Add("account_id", ConfigurationManager.AppSettings["AccountId"]);
            campaignSpecs.Add("name", addingCampaignObject.Name);
            campaignSpecs.Add("daily_budget", (Double.Parse(addingCampaignObject.Budget) * 100).ToString());

            double hourOffset = double.Parse(ConfigurationManager.AppSettings["HourOffSet"]);
            DateTime start = DateTime.SpecifyKind(DateTime.Parse(addingCampaignObject.StartTime), DateTimeKind.Utc);
            //campaignSpecs.Add("time_start", DateHelper.ConvertDateToFacebookDate(start).ToString());
            campaignSpecs.Add("time_start", DateHelper.ConvertAccountDateToFacebookDateDirectly(start, hourOffset).ToString());

            if (addingCampaignObject.StopTime.Equals("0"))
            {
                campaignSpecs.Add("time_stop", "0");
            }
            else
            {
                DateTime stop = DateTime.SpecifyKind(DateTime.Parse(addingCampaignObject.StopTime), DateTimeKind.Utc);
                campaignSpecs.Add("time_stop", DateHelper.ConvertAccountDateToFacebookDateDirectly(stop, hourOffset).ToString());
            }
            var respsone = FacebookServices.createCampaigns(long.Parse(ConfigurationManager.AppSettings["AccountId"]), new Dictionary<string, string>[] { campaignSpecs });
            Assert.AreEqual(0, respsone.failed_campaigns.Length, "Creating campaign '" + addingCampaignObject.Name + "' through API is failed!!");
            if (respsone.updated_campaigns.Length != 0)
            {
                return respsone.updated_campaigns[0];
            }
            else
            {
                return 0;
            }
        }

        public void DeleteCampaignApi(long id)
        {
            var campaignSpec = new Dictionary<string, string>();
            campaignSpec.Add("campaign_status", FacebookStatusUtils.Deleted.ToString());
            campaignSpec.Add("campaign_id", id.ToString());
            var updateResponse = FacebookServices.updateCampaigns(long.Parse(ConfigurationManager.AppSettings["AccountId"]), new Dictionary<string, string>[] { campaignSpec });
            Assert.AreEqual(0, updateResponse.failed_campaigns.Count(), "The number of failed campaigns should be 0!");
            Assert.AreEqual(1, updateResponse.updated_campaigns.Count(), "The number of updated campaigns should be 1!");
        }

        public AdSage.Concert.Facebook.Api.Schema.Model.ads_campaign GetCampaignByNameApi(string name)
        {
            var resposneCampaigns =
                FacebookServices.getCampaigns(long.Parse(ConfigurationManager.AppSettings["AccountId"]),
                                              new List<long>(), false, 500, 0);
            var campaignAdded = (from i in resposneCampaigns where string.Equals(i.name, name, StringComparison.OrdinalIgnoreCase) select i).First();
            return campaignAdded;
        }

        public bool TryGetCampaignByNameApi(string name, out AdSage.Concert.Facebook.Api.Schema.Model.ads_campaign responseCampaign)
        {
            var resposneCampaigns =
                FacebookServices.getCampaigns(long.Parse(ConfigurationManager.AppSettings["AccountId"]),
                                              new List<long>(), false, 500, 0);
            var resultCollection = (from i in resposneCampaigns where string.Equals(i.name, name, StringComparison.OrdinalIgnoreCase) select i);
            if (resultCollection.Count() == 0)
            {
                responseCampaign = null;
                return false;
            }
            responseCampaign = resultCollection.First();
            return true;
        }

        public AdSage.Concert.Facebook.Api.Schema.Model.ads_createAdGroups_response CreateAdvertisementsApi(Facebook.UITestFramework.Object.Advertisement advertisementObject)
        {
            string campaignId = GetCampaignByNameApi(advertisementObject.CampaignName).campaign_id.ToString();

            Facebook.UITestFramework.Object.ads_creative creativeObject = new UITestFramework.Object.ads_creative
            {
                link_url = advertisementObject.DestinationUrl.ToString(),
                title = advertisementObject.Title,
                image_file = Path.GetFileName(ConfigurationManager.AppSettings["ImagePath"]),
                body = advertisementObject.Body,
            };

            Facebook.UITestFramework.Object.ads_targeting targetingObject = new UITestFramework.Object.ads_targeting
            {
                countries = new List<string> { "US" },
                age_min = 18,
                age_max = 65,
                broad_age = 1,
            };

            var advertisementSpec = new Dictionary<string, string>();
            advertisementSpec.Add("campaign_id", campaignId);
            advertisementSpec.Add("name", advertisementObject.AdName);
            advertisementSpec.Add("bid_type", ((int)(advertisementObject.BidType)).ToString());
            advertisementSpec.Add("max_bid", (advertisementObject.MaxBid * 100).ToString());
            advertisementSpec.Add("targeting", Facebook.UITestFramework.Object.ads_targeting.SerializeToJsonString(targetingObject));
            advertisementSpec.Add("creative", Facebook.UITestFramework.Object.ads_creative.SerializeToJsonString(creativeObject));
            advertisementSpec.Add("attached_files", "pic");

            //FileInfo imageFileInfo = new FileInfo(ConfigurationManager.AppSettings["ImagePath"]);
            var imagePath = ConfigurationManager.AppSettings["ImagePath"];
            //return FacebookServices.createAdGroups(long.Parse(ConfigurationManager.AppSettings["AccountId"]), advertisementSpec, imageFileInfo);
            var mediaObj =
                new FacebookMediaObject
                    {
                        FileName = Path.GetFileName(imagePath),
                        ContentType = "image/" + Path.GetExtension(imagePath).Substring(1).ToLower()
                    }.SetValue(
                        File.ReadAllBytes(imagePath));
            return FacebookServices.createAdGroups(long.Parse(ConfigurationManager.AppSettings["AccountId"]),
                                                   new Dictionary<string, string>[] {advertisementSpec},
                                                   new Dictionary<string, FacebookMediaObject> {{"pic", mediaObj}});
        }

        public AdSage.Concert.Facebook.Api.Schema.Model.ads_createAdGroups_response CreateSponsorStoryAdvertisementsApi(Facebook.UITestFramework.Object.Advertisement advertisementObject)
        {
            string campaignId = GetCampaignByNameApi(advertisementObject.CampaignName).campaign_id.ToString();

            //Get connection object id through api by using advertisementobject.title
            var objectIds = FacebookServices.getConnectionObjectIds(long.Parse(ConfigurationManager.AppSettings.Get("AccountId")));
            ads_connection_obj objectId = (from i in objectIds where string.Equals(i.name, advertisementObject.Title, StringComparison.OrdinalIgnoreCase) select i).FirstOrDefault();

            Facebook.UITestFramework.Object.ads_creative creativeObject = new UITestFramework.Object.ads_creative
            {
                link_url = objectId.url,
                link_type = ((int)LinkType.Facebook).ToString(),
                image_file = Path.GetFileName(ConfigurationManager.AppSettings["PageImagePath"]),
                object_id = objectId.id,
            };
            switch (advertisementObject.AdType)
            {
                case AdType.Page_Like_Story:
                    creativeObject.type = ((int)CreativeType.PageLikeEvent).ToString();
                    break;
                case AdType.Page_Post_Story:
                    creativeObject.type = ((int)CreativeType.PagePost).ToString();
                    break;
                case AdType.Page_Post_Like_Story:
                    creativeObject.type = ((int)CreativeType.PagePostLikeStory).ToString();
                    break;
                case AdType.App_Used_Story:
                    creativeObject.type = ((int)CreativeType.AppUsedStory).ToString();
                    break;
                case AdType.App_Share_Story:
                    creativeObject.type = ((int)CreativeType.ApplicationStory).ToString();
                    break;
                default:
                    break;
            }

            Facebook.UITestFramework.Object.ads_targeting targetingObject = new UITestFramework.Object.ads_targeting
            {
                countries = new List<string> { "US" },
                age_min = 18,
                age_max = 65,
                broad_age = 1,
                connections = new List<string> { objectId.id.ToString() },
                friends_of_connections = new List<string> { objectId.id.ToString() },
            };

            var advertisementSpec = new Dictionary<string, string>();
            advertisementSpec.Add("campaign_id", campaignId);
            advertisementSpec.Add("name", advertisementObject.AdName);
            advertisementSpec.Add("bid_type", ((int)(advertisementObject.BidType)).ToString());
            advertisementSpec.Add("max_bid", (advertisementObject.MaxBid * 100).ToString());
            advertisementSpec.Add("targeting", Facebook.UITestFramework.Object.ads_targeting.SerializeToJsonString(targetingObject));
            advertisementSpec.Add("creative", Facebook.UITestFramework.Object.ads_creative.SerializeToJsonString(creativeObject));
            advertisementSpec.Add("attached_files", "pic");

            //FileInfo imageFileInfo = null;
            string imagePath = null;
            if (advertisementObject.AdType == AdType.Page_Like_Story ||
                advertisementObject.AdType == AdType.Page_Post_Story ||
                advertisementObject.AdType == AdType.Page_Post_Like_Story)
            {
                //imageFileInfo = new FileInfo(ConfigurationManager.AppSettings["PageImagePath"]);
                imagePath = ConfigurationManager.AppSettings["PageImagePath"];
            }
            else if (advertisementObject.AdType == AdType.App_Used_Story ||
                advertisementObject.AdType == AdType.App_Share_Story)
            {
                //imageFileInfo = new FileInfo(ConfigurationManager.AppSettings["AppImagePath"]);
                imagePath = ConfigurationManager.AppSettings["AppImagePath"];
            }
            var mediaObj =
                new FacebookMediaObject
                {
                    FileName = Path.GetFileName(imagePath),
                    ContentType = "image/" + Path.GetExtension(imagePath).Substring(1).ToLower()
                }.SetValue(
                        File.ReadAllBytes(imagePath));

            return FacebookServices.createAdGroups(long.Parse(ConfigurationManager.AppSettings["AccountId"]),
                                                   new Dictionary<string, string>[] {advertisementSpec},
                                                   new Dictionary<string, FacebookMediaObject> {{"pic", mediaObj}});
        }

        public AdSage.Concert.Facebook.Api.Schema.Model.ads_adgroup GetAdvertisementsApi(string campaignName, string adName)
        {
            return getAdvertisements(campaignName, adName).FirstOrDefault();
        }

        public bool TryGetAdvertisementByNameApi(string campaignName, string adName, out ads_adgroup responseAd)
        {
            var resultCollection = getAdvertisements(campaignName, adName);
            if (resultCollection.Count() == 0)
            {
                responseAd = null;
                return false;
            }
            responseAd = resultCollection.FirstOrDefault();
            return true;
        }

        public IEnumerable<AdSage.Concert.Facebook.Api.Schema.Model.ads_adgroup> getAdvertisements(string campaignName, string adName)
        {
            var responseCampaign = GetCampaignByNameApi(campaignName);
            var respsoneAds = FacebookServices.getAdGroups(long.Parse(ConfigurationManager.AppSettings["AccountId"]),
                                                           new List<long> {responseCampaign.campaign_id},
                                                           new List<long>(), false, 1000, 0);
            var resultCollection = from i in respsoneAds where string.Equals(i.name, adName, StringComparison.OrdinalIgnoreCase) select i;
            return resultCollection.ToList();
        }

        public void GetCampaignUI(Facebook.UITestFramework.Object.Campaign addingCampaign)
        {
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();

            //Click right button to downlaod campaign
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ContextMenuDownloadAccount();

            GridViewUtilities.GetCampaignUI(addingCampaign.Name, detailedInfoForDownloadWindow.VerifyDownloadOneCampaignNoneAd);
        }

        public void GetAllCampaignsUI()
        {
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();

            //Click right button to downlaod campaign
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ContextMenuDownloadAccount();

            GridViewUtilities.GetAllCampaignsUI(detailedInfoForDownloadWindow.VerifyDownloadAllCampaignsWithAds);
        }

        public void AddCampaignUI(Facebook.UITestFramework.Object.Campaign addCampaign)
        {
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            Facebook.UITestFramework.UIMaps.CampaignsClasses.UIDataGridViewTable campaignGridView = campaignPanel.UIFacebookCampaignGridWindow.UIDataGridViewTable;

            //Add campaign in ui
            campaignPanel.AddCampaign(addCampaign);

            //Get from and to date time
            WinDateTimePicker uIDtpFromDateTimePicker = campaignPanel.UIHaihadsagecom4684830Window2.UIDtpFromWindow.UIDtpFromDateTimePicker;
            WinDateTimePicker uIDtpToDateTimePicker = campaignPanel.UIHaihadsagecom4684830Window3.UIDtpToWindow.UIDtpToDateTimePicker;
            addCampaign.StartTime = uIDtpFromDateTimePicker.DateTime.ToString("MM/dd/yyyy HH:mm");
            addCampaign.StopTime = uIDtpToDateTimePicker.DateTime.ToString("MM/dd/yyyy HH:mm");

            //Parse campaign from campaign grid
            WinRow row;
            bool getCampaignOrNot =
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                    addCampaign.Name,
                    out row);
            Assert.IsTrue(getCampaignOrNot, "Fail to get campaign from campaign grid view!");

            Facebook.UITestFramework.Object.Campaign actualCampaign = Facebook.UITestFramework.Object.Campaign.Parse(row);
            Assert.AreEqual<Facebook.UITestFramework.Object.Campaign>(addCampaign, actualCampaign);
        }

        public void EditCampaignUI(Facebook.UITestFramework.Object.Campaign addingCampaignThroughApi, Facebook.UITestFramework.Object.Campaign editCampaignObject)
        {
            //Edit Campaign
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.EditCampaign(editCampaignObject);

            //Get from and to date time
            WinDateTimePicker uIDtpFromDateTimePicker = campaignPanel.UIHaihadsagecom4684830Window2.UIDtpFromWindow.UIDtpFromDateTimePicker;
            WinDateTimePicker uIDtpToDateTimePicker = campaignPanel.UIHaihadsagecom4684830Window3.UIDtpToWindow.UIDtpToDateTimePicker;
            editCampaignObject.StartTime = uIDtpFromDateTimePicker.DateTime.ToString("MM/dd/yyyy HH:mm");
            editCampaignObject.StopTime = uIDtpToDateTimePicker.DateTime.ToString("MM/dd/yyyy HH:mm");

            //Get campaign in grid view
            WinRow row;
            Assert.IsFalse(
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                    addingCampaignThroughApi.Name,
                    out row));
            Assert.IsTrue(
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                    editCampaignObject.Name,
                    out row));
            Facebook.UITestFramework.Object.Campaign campaignObjectInGrid = Facebook.UITestFramework.Object.Campaign.Parse(row);

            //Compare campaign
            Assert.AreEqual<Facebook.UITestFramework.Object.Campaign>(editCampaignObject, campaignObjectInGrid);
        }

        public void AddAdvertisementUI(Facebook.UITestFramework.Object.Campaign addingCampaignThroughApi)
        {
            //Getting campaign from ui 
            GetCampaignUI(addingCampaignThroughApi);

            //Switch to advertisement tab
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ClickAdsTab();

            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = testBase.Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            advertisementUI.ClickAddAdButton();

            //Choose campaign name from choose campaign window
            Facebook.UITestFramework.UIMaps.ChooseCampaignWindowClasses.ChooseCampaignWindow chooseCampaignWindow = testBase.Get<Facebook.UITestFramework.UIMaps.ChooseCampaignWindowClasses.ChooseCampaignWindow>();
            chooseCampaignWindow.UIChooseaCampaignWindow.WaitForControlExist();
            chooseCampaignWindow.ChooseCampaignByName(addingCampaignThroughApi.Name);
            chooseCampaignWindow.UIChooseaCampaignWindow.WaitForControlNotExist();
        }

        public void GetAdvertisementUI(Facebook.UITestFramework.Object.Campaign addingCampaignThroughApi, Facebook.UITestFramework.Object.Advertisement addingAdvertisementThroughApi)
        {
            //Getting campaign from ui
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ContextMenuDownloadAccount();
            GridViewUtilities.GetCampaignUI(addingCampaignThroughApi.Name, detailedInfoForDownloadWindow.VerifyDownloadOneCampaignOneAd);

            //Switch to advertisement tab
            campaignPanel.ClickAdsTab(1);

            //Get Ad from AdGridVeiw
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = testBase.Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            WinRow row;
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetOneRowByName(headerRow, addingAdvertisementThroughApi.AdName, out row), "The ad name in advertisement grid view should be found!!");
            Facebook.UITestFramework.Object.Advertisement advertisementInGridView = Facebook.UITestFramework.Object.Advertisement.Parse(row);

            //Compare Ad
            addingAdvertisementThroughApi.SuggestedBid.IsEmpty = true;
            addingAdvertisementThroughApi.TargetingEstimation = 0;
            addingAdvertisementThroughApi.AdStatus = advertisementInGridView.AdStatus;
            Assert.AreEqual<Facebook.UITestFramework.Object.Advertisement>(addingAdvertisementThroughApi, advertisementInGridView, "The advertisement in grid view is not correct!!");
        }

        public static void ReconnectVpn()
        {
            if (bool.Parse(ConfigurationManager.AppSettings.Get("NeedVPN")))
            {
                System.Diagnostics.Process reconnectVpnBat = System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["ReconnectVpnPath"]);
                reconnectVpnBat.WaitForExit();
            }
        }

        public void UploadChanges(Action verifyMethod)
        {
            //Upload
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.UploadChanges();

            //Wait Detailed Info for Upload windows exist
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.WaitForControlExist();

            //Wait the status column change to "Finished"
            detailedInfoForUploadWindow.UIDataGridViewTableForJob.WaitForStatusPropertyEqual("Finished");

            //Verify information tab
            try
            {
                verifyMethod();
            }
            catch
            {
                detailedInfoForUploadWindow.ClickErrorMessageTab();
                throw;
            }

            //Click close button
            WinButton closeButtonInDetailedInfoForUploadWindow = detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.UICloseWindow.UICloseButton;
            Mouse.Click(closeButtonInDetailedInfoForUploadWindow);

            //Wait Detailed Info for upload windows not exist
            detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.WaitForControlNotExist();
        }

        public void VerifyCampaignStatusColumnIsNull(string campaignName)
        {
            WinRow row;

            var campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            var dataGridTable = campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            var facebookAccountItem = testBase.Get<UIMaps.UIMap1Classes.UIMap1>();
            facebookAccountItem.ExpandFacebookAccount();
            Assert.IsTrue(
                dataGridTable.TryGetOneRowByName(
                    headerRow,
                    campaignName,
                    out row));
            WinCell statusCell = row.Cells[0] as WinCell;
            Assert.AreEqual<string>(String.Empty, statusCell.GetProperty(WinCell.PropertyNames.Value) as string);
        }

        public void VerifyAdStatusColumnIsNull(string adName)
        {
            WinRow row;

            var advertisementUI = testBase.Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(
                dataGridTable.TryGetOneRowByName(
                    headerRow,
                    adName,
                    out row));
            WinCell statusCell = row.Cells[0] as WinCell;
            Assert.AreEqual<string>(String.Empty, statusCell.GetProperty(WinCell.PropertyNames.Value) as string);
        }

        public void GetCampaignArray(string[] gettingcampaignArray)
        {
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();

            //Click right button to downlaod campaign
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.RightClickDownloadAccount();

            GridViewUtilities.GetCampaignArray(gettingcampaignArray, detailedInfoForDownloadWindow.VerifyDownloadFourCampaignWithAds);
        }

        public void GetPerformanceDateRange(Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload downloadPerformanceInfo, out string performanceDateRange)
        {
            performanceDateRange = downloadPerformanceInfo.UIDataGridViewTableForJob.GetDateRangeCellValue();
        }

        public void PrepareDownloadPerformanceData(UIMaps.PerformanceDataClasses.PerformanceData performanceData)
        {
            //Download Performance data
            performanceData.ClickDownloadPerformanceButton();
            performanceData.UIDownloadPerformanceWindow.WaitForControlExist();

            performanceData.SelectFacebookAccount();
            performanceData.UICreateCustomDateRangWindow.WaitForControlExist();

            //Select date range from CustomRangeWindow
            performanceData.SelectStartDate();
            performanceData.SelectEndDate();
            performanceData.ClickCreateCustomDateOKButton();
            performanceData.UICreateCustomDateRangWindow.WaitForControlNotExist();
            performanceData.ClickDownloadCheckedAccounts();
            performanceData.UIDownloadPerformanceWindow.WaitForControlNotExist();
        }

        public void DownloadPerformanceData(Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload performanceDataInfo, string performanceDateRange, Action<string> verifyMethod)
        {
            //Verify downloaded performance data 
            performanceDataInfo.UIDataGridViewTableForJob.WaitForPerformanceStatusPropertyEqual("Finished");
            try
            {
                verifyMethod(performanceDateRange);
            }
            catch
            {
                performanceDataInfo.ClickErrorMessageTab();
                throw;
            }

            //Click close button
            performanceDataInfo.ClickCloseButton();
            performanceDataInfo.UIDetailedInfoforDownlWindow.WaitForControlNotExist();
        }

        public DataRow[] GetPerformanceDataFromCSV(string campaignName, string fileName)
        {
            DataTable dataVehicle = new DataTable();
            DataRow[] result;
            string filePath = ConfigurationManager.AppSettings.Get("CSVFilePath");
            string path = Path.Combine(Path.GetDirectoryName(filePath), fileName);
            bool isReadCompleted = CSVFileUtilities.ReadDatasFromCSVFile(ref dataVehicle, path);
            if (isReadCompleted)
            {
                string filterExpression = "CampaignName='" + campaignName + "'";
                result = dataVehicle.Select(filterExpression);
            }
            else
            {
                throw new Exception("Failed to fetch data from CSV file!");
            }
            return result;
        }

        public void GetAllAdvertisementsUI(Object.Campaign addingCampaignThroughApi, List<Object.Advertisement> addingAdvertisementThroughApi)
        {
            //Getting campaign from ui
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ContextMenuDownloadAccount();
            GridViewUtilities.GetCampaignUI(addingCampaignThroughApi.Name, detailedInfoForDownloadWindow.VerifyDownloadOneCampaignWithSeveralAds);

            //Switch to advertisement tab
            campaignPanel.ClickAdsTab(5);

            //Get Ad from AdGridVeiw
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = testBase.Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            List<WinRow> advertisementRows = new List<WinRow>();
            Object.Advertisement oneAdvertisementThroughApi = null;
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetSomeRowsByName(headerRow, addingCampaignThroughApi.Name, advertisementRows), "The ads name in advertisement grid view should be found!!");
            List<Object.Advertisement> advertisementInGridView = Facebook.UITestFramework.Object.Advertisement.Parse(advertisementRows);

            //Compare Ad
            for (int i = 0; i < advertisementInGridView.Count; i++)
            {
                oneAdvertisementThroughApi = addingAdvertisementThroughApi.Find(advertisement => string.Equals(advertisement.AdName, advertisementInGridView[i].AdName, StringComparison.InvariantCultureIgnoreCase));
                oneAdvertisementThroughApi.SuggestedBid.IsEmpty = true;
                oneAdvertisementThroughApi.TargetingEstimation = 0;
                oneAdvertisementThroughApi.AdStatus = advertisementInGridView[i].AdStatus;
                if (oneAdvertisementThroughApi.AdStatus != advertisementInGridView[i].AdStatus)
                {
                    oneAdvertisementThroughApi.AdStatus = advertisementInGridView[i].AdStatus;
                    Assert.AreEqual<Facebook.UITestFramework.Object.Advertisement>(oneAdvertisementThroughApi, advertisementInGridView[i], "The advertisement in grid view is not correct!!");
                }
                else
                {
                    Assert.AreEqual<Facebook.UITestFramework.Object.Advertisement>(oneAdvertisementThroughApi, advertisementInGridView[i], "The advertisement in grid view is not correct!!");
                }
            }
        }

        public void GetBulkAdvertisements(Campaign addingCampaignThroughApi, List<Advertisement> addingAdvertisements, List<ads_createAdGroups_response> responseResult)
        {
            int offset = 0;
            string campaignName = addingCampaignThroughApi.Name;
            addingAdvertisements = AdGenerator(campaignName).ToList();
            var responseSet = new List<ads_createAdGroups_response>();

            while (offset < addingAdvertisements.Count)
            {
                int count = Math.Min(BatchCount, addingAdvertisements.Count - offset);
                var batchAdList = addingAdvertisements.Skip(offset).Take(count).ToList();

                var syncEvent = new AutoResetEvent(false);
                ExecuteTaskAsync(
                    CreateAdGroupsFunc,
                    HandleResultFunc,
                    new object[] {campaignName, batchAdList, responseSet},
                    responseResult,
                    syncEvent);

                offset += count;
            }
        }

        private AdType NextAdvertisementType()
        {
            return (AdType) testBase.RandomData.NextChoice((int) AdType.External_URL, (int) AdType.Page_Like_Story,
                                                           (int) AdType.Page_Post_Like_Story,
                                                           (int) AdType.App_Share_Story,
                                                           (int) AdType.App_Used_Story);
        }

        public IList<Advertisement> AdGenerator(string campaignName)
        {
            var adList = new List<Advertisement>();
            Parallel.For(0, 500, item =>
            {
                AdType adType = NextAdvertisementType();
                var advertisement = new Advertisement();
                if (adType == AdType.External_URL)
                {
                    advertisement = Advertisement.NextExternalAdvertisement(testBase.RandomData);
                    advertisement.CampaignName = campaignName;
                }
                else if (adType == AdType.Page_Like_Story)
                {
                    advertisement = Advertisement.NextPageLikeStoryAdvertisement(testBase.RandomData);
                    advertisement.CampaignName = campaignName;
                }
                else if (adType == AdType.Page_Post_Like_Story)
                {
                    advertisement = Advertisement.NextPagePostLikeStoryAdvertisement(testBase.RandomData);
                    advertisement.CampaignName = campaignName;
                }
                else if (adType == AdType.App_Used_Story)
                {
                    advertisement = Advertisement.NextAppUsedStoryAdvertisement(testBase.RandomData);
                    advertisement.CampaignName = campaignName;
                }
                else if (adType == AdType.App_Share_Story)
                {
                    advertisement = Advertisement.NextAppShareStoryAdvertisement(testBase.RandomData);
                    advertisement.CampaignName = campaignName;
                }
                Monitor.Enter(adList);
                adList.Add(advertisement);
                Monitor.Exit(adList);
            });
            return adList;
        }

        public void ExecuteTaskAsync<T, R>(Func<object, T> executeFunc, Action<T, R> HandleResultFunc, object obj, R responseResult, AutoResetEvent syncEvent)
        {
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    T response = executeFunc(obj);
                    HandleResultFunc(response, responseResult);
                    syncEvent.Set();
                });
        }

        private IList<ads_createAdGroups_response> CreateAdGroupsFunc(object obj)
        {
            this.pool.WaitOne();
            var args = obj as object[];
            var campaignName = args[0].ToString();
            var batchAdList = args[1] as List<Advertisement>;
            var responseSet = args[2] as List<ads_createAdGroups_response>;
            ads_createAdGroups_response response = null;

            foreach (var advertisement in batchAdList)
            {
                advertisement.CampaignName = campaignName;
                if (advertisement.AdType == AdType.External_URL)
                {
                    response = CreateAdvertisementsApi(advertisement);
                }
                else
                {
                    response = CreateSponsorStoryAdvertisementsApi(advertisement);
                }
            }

            lock (responseSet)
            {
                responseSet.Add(response);
            }

            this.pool.Release();
            return responseSet;
        }

        private void HandleResultFunc(IList<ads_createAdGroups_response> source, List<ads_createAdGroups_response> responseResult)
        {
            lock (responseResult)
            {
                if (source == null)
                {
                    return;
                }
                responseResult.AddRange(source.ToList());
            }
        }

        public void GetHundredsOfAdvertisementsUI(Campaign addingCampaignThroughApi, List<Advertisement> addingAdvertisementThroughApi)
        {
            //Getting campaign from ui
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ContextMenuDownloadAccount();
            GridViewUtilities.GetCampaignUI(addingCampaignThroughApi.Name, detailedInfoForDownloadWindow.VerifyDownloadOneCampaignWithSeveralAds);

            //Switch to advertisement tab
            campaignPanel.ClickAdsTab(500);

            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = testBase.Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            Object.Advertisement oneAdvertisementThroughApi = null;
            List<WinRow> advertisementRows = new List<WinRow>();
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetSomeRowsByName(headerRow, addingCampaignThroughApi.Name, advertisementRows), "The ads name in advertisement grid view should be found!!");
        }
    }
}
