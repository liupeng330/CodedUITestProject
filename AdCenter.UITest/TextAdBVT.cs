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
    public class TextAdvertisementBVT : TestBase
    {
        public TextAdvertisementBVT()
        {
            CampaignBVT = new UITest.CampaignBVT();
            RunInit = false;
            RunClean = false;
            RunVPN = false;
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
        private static AdGroup adGroup;
        private static TextAdvertisement textAd;

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();
            CampaignBVT.OnTestInitialize();
            campaign = TestHelper.AddCampaignForInit(this.RandomData);
            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandAdCenterAccountTreeView();
            adGroup = TestHelper.AddAdGroupForInit(this.RandomData);
            mainWindow.ExpandAdCenterAccountTreeView();
        }

        [TestMethod]
        public void AddTextAd_AdCenter()
        {
            OrderedTestFirstStep(() =>
                {
                    AdCenter.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
                    textAdUI.ClickAddTextAdButton();

                    AdCenter.UITestFramework.Object.TextAdvertisement textAdObject = AdCenter.UITestFramework.Object.TextAdvertisement.NextTextAd(this.RandomData);
                    TextAdvertisementBVT.textAd = textAdObject;

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                    TestHelper.AddTextAd(textAdObject, uploadWindow.VerifyUploadOneAdCenterTextAd);
                }
            );
        }

        [TestMethod]
        public void GetTextAd_AdCenter()
        {
            OrderedTestInProgress(() =>
                {
                    AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenter);

                    AdCenterUIMaps.TextAdClasses.TextAd textAdUI = Get<AdCenterUIMaps.TextAdClasses.TextAd>();
                    WinClient gridViewContainer = textAdUI.UIMicrosoftadlabsUSD__Window.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = textAdUI.UIMicrosoftadlabsUSD__Window.UIItemWindow.UINewItemRowRow;
                    WinRow textAdRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandAdCenterAccountTreeView();
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, TextAdvertisementBVT.textAd.Title, out textAdRow), "Fail to get text ad by title in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditTextAd_AdCenter()
        {
            OrderedTestInProgress(() =>
                {
                    AdCenter.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
                    textAd = AdCenter.UITestFramework.Object.TextAdvertisement.NextTextAd(this.RandomData);
                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.AddTextAd(textAd, uploadWindow.VerifyUpdateOneTextAdForAdCenter);
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandAdCenterAccountTreeView();
                }
            );
        }

        [TestMethod]
        public void DeleteTextAd_AdCenter()
        {
            OrderedTestLastStep(() =>
                {
                    AdCenterUIMaps.TextAdClasses.TextAd textAdUI = Get<AdCenterUIMaps.TextAdClasses.TextAd>();
                    textAdUI.ClickDeleteTextAdButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneTextAdForAdCenter);

                    textAdUI.ClickCampaign1Tab();
                    AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ClickDeleteButton();

                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneAdCenterCampaign);
                }
            );
        }
    }
}
