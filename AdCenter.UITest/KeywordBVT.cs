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
    public class KeywordBVT: TestBase
    {
        public KeywordBVT()
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
        private static Keyword keywordObject;

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();
            CampaignBVT.OnTestInitialize();
            campaign = TestHelper.AddCampaignForInit(this.RandomData);
            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandAdCenterAccountTreeView();
            adGroup = TestHelper.AddAdGroupForInit(this.RandomData);
            mainWindow.ExpandAdCenterAccountTreeView();
            textAd = TestHelper.AddTextAdforInit(this.RandomData);
            mainWindow.ExpandAdCenterAccountTreeView();
        }

        [TestMethod]
        public void AddKeyword_Adcenter()
        {
            OrderedTestFirstStep(() =>
            {
                AdCenter.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();
                keywordUI.ClickAddKeywordButton();
                keywordObject = AdCenter.UITestFramework.Object.Keyword.NextKeyword(this.RandomData);

                keywordUI.AddKeyword(keywordObject);

                WinClient gridViewContainer = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
                WinRow headerRow = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UINewItemRowRow;
                WinRow keywordRow;
                Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");

                AdCenter.UITestFramework.Object.Keyword keywordFromGridView = AdCenter.UITestFramework.Object.Keyword.Parse(keywordRow);
                AdCenter.UITestFramework.Object.Keyword keywordFromEditPanel = keywordUI.GetKeywordFromEditPanel(keywordObject.DesURL);

                Assert.IsTrue(keywordFromGridView.Equals(keywordFromEditPanel, true), "GridView: " + keywordFromGridView.ToString() + "--EditPanel: " + keywordFromEditPanel.ToString());
                Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                TestHelper.UploadChanges(uploadWindow.VerifyUploadOneAdcenterKeywords);
            });
        }

        [TestMethod]
        public void GetKeyword_AdCenter()
        {
            OrderedTestInProgress(() =>
            {
                AdCenter.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
                campaignPanel.ContextMenuDownloadAccount();

                Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenter);

                AdCenter.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();
                WinClient gridViewContainer = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
                WinRow headerRow = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UINewItemRowRow;
                WinRow keywordRow;
                UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                mainWindow.ExpandAdCenterAccountTreeView();
                Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");
            }
            );
        }

        [TestMethod]
        public void EditKeyword_AdCenter()
        {
            OrderedTestInProgress(() =>
            {
                AdCenter.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();

                keywordObject = AdCenter.UITestFramework.Object.Keyword.NextKeyword(this.RandomData);

                Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                keywordUI.AddKeyword(keywordObject);

                WinClient gridViewContainer = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
                WinRow headerRow = keywordUI.UIMicrosoftadlabsUSDdgWindow.UIItemWindow.UINewItemRowRow;
                WinRow keywordRow;
                Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");

                AdCenter.UITestFramework.Object.Keyword keywordFromGridView = AdCenter.UITestFramework.Object.Keyword.Parse(keywordRow);
                AdCenter.UITestFramework.Object.Keyword keywordFromEditPanel = keywordUI.GetKeywordFromEditPanel(keywordObject.DesURL);

                Assert.IsTrue(keywordFromGridView.Equals(keywordFromEditPanel, true), "GridView: " + keywordFromGridView.ToString() + "--EditPanel: " + keywordFromEditPanel.ToString());
                TestHelper.UploadChanges(uploadWindow.VerifyUpdateOneAdcenterKeywords);
                UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                mainWindow.ExpandAdCenterAccountTreeView();
            }
            );
        }

        [TestMethod]
        public void DeleteKeyword_Adcenter()
        {
            OrderedTestLastStep(() => 
            {
                AdCenter.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();
                keywordUI.ClickDeleteKeywordButton();

                Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneKeywordForAdcenter);

                keywordUI.ClickCampaignTab();
                AdCenterUIMaps.CampaignsClasses.Campaigns campaignPanel = Get<AdCenterUIMaps.CampaignsClasses.Campaigns>();
                campaignPanel.ClickDeleteButton();

                TestHelper.UploadChanges(uploadWindow.VerifyDeleteOneAdCenterCampaign);
            }
            );
        }
    }
}
