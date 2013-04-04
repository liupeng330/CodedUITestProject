using AdCenter.UITestFramework;
using Common.UITest;
using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdCenterFramework = AdCenter.UITestFramework;
using AdCenterUIMaps = AdCenter.UITestFramework.UIMaps;
using CommonUIMaps = Common.UITestFramework.UIMaps;
using UIMaps = Common.UITestFramework.UIMaps;

namespace AdCenter.UITest
{
    [CodedUITest]
    public class CampaignBVT : TestBase
    {
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
        private AddUserBVT AddUserBVT;

        private static AdCenterFramework.Object.Campaign campaign;

        public CampaignBVT()
        {
            AddUserBVT = new AddUserBVT();
            RunInit = false;
            RunClean = false;
            RunVPN = false;
            RunProxy = false;
        }

        public override void OnTestInitialize()
        {
            AddUserBVT.OnTestInitialize();
            AddUserBVT.AddUserInit(SearchEngineType.Adcenter);

            UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = Get<UIMaps.AccountManagementCenterClasses.AccountManagementCenter>();
            System.Threading.Thread.Sleep(5 * 1000);
            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = Get<UIMaps.QuestionWindowClasses.QuestionWindow>();
            questionWindow.ClickNoButton();

            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandAccountsView();
            mainWindow.ClickAdCenterAccount();

            UIMaps.UIWaitingWindowClass waitingWindow = Get<UIMaps.UIWaitingWindowClass>();
            waitingWindow.UIWaitingWindow.WaitForControlNotExist();
        }

        [TestMethod]
        public void AddCampaign_AdCenter()
        {
            OrderedTestFirstStep(() =>
            {
                AdCenterUIMaps.CampaignsClasses.Campaigns campaignUI = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                campaignUI.ClickAddCampaignButton();
                string campaignName = AdCenterFramework.Object.Campaign.NextCampaignName(this.RandomData);

                CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                campaign = TestHelper.AddCampaign(campaignName, uploadWindow.VerifyUploadOneAdCenterCampaign);
            });
        }

        [TestMethod]
        public void GetCampaign_AdCenter()
        {
            OrderedTestInProgress(() =>
            {
                AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                campaignPanel.ContextMenuDownloadAccount();

                CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                GridViewUtilities.GetCampaignUI(CampaignBVT.campaign.Name, detailInforDownload.VerifyDownloadOneCampaignForAdCenter);

                AdCenterUIMaps.CampaignsClasses.Campaigns campaignUI = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                WinClient gridViewContainer = campaignUI.UIMicrosoftadlabsUSDadWindow6.UIItemWindow.UIItemTable.UIDataPanelClient;
                WinRow headerRow = campaignUI.UIMicrosoftadlabsUSDadWindow6.UIItemWindow.UINewItemRowRow;
                WinRow campaignRow;
                UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                mainWindow.ExpandAdCenterAccountTreeView();
                Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, CampaignBVT.campaign.Name, out campaignRow), "Fail to get campaign by name in grid view!!");
            });
        }

        [TestMethod]
        public void EditCampaign_AdCenter()
        {
            OrderedTestInProgress(() =>
            {
                CampaignBVT.campaign.Name = AdCenterFramework.Object.Campaign.NextCampaignName(this.RandomData);
                CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                TestHelper.AddCampaign(CampaignBVT.campaign.Name, uploadWindow.VerifyEditOneAdCenterCampaign);
                UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                mainWindow.ExpandAdCenterAccountTreeView();
            });
        }

        [TestMethod]
        public void DeleteCampaign_AdCenter()
        {
            OrderedTestLastStep(() =>
            {
                AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                campaignPanel.ClickCampaignsTab();
                campaignPanel.ClickDeleteButton();

                CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneAdCenterCampaign);
            });
        }
    }
}
