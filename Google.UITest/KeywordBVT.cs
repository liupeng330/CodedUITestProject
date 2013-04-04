using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Common.UITestFramework;
using Google.UITestFramework;
using Google.UITestFramework.Object;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;
using UIMaps = Common.UITestFramework.UIMaps;

namespace Google.UITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class KeywordBVT : TestBase
    {
        public KeywordBVT()
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
        private static Keyword keywordObject;

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();
            CampaignBVT.OnTestInitialize();
            campaign = TestHelper.AddCampaignForInit(this.RandomData);
            UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
            mainWindow.ExpandGoogleAccountTreeView();
            adGroup = TestHelper.AddAdGroupForInit(this.RandomData);
            mainWindow.ExpandGoogleAccountTreeView();
            textAd = TestHelper.AddTextAdForInit(this.RandomData);
            mainWindow.ExpandGoogleAccountTreeView();
        }

        [TestMethod]
        public void AddKeyword_Google()
        {
            OrderedTestFirstStep(() =>
                {
                    Google.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();
                    keywordUI.ClickAddKeywordButton();
                    keywordObject = Google.UITestFramework.Object.Keyword.NextKeyword(this.RandomData);

                    keywordUI.AddKeyword(keywordObject);

                    WinClient gridViewContainer = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UINewItemRowRow;
                    WinRow keywordRow;
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");

                    Google.UITestFramework.Object.Keyword keywordFromGridView = Google.UITestFramework.Object.Keyword.Parse(keywordRow);
                    Google.UITestFramework.Object.Keyword keywordFromEditPanel = keywordUI.GetKeywordFromEditPanel(keywordObject.DestinationUrl);

                    Assert.IsTrue(keywordFromGridView.Equals(keywordFromEditPanel, true), "GridView: " + keywordFromGridView.ToString() + "--EditPanel: " + keywordFromEditPanel.ToString());
                    Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
                    TestHelper.UploadChanges(uploadWindow.VerifyUploadOneGoogleKeywords);
                });
        }

        [TestMethod]
        public void GetKeyword_Google()
        {
            OrderedTestInProgress(() =>
                {
                    Google.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = Get<UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
                    campaignPanel.ContextMenuDownloadAccount();

                    Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailInforDownload = Get<Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload>();
                    GridViewUtilities.GetCampaignUI(campaign.Name, detailInforDownload.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogle);

                    Google.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();
                    WinClient gridViewContainer = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UINewItemRowRow;
                    WinRow keywordRow;
                    UIMaps.MainWindowClasses.MainWindow mainWindow = Get<UIMaps.MainWindowClasses.MainWindow>();
                    mainWindow.ExpandGoogleAccountTreeView();
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");
                }
            );
        }

        [TestMethod]
        public void EditKeyword_Google()
        {
            OrderedTestInProgress(() =>
                {
                    Google.UITestFramework.UIMaps.KeywordClasses.Keyword keywordUI = Get<UITestFramework.UIMaps.KeywordClasses.Keyword>();

                    keywordObject = Google.UITestFramework.Object.Keyword.NextKeyword(this.RandomData);

                    Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

                    keywordUI.AddKeyword(keywordObject);

                    WinClient gridViewContainer = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UIItemTable.UIDataPanelClient;
                    WinRow headerRow = keywordUI.UIWss_adsagetest163comWindow2.UIItemWindow.UINewItemRowRow;
                    WinRow keywordRow;
                    Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, keywordObject.Keywords, out keywordRow), "Fail to get keyword in grid view!!");

                    Google.UITestFramework.Object.Keyword keywordFromGridView = Google.UITestFramework.Object.Keyword.Parse(keywordRow);
                    Google.UITestFramework.Object.Keyword keywordFromEditPanel = keywordUI.GetKeywordFromEditPanel(keywordObject.DestinationUrl);

                    Assert.IsTrue(keywordFromGridView.Equals(keywordFromEditPanel, true), "GridView: " + keywordFromGridView.ToString() + "--EditPanel: " + keywordFromEditPanel.ToString());
                    TestHelper.UploadChanges(uploadWindow.VerifyUploadOneGoogleKeywords);
                }
            );
        }
    }
}
