namespace Common.UITestFramework.UIMaps.UploadChangesClasses
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
    
    
    public partial class UploadChanges
    {
        /// <summary>
        /// RecordedMethod1
        /// </summary>
        public void SelectFacebookAccountAndClickOKButton()
        {
            #region Variable Declarations
            WinCell uIFalseCell = this.UIUploadchangesWindow.UIAccountsDataGridViewWindow.UIAccountsDataGridViewTable.UIRow0Row1.UIFalseCell;
            WinButton uIOKButton = this.UIUploadchangesWindow.UIOKWindow.UIOKButton;
            #endregion

            // Click 'False' cell
            Mouse.Click(uIFalseCell, new Point(14, 11));

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(34, 11));
}
    }
}
