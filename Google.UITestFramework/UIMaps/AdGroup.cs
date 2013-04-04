namespace Google.UITestFramework.UIMaps.AdvertisementClasses
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


    public partial class AdGroup
    {
        /// <summary>
        /// AddAdvertisement - Use 'AddAdvertisementParams' to pass parameters into this method.
        /// </summary>
        public void AddAdvertisement(string name, string cpmBid)
        {
            #region Variable Declarations
            WinClient uIDataPanelClient = this.UIWss_adsagetest163comWindow1.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;
            WinEdit uITBMaximumCPMBidEdit = this.UIWss_adsagetest163comWindow1.UITBMaximumCPMBidWindow.UITBMaximumCPMBidEdit;
            #endregion

            // Type 'test' in 'TBName' text box
            uITBNameEdit.Text = name;

            // Type '0.01' in 'TBMaximumCPMBid' text box
            uITBMaximumCPMBidEdit.Text = cpmBid;

            // Type '{Enter}' in 'TBMaximumCPMBid' text box
            Keyboard.SendKeys(uITBMaximumCPMBidEdit, "{Enter}", ModifierKeys.None);
        }

        public Google.UITestFramework.Object.AdGroup GetAdFromEditPanel()
        {
            #region Variable Declarations
            WinEdit uITBNameEdit = this.UIWss_adsagetest163comWindow1.UITBNameWindow.UITBNameEdit;
            WinComboBox uICBStatusComboBox = this.UIWss_adsagetest163comWindow2.UICBStatusWindow.UICBStatusComboBox;
            WinEdit uITBMaximumCPCBidEdit = this.UIWss_adsagetest163comWindow3.UITBMaximumCPCBidWindow.UITBMaximumCPCBidEdit;
            WinEdit uITBMaximumCPMBidEdit = this.UIWss_adsagetest163comWindow1.UITBMaximumCPMBidWindow.UITBMaximumCPMBidEdit;
            WinEdit uITBMaximumCPCContentBEdit = this.UIWss_adsagetest163comWindow4.UITBMaximumCPCContentBWindow.UITBMaximumCPCContentBEdit;
            WinEdit uITBMaximumCPABidEdit = this.UIWss_adsagetest163comWindow5.UITBMaximumCPABidWindow.UITBMaximumCPABidEdit;
            #endregion

            Google.UITestFramework.Object.AdGroup ad = new UITestFramework.Object.AdGroup
            {
                Name = uITBNameEdit.Text,
                Status = uICBStatusComboBox.SelectedItem,
                DefaultMaxCPCBid = uITBMaximumCPCBidEdit.Text,
                MaxCPMBid = uITBMaximumCPMBidEdit.Text,
                DisplaytNetworkMaxCPCBid = uITBMaximumCPCContentBEdit.Text,
                CPABid = uITBMaximumCPABidEdit.Text,
            };
            return ad;
        }
    }
}
