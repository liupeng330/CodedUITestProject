namespace Common.UITestFramework.UIMaps.AddUsersClasses
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
    using System.Configuration;


    public partial class AddUsers
    {

        /// <summary>
        /// AddGoogleUser - Use 'AddGoogleUserParams' to pass parameters into this method.
        /// </summary>
        public void AddGoogleUser()
        {
            #region Variable Declarations
            WinComboBox uIOnlineMediaComboBox = this.UIAddUserWindow.UICboxEngineWindow.UIOnlineMediaComboBox;
            WinEdit uITxtUserNameEdit = this.UIAddUserWindow.UITxtUserNameWindow1.UITxtUserNameEdit;
            WinEdit uITxtPasswordEdit = this.UIAddUserWindow.UITxtPasswordWindow1.UITxtPasswordEdit;
            WinEdit uITxtDevTokenEdit = this.UIAddUserWindow.UITxtDevTokenWindow1.UITxtDevTokenEdit;
            WinButton uIOKButton = this.UIAddUserWindow.UIOKWindow.UIOKButton;
            #endregion

            // Select 'Google' in 'Online Media:' combo box
            uIOnlineMediaComboBox.SelectedItem = "Google";

            // Type 'wss_adsagetest@163.com' in 'txtUserName' text box
            uITxtUserNameEdit.Text = ConfigurationManager.AppSettings.Get("GoogleUser");

            // Type '********' in 'txtPassword' text box
            Keyboard.SendKeys(uITxtPasswordEdit, ConfigurationManager.AppSettings.Get("GooglePassword"));

            // Type 'x9dEMwEcVHybpWvw9979KQ' in 'txtDevToken' text box
            uITxtDevTokenEdit.Text = ConfigurationManager.AppSettings.Get("GoogleToken");

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(36, 10));
        }

        /// <summary>
        /// AddAdcenterUser - Use 'AddAdcenterUserParams' to pass parameters into this method.
        /// </summary>
        public void AddAdcenterUser()
        {
            #region Variable Declarations
            WinComboBox uIOnlineMediaComboBox = this.UIAddUserWindow.UICboxEngineWindow.UIOnlineMediaComboBox;
            WinEdit uITxtUserNameEdit = this.UIAddUserWindow.UITxtUserNameWindow1.UITxtUserNameEdit;
            WinEdit uITxtPasswordEdit = this.UIAddUserWindow.UITxtPasswordWindow1.UITxtPasswordEdit;
            WinEdit uITxtUserAccessKeyEdit = this.UIAddUserWindow.UITxtUserAccessKeyWindow.UITxtUserAccessKeyEdit;
            WinButton uIOKButton = this.UIAddUserWindow.UIOKWindow.UIOKButton;
            #endregion

            // Select 'AdCenter' in 'Online Media:' combo box
            uIOnlineMediaComboBox.SelectedItem = "AdCenter";

            // Type 'API_msft_adlabs' in 'txtUserName' text box
            uITxtUserNameEdit.Text = ConfigurationManager.AppSettings.Get("AdcenterUser");

            // Type '********' in 'txtPassword' text box
            Keyboard.SendKeys(uITxtPasswordEdit, ConfigurationManager.AppSettings.Get("AdcenterPassword"));

            // Type '5HJ0A8D6B3' in 'txtUserAccessKey' text box
            uITxtUserAccessKeyEdit.Text = ConfigurationManager.AppSettings.Get("AdcenterToken");

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(26, 14));
        }
    }
}
