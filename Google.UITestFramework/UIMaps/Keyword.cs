namespace Google.UITestFramework.UIMaps.KeywordClasses
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
        public void AddKeyword(Google.UITestFramework.Object.Keyword keyword)
        {
            #region Variable Declarations
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;
            WinEdit uIDestinationUrlEdit = this.UIWss_adsagetest163comWindow2.UIGoogleKeywordEditorWindow.UIButtonEditDestinatioEdit2.UIButtonEditDestinatioEdit1;
            #endregion

            // Type 'aaa' in 'TBName' text box
            uITBNameEdit.Text = keyword.Keywords;

            // Type 'bbb{Enter}' in 'Append text' text box
            uIDestinationUrlEdit.Text = keyword.DestinationUrl;
            Keyboard.SendKeys(uIDestinationUrlEdit, "{Enter}", ModifierKeys.None);
        }

        public Google.UITestFramework.Object.Keyword GetKeywordFromEditPanel(string destinationUrl)
        {
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;
            WinComboBox uICBMatchTypeComboBox = this.UIWss_adsagetest163comWindow2.UICBMatchTypeWindow.UICBMatchTypeComboBox;
            WinComboBox uICBStatusComboBox = this.UIWss_adsagetest163comWindow2.UICBStatusWindow.UICBStatusComboBox;
            Google.UITestFramework.Object.Keyword keyword = new UITestFramework.Object.Keyword 
            {
                Keywords = uITBNameEdit.Text,
                MatchType = uICBMatchTypeComboBox.SelectedItem,
                Status = uICBStatusComboBox.SelectedItem,
                DestinationUrl = GetUIEditDestination(destinationUrl).Text,
            };
            return keyword;
        }

        private UIEditDestinatioEdit GetUIEditDestination(string destinationUrl)
        {
            if (this.uiEditDestinationEdit == null)
            {
                uiEditDestinationEdit = new UIEditDestinatioEdit(this.UIWss_adsagetest163comWindow2.UIGoogleKeywordEditorWindow, destinationUrl);
            }
            return this.uiEditDestinationEdit;
        }

        private UIEditDestinatioEdit uiEditDestinationEdit;
    }

    public class UIEditDestinatioEdit : WinEdit
    {
        public UIEditDestinatioEdit(UITestControl searchLimitContainer, string destinationURL) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.destinationUrl = destinationURL;
            this.SearchProperties[WinEdit.PropertyNames.Name] = this.destinationUrl;
            this.WindowTitles.Add("wss_adsagetest@163.com(CNY) - ___WJW6IR - ___fWiBI9 - adSage for Performance");
            #endregion
        }

        private string destinationUrl;

        #region Properties
        public WinEdit UIButtonEditDestinatioEdit1
        {
            get
            {
                if ((this.mUIButtonEditDestinatioEdit1 == null))
                {
                    this.mUIButtonEditDestinatioEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUIButtonEditDestinatioEdit1.SearchProperties[WinEdit.PropertyNames.Name] = this.destinationUrl;
                    this.mUIButtonEditDestinatioEdit1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIButtonEditDestinatioEdit1.WindowTitles.Add("wss_adsagetest@163.com(CNY) - ___WJW6IR - ___fWiBI9 - adSage for Performance");
                    #endregion
                }
                return this.mUIButtonEditDestinatioEdit1;
            }
        }
        #endregion

        #region Fields
        private WinEdit mUIButtonEditDestinatioEdit1;
        #endregion
    }
}