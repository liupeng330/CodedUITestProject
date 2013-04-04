namespace Facebook.UITestFramework.UIMaps.CampaignsClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    public partial class Campaigns
    {
        /// <summary>
        /// AddCampaign - Use 'AddCampaignParams' to pass parameters into this method.
        /// </summary>
        public void AddCampaign(Facebook.UITestFramework.Object.Campaign addCampaign)
        {
            #region Variable Declarations
            WinButton uIAddCampaignButton = this.UIAdSageforPerformanceWindow.UIRibbonToolBar1.UIAddCampaignButton;
            WinEdit uITxtCamNameEdit = this.UIAdSageforPerformanceWindow.UITxtCamNameWindow.UITxtCamNameEdit;
            WinComboBox uICbBudgetTypeComboBox = this.UIAdSageforPerformanceWindow.UICbBudgetTypeWindow.UICbBudgetTypeComboBox;
            WinEdit uITxtBudgetEdit = this.UIAdSageforPerformanceWindow.UITxtBudgetWindow.UITxtBudgetEdit;
            WinComboBox uICbStatusComboBox = this.UIAdSageforPerformanceWindow.UICbStatusWindow.UICbStatusComboBox;
            WinDateTimePicker uIDtpFromDateTimePicker =this.UIAdSageforPerformanceWindow.UIDtpFromWindow.UIDtpFromDateTimePicker;
            #endregion

            // Click 'Add Campaign' button
            Mouse.Click(uIAddCampaignButton, new Point(36, 32));

            // Type 'AutomationCampaignName' in 'txtCamName' text box
            uITxtCamNameEdit.Text = addCampaign.Name;

            // Select 'Daily' in 'cbBudgetType' combo box
            uICbBudgetTypeComboBox.SelectedItem = addCampaign.BudgetType;

            // Click 'txtBudget' text box
            Mouse.Click(uITxtBudgetEdit, new Point(40, 6));

            // Type '12' in 'txtBudget' text box
            uITxtBudgetEdit.Text = addCampaign.Budget;

            // Select 'Active' in 'cbStatus' combo box
            uICbStatusComboBox.SelectedItem = addCampaign.RunStatus;

            //uIDtpFromDateTimePicker.DateTimeAsString = addCampaign.StartTime;
        }

        public void EditCampaign(Facebook.UITestFramework.Object.Campaign editCampaign)
        {
            #region Variable Declarations
            WinEdit uITxtCamNameEdit = this.UIAdSageforPerformanceWindow.UITxtCamNameWindow.UITxtCamNameEdit;
            WinComboBox uICbBudgetTypeComboBox = this.UIAdSageforPerformanceWindow.UICbBudgetTypeWindow.UICbBudgetTypeComboBox;
            WinEdit uITxtBudgetEdit = this.UIAdSageforPerformanceWindow.UITxtBudgetWindow.UITxtBudgetEdit;
            #endregion

            // Type 'AutomationCampaignName' in 'txtCamName' text box
            uITxtCamNameEdit.Text = editCampaign.Name;

            // Select 'Daily' in 'cbBudgetType' combo box
            uICbBudgetTypeComboBox.SelectedItem = editCampaign.BudgetType;

            // Click 'txtBudget' text box
            Mouse.Click(uITxtBudgetEdit, new Point(40, 6));

            // Type '12' in 'txtBudget' text box
            uITxtBudgetEdit.Text = editCampaign.Budget;

            // Type '{Enter}' in 'txtBudget' text box
            Keyboard.SendKeys(uITxtBudgetEdit, "{Enter}", ModifierKeys.None);
        }

        public UIFacebookCampaignGridWindow UIFacebookCampaignGridWindow
        {
            get
            {
                if (mUIFacebookCampaignGridWindow == null)
                {
                    this.mUIFacebookCampaignGridWindow = new UIFacebookCampaignGridWindow(this.UIAdSageforPerformanceWindow);
                }
                return mUIFacebookCampaignGridWindow;
            }
        }
        private UIFacebookCampaignGridWindow mUIFacebookCampaignGridWindow;

        /// <summary>
        /// Upload change
        /// </summary>
        public void UploadChanges()
        {
            #region Variable Declarations
            WinTabPage uIHomeTabPage = this.UIHaihadsagecom4684830Window.UIRibbonTabsTabList.UIHomeTabPage;
            WinButton uIUploadAccountsButton = this.UIHaihadsagecom4684830Window.UIRibbonToolBar.UIUploadAccountsButton;
            #endregion

            // Click 'Home' tab
            Mouse.Click(uIHomeTabPage, new Point(21, 8));

            // Click 'Upload Accounts' button
            Mouse.Click(uIUploadAccountsButton, new Point(32, 37));

            //Wait Upload change windows exist
            Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges uploadChangeWindow = new Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges();
            uploadChangeWindow.UIUploadchangesWindow.WaitForControlExist();

            //Check first row and click OK button
            uploadChangeWindow.SelectFacebookAccountAndClickOKButton();
        }

        /// <summary>
        /// ClickAdsTab
        /// </summary>
        public void ClickAdsTab()
        {
            WinTabPage uIAds0TabPage = this.UIHaihadsagecom4684830Window1.UIItemTabList.UIAds0TabPage;
            WaitForEnable(uIAds0TabPage);
            Mouse.Click(uIAds0TabPage, new Point(17, 7));
        }

        /// <summary>
        /// ClickAdsTab
        /// </summary>
        public void ClickAdsTab(int countOfAd)
        {
            WinTabPage uIAdsTabPage = this.UIHaihadsagecom4684830Window1.UIItemTabList.UIAds0TabPage;
            uIAdsTabPage.SearchProperties[WinTabPage.PropertyNames.Name] = "Ads(" + countOfAd + ")";
            WaitForEnable(uIAdsTabPage);
            Mouse.Click(uIAdsTabPage, new Point(17, 7));
        }

        private void WaitForEnable(UITestControl control)
        {
            try
            {
                int waitTime = 1000 * 60 * 2;
                control.WaitForControlExist(waitTime);
                control.WaitForControlReady(waitTime);
            }
            catch (UITestControlNotFoundException)
            {
                control.SearchProperties[WinTabPage.PropertyNames.Name] = "Ads(...)";
            }
        }
    }

    public class UITopRowRow : WinRow
    {

        public UITopRowRow(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Name] = "Top Row";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            #endregion
        }

        #region Properties
        public WinColumnHeader UIItemColumnHeader
        {
            get
            {
                if ((this.mUIItemColumnHeader == null))
                {
                    this.mUIItemColumnHeader = new WinColumnHeader(this);
                }
                return this.mUIItemColumnHeader;
            }
        }

        public WinColumnHeader UIItemColumnHeader1
        {
            get
            {
                if ((this.mUIItemColumnHeader1 == null))
                {
                    this.mUIItemColumnHeader1 = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIItemColumnHeader1.SearchProperties[WinControl.PropertyNames.Instance] = "2";
                    #endregion
                }
                return this.mUIItemColumnHeader1;
            }
        }

        public WinColumnHeader UICampaignNameColumnHeader
        {
            get
            {
                if ((this.mUICampaignNameColumnHeader == null))
                {
                    this.mUICampaignNameColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignNameColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Name*";
                    #endregion
                }
                return this.mUICampaignNameColumnHeader;
            }
        }

        public WinColumnHeader UICampaignRunStatusColumnHeader
        {
            get
            {
                if ((this.mUICampaignRunStatusColumnHeader == null))
                {
                    this.mUICampaignRunStatusColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignRunStatusColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Run Status";
                    #endregion
                }
                return this.mUICampaignRunStatusColumnHeader;
            }
        }

        public WinColumnHeader UICampaignBudgetColumnHeader
        {
            get
            {
                if ((this.mUICampaignBudgetColumnHeader == null))
                {
                    this.mUICampaignBudgetColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignBudgetColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Budget";
                    #endregion
                }
                return this.mUICampaignBudgetColumnHeader;
            }
        }

        public WinColumnHeader UICampaignBudgetTypeColumnHeader
        {
            get
            {
                if ((this.mUICampaignBudgetTypeColumnHeader == null))
                {
                    this.mUICampaignBudgetTypeColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignBudgetTypeColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Budget Type";
                    #endregion
                }
                return this.mUICampaignBudgetTypeColumnHeader;
            }
        }

        public WinColumnHeader UICampaignTimeStartColumnHeader
        {
            get
            {
                if ((this.mUICampaignTimeStartColumnHeader == null))
                {
                    this.mUICampaignTimeStartColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignTimeStartColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Time Start";
                    #endregion
                }
                return this.mUICampaignTimeStartColumnHeader;
            }
        }

        public WinColumnHeader UICampaignTimeStopColumnHeader
        {
            get
            {
                if ((this.mUICampaignTimeStopColumnHeader == null))
                {
                    this.mUICampaignTimeStopColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignTimeStopColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Time Stop";
                    #endregion
                }
                return this.mUICampaignTimeStopColumnHeader;
            }
        }
        #endregion

        #region Fields
        private WinColumnHeader mUIItemColumnHeader;

        private WinColumnHeader mUIItemColumnHeader1;

        private WinColumnHeader mUICampaignNameColumnHeader;

        private WinColumnHeader mUICampaignRunStatusColumnHeader;

        private WinColumnHeader mUICampaignBudgetColumnHeader;

        private WinColumnHeader mUICampaignBudgetTypeColumnHeader;

        private WinColumnHeader mUICampaignTimeStartColumnHeader;

        private WinColumnHeader mUICampaignTimeStopColumnHeader;
        #endregion
    }

    public class UIFacebookCampaignGridWindow : WinWindow
    {
        public UIFacebookCampaignGridWindow(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "FacebookCampaignGridView";
            this.WindowTitles.Add("adSage for Performance");
            #endregion
        }

        #region Properties
        public UIDataGridViewTable UIDataGridViewTable
        {
            get
            {
                if ((this.mUIDataGridViewTable == null))
                {
                    this.mUIDataGridViewTable = new UIDataGridViewTable(this);
                }
                return this.mUIDataGridViewTable;
            }
        }
        #endregion

        #region Fields
        private UIDataGridViewTable mUIDataGridViewTable;
        #endregion
    }

    public class UIDataGridViewTable : WinTable
    {

        public UIDataGridViewTable(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTable.PropertyNames.Name] = "DataGridView";
            this.WindowTitles.Add("adSage for Performance");
            #endregion
        }

        #region Properties
        public UITopRowRow UITopRowRow
        {
            get
            {
                if ((this.mUITopRowRow == null))
                {
                    this.mUITopRowRow = new UITopRowRow(this);
                }
                return this.mUITopRowRow;
            }
        }

        #endregion

        #region Fields
        private UITopRowRow mUITopRowRow;
        #endregion

        //public bool TryGetCampaign(string campaignName, out WinRow row)
        //{
        //    foreach (UITestControl oneRow in this.Rows)
        //    {
        //        if (oneRow.Equals(this.UITopRowRow))
        //        {
        //            continue;
        //        }
        //        foreach (UITestControl oneCell in oneRow.GetChildren())
        //        {
        //            string actualCampaignName = oneCell.GetProperty(WinCell.PropertyNames.Value) as string;
        //            if (string.Equals(actualCampaignName, campaignName, StringComparison.OrdinalIgnoreCase))
        //            {
        //                row = oneRow as WinRow;
        //                return true;
        //            }
        //        }
        //    }
        //    row = null;
        //    return false;
        //}

        //public void VerifyStatusColumnIsNull(string campaignName)
        //{
        //    WinRow row;
        //    Assert.IsTrue(TryGetCampaign(campaignName, out row));
        //    if (row.Cells.Count != 8)
        //    {
        //        throw new Exception("The count of cell in campaign grid should be equal to 8!");
        //    }
        //    WinCell statusCell = row.Cells[0] as WinCell;
        //    Assert.AreEqual<string>(Constants.NullInGridView, statusCell.GetProperty(WinCell.PropertyNames.Value) as string);
        //}
    }
}
