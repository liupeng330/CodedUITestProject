using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using AdSage.Concert.Facebook.Api.Schema.Model;
using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Facebook.UITestFramework;
using Facebook.UITestFramework.Enums;
using Facebook.UITestFramework.Object;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facebook.UITest
{
    [CodedUITest]
    public class BVT : TestBase
    {
        private List<long> deleteCampaignIds = new List<long>();

        public BVT()
        {
            this.RunVPN = true;
            this.RunProxy = false;
        }

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();

            //Click Add New User button
            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = Get<Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter>();
            WinButton addNewUserButton = accountManagementCenter.UIAccountManagementCenWindow.UISageToolStrip1ToolBar.UIAddNewUserButton;
            Mouse.Click(addNewUserButton);

            //Wait Add User Window Exist
            Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers addUser = Get<Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers>();
            addUser.UIAddUserWindow.WaitForControlExist();

            //Click Add New User
            addUser.AddFacebookUser();

            //Wait Facebook Login Windows Exist
            Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin facbookLogin = Get<Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin>();
            facbookLogin.UIFacebookLoginWindow.WaitForControlExist();

            //facbookLogin.Login();
            Common.UITestFramework.UIMaps.LoginWindow loginWindow = Get<Common.UITestFramework.UIMaps.LoginWindow>();
            bool notHai = loginWindow.Login(
                ConfigurationManager.AppSettings["Email"],
                ConfigurationManager.AppSettings["Password"]);

            //Wait Add User Window Not Exist
            addUser.UIAddUserWindow.WaitForControlNotExist();

            //Need to double login
            if (notHai)
            {
                addUser.AddFacebookUser();
                facbookLogin.UIFacebookLoginWindow.WaitForControlExist();

                loginWindow.Login(
                    ConfigurationManager.AppSettings["Email"],
                    ConfigurationManager.AppSettings["Password"]);

                addUser.UIAddUserWindow.WaitForControlNotExist();
            }

            //Activate account
            accountManagementCenter.ClickActivateButton();

            //Wait AccountManagementCenter window loading completed
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlReady();

            //Verify Inactives accounts
            accountManagementCenter.VerifyActiveAccount();

            //Close AccountManagementCenter window close
            System.Threading.Thread.Sleep(5 * 1000);
            accountManagementCenter.ClickCloseWindowButton();

            //Wait AccountManagementCenter window not exist
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            //Wait Question Window Exist
            Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = Get<Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow>();
            questionWindow.UIQuestionWindow.WaitForControlExist();

            //Click No button
            questionWindow.ClickNoButton();

            //Wait Question Window Not Exist
            questionWindow.UIQuestionWindow.WaitForControlNotExist();

            //Navigate to campaign panel
            Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow mainWindow = Get<Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.NavigateToCampaignPanel();
        }

        public override void OnTestCleanup()
        {
            base.OnTestCleanup();
            foreach (var id in this.deleteCampaignIds)
            {
                TestHelper.DeleteCampaignApi(id);
            }
        }


        public TestHelper TestHelper
        {
            get
            {
                if (this.testHelper == null)
                {
                    testHelper = new TestHelper(this);
                }
                return testHelper;
            }
        }
        private TestHelper testHelper;

        [TestMethod]
        public void AddCampaign_Facebook()
        {
            Facebook.UITestFramework.Object.Campaign addCampaign = UITestFramework.Object.Campaign.NextCampaign(this.RandomData);

            TestHelper.AddCampaignUI(addCampaign);

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUploadOneCampaign);

            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            TestHelper.VerifyCampaignStatusColumnIsNull(addCampaign.Name);

            //Add this campaign name to delete campaign name list
            this.deleteCampaignIds.Add(TestHelper.GetCampaignByNameApi(addCampaign.Name).campaign_id);
        }

        [TestMethod]
        public void GetCampaign_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            var campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            TestHelper.GetCampaignUI(addingCampaignThroughApi);

            //Get campaign in grid view
            WinRow row;
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                addingCampaignThroughApi.Name,
                out row);
            Facebook.UITestFramework.Object.Campaign campaignObjectInGrid = Facebook.UITestFramework.Object.Campaign.Parse(row);

            //Compare campaign
            addingCampaignThroughApi.RunStatus = "Scheduled";
            addingCampaignThroughApi.StartTime = campaignObjectInGrid.StartTime;
            addingCampaignThroughApi.StopTime = campaignObjectInGrid.StopTime;
            Assert.AreEqual<Facebook.UITestFramework.Object.Campaign>(addingCampaignThroughApi, campaignObjectInGrid, "The campaign in grid view is not correct!!");
        }

        [TestMethod]
        public void GetAllCampaigns_Facebook()
        {
            TestHelper.GetAllCampaignsUI();
        }

        [TestMethod]
        public void DeleteCampaign_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            TestHelper.CreateCampaignsApi(addingCampaignThroughApi);

            TestHelper.GetCampaignUI(addingCampaignThroughApi);

            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            campaignPanel.ClickDeleteButton();

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyDeleteOneCampaign);

            Assert.AreEqual<int>(0,
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.GetRowCount(
                    campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow),
                "After deleting campaign, there should not be an campaign in grid view!");
            AdSage.Concert.Facebook.Api.Schema.Model.ads_campaign responseCampaign;
            Assert.IsFalse(TestHelper.TryGetCampaignByNameApi(addingCampaignThroughApi.Name, out responseCampaign));
        }

        [TestMethod]
        public void EditCampaign_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            TestHelper.GetCampaignUI(addingCampaignThroughApi);

            //Edit Campaign
            UITestFramework.Object.Campaign editCampaignObject = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            editCampaignObject.Budget = "2.01";
            editCampaignObject.RunStatus = "Scheduled";
            this.deleteCampaignIds.Add(campaignId);
            TestHelper.EditCampaignUI(addingCampaignThroughApi, editCampaignObject);

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUpdateOneCampaign);

            //Verify Status Column
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            TestHelper.VerifyCampaignStatusColumnIsNull(editCampaignObject.Name);
        }

        [TestMethod]
        public void RevertNewCampaign_Facebook()
        {
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();

            Facebook.UITestFramework.Object.Campaign addCampaign = UITestFramework.Object.Campaign.NextCampaign(this.RandomData);
            TestHelper.AddCampaignUI(addCampaign);

            //Click rever button
            campaignPanel.ClickRevertButton();

            //Wait waiting window not exist
            Common.UITestFramework.UIMaps.UIWaitingWindowClass waitingWindow = Get<Common.UITestFramework.UIMaps.UIWaitingWindowClass>();
            waitingWindow.UIWaitingWindow.WaitForControlNotExist();

            //Verify that there is no one campaign in campaign grid view 
            WinRow row;
            Assert.IsFalse(
            campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                addCampaign.Name,
                out row),
 "After reverting a new campaign, there should not be an campaign in grid view!!");
        }

        [TestMethod]
        public void RevertEditCampaign_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            TestHelper.GetCampaignUI(addingCampaignThroughApi);

            //Edit Campaign
            Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<Facebook.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
            UITestFramework.Object.Campaign editCampaignObject = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            editCampaignObject.BudgetType = "Lifetime";
            editCampaignObject.Budget = "13.01";
            editCampaignObject.RunStatus = "Scheduled";
            TestHelper.EditCampaignUI(addingCampaignThroughApi, editCampaignObject);

            //Click rever button
            campaignPanel.ClickRevertButton();

            //Wait waiting window not exist
            Common.UITestFramework.UIMaps.UIWaitingWindowClass waitingWindow = Get<Common.UITestFramework.UIMaps.UIWaitingWindowClass>();
            waitingWindow.UIWaitingWindow.WaitForControlNotExist();

            //Verify revert
            WinRow row;
            Assert.IsTrue(
                campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    campaignPanel.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow,
                    addingCampaignThroughApi.Name,
                    out row),
                "There should be an campaign in grid view!!");
            Facebook.UITestFramework.Object.Campaign revertedCampaignObjectInGrid = Facebook.UITestFramework.Object.Campaign.Parse(row);
            Assert.AreEqual(addingCampaignThroughApi.Name, revertedCampaignObjectInGrid.Name, "The campaign name should be equal to the one before editing!!");
            Assert.AreEqual(addingCampaignThroughApi.Budget, revertedCampaignObjectInGrid.Budget, "The campaign budget should be equal to the one before editing!!");
            Assert.AreEqual(addingCampaignThroughApi.BudgetType, revertedCampaignObjectInGrid.BudgetType, "The campaign type should be equal to the one before editing!!");
        }

        [TestMethod]
        public void AddExternalAdvertisement_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            TestHelper.AddAdvertisementUI(addingCampaignThroughApi);

            //Add advertisement
            Facebook.UITestFramework.Object.Advertisement addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextExternalAdvertisement(this.RandomData);
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            advertisementUI.AddAdvertisement(addingAdvertisementThroughApi, false);
            advertisementUI.ChooseImageFromLocal(ConfigurationManager.AppSettings["ImagePath"]);

            //Click Suggested Bid Button
            advertisementUI.ClickSuggestedBidButton();
            addingAdvertisementThroughApi.SuggestedBid = UITestFramework.Object.SuggestedBid.ParseWithCurrency(advertisementUI.GetSuggestBid());

            //Get Ad from AdGridVeiw
            WinRow row;
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetOneRowByName(headerRow, addingAdvertisementThroughApi.AdName, out row), "The ad name in advertisement grid view should be found!!");
            UITestFramework.Object.Advertisement advertisementInGridView = UITestFramework.Object.Advertisement.Parse(row);

            //Compare Ad
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            addingAdvertisementThroughApi.TargetingEstimation = advertisementInGridView.TargetingEstimation;
            Assert.AreEqual<UITestFramework.Object.Advertisement>(addingAdvertisementThroughApi, advertisementInGridView, "The advertisement in advertisement grid view should be same with the one in edit panel!!");

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUploadOneAdvertisement);

            TestHelper.VerifyAdStatusColumnIsNull(addingAdvertisementThroughApi.AdName);
        }

        [TestMethod]
        public void GetExternalAdvertisement_Facebook()
        {
            //Adding campaign through api
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Adding advertisement through api
            UITestFramework.Object.Advertisement addingAdvertisementThroughApi = UITestFramework.Object.Advertisement.NextExternalAdvertisement(RandomData);
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateAdvertisementsApi(addingAdvertisementThroughApi);

            TestHelper.GetAdvertisementUI(addingCampaignThroughApi, addingAdvertisementThroughApi);
        }

        [TestMethod]
        public void DeleteExternalAdvertisement_Facebook()
        {
            //Adding campaign through api
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Adding advertisement through api
            UITestFramework.Object.Advertisement addingAdvertisementThroughApi = UITestFramework.Object.Advertisement.NextExternalAdvertisement(RandomData);
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateAdvertisementsApi(addingAdvertisementThroughApi);

            TestHelper.GetAdvertisementUI(addingCampaignThroughApi, addingAdvertisementThroughApi);

            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            advertisementUI.ClickDeleteButton();

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyDeleteOneAdvertisement);

            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.AreEqual<int>(0, dataGridTable.GetRowCount(headerRow));
            //Assert.AreEqual<int>(0, advertisementUI.UIFacebookAdGroupGridVWindow.UIDataGridViewTable.Rows.Count);
            //AdSage.Concert.Facebook.Api.Schema.Model.ads_adgroup responseAd;
            //Assert.IsFalse(TestHelper.TryGetAdvertisementByNameApi(addingCampaignThroughApi.Name, addingAdvertisementThroughApi.AdName, out responseAd));
        }

        [TestMethod]
        public void EditExternalAdvertisement_Facebook()
        {
            //Adding campaign through api
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Adding advertisement through api
            UITestFramework.Object.Advertisement addingAdvertisementThroughApi = UITestFramework.Object.Advertisement.NextExternalAdvertisement(RandomData);
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateAdvertisementsApi(addingAdvertisementThroughApi);

            TestHelper.GetAdvertisementUI(addingCampaignThroughApi, addingAdvertisementThroughApi);

            UITestFramework.Object.Advertisement editingAdvertisement = UITestFramework.Object.Advertisement.NextExternalAdvertisement(RandomData);
            editingAdvertisement.AdStatus = Facebook.UITestFramework.Enums.AdStatus.Pendingreview;
            editingAdvertisement.DestinationUrl = addingAdvertisementThroughApi.DestinationUrl;
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            advertisementUI.AddAdvertisement(editingAdvertisement, true);

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUpdateOneAdvertisement);

            TestHelper.VerifyAdStatusColumnIsNull(editingAdvertisement.AdName);
        }

        [TestMethod]
        public void AddPageLikeStoryAdvertisement_Facebook()
        {
            addSponsorStoryAdvertisement(AdType.Page_Like_Story);
        }

        [TestMethod]
        public void AddPagePostStoryAdvertisement_Facebook()
        {
            addSponsorStoryAdvertisement(AdType.Page_Post_Story);
        }

        [TestMethod]
        public void AddPagePostLikeStoryAdvertisement_Facebook()
        {
            addSponsorStoryAdvertisement(AdType.Page_Post_Like_Story);
        }

        private void addSponsorStoryAdvertisement(AdType type)
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            TestHelper.AddAdvertisementUI(addingCampaignThroughApi);

            //Add advertisement
            Facebook.UITestFramework.Object.Advertisement addingAdvertisementThroughApi = new Advertisement();
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            switch (type)
            {
                case AdType.Page_Like_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPageLikeStoryAdvertisement(this.RandomData);
                    advertisementUI.AddPageLikeStoryAdvertisement(addingAdvertisementThroughApi);
                    break;
                case AdType.Page_Post_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPagePostStoryAdvertisement(this.RandomData);
                    advertisementUI.AddPagePostStoryAdvertisement(addingAdvertisementThroughApi);
                    break;
                case AdType.Page_Post_Like_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPagePostLikeStoryAdvertisement(this.RandomData);
                    advertisementUI.AddPagePostLikeStoryAdvertisement(addingAdvertisementThroughApi);
                    break;
                case AdType.App_Share_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextAppShareStoryAdvertisement(this.RandomData);
                    advertisementUI.AddAppShareStoryAdvertisement(addingAdvertisementThroughApi);
                    break;
                case AdType.App_Used_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextAppUsedStoryAdvertisement(this.RandomData);
                    advertisementUI.AddAppUsedStoryAdvertisement(addingAdvertisementThroughApi);
                    break;
                default:
                    break;
            }

            //Click Suggested Bid Button
            advertisementUI.ClickSuggestedBidButton();
            addingAdvertisementThroughApi.SuggestedBid = UITestFramework.Object.SuggestedBid.ParseWithCurrency(advertisementUI.GetSuggestBid());

            //Get Ad from AdGridVeiw
            WinRow row;
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetOneRowByName(headerRow, addingAdvertisementThroughApi.AdName, out row), "The ad name in advertisement grid view should be found!!");
            UITestFramework.Object.Advertisement advertisementInGridView = UITestFramework.Object.Advertisement.Parse(row);

            //Compare Ad
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            addingAdvertisementThroughApi.TargetingEstimation = advertisementInGridView.TargetingEstimation;
            addingAdvertisementThroughApi.DestinationUrl = null;
            Assert.AreEqual<UITestFramework.Object.Advertisement>(addingAdvertisementThroughApi, advertisementInGridView, "The advertisement in advertisement grid view should be same with the one in edit panel!!");

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUploadOneAdvertisement);

            TestHelper.VerifyAdStatusColumnIsNull(addingAdvertisementThroughApi.AdName);
        }

        [TestMethod]
        public void DeletePageLikeStoryAdvertisement_Facebook()
        {
            deleteSponsorStoryAdvertisement(AdType.Page_Like_Story);
        }

        [TestMethod]
        public void DeletePagePostStoryAdvertisement_Facebook()
        {
            deleteSponsorStoryAdvertisement(AdType.Page_Post_Story);
        }

        [TestMethod]
        public void DeletePagePostLikeStoryAdvertisement_Facebook()
        {
            deleteSponsorStoryAdvertisement(AdType.Page_Post_Like_Story);
        }

        private void deleteSponsorStoryAdvertisement(AdType type)
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(type, out campaignObject, out adObject);
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            advertisementUI.ClickDeleteButton();

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyDeleteOneAdvertisement);

            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.AreEqual<int>(0, dataGridTable.GetRowCount(headerRow));
            //Assert.AreEqual<int>(0, advertisementUI.UIFacebookAdGroupGridVWindow.UIDataGridViewTable.Rows.Count);
            //AdSage.Concert.Facebook.Api.Schema.Model.ads_adgroup responseAd;
            //Assert.IsFalse(TestHelper.TryGetAdvertisementByNameApi(addingCampaignThroughApi.Name, addingAdvertisementThroughApi.AdName, out responseAd));
        }

        [TestMethod]
        public void GetPageLikeStoryAdvertisement_Facebook()
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(AdType.Page_Like_Story, out campaignObject, out adObject);
        }

        [TestMethod]
        public void GetPagePostStoryAdvertisement_Facebook()
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(AdType.Page_Post_Story, out campaignObject, out adObject);
        }

        [TestMethod]
        public void GetPagePostLikeStoryAdvertisement_Facebook()
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(AdType.Page_Post_Like_Story, out campaignObject, out adObject);
        }

        private void getSponsorStoryAdvertisement(AdType type, out UITestFramework.Object.Campaign addingCampaign, out UITestFramework.Object.Advertisement addingAd)
        {
            //Adding campaign through api
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            addingCampaign = addingCampaignThroughApi;
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Adding advertisement through api
            UITestFramework.Object.Advertisement addingAdvertisementThroughApi = new Advertisement();
            switch (type)
            {
                case AdType.Page_Like_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPageLikeStoryAdvertisement(this.RandomData);
                    break;
                case AdType.Page_Post_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPagePostStoryAdvertisement(this.RandomData);
                    break;
                case AdType.Page_Post_Like_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextPagePostLikeStoryAdvertisement(this.RandomData);
                    break;
                case AdType.App_Share_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextAppShareStoryAdvertisement(this.RandomData);
                    break;
                case AdType.App_Used_Story:
                    addingAdvertisementThroughApi = Facebook.UITestFramework.Object.Advertisement.NextAppUsedStoryAdvertisement(this.RandomData);
                    break;
                default:
                    break;
            }
            addingAdvertisementThroughApi.CampaignName = addingCampaignThroughApi.Name;
            addingAd = addingAdvertisementThroughApi;
            TestHelper.CreateSponsorStoryAdvertisementsApi(addingAdvertisementThroughApi);

            TestHelper.GetAdvertisementUI(addingCampaignThroughApi, addingAdvertisementThroughApi);
        }

        [TestMethod]
        public void EditPageLikeStoryAdvertisement_Facebook()
        {
            editSponsorStoryAdvertisement(AdType.Page_Like_Story);
        }

        [TestMethod]
        public void EditPagePostStoryAdvertisement_Facebook()
        {
            editSponsorStoryAdvertisement(AdType.Page_Post_Story);
        }

        [TestMethod]
        public void EditPagePostLikeStoryAdvertisement_Facebook()
        {
            editSponsorStoryAdvertisement(AdType.Page_Post_Like_Story);
        }

        private void editSponsorStoryAdvertisement(AdType type)
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(type, out campaignObject, out  adObject);

            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
            WinRow row;
            var dataGridTable = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UIItemTable.UIDataPanelClient;
            var headerRow = advertisementUI.UIHaihadsagecom4684830Window4.UIItemWindow.UINewItemRowRow;
            Assert.IsTrue(dataGridTable.TryGetOneRowByName(headerRow, adObject.AdName, out row), "The ad name in advertisement grid view should be found!!");
            Facebook.UITestFramework.Object.Advertisement advertisementInGridView = Facebook.UITestFramework.Object.Advertisement.Parse(row);

            switch (type)
            {
                case AdType.Page_Like_Story:
                    adObject = Facebook.UITestFramework.Object.Advertisement.NextPageLikeStoryAdvertisement(this.RandomData);
                    adObject.AdStatus = advertisementInGridView.AdStatus;
                    advertisementUI.AddPageLikeStoryAdvertisement(adObject);
                    break;
                case AdType.Page_Post_Story:
                    adObject = Facebook.UITestFramework.Object.Advertisement.NextPagePostStoryAdvertisement(this.RandomData);
                    adObject.AdStatus = advertisementInGridView.AdStatus;
                    advertisementUI.AddPagePostStoryAdvertisement(adObject);
                    break;
                case AdType.Page_Post_Like_Story:
                    adObject = Facebook.UITestFramework.Object.Advertisement.NextPagePostLikeStoryAdvertisement(this.RandomData);
                    adObject.AdStatus = advertisementInGridView.AdStatus;
                    advertisementUI.AddPagePostLikeStoryAdvertisement(adObject);
                    break;
                case AdType.App_Share_Story:
                    adObject = Facebook.UITestFramework.Object.Advertisement.NextAppShareStoryAdvertisement(this.RandomData);
                    adObject.AdStatus = advertisementInGridView.AdStatus;
                    advertisementUI.AddAppShareStoryAdvertisement(adObject);
                    break;
                case AdType.App_Used_Story:
                    adObject = Facebook.UITestFramework.Object.Advertisement.NextAppUsedStoryAdvertisement(this.RandomData);
                    adObject.AdStatus = advertisementInGridView.AdStatus;
                    advertisementUI.AddAppUsedStoryAdvertisement(adObject);
                    break;
                default:
                    break;
            }

            //Upload changes
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            TestHelper.UploadChanges(detailedInfoForUploadWindow.VerifyUpdateOneAdvertisement);

            TestHelper.VerifyAdStatusColumnIsNull(adObject.AdName);
        }

        [TestMethod]
        public void AddAppUsedSponsorStoryAdvertisement_Facebook()
        {
            addSponsorStoryAdvertisement(AdType.App_Used_Story);
        }

        [TestMethod]
        public void AddAppShareSponsorStoryAdvertisement_Facebook()
        {
            addSponsorStoryAdvertisement(AdType.App_Share_Story);
        }

        [TestMethod]
        public void DeleteAppUsedSponsorStoryAdvertisement_Facebook()
        {
            deleteSponsorStoryAdvertisement(AdType.App_Used_Story);
        }

        [TestMethod]
        public void DeleteAppShareSponsorStoryAdvertisement_Facebook()
        {
            deleteSponsorStoryAdvertisement(AdType.App_Share_Story);
        }

        [TestMethod]
        public void GetAppUsedSponsorStoryAdvertisement_Facebook()
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(AdType.App_Used_Story, out campaignObject, out adObject);
        }

        [TestMethod]
        public void GetAppShareSponsorStoryAdvertisement_Facebook()
        {
            UITestFramework.Object.Campaign campaignObject;
            UITestFramework.Object.Advertisement adObject;
            getSponsorStoryAdvertisement(AdType.App_Share_Story, out campaignObject, out adObject);
        }

        [TestMethod]
        public void EditAppUsedSponsorStoryAdvertisement_Facebook()
        {
            editSponsorStoryAdvertisement(AdType.App_Used_Story);
        }

        [TestMethod]
        public void EditAppShareSponsorStoryAdvertisement_Facebook()
        {
            editSponsorStoryAdvertisement(AdType.App_Share_Story);
        }

        [TestMethod]
        public void AddFacebookContentAdvertisement_Facebook()
        {
            //Adding campaign through api first
            UITestFramework.Object.Campaign addingCampaignThroughApi = UITestFramework.Object.Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            TestHelper.AddAdvertisementUI(addingCampaignThroughApi);

            //Add advertisement
            Facebook.UITestFramework.Object.Advertisement addingAdvertisementThroughApi = new Advertisement();
            Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements advertisementUI = Get<Facebook.UITestFramework.UIMaps.AdvertisementsClasses.Advertisements>();
        }

        [TestMethod]
        public void GetCampaignWithAllKindsOfAds_Facebook()
        {
            //Define basic variable
            Campaign addingCampaignThroughApi;
            List<Advertisement> addingAdvertisementThroughApi = new List<Advertisement>();

            //Adding six types ads through api
            GetAllAdvertisementsApi(out addingCampaignThroughApi, addingAdvertisementThroughApi);
            //Get six types advertisement
            TestHelper.GetAllAdvertisementsUI(addingCampaignThroughApi, addingAdvertisementThroughApi);
        }

        private void GetAllAdvertisementsApi(out Campaign addingCampaignThroughApi, List<Advertisement> addingAdvertisements)
        {
            //Adding campaign through api
            addingCampaignThroughApi = Campaign.NextCampaign(RandomData);
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Adding External Type ad through api
            Advertisement externalAdvertisement = new Advertisement();
            externalAdvertisement = Advertisement.NextExternalAdvertisement(RandomData);
            externalAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateAdvertisementsApi(externalAdvertisement);
            addingAdvertisements.Add(externalAdvertisement);

            //Adding Page Like Type ad through api
            Advertisement pageLikeStoryAdvertisement = new Advertisement();
            pageLikeStoryAdvertisement = Advertisement.NextPageLikeStoryAdvertisement(this.RandomData);
            pageLikeStoryAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateSponsorStoryAdvertisementsApi(pageLikeStoryAdvertisement);
            addingAdvertisements.Add(pageLikeStoryAdvertisement);

            #region Debug Post
            ////Adding Page Post Type ad throup api
            //Advertisement pagePostStoryAdvertisement = new Advertisement();
            //pagePostStoryAdvertisement = Advertisement.NextPagePostStoryAdvertisement(this.RandomData);
            //pagePostStoryAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            //TestHelper.CreateSponsorStoryAdvertisementsApi(pagePostStoryAdvertisement);
            //addingAdvertisements.Add(pagePostStoryAdvertisement);
            #endregion

            //Adding Page Post Like Type ad throup api
            Advertisement pagePostLikeStoryAdvertisement = new Advertisement();
            pagePostLikeStoryAdvertisement = Advertisement.NextPagePostLikeStoryAdvertisement(this.RandomData);
            pagePostLikeStoryAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateSponsorStoryAdvertisementsApi(pagePostLikeStoryAdvertisement);
            addingAdvertisements.Add(pagePostLikeStoryAdvertisement);

            //Adding App Used Type ad throup api
            Advertisement appUsedStoryAdvertisement = new Advertisement();
            appUsedStoryAdvertisement = Advertisement.NextAppUsedStoryAdvertisement(this.RandomData);
            appUsedStoryAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateSponsorStoryAdvertisementsApi(appUsedStoryAdvertisement);
            addingAdvertisements.Add(appUsedStoryAdvertisement);

            //Adding App Share Type ad throup api
            Advertisement AppShareStoryAdvertisement = new Advertisement();
            AppShareStoryAdvertisement = Advertisement.NextAppShareStoryAdvertisement(this.RandomData);
            AppShareStoryAdvertisement.CampaignName = addingCampaignThroughApi.Name;
            TestHelper.CreateSponsorStoryAdvertisementsApi(AppShareStoryAdvertisement);
            addingAdvertisements.Add(AppShareStoryAdvertisement);
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public void GetHundredsOfAdvertisements_Facebook()
        {
            //Define basic variable
            Campaign addingCampaignThroughApi = Campaign.NextCampaign(RandomData);
            List<Advertisement> addingAdvertisementThroughApi = new List<Advertisement>();
            var responseResult = new List<ads_createAdGroups_response>();
            long campaignId = TestHelper.CreateCampaignsApi(addingCampaignThroughApi);
            this.deleteCampaignIds.Add(campaignId);

            //Add five hundreds of Ads through api 
            TestHelper.GetBulkAdvertisements(addingCampaignThroughApi, addingAdvertisementThroughApi, responseResult);
            //Get all Ads which are created before from facebook server
            TestHelper.GetHundredsOfAdvertisementsUI(addingCampaignThroughApi, addingAdvertisementThroughApi);
        }
    }
}
