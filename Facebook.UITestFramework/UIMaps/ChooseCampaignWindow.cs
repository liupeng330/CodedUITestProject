namespace Facebook.UITestFramework.UIMaps.ChooseCampaignWindowClasses
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


    public partial class ChooseCampaignWindow
    {

        /// <summary>
        /// ChooseCampaignByName - Use 'ChooseCampaignByNameParams' to pass parameters into this method.
        /// </summary>
        public void ChooseCampaignByName(string name)
        {
            #region Variable Declarations
            WinComboBox uICampaignComboBox = this.UIChooseaCampaignWindow.UIParentLocalizerWindow.UICampaignComboBox;
            WinButton uIOKButton = this.UIChooseaCampaignWindow.UIOKWindow.UIOKButton;
            #endregion

            // Select 'Campaign' in 'Campaign:' combo box
            uICampaignComboBox.SelectedItem = name;

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(35, 9));
        }
    }
}
