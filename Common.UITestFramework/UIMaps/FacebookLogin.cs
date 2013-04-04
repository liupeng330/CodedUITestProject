namespace Common.UITestFramework.UIMaps.FacebookLoginClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
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


    public partial class FacebookLogin
    {

        /// <summary>
        /// Login - Use 'LoginParams' to pass parameters into this method.
        /// </summary>
        public void Login()
        {
            #region Variable Declarations
            HtmlEdit uIEmailEdit = this.UIFacebookLoginWindow.UIItemClient.UILogInFacebookDocument.UIEmailEdit;
            HtmlEdit uIPasswordEdit = this.UIFacebookLoginWindow.UIItemClient.UILogInFacebookDocument.UIPasswordEdit;
            HtmlInputButton uILogInButton = this.UIFacebookLoginWindow.UIItemClient.UILogInFacebookDocument.UILogInButton;
            #endregion

            // Type 'haih@ad-sage.com' in 'Email:' text box
            uIEmailEdit.WaitForControlExist(1000*120);
            uIEmailEdit.Text = this.LoginParams.UIEmailEditText;

            // Type '{Tab}' in 'Email:' text box
            Keyboard.SendKeys(uIEmailEdit, this.LoginParams.UIEmailEditSendKeys, ModifierKeys.None);

            // Type '********' in 'Password:' text box
            uIEmailEdit.WaitForControlExist(1000*120);
            uIPasswordEdit.Password = this.LoginParams.UIPasswordEditPassword;

            // Click 'Log In' button
            Mouse.Click(uILogInButton, new Point(26, 2));
        }

        public virtual LoginParams LoginParams
        {
            get
            {
                if ((this.mLoginParams == null))
                {
                    this.mLoginParams = new LoginParams();
                }
                return this.mLoginParams;
            }
        }

        private LoginParams mLoginParams;
    }
    /// <summary>
    /// Parameters to be passed into 'Login'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class LoginParams
    {

        #region Fields
        /// <summary>
        /// Type 'haih@ad-sage.com' in 'Email:' text box
        /// </summary>
        public string UIEmailEditText = "haih@ad-sage.com";

        /// <summary>
        /// Type '{Tab}' in 'Email:' text box
        /// </summary>
        public string UIEmailEditSendKeys = "{Tab}";

        /// <summary>
        /// Type '********' in 'Password:' text box
        /// </summary>
        public string UIPasswordEditPassword = "MhvBzIeW0NDQBXnlCN84qej3ei3DX3qI";
        #endregion
}
}
