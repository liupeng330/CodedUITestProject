namespace AdCenter.UITestFramework.UIMaps.CampaignsClasses
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
        public void AddCampaign(string name)
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIMicrosoftadlabsUSDadWindow1.UITxtNameWindow.UITxtNameEdit;
            #endregion

            // Type 'adfasdfasdf' in 'txtName' text box
            uITxtNameEdit.Text = name;

            // Type '{Enter}' in 'txtName' text box
            Keyboard.SendKeys(uITxtNameEdit, "{Enter}", ModifierKeys.None);
        }

        /// <summary>
        /// AssertMethod1 - Use 'AssertMethod1ExpectedValues' to pass parameters into this method.
        /// </summary>
        public AdCenter.UITestFramework.Object.Campaign GetCampaignFromEditPanel()
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIMicrosoftadlabsUSDadWindow1.UITxtNameWindow.UITxtNameEdit;
            WinComboBox uICbBudgetTypeComboBox = this.UIMicrosoftadlabsUSDadWindow2.UICbBudgetTypeWindow.UICbBudgetTypeComboBox;
            WinComboBox uICbStatusComboBox = this.UIMicrosoftadlabsUSDadWindow3.UICbStatusWindow.UICbStatusComboBox;
            WinEdit uITxtDailyBudgetEdit = this.UIMicrosoftadlabsUSDadWindow4.UITxtDailyBudgetWindow.UITxtDailyBudgetEdit;
            WinEdit uITxtMonthlyBudgetEdit = this.UIMicrosoftadlabsUSDadWindow5.UITxtMonthlyBudgetWindow.UITxtMonthlyBudgetEdit;
            #endregion

            AdCenter.UITestFramework.Object.Campaign campaignObject = new UITestFramework.Object.Campaign 
            {
                Name = uITxtNameEdit.Text,
                Status = uICbStatusComboBox.SelectedItem,
                BudgetType = uICbBudgetTypeComboBox.SelectedItem,
                DailyBudget = uITxtDailyBudgetEdit.Text,
                MonthlyBudget = uITxtMonthlyBudgetEdit.Text,
            };
            return campaignObject;
        }

        /// <summary>
        /// UploadAccounts
        /// </summary>
        public void UploadAccounts()
        {
            #region Variable Declarations
            WinTabPage uIHomeTabPage = this.UIMicrosoftadlabsUSDadWindow.UIRibbonTabsTabList.UIHomeTabPage;
            WinButton uIUploadAccountsButton = this.UIMicrosoftadlabsUSDadWindow.UIRibbonToolBar1.UIUploadAccountsButton;
            #endregion

            // Click 'Home' tab
            Mouse.Click(uIHomeTabPage, new Point(15, 8));

            // Click 'Upload Accounts' button
            Mouse.Click(uIUploadAccountsButton, new Point(21, 24));

            //Wait Upload change windows exist
            Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges uploadChangeWindow = new Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges();
            uploadChangeWindow.UIUploadchangesWindow.WaitForControlExist();

            //Check first row and click OK button
            uploadChangeWindow.SelectAdCenterAccountAndClickOKButton();
        }
    }
}
