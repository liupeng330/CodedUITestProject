using System;
using Common.UITest;
using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Google.UITestFramework;
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

        private static GoogleFramework.Object.Campaign campaign;

        public CampaignBVT()
        {
            AddUserBVT = new AddUserBVT();
            RunInit = RunClean = false;
        }

        public override void OnTestInitialize()
        {
            AddUserBVT.OnTestInitialize();
            AddUserBVT.AddUserInit(SearchEngineType.Google);

            UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = Get<UIMaps.AccountManagementCenterClasses.AccountManagementCenter>();
            System.Threading.Thread.Sleep(5 * 1000);
            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = Get<UIMaps.QuestionWindowClasses.QuestionWindow>();
            questionWindow.ClickNoButton();

            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandAccountsView();
            mainWindow.ClickGoogleAccount();

            UIMaps.UIWaitingWindowClass waitingWindow = Get<UIMaps.UIWaitingWindowClass>();
            waitingWindow.UIWaitingWindow.WaitForControlNotExist();
        }

        [TestMethod]
        public void AddCampaign_Google()
        {
            OrderedTestFirstStep(() =>
                {
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignUI = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignUI.ClickAddCPMCampaignButton();
                    string campaignName = GoogleFramework.Object.Campaign.NextCampaignName(this.RandomData);

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    campaign = TestHelper.AddCampaign(campaignName, uploadWindow.VerifyUploadOneGoogleCampaign);
                }
            );
        }

        [TestMethod]
        public void GetCampaign_Google()
        {
            OrderedTestInProgress(() =>
                {
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(CampaignBVT.campaign.Name, detailInforDownload.VerifyDownloadOneCampaignForGoogle);

                    GoogleUIMaps.CampaignsClasses.Campaigns campaignUI = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    WinClient gridViewContainer = campaignUI.UIWss_adsagetest163comWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = campaignUI.UIWss_adsagetest163comWindow.UIItemWindow.UIItemTable.UIDataPanelClient.UINewItemRowRow;
                    WinRow campaignRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, CampaignBVT.campaign.Name, out campaignRow), "Fail to get campaign by name in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditCampaign_Google()
        {
            OrderedTestInProgress(() =>
                {
                    CampaignBVT.campaign.Name = GoogleFramework.Object.Campaign.NextCampaignName(this.RandomData);
                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.AddCampaign(CampaignBVT.campaign.Name, uploadWindow.VerifyEditOneGoogleCampaign);
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                }
            );
        }

        [TestMethod]
        public void DeleteCampaign_Google()
        {
            OrderedTestLastStep(() =>
                {
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ClickDeleteButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneGoogleCampaign);
                }
            );
        }

    }
}
