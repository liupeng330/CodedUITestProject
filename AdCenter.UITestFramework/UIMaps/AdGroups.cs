namespace AdCenter.UITestFramework.UIMaps.AdGroupsClasses
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


    public partial class AdGroups
    {
        public void AddAdvertisement(string name)
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIMicrosoftadlabsUSD__Window.UITxtNameWindow.UITxtNameEdit;
            #endregion

            // Type 'abcabcabc' in 'txtName' text box
            uITxtNameEdit.Text = name;

            // Type '{Enter}' in 'txtName' text box
            Keyboard.SendKeys(uITxtNameEdit, "{Enter}", ModifierKeys.None);
        }

        /// <summary>
        /// AssertMethod1 - Use 'AssertMethod1ExpectedValues' to pass parameters into this method.
        /// </summary>
        public AdCenter.UITestFramework.Object.AdGroup GetAdFromEditPanel()
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIMicrosoftadlabsUSDadWindow.UITxtNameWindow.UITxtNameEdit;
            WinComboBox uICbStatusComboBox = this.UIMicrosoftadlabsUSDadWindow.UICbStatusWindow.UICbStatusComboBox;
            UITestControl startDate = this.UIMicrosoftadlabsUSDadWindow.UIDtpStartDateWindow.UISearchBidUSDClient.GetChildren()[0];
            UITestControl endDate = this.UIMicrosoftadlabsUSDadWindow.UINoneWindow.UINoneClient.GetChildren()[0];
            WinEdit uITxtSearchBidEdit = this.UIMicrosoftadlabsUSDadWindow.UITxtSearchBidWindow.UITxtSearchBidEdit;
            WinEdit uITxtContentBidEdit = this.UIMicrosoftadlabsUSDadWindow.UITxtContentBidWindow.UITxtContentBidEdit;
            #endregion

            AdCenter.UITestFramework.Object.AdGroup adGroupObject = new UITestFramework.Object.AdGroup 
            {
                Name=uITxtNameEdit.Text,
                Status=uICbStatusComboBox.SelectedItem,
                StartDate = DateTime.Parse(startDate.GetProperty(WinWindow.PropertyNames.AccessibleName).ToString()).ToString("MM/dd/yyyy"),
                EndDate = DateTime.Parse(endDate.GetProperty(WinWindow.PropertyNames.AccessibleName).ToString()).ToString("MM/dd/yyyy"),
                SearchBid = uITxtSearchBidEdit.Text,
                ContentBid = uITxtContentBidEdit.Text,
            };
            return adGroupObject;
        }

        /// <summary>
        /// ClickAddAdGroupButton
        /// </summary>
        public void ClickAddAdGroupButton()
        {
            #region Variable Declarations

            WinTabPage uIAdGroups0TabPage = this.UIMicrosoftadlabsUSDadWindow.UIItemTabList.UIAdGroups0TabPage;
            WinButton uIAddAdGroupButton = this.UIMicrosoftadlabsUSDadWindow.UIRibbonToolBar.UIAddAdGroupButton;
            WinButton uIOKButton = this.UIChooseaCampaignWindow.UIOKWindow.UIOKButton;

            #endregion

            // Click 'Ad Groups(0)' tab
            Mouse.Click(uIAdGroups0TabPage, new Point(40, 10));

            // Click 'Add Ad Group' button
            Mouse.Click(uIAddAdGroupButton, new Point(18, 28));

            // Click 'OK' button
            bool isOkWindowExist = UIChooseaCampaignWindow.UIOKWindow.WaitForControlExist();
            if (isOkWindowExist)
            {
                Mouse.Click(uIOKButton, new Point(41, 17));
            }
        }
    }
}
