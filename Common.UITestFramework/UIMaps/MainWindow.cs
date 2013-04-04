namespace Common.UITestFramework.UIMaps.MainWindowClasses
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
    
    
    public partial class MainWindow
    {

        /// <summary>
        /// ContextMenuDownloadAccount
        /// </summary>
        public void ContextMenuDownloadAccount()
        {
            #region Variable Declarations
            WinTreeItem uIHaihadsagecom4684830TreeItem = this.UIAdSageforPerformanceWindow.UIAccountTreeViewWindow.UIYourAccounts1TreeItem.UIHaihadsagecom4684830TreeItem;
            WinMenuItem uIDownloadAccountMenuItem = this.UIItemWindow.UIDropDownMenu.UIDownloadAccountMenuItem;
            #endregion

            // Right-Click 'Your Accounts(1)' -> 'haih@ad-sage.com #46848300(USD)' tree item
            Mouse.Click(uIHaihadsagecom4684830TreeItem, MouseButtons.Right, ModifierKeys.None, new Point(16, 10));

            // Click 'Download Account' menu item
            Mouse.Click(uIDownloadAccountMenuItem, new Point(93, 9));
}

        /// <summary>
        /// NavigateToCampaignPanel
        /// </summary>
        public void NavigateToCampaignPanel()
        {
            #region Variable Declarations
            WinTreeItem uIHaihadsagecom4684830TreeItem = this.UIAdSageforPerformanceWindow.UIAccountTreeViewWindow.UIYourAccounts1TreeItem.UIHaihadsagecom4684830TreeItem;
            WinTabPage uICampaigns0TabPage = this.UIAdSageforPerformanceWindow.UIItemTabList.UICampaigns0TabPage;
            #endregion

            // Click 'Your Accounts(1)' -> 'haih@ad-sage.com #46848300(USD)' tree item
            Mouse.Click(uIHaihadsagecom4684830TreeItem, new Point(-17, 9));

            WaitForEnable(uICampaigns0TabPage);
            // Click 'Campaigns(0)' tab
            Mouse.Click(uICampaigns0TabPage, new Point(39, 13));
        }

        private void WaitForEnable(UITestControl control)
        {
            try
            {
                int waitTime = 1000 * 60 * 2;
                control.WaitForControlExist(waitTime);
                control.WaitForControlReady(waitTime);
            }
            catch (UITestControlNotFoundException)
            {
                control.SearchProperties[WinTabPage.PropertyNames.Name] = "Campaigns(...)";
            }
        }

        /// <summary>
        /// NavigateToAccount2Item
        /// </summary>
        public void NavigateToAccount2Item()
        {
            #region Variable Declarations

            WinTreeItem uIAccount2348004880USDTreeItem =
                this.UIAccount2348004880USDWindow.UIItemWindow.UIItemTree.UIYourAccounts1TreeItem.
                    UIAccount2348004880USDTreeItem;
            WinTabPage uICampaigns0TabPage =
                this.UIAccount2348004880USDWindow.UIDxTabPageContainerCoWindow.UIItemTabList.UICampaigns0TabPage;

            #endregion

            // Click 'Your Accounts(1)' -> 'Account2 #348004880(USD)' tree item
            Mouse.Click(uIAccount2348004880USDTreeItem, new Point(18, 9));

            // Click 'Campaigns(0)' tab
            Mouse.Click(uICampaigns0TabPage, new Point(45, 8));
        }
    }
}
