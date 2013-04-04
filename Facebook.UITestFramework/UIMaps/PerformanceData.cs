namespace Facebook.UITestFramework.UIMaps.PerformanceDataClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    public partial class PerformanceData
    {

        /// <summary>
        /// SelectFacebookAccount
        /// </summary>
        public void SelectFacebookAccount()
        {
            #region Variable Declarations
            WinCell uIFalseCell = this.UIDownloadPerformanceWindow.UIDgvAccountWindow.UIDataGridViewTable.UIRow1Row1.UIFalseCell;
            WinMenuItem uICreateCustomDateRangMenuItem = this.UIDownloadPerformanceWindow.UIToolStripToolBar.UICustomDateSelectButtMenuItem.UICreateCustomDateRangMenuItem;
            #endregion

            // Click 'False' cell
            Mouse.Click(uIFalseCell, MouseButtons.Left);

            // Click 'customDateSelectButton' -> 'Create Custom Date Range...' menu item
            Mouse.Click(uICreateCustomDateRangMenuItem, new Point(60, 6));
        }

        /// <summary>
        /// SelectEndDateTime
        /// </summary>
        public void SelectEndDateTime()
        {
            #region Variable Declarations
            WinControl uITuesdayJanuary172012DropDown = this.UICreateCustomDateRangWindow.UIDateTimePickerEndClient.UITuesdayJanuary172012DropDown;
            WinClient uIItemClient = this.UIItemWindow.UIItemWindow1.UIItemClient;
            #endregion

            // Click 'Tuesday, January 17, 2012' DropDown
            Thread.Sleep(1000);
            Mouse.Click(uITuesdayJanuary172012DropDown, new Point(161, 7));

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(128, 29));
            Thread.Sleep(1000);

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(130, 28));
            Thread.Sleep(1000);

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(163, 68));
            Thread.Sleep(1000);

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(226, 158));
            Thread.Sleep(1000);

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(222, 102));
            Thread.Sleep(1000);
        }

        /// <summary>
        /// SelectStartDateTime
        /// </summary>
        public void SelectStartDateTime()
        {
            #region Variable Declarations
            WinControl uISundayDecember182011DropDown = this.UICreateCustomDateRangWindow.UIDateTimePickerStartClient.UISundayDecember182011DropDown;
            WinClient uIItemClient = this.UIItemWindow.UIItemWindow1.UIItemClient;
            #endregion

            // Click 'Sunday, December 18, 2011' DropDown
            Mouse.Click(uISundayDecember182011DropDown, new Point(159, 9));
            Thread.Sleep(1000);

            // Click 'Unknown Name' client
            Mouse.Click(uIItemClient, new Point(162, 83));
            Thread.Sleep(1000);
        }
    }
}
