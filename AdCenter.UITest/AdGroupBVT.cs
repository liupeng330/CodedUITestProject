using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using AdCenter.UITestFramework;
using AdCenter.UITestFramework.Object;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUIMaps = Common.UITestFramework.UIMaps;
using AdCenterFramework = AdCenter.UITestFramework;
using AdCenterUIMaps = AdCenter.UITestFramework.UIMaps;
using UIMaps = Common.UITestFramework.UIMaps;

namespace AdCenter.UITest
{
    [CodedUITest]
    public class AdGroupBVT : TestBase
    {
        public AdGroupBVT()
        {
            CampaignBVT = new UITest.CampaignBVT();
            RunInit = RunClean =  RunVPN = false;
            RunProxy = false;
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
            mainWindow.ExpandAdCenterAccountTreeView();
        }

        [TestMethod]
        public void AddAdGroup_AdCenter()
        {
            OrderedTestFirstStep(() =>
                {
                    AdCenterUIMaps.AdGroupsClasses.AdGroups adversiementUI = Get<AdCenterUIMaps.AdGroupsClasses.AdGroups>();
                    adversiementUI.ClickAddAdGroupButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    string adGroupName = AdCenterFramework.Object.AdGroup.NextAdName(this.RandomData);
                    AdGroupBVT.Advertisement = TestHelper.AddAdGroup(adGroupName, uploadWindow.VerifyUploadOneAdCenterAdvertisement);
                }
            );
        }

        [TestMethod]
        public void GetAdGroup_AdCenter()
        {
            OrderedTestInProgress(() =>
                {
                    AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdForAdCenter);

                    AdCenterUIMaps.AdGroupsClasses.AdGroups adGroupsUI = Get<AdCenterUIMaps.AdGroupsClasses.AdGroups>();
                    WinClient gridViewContainer = adGroupsUI.UIMicrosoftadlabsUSDadWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = adGroupsUI.UIMicrosoftadlabsUSDadWindow.UIItemWindow.UINewItemRowRow;
                    WinRow adRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandAdCenterAccountTreeView();
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, AdGroupBVT.Advertisement.Name, out adRow), "Fail to get ad by name in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditAdGroup_AdCenter()
        {
            OrderedTestInProgress(() =>
                {
                    Advertisement.Name = AdCenterFramework.Object.AdGroup.NextAdName(CampaignBVT.RandomData);

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    AdGroupBVT.Advertisement = TestHelper.AddAdGroup(
                        Advertisement.Name,
                        uploadWindow.VerifyUpdateOneAdvertisementForAdCenter);
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandAdCenterAccountTreeView();
                }
            );
        }

        [TestMethod]
        public void DeleteAdGroup_AdCenter()
        {
            OrderedTestLastStep(() =>
                {
                    AdCenterUIMaps.AdGroupsClasses.AdGroups adversiementUI = Get<AdCenterUIMaps.AdGroupsClasses.AdGroups>();
                    adversiementUI.ClickDeleteAdGroupButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneAdCenterAdGroup);

                    adversiementUI.ClickCampaign1Tab();

                    AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ClickDeleteButton();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneAdCenterCampaign);
                }
            );
        }
    }
}
