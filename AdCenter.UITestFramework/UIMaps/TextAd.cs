namespace AdCenter.UITestFramework.UIMaps.TextAdClasses
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


    public partial class TextAd
    {
        public void AddTextAd(AdCenter.UITestFramework.Object.TextAdvertisement textAd)
        {
            #region Variable Declarations
            WinEdit uITxtTitleEdit = this.UIMicrosoftadlabsUSD__Window.UITxtTitleWindow.UITxtTitleEdit;
            WinEdit uITxtTextEdit = this.UIMicrosoftadlabsUSD__Window.UITxtTextWindow.UITxtTextEdit;
            WinEdit uITxtDisplayUrlEdit = this.UIMicrosoftadlabsUSD__Window.UITxtDisplayUrlWindow.UITxtDisplayUrlEdit;
            WinEdit buttonEditDestinationURL = GetUIEditDestination(textAd.DisplayUrl.Length + "/35").UIButtonEditDestinatioEdit1;
            #endregion

            uITxtTitleEdit.Text = textAd.Title;
            uITxtTextEdit.Text = textAd.Text;
            uITxtDisplayUrlEdit.Text = textAd.DisplayUrl;
            buttonEditDestinationURL.Text = textAd.DestinationUrl;
            Keyboard.SendKeys(buttonEditDestinationURL, "{Enter}", ModifierKeys.None);
        }

        public AdCenter.UITestFramework.Object.TextAdvertisement GetTextAdFromEditPanel(string displayUrl)
        {
            WinEdit uITxtTitleEdit = this.UIMicrosoftadlabsUSD__Window.UITxtTitleWindow.UITxtTitleEdit;
            WinEdit uITxtTextEdit = this.UIMicrosoftadlabsUSD__Window.UITxtTextWindow.UITxtTextEdit;
            WinEdit uITxtDisplayUrlEdit = this.UIMicrosoftadlabsUSD__Window.UITxtDisplayUrlWindow.UITxtDisplayUrlEdit;
            WinEdit buttonEditDestinationURL = GetUIEditDestination(displayUrl.Length + "/35").UIButtonEditDestinatioEdit1;
            WinComboBox status = this.UIMicrosoftadlabsUSD__Window1.UICbStatusWindow.UICbStatusComboBox;

            AdCenter.UITestFramework.Object.TextAdvertisement textAd = new UITestFramework.Object.TextAdvertisement
            {
                Title = uITxtTitleEdit.Text,
                Text = uITxtTextEdit.Text,
                DisplayUrl = uITxtDisplayUrlEdit.Text,
                DestinationUrl = this.GetUIEditDestination(displayUrl.Length + "/35").UIButtonEditDestinatioEdit1.Text,
                AdGroupStatus = status.SelectedItem,
            };
            return textAd;
        }

        public void VerifyAdPreview(UITestFramework.Object.TextAdvertisement textAdObject)
        {
            Assert.AreEqual<string>(textAdObject.Title, this.UIMicrosoftadlabsUSD__Window.lableTitle.Name);
            Assert.AreEqual<string>(textAdObject.Text, this.UIMicrosoftadlabsUSD__Window.labelText.Name);
            Assert.AreEqual<string>(textAdObject.DisplayUrl, this.UIMicrosoftadlabsUSD__Window.LBDisplayURL.Name);
        }

        private UIButtonEditDestinatioEdit GetUIEditDestination(string destinationUrl)
        {
            if (uiEditDestinationEdit == null)
            {
                uiEditDestinationEdit = new UIButtonEditDestinatioEdit(this.UIMicrosoftadlabsUSD__Window.UIAdCenterTextAdEditorWindow, destinationUrl);
            }
            return this.uiEditDestinationEdit;
        }

        private UIButtonEditDestinatioEdit uiEditDestinationEdit;
    }

    public class UIButtonEditDestinatioEdit : WinEdit
    {
        public UIButtonEditDestinatioEdit(UITestControl searchLimitContainer, string name) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.name = name;
            this.SearchProperties[WinEdit.PropertyNames.Name] = name;
            this.SearchProperties[WinEdit.PropertyNames.ControlName] = "buttonEditDestinationURL";
            this.WindowTitles.Add("Microsoft adlabs(USD) - ___zOACz_V - ___SmI87v - adSage for Performance");
            #endregion
        }

        private string name;

        #region Properties
        public WinEdit UIButtonEditDestinatioEdit1
        {
            get
            {
                if ((this.mUIButtonEditDestinatioEdit == null))
                {
                    this.mUIButtonEditDestinatioEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIButtonEditDestinatioEdit.SearchProperties[WinEdit.PropertyNames.Name] = this.name;
                    this.mUIButtonEditDestinatioEdit.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIButtonEditDestinatioEdit.WindowTitles.Add("Microsoft adlabs(USD) - ___zOACz_V - ___SmI87v - adSage for Performance");
                    #endregion
                }
                return this.mUIButtonEditDestinatioEdit;
            }
        }
        #endregion

        #region Fields
        private WinEdit mUIButtonEditDestinatioEdit;
        #endregion
    }
}
