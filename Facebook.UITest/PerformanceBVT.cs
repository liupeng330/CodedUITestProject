using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Data;
using Facebook.UITestFramework;
using Facebook.UITestFramework.Enums;
using Facebook.UITestFramework.Object;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.UITestFramework;

namespace Facebook.UITest
{
    [CodedUITest]
    public class PerformanceBVT : TestBase
    {
        private List<long> deleteCampaignIds = new List<long>();

        public PerformanceBVT()
        {
            this.RunVPN = false;
            this.RunProxy = true;
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
                ConfigurationManager.AppSettings["PerfEmail"],
                ConfigurationManager.AppSettings["Password"]);

            //Wait Add User Window Not Exist
            addUser.UIAddUserWindow.WaitForControlNotExist();

            //Need to double login
            if (notHai)
            {
                addUser.AddFacebookUser();
                facbookLogin.UIFacebookLoginWindow.WaitForControlExist();

                loginWindow.Login(
                    ConfigurationManager.AppSettings["PerfEmail"],
                    ConfigurationManager.AppSettings["Password"]);

                addUser.UIAddUserWindow.WaitForControlNotExist();
            }

            //Activate Account2 #348004880
            accountManagementCenter.ClickAccountActivateButton();

            //Wait AccountManagementCenter window loading completed
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlReady();

            //Verify Inactives accounts
            accountManagementCenter.VerifyAccountActiveAccount();

            //Close AccountManagementCenter window close
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
            mainWindow.NavigateToAccount2Item();
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
        public void LookupCampaignPerformanceData_Facebook()
        {
            //Get four specified campaigns form Customized Campaign Array
            string[] gettingcampaignArray = UITestFramework.Object.Campaign.GetCampaignArray();            
            TestHelper.GetCampaignArray(gettingcampaignArray);

            //Prepare download Performance data
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performanceData = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            TestHelper.PrepareDownloadPerformanceData(performanceData);          
            
            //Get Date range from GridViewTable cell
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload performanceDataInfo = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            performanceDataInfo.UIDetailedInfoforDownlWindow1.WaitForControlExist();
            string performanceDateRange;
            TestHelper.GetPerformanceDateRange(performanceDataInfo, out performanceDateRange);

            //Downloading performance data and verify it
            TestHelper.DownloadPerformanceData(performanceDataInfo, performanceDateRange, performanceDataInfo.VerifyDownloadPerformanceData);

            //Get Performance data from datagrid view
            performanceData.ClickCampaignsTab();
            WinRow performanceRow;
            DataRow[] rows;
            string specifiedFileName = ConfigurationManager.AppSettings.Get("CampaignCSV");
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performancePanel = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            foreach (string campaignName in gettingcampaignArray)
	        {
                performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UINewItemRowRow, campaignName, out performanceRow);
                Facebook.UITestFramework.Object.Performance campaignObjectInGrid = Facebook.UITestFramework.Object.Performance.Parse(performanceRow);
                rows = TestHelper.GetPerformanceDataFromCSV(campaignName, specifiedFileName);         
                Facebook.UITestFramework.Object.Performance campaignPerformanceInCSV = Facebook.UITestFramework.Object.Performance.FetchPerformance(rows);
                if (campaignPerformanceInCSV != null)
                {
                    Assert.AreEqual<Facebook.UITestFramework.Object.Performance>(campaignPerformanceInCSV, campaignObjectInGrid, "The Facebook campaign performance datas are not correct!!");
                }
            }       
        }

        [TestMethod]
        public void LookupAdsPerformanceData_Facebook()
        {
            //Get four specified campaigns form Customized Campaign Array
            string[] gettingcampaignArray = UITestFramework.Object.Campaign.GetCampaignArray();
            TestHelper.GetCampaignArray(gettingcampaignArray);

            //Prepare download Performance data
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performanceData = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            TestHelper.PrepareDownloadPerformanceData(performanceData);

            //Get Date range from GridViewTable cell
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload performanceDataInfo = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            performanceDataInfo.UIDetailedInfoforDownlWindow1.WaitForControlExist();
            string performanceDateRange;
            TestHelper.GetPerformanceDateRange(performanceDataInfo, out performanceDateRange);

            //Downloading performance data and verify it
            TestHelper.DownloadPerformanceData(performanceDataInfo, performanceDateRange, performanceDataInfo.VerifyDownloadPerformanceData);

            //Get Performance data from datagrid view
            performanceData.ClickAdsTab();
            List<WinRow> performanceRows = new List<WinRow>();
            DataRow[] rows;
            string specifiedFileName = ConfigurationManager.AppSettings.Get("AdsCSV");
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performancePanel = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            Facebook.UITestFramework.Object.AdsPerformance oneRowInGrid = null;
            Facebook.UITestFramework.Object.AdsPerformance oneRowInCSV = null;
            foreach (string campaignName in gettingcampaignArray)
            {
                performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetSomeRowsByName(
                    performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UINewItemRowRow, campaignName, performanceRows);
                Facebook.UITestFramework.Object.AdsPerformance[] campaignObjectInGrid = Facebook.UITestFramework.Object.AdsPerformance.Parse(performanceRows);
                rows = TestHelper.GetPerformanceDataFromCSV(campaignName, specifiedFileName);
                Facebook.UITestFramework.Object.AdsPerformance[] campaignPerformanceInCSV = Facebook.UITestFramework.Object.AdsPerformance.FetchPerformance(rows);
                for (int i = 0; i < rows.Length; i++)
                {
                    oneRowInCSV = campaignPerformanceInCSV[i];
                    oneRowInGrid = campaignObjectInGrid[i];
                    Assert.AreEqual<Facebook.UITestFramework.Object.AdsPerformance>(oneRowInCSV, oneRowInGrid, "The Facebook campaign performance datas are not correct!!");
                }
            }    
        }

