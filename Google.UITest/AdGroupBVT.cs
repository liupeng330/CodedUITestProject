using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Google.UITestFramework;
using Google.UITestFramework.Object;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUIMaps = Common.UITestFramework.UIMaps;
using GoogleFramework = Google.UITestFramework;
using GoogleUIMaps = Google.UITestFramework.UIMaps;
using UIMaps = Common.UITestFramework.UIMaps;

namespace Google.UITest
{
    [CodedUITest]
    public class AdGroupBVT : TestBase
    {
        public AdGroupBVT()
        {
            CampaignBVT = new UITest.CampaignBVT();
            RunInit = RunClean = false;
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
        private CampaignBVT CampaignBVT;
        private static Campaign campaign;
        private static AdGroup Advertisement;

        public override void  OnTestInitialize()
        {
            base.OnTestInitialize();
            CampaignBVT.OnTestInitialize();
            campaign = TestHelper.AddCampaignForInit(this.RandomData);
            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandGoogleAccountTreeView();
        }

        [TestMethod]
        public void AddAdGroup_Google()
        {
            OrderedTestFirstStep(() =>
                {
                    GoogleUIMaps.AdvertisementClasses.AdGroup adversiementUI = Get<GoogleUIMaps.AdvertisementClasses.AdGroup>();
                    adversiementUI.ClickAddAdGroupButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                    AdGroupBVT.Advertisement = TestHelper.AddAdGroup(
                        GoogleFramework.Object.AdGroup.NextAdName(CampaignBVT.RandomData),
                        "10.00",
                        uploadWindow.VerifyUploadOneGoogleAdvertisement);
                }
            );
        }

        [TestMethod]
        public void GetAdGroup_Google()
        {
            OrderedTestInProgress(() =>
                {
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdForGoogle);

                    GoogleUIMaps.AdvertisementClasses.AdGroup adversiementUI = Get<GoogleUIMaps.AdvertisementClasses.AdGroup>();
                    WinClient gridViewContainer = adversiementUI.UIWss_adsagetest163comWindow1.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = adversiementUI.UIWss_adsagetest163comWindow1.UIItemWindow.UINewItemRowRow;
                    WinRow adRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                    Assert.IsTrue(
                        gridViewContainer.TryGetOneRowByName(
                            headerRow,
                            Advertisement.Name,
                            out adRow),
                        "Fail to get ad by name in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditAdGroup_Google()
        {
            OrderedTestInProgress(() =>
                {
                    Advertisement.Name = GoogleFramework.Object.AdGroup.NextAdName(CampaignBVT.RandomData);
                    Advertisement.MaxCPMBid = "9.00";

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    AdGroupBVT.Advertisement = TestHelper.AddAdGroup(
                        Advertisement.Name,
                        Advertisement.MaxCPMBid,
                        uploadWindow.VerifyUpdateOneAdvertisementForGoogle);
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                }
            );
        }

        [TestMethod]
        public void DeleteAdGroup_Google()
        {
            OrderedTestLastStep(() =>
                {
                    GoogleUIMaps.AdvertisementClasses.AdGroup adversiementUI = Get<GoogleUIMaps.AdvertisementClasses.AdGroup>();
                    adversiementUI.ClickDeleteAdGroupButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneGoogleAdvertisement);

                    adversiementUI.ClickCampaign1Tab();

                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ClickDeleteButton();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneGoogleCampaign);
                }
            );
        }
    }
}
