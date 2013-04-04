namespace Google.UITestFramework.UIMaps.TextAdClasses
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

    public partial class TextAd
    {
        public void AddTextAd(Google.UITestFramework.Object.TextAdvertisement textAd, bool isEdit)
        {
            #region Variable Declarations
            WinEdit uITBHeadlineEdit = this.UIWss_adsagetest163comWindow.UITBHeadlineWindow.UITBHeadlineEdit;
            WinEdit uITBDesc1Edit = this.UIWss_adsagetest163comWindow.UITBDesc1Window.UITBDesc1Edit;
            WinEdit uITBDesc2Edit = this.UIWss_adsagetest163comWindow.UITBDesc2Window.UITBDesc2Edit;
            WinEdit uITBDisplayEdit = this.UIWss_adsagetest163comWindow.UITBDisplayWindow.UITBDisplayEdit;
            WinEdit uILBDestinationEdit = this.UIWss_adsagetest163comWindow3.UIGoogleTextAdEditorWindow.UIButtonEditDestinatioEdit.UILBDestinationEdit;
            #endregion

            if (!isEdit)
            {
                uITBHeadlineEdit.Text = textAd.Headline;
            }
            uITBDesc1Edit.Text = textAd.DescriptionLine1;
            uITBDesc2Edit.Text = textAd.DescriptionLine2;
            uITBDisplayEdit.Text = textAd.DisplayUrl;
            uILBDestinationEdit.Text = textAd.DestinationUrl;
            Keyboard.SendKeys(uILBDestinationEdit, "{Enter}");
        }

        /// <summary>
        /// AssertMethod1 - Use 'AssertMethod1ExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyAdPreview(Google.UITestFramework.Object.TextAdvertisement textAd)
        {
            #region Variable Declarations
            WinEdit uILBDestinationEdit = this.UIWss_adsagetest163comWindow3.UIGoogleTextAdEditorWindow.UIButtonEditDestinatioEdit.UILBDestinationEdit;
            WinHyperlink uIHeadlineHyperlink = this.UIWss_adsagetest163comWindow2.UIHeadlineWindow.UIHeadlineText.UIHeadlineHyperlink;
            WinText uIDescriptionLine1Text = this.UIWss_adsagetest163comWindow2.UIDescriptionLine1Window.UIDescriptionLine1Text;
            WinText uIDescriptionLine2Text = this.UIWss_adsagetest163comWindow2.UIDescriptionLine2Window.UIDescriptionLine2Text;
            WinText uIDisplayURLText = this.UIWss_adsagetest163comWindow2.UIDisplayURLWindow.UIDisplayURLText;
            #endregion

            // Verify that 'Headline' link's property 'DisplayText' equals 'Headline'
            Assert.AreEqual(textAd.Headline, uIHeadlineHyperlink.Name);

            // Verify that 'DescriptionLine1' label's property 'DisplayText' equals 'DescriptionLine1'
            Assert.AreEqual(textAd.DescriptionLine1, uIDescriptionLine1Text.DisplayText);

            // Verify that 'DescriptionLine2' label's property 'DisplayText' equals 'DescriptionLine2'
            Assert.AreEqual(textAd.DescriptionLine2, uIDescriptionLine2Text.DisplayText);

            // Verify that 'DisplayURL' label's property 'DisplayText' equals 'DisplayURL'
            Assert.AreEqual(textAd.DisplayUrl, uIDisplayURLText.DisplayText);
        }

        public Google.UITestFramework.Object.TextAdvertisement GetTextAdFromEditPanel()
        {
            #region Variable Declarations
            WinEdit uITBHeadlineEdit = this.UIWss_adsagetest163comWindow3.UITBHeadlineWindow.UITBHeadlineEdit;
            WinEdit uITBDesc1Edit = this.UIWss_adsagetest163comWindow3.UITBDesc1Window.UITBDesc1Edit;
            WinEdit uITBDesc2Edit = this.UIWss_adsagetest163comWindow3.UITBDesc2Window.UITBDesc2Edit;
            WinEdit uITBDisplayEdit = this.UIWss_adsagetest163comWindow3.UITBDisplayWindow.UITBDisplayEdit;
            WinEdit uIButtonEditDestinatioEdit1 = this.UIWss_adsagetest163comWindow3.UIGoogleTextAdEditorWindow.UIButtonEditDestinatioEdit.UIButtonEditDestinatioEdit1;
            WinComboBox uICBStatusComboBox = this.UIWss_adsagetest163comWindow3.UICBStatusWindow.UICBStatusComboBox;
            #endregion

            Google.UITestFramework.Object.TextAdvertisement textAd = new UITestFramework.Object.TextAdvertisement 
            {
                Headline = uITBHeadlineEdit.Text,
                DescriptionLine1 = uITBDesc1Edit.Text,
                DescriptionLine2 = uITBDesc2Edit.Text,
                DisplayUrl = uITBDisplayEdit.Text,
                DestinationUrl = uIButtonEditDestinatioEdit1.Text,
                Status = uICBStatusComboBox.SelectedItem,
            };
            return textAd;
        }
    }
}