        [TestMethod]
        public void LookupAccountDetail_Facebook()
        {
            //Get four specified campaigns form Customized Campaign Array
            string[] gettingcampaignArray = UITestFramework.Object.Campaign.GetCampaignArray();
            TestHelper.GetCampaignArray(gettingcampaignArray);

            //Prepare download Performance data
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performanceData = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            TestHelper.PrepareDownloadPerformanceData(performanceData);

            //Get Date range from GridViewTable cell
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload performanceDataInfo = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            performanceDataInfo.UIDetailedInfoforDownlWindow1.WaitForControlExist();
            string performanceDateRange;
            TestHelper.GetPerformanceDateRange(performanceDataInfo, out performanceDateRange);

            //Downloading performance data and verify it
            TestHelper.DownloadPerformanceData(performanceDataInfo, performanceDateRange, performanceDataInfo.VerifyDownloadPerformanceData);

            //Get Performance data from datagrid view
            performanceData.ClickAccountDetailTab();
            WinRow performanceRow;
            DataRow[] rows;
            string specifiedFileName = ConfigurationManager.AppSettings.Get("TopCampaignCSV");
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performancePanel = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            foreach (string campaignName in gettingcampaignArray)
            {
                performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIRow1Row, campaignName, out performanceRow);
                Facebook.UITestFramework.Object.AccountDetails campaignObjectInGrid = Facebook.UITestFramework.Object.AccountDetails.Parse(performanceRow);
                rows = TestHelper.GetPerformanceDataFromCSV(campaignName, specifiedFileName);
                Facebook.UITestFramework.Object.AccountDetails campaignPerformanceInCSV = Facebook.UITestFramework.Object.AccountDetails.FetchPerformance(rows);
                if (campaignPerformanceInCSV != null)
                {
                    Assert.AreEqual<Facebook.UITestFramework.Object.AccountDetails>(campaignPerformanceInCSV, campaignObjectInGrid, "The Facebook campaign performance datas are not correct!!");
                }
            }

            //Drag the ScrollBar
            Mouse.MoveScrollWheel(performanceData.UIAccount2348004880USDWindow.UIItemWindow2.UIVerticalScrollBar.UIPositionIndicator, 1, System.Windows.Input.ModifierKeys.None);
            specifiedFileName = ConfigurationManager.AppSettings.Get("TopAdsCSV");
            foreach (string campaignName in gettingcampaignArray)
            {
                performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    performancePanel.UIAccount2348004880USDWindow.UIItemWindow1.UIItemTable.UIDataPanelClient.UIRow1Row, campaignName, out performanceRow);
                Facebook.UITestFramework.Object.AccountDetails campaignObjectInGrid = Facebook.UITestFramework.Object.AccountDetails.Parse(performanceRow);
                rows = TestHelper.GetPerformanceDataFromCSV(campaignName, specifiedFileName);
                Facebook.UITestFramework.Object.AccountDetails campaignPerformanceInCSV = Facebook.UITestFramework.Object.AccountDetails.FetchPerformance(rows);
                if (campaignPerformanceInCSV != null)
                {
                    Assert.AreEqual<Facebook.UITestFramework.Object.AccountDetails>(campaignPerformanceInCSV, campaignObjectInGrid, "The Facebook campaign performance datas are not correct!!");
                }
            }
        }

        [TestMethod]
        public void LookupAccountSummary_Facebook()
        {
            //Get four specified campaigns form Customized Campaign Array
            string[] gettingcampaignArray = UITestFramework.Object.Campaign.GetCampaignArray();
            TestHelper.GetCampaignArray(gettingcampaignArray);

            //Prepare download Performance data
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performanceData = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            TestHelper.PrepareDownloadPerformanceData(performanceData);

            //Get Date range from GridViewTable cell
            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload performanceDataInfo = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            performanceDataInfo.UIDetailedInfoforDownlWindow1.WaitForControlExist();
            string performanceDateRange;
            TestHelper.GetPerformanceDateRange(performanceDataInfo, out performanceDateRange);

            //Downloading performance data and verify it
            TestHelper.DownloadPerformanceData(performanceDataInfo, performanceDateRange, performanceDataInfo.VerifyDownloadPerformanceData);

            //Get Performance data from datagrid view
            performanceData.ClickCampaignsTab();
            WinRow performanceRow;
            DataRow[] rows;
            string specifiedFileName = ConfigurationManager.AppSettings.Get("AccountSummaryCSV");
            Facebook.UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData performancePanel = new UITestFramework.UIMaps.PerformanceDataClasses.PerformanceData();
            foreach (string campaignName in gettingcampaignArray)
            {
                performancePanel.UIAccount2348004880USDWindow.UIItemWindow.UIItemTable.UIDataPanelClient.TryGetOneRowByName(
                    performancePanel.UIAccount2348004880USDWindow.UIGrdCtrSummaryWindow.UINoadsinthiscampaignrTable.UIDataPanelClient.UIRow1Row, 
                    campaignName, out performanceRow);
                Facebook.UITestFramework.Object.AccountSummary campaignObjectInGrid = Facebook.UITestFramework.Object.AccountSummary.Parse(performanceRow);
                rows = TestHelper.GetPerformanceDataFromCSV(campaignName, specifiedFileName);
                Facebook.UITestFramework.Object.AccountSummary campaignPerformanceInCSV = Facebook.UITestFramework.Object.AccountSummary.FetchPerformance(rows);
                if (campaignPerformanceInCSV != null)
                {
                    Assert.AreEqual<Facebook.UITestFramework.Object.AccountSummary>(campaignPerformanceInCSV, campaignObjectInGrid, "The Facebook campaign performance datas are not correct!!");
                }
            }  
        }
    }
}
