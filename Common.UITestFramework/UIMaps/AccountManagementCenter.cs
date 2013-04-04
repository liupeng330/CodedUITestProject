namespace Common.UITestFramework.UIMaps.AccountManagementCenterClasses
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


    public partial class AccountManagementCenter
    {
        public Common.UITestFramework.UIMaps.UploadingRestrictionClasses.UIUploadingRestrictionWindow UIUploadingRestrictionWindow
        {
            get
            {
                if (this.mUIUploadingRestrictionWindow == null)
                {
                    this.mUIUploadingRestrictionWindow = new Common.UITestFramework.UIMaps.UploadingRestrictionClasses.UIUploadingRestrictionWindow();
                }
                return this.mUIUploadingRestrictionWindow;
            }
        }

        private Common.UITestFramework.UIMaps.UploadingRestrictionClasses.UIUploadingRestrictionWindow mUIUploadingRestrictionWindow;

        /// <summary>
        /// VerifyActiveGoogleAccount - Use 'VerifyActiveGoogleAccountExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyActiveGoogleAccount()
        {
            #region Variable Declarations

            WinRow uIRow2Row = this.UIAccountManagementCenWindow.UIDgvAccountWindow.UIDataGridViewTable.UIRow3Row;
            WinTreeItem uIWss_adsagetest163comTreeItem = this.UIAccountManagementCenWindow.UISageTreeViewWindow.UIWss_adsagetest163comTreeItem;

            #endregion

            // Verify that 'Row 1' row's property 'Value' equals 'wss_adsagetest@163.com(CNY);Google;&Activate'
            Assert.AreEqual(this.VerifyActiveGoogleAccountExpectedValues.UIRow1RowValue, uIRow2Row.Value);

            // Verify that 'wss_adsagetest@163.com' tree item's property 'Name' equals 'adsagetest@163.com'
            Assert.AreEqual(this.VerifyActiveGoogleAccountExpectedValues.UIWss_adsagetest163comTreeItemName, uIWss_adsagetest163comTreeItem.Name);
        }

        public virtual VerifyActiveGoogleAccountExpectedValues VerifyActiveGoogleAccountExpectedValues
        {
            get
            {
                if ((this.mVerifyActiveGoogleAccountExpectedValues == null))
                {
                    this.mVerifyActiveGoogleAccountExpectedValues = new VerifyActiveGoogleAccountExpectedValues();
                }
                return this.mVerifyActiveGoogleAccountExpectedValues;
            }
        }
        private VerifyActiveGoogleAccountExpectedValues mVerifyActiveGoogleAccountExpectedValues;
    }

    /// <summary>
    /// Parameters to be passed into 'VerifyActiveGoogleAccount'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyActiveGoogleAccountExpectedValues
    {
        #region Fields

        /// <summary>
        /// Verify that 'Row 1' row's property 'Value' equals 'wss_adsagetest@163.com(CNY);Google;&Activate'
        /// </summary>
        public string UIRow1RowValue = "wss_adsagetest@163.com(CNY);Google;&Activate";

        /// <summary>
        /// Verify that 'wss_adsagetest@163.com' tree item's property 'Name' equals 'adsagetest@163.com'
        /// </summary>
        public string UIWss_adsagetest163comTreeItemName = "adsagetest@163.com";

        #endregion
    }
}
