namespace AdCenter.UITestFramework.UIMaps.KeywordClasses
{
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    
    
    public partial class Keyword
    {
        public void AddKeyword(UITestFramework.Object.Keyword keyword)
        {
            #region Variable Declarations
            WinEdit uITBNameEdit = UIMicrosoftadlabsUSDadWindow.UITBNameWindow.UITBNameEdit;
            WinEdit uIDestinationUrlEdit = UIMicrosoftadlabsUSDadWindow.UIAdCenterOrderItemEdiWindow.UIButtonEditDestinatioEdit;
            #endregion

            // Type 'aaa' in 'TBName' text box
            uITBNameEdit.Text = keyword.Keywords;

            // Type 'bbb{Enter}' in 'Append text' text box
            uIDestinationUrlEdit.Text = keyword.DesURL;
            Keyboard.SendKeys(uIDestinationUrlEdit, "{Enter}", ModifierKeys.None);

        }

        public UITestFramework.Object.Keyword GetKeywordFromEditPanel(string destinationUrl)
        {
            WinEdit uITBNameEdit = this.UIMicrosoftadlabsUSDadWindow.UITBNameWindow.UITBNameEdit;
            WinEdit uIbroadMatchBid = this.UIMicrosoftadlabsUSDadWindow.UITBBroadMatchBidWindow.UITBBroadMatchBidEdit;
            WinEdit uIexactMatchBid = this.UIMicrosoftadlabsUSDadWindow.UITBExactMatchBidWindow.UITBExactMatchBidEdit;
            WinEdit uIphraseMatchBid = this.UIMicrosoftadlabsUSDadWindow.UITBPhraseMatchBidWindow.UITBPhraseMatchBidEdit;
            WinEdit uIDestinationURL=this.UIMicrosoftadlabsUSDadWindow.UIAdCenterOrderItemEdiWindow.UIButtonEditDestinatioEdit;
            WinComboBox uICBStatusComboBox = this.UIMicrosoftadlabsUSDadWindow.UICBStatusWindow.UICBStatusComboBox;

            AdCenter.UITestFramework.Object.Keyword keyword = new UITestFramework.Object.Keyword
            {
                Keywords = uITBNameEdit.Text,
                KeywordStatus = uICBStatusComboBox.SelectedItem,
                BroadMatchBid=uIbroadMatchBid.Text,
                ExactMatchBid=uIexactMatchBid.Text,
                PhraseMatchBid=uIphraseMatchBid.Text,
                DesURL = uIDestinationURL.Text,
            };
            return keyword;

        }
    }
}
