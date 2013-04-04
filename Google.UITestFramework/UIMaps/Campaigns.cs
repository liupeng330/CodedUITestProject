namespace Google.UITestFramework.UIMaps.CampaignsClasses
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
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;
            #endregion

            // Type 'CampaignForAuto' in 'TBName' text box
            uITBNameEdit.Text = name;
            Keyboard.SendKeys(uITBNameEdit, "{Enter}");
        }

        public Google.UITestFramework.Object.Campaign GetCampaignFromEditPanel()
        {
            WinEdit uITBDailyBudgetEdit = this.UIWss_adsagetest163comWindow1.UITBDailyBudgetWindow.UITBDailyBudgetEdit;
            WinComboBox uICBStatusComboBox = this.UIWss_adsagetest163comWindow1.UICBStatusWindow.UICBStatusComboBox;
            UITestControl startDate = this.UIWss_adsagetest163comWindow1.UIDTPStartDateWindow.UIDTPStartDateClient.GetChildren()[0];
            UITestControl endDate = this.UIWss_adsagetest163comWindow1.UIDTPEndDateWindow.UIDTPEndDateClient.GetChildren()[0];
            WinComboBox uICBSearchNetworkComboBox = this.UIWss_adsagetest163comWindow1.UICBSearchNetworkWindow.UICBSearchNetworkComboBox;
            WinComboBox uICBContentNetworkComboBox = this.UIWss_adsagetest163comWindow1.UICBContentNetworkWindow.UICBContentNetworkComboBox;
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;

            Google.UITestFramework.Object.Campaign campaign = new UITestFramework.Object.Campaign
            {
                Name = uITBNameEdit.Text,
                DailyBudget = uITBDailyBudgetEdit.Text,
                Status = uICBStatusComboBox.SelectedItem,
                StartDate = DateTime.Parse(startDate.GetProperty(WinWindow.PropertyNames.AccessibleName).ToString()).ToString("MM/dd/yyyy"),
                EndDate = DateTime.Parse(endDate.GetProperty(WinWindow.PropertyNames.AccessibleName).ToString()).ToString("MM/dd/yyyy"),
                SearchNetwork = uICBSearchNetworkComboBox.SelectedItem,
                DisplayNetwork = uICBContentNetworkComboBox.SelectedItem,
            };
            return campaign;
        }

        /// <summary>
        /// UploadAccounts
        /// </summary>
        public void UploadAccounts()
        {
            #region Variable Declarations
            WinTabPage uIHomeTabPage = this.UIWss_adsagetest163comWindow1.UIRibbonTabsTabList.UIHomeTabPage;
            WinButton uIUploadAccountsButton = this.UIWss_adsagetest163comWindow1.UIRibbonToolBar.UIUploadAccountsButton;
            #endregion

            // Click 'Home' tab
            Mouse.Click(uIHomeTabPage, new Point(27, 1));

            // Click 'Upload Accounts' button
            Mouse.Click(uIUploadAccountsButton, new Point(17, 49));

            //Wait Upload change windows exist
            Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges uploadChangeWindow = new Common.UITestFramework.UIMaps.UploadChangesClasses.UploadChanges();
            uploadChangeWindow.UIUploadchangesWindow.WaitForControlExist();

            //Check first row and click OK button
            uploadChangeWindow.SelectGoogleAccountAndClickOKButton();
        }
    }
}
