using Common.UITestFramework;
using Common.UITestFramework.Utilities;
using Google.UITestFramework;
using Google.UITestFramework.Object;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUIMaps = Common.UITestFramework.UIMaps;
using GoogleUIMaps = Google.UITestFramework.UIMaps;
using UIMaps = Common.UITestFramework.UIMaps;

namespace Google.UITest
{
    [CodedUITest]
    public class TextAdvertisementBVT : TestBase
    {
        public TextAdvertisementBVT()
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
        private static AdGroup adGroup;
        private static TextAdvertisement textAd;

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();
            CampaignBVT.OnTestInitialize();
            campaign = TestHelper.AddCampaignForInit(this.RandomData);
            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandGoogleAccountTreeView();
            adGroup = TestHelper.AddAdGroupForInit(this.RandomData);
            mainWindow.ExpandGoogleAccountTreeView();
        }

        [TestMethod]
        public void AddTextAd_Google()
        {
            OrderedTestFirstStep(() =>
                {
                    Google.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
                    textAdUI.ClickAddTextAdButton();

                    Google.UITestFramework.Object.TextAdvertisement textAdObject = Google.UITestFramework.Object.TextAdvertisement.NextTextAd(this.RandomData);
                    TextAdvertisementBVT.textAd = textAdObject;

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                    TestHelper.AddTextAd(textAdObject, false, uploadWindow.VerifyUploadOneGoogleTextAd);
                }
            );
        }

        [TestMethod]
        public void GetTextAd_Google()
        {
            OrderedTestInProgress(() =>
                {
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    CommonUIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogle);

                    GoogleUIMaps.TextAdClasses.TextAd textAdUI = Get<GoogleUIMaps.TextAdClasses.TextAd>();
                    WinClient gridViewContainer = textAdUI.UIWss_adsagetest163comWindow3.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = textAdUI.UIWss_adsagetest163comWindow3.UIItemWindow.UINewItemRowRow;
                    WinRow textAdRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                    Assert.IsTrue(
                        gridViewContainer.TryGetOneRowByName(
                            headerRow,
                            textAd.Headline
                            , out textAdRow),
                        "Fail to get text ad by headline in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditTextAd_Google()
        {
            OrderedTestInProgress(() =>
                {
                    Google.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();

                    string headLine = TextAdvertisementBVT.textAd.Headline;
                    textAd = Google.UITestFramework.Object.TextAdvertisement.NextTextAd(this.RandomData);
                    textAd.Headline = headLine;

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                    TestHelper.AddTextAd(textAd, true, uploadWindow.VerifyUpdateOneTextAdForGoogle);
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                }
            );
        }

        [TestMethod]
        public void DeleteTextAd_Google()
        {
            OrderedTestLastStep(() =>
                {
                    GoogleUIMaps.TextAdClasses.TextAd textAdUI = Get<GoogleUIMaps.TextAdClasses.TextAd>();
                    textAdUI.ClickDeleteTextAdButton();

                    CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneTextAdForGoogle);

                    textAdUI.ClickCampaign1Tab();
                    GoogleUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ClickDeleteButton();

                    TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneGoogleCampaign);
                }
            );
        }
    }
}
