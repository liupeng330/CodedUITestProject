namespace Common.UITestFramework.UIMaps.OptionsWindowClasses
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


    public partial class OptionsWindow
    {

        /// <summary>
        /// TearDownProxy - Use 'TearDownProxyParams' to pass parameters into this method.
        /// </summary>
        public void TearDownProxy()
        {
            #region Variable Declarations
            WinCheckBox uIConnecttoPublishthroCheckBox = this.UIOptionsWindow.UIConnecttoPublishthroWindow.UIConnecttoPublishthroCheckBox;
            WinButton uIOKButton = this.UIOptionsWindow.UIOKWindow.UIOKButton;
            WinButton uICancelButton = this.UIOptionsWindow.UICancelWindow.UICancelButton;
            #endregion

            // Clear 'Connect to Publish through an HTTP Proxy' check box
            uIConnecttoPublishthroCheckBox.Checked = this.TearDownProxyParams.UIConnecttoPublishthroCheckBoxChecked;

            // Click '&OK' button
            if (uIOKButton.Enabled)
            {
                Mouse.Click(uIOKButton, new Point(38, 9));
            }
            else
            {
                Mouse.Click(uICancelButton, new Point(5, 5));
            }
        }

        public virtual TearDownProxyParams TearDownProxyParams
        {
            get
            {
                if ((this.mTearDownProxyParams == null))
                {
                    this.mTearDownProxyParams = new TearDownProxyParams();
                }
                return this.mTearDownProxyParams;
            }
        }

        private TearDownProxyParams mTearDownProxyParams;
    }

    /// <summary>
    /// Parameters to be passed into 'TearDownProxy'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class TearDownProxyParams
    {
        #region Fields
        /// <summary>
        /// Clear 'Connect to Publish through an HTTP Proxy' check box
        /// </summary>
        public bool UIConnecttoPublishthroCheckBoxChecked = false;
        #endregion
    }
}
