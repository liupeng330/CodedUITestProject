namespace Facebook.UITestFramework.UIMaps.AdvertisementsClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
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
    using Facebook.UITestFramework.Object;
    using Facebook.UITestFramework.Enums;

    public partial class Advertisements
    {
        public UIFacebookAdGroupGridVWindow UIFacebookAdGroupGridVWindow
        {
            get
            {
                if (this.mUIFacebookAdGroupGridVWnidow == null)
                {
                    this.mUIFacebookAdGroupGridVWnidow = new UIFacebookAdGroupGridVWindow(this.UIHaihadsagecom4684830Window);
                }
                return this.mUIFacebookAdGroupGridVWnidow;
            }
        }
        private UIFacebookAdGroupGridVWindow mUIFacebookAdGroupGridVWnidow;

        /// <summary>
        /// AddAdvertisement - Use 'AddAdvertisementParams' to pass parameters into this method.
        /// </summary>
        public void AddAdvertisement(Advertisement advertisement, bool isEdit)
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIHaihadsagecom4684830Window.UITxtNameWindow.UITxtNameEdit;
            WinComboBox uIDestinationComboBox = this.UIHaihadsagecom4684830Window.UICbContentWindow.UIDestinationComboBox;
            WinListItem uIExternalURLListItem = this.UIItemWindow.UIListViewWindow.UIExternalURLListItem;
            WinEdit uITxtTitleEdit = this.UIHaihadsagecom4684830Window.UITxtTitleWindow.UITxtTitleEdit;
            WinEdit uITxtBodyEdit = this.UIHaihadsagecom4684830Window.UITxtBodyWindow.UITxtBodyEdit;
            WinRadioButton uIClicksRadioButton = this.UIHaihadsagecom4684830Window.UIClicksWindow.UIClicksRadioButton;
            WinRadioButton uIImpressionRadioButton = this.UIHaihadsagecom4684830Window.UIImpressionsWindow.UIImpressionsRadioButton;
            WinEdit uITxtBidEdit = this.UIHaihadsagecom4684830Window.UITxtBidWindow.UITxtBidEdit;
            WinComboBox uICbStatusComboBox = this.UIHaihadsagecom4684830Window.UICbStatusWindow.UICbStatusComboBox;
            WinEdit uIButtonEditDestinatioEdit1 = this.UIHaihadsagecom4684830Window6.UIPanelDesUrlWindow.UIButtonEditDestinatioEdit.UIButtonEditDestinatioEdit1;
            WinEdit uIItem0255Edit = this.UIHaihadsagecom4684830Window6.UIPanelDesUrlWindow.UIButtonEditDestinatioEdit.UIItem0255Edit;
            #endregion

            // Type 'ad-external' in 'txtName' text box
            uITxtNameEdit.Text = advertisement.AdName;

            // Click 'Destination:' combo box
            Mouse.Click(uIDestinationComboBox, new Point(250, 12));

            // Click 'External URL' list item
            Mouse.Click(uIExternalURLListItem, new Point(137, 6));

            // Type 'www.adsage.com' in 'txtUrl' text box
            if (!isEdit)
            {
                Keyboard.SendKeys(uIItem0255Edit, advertisement.DestinationUrl.ToString(), ModifierKeys.None);
            }

            // Type 'adsage for performance' in 'txtTitle' text box
            uITxtTitleEdit.Text = advertisement.Title;

            // Type 'adsage for performance' in 'txtBody' text box
            uITxtBodyEdit.Text = advertisement.Body;

            // Select 'Clicks' radio button
            if (advertisement.BidType == BidType.CPC)
            {
                uIClicksRadioButton.Selected = true;
            }
            else
            {
                uIImpressionRadioButton.Selected = true;
            }

            // Type '0.01' in 'txtBid' text box
            uITxtBidEdit.Text = advertisement.MaxBid.ToString();

            // Select 'Active' in 'cbStatus' combo box
            if (advertisement.AdStatus == AdStatus.Pendingreview)
            {
                uICbStatusComboBox.SelectedItem = "Pending review";
            }
            else
            {
                uICbStatusComboBox.SelectedItem = advertisement.AdStatus.ToString();
            }
        }

        /// <summary>
        /// ChooseImageFromLocal - Use 'ChooseImageFromLocalParams' to pass parameters into this method.
        /// </summary>
        public void ChooseImageFromLocal(string imageFileName)
        {
            #region Variable Declarations
            WinComboBox uIFilenameComboBox = this.UIOpenWindow.UIItemWindow.UIFilenameComboBox;
            WinSplitButton uIOpenSplitButton = this.UIOpenWindow.UIOpenWindow1.UIOpenSplitButton;
            WinButton uIChooseimagefromlocalButton = this.UIHaihadsagecom4684830Window5.UITSChooseImageWindow.UITSChooseImageToolBar.UIChooseimagefromlocalButton;
            #endregion

            // Click 'Choose image from local' button
            Mouse.Click(uIChooseimagefromlocalButton, new Point(78, 12));

            // Click 'Choose image from local' button
            Mouse.Click(uIChooseimagefromlocalButton, new Point(162, 10));

            //Wait OpenWindow exist
            this.UIOpenWindow.WaitForControlExist();

            // Select 'c:\users\liupeng\desktop\auto.jpg' in 'File name:' combo box
            uIFilenameComboBox.EditableItem = imageFileName;

            Keyboard.SendKeys(uIFilenameComboBox, "{Enter}", ModifierKeys.None);

            //Wait OpenWindow not exist
            this.UIOpenWindow.WaitForControlNotExist();
        }

        /// <summary>
        /// ClickSuggestedBidButton
        /// </summary>
        public void ClickSuggestedBidButton()
        {
            #region Variable Declarations
            WinButton uISuggestedBidButton = this.UIHaihadsagecom4684830Window.UISuggestedBidWindow.UISuggestedBidButton;
            WinTitleBar uIWaitingTitleBar = this.UIWaitingWindow.UIWaitingTitleBar;
            WinText uIEstimatingsuggestedbText = this.UIWaitingWindow.UIEstimatingsuggestedbWindow.UIEstimatingsuggestedbText;
            #endregion

            // Click '&Suggested Bid' button
            Mouse.Click(uISuggestedBidButton, new Point(59, 18));

            //Wait waiting window not exist
            this.UIWaitingWindow.WaitForControlNotExist();
        }

        public string GetSuggestBid()
        {
            WinText suggestdBidText = this.UIHaihadsagecom4684830Window7.UIItem215523USDWindow.UIItem215523USDText;
            return suggestdBidText.Name;
        }

        private void addPageSponsorStoryAdvertisement(AdType type, Advertisement pageAd)
        {
            #region Variable Declarations
            WinComboBox uIPagePostSelectionComboBox = this.UIHaihadsagecom4684830Window2.UICbPagePostSelWindow.UIPagePostSelectionComboBox;
            WinEdit uITxtNameEdit = this.UIHaihadsagecom4684830Window3.UITxtNameWindow.UITxtNameEdit;
            WinComboBox uIDestinationComboBox = this.UIHaihadsagecom4684830Window3.UICbContentWindow.UIDestinationComboBox;
            WinList uIListViewList = this.UIItemWindow.UIListViewWindow.UIListViewList;
            WinRadioButton uISponsoredStoriesRadioButton = this.UIHaihadsagecom4684830Window3.UISponsoredStoriesWindow.UISponsoredStoriesRadioButton;
            WinRadioButton uIClicksRadioButton = this.UIHaihadsagecom4684830Window3.UIClicksWindow.UIClicksRadioButton;
            WinRadioButton uIImpressionRadioButton = this.UIHaihadsagecom4684830Window2.UIImpressionsWindow.UIImpressionsRadioButton;
            WinEdit uITxtBidEdit = this.UIHaihadsagecom4684830Window3.UITxtBidWindow.UITxtBidEdit;
            WinComboBox uICbStatusComboBox = this.UIHaihadsagecom4684830Window3.UICbStatusWindow.UICbStatusComboBox;
            WinComboBox uICbAdTypeComboBox = this.UIHaihadsagecom4684830Window2.UICbAdTypeWindow.UICbAdTypeComboBox;
            WinComboBox uIAdTypeComboBox = this.UIHaihadsagecom4684830Window2.UICbStoryTypeWindow.UIAdTypeComboBox;
            #endregion

            // Click 'txtName' text box
            Mouse.Click(uITxtNameEdit, new Point(254, 8));

            // Type 'Ad-PageLikeStory' in 'txtName' text box
            uITxtNameEdit.Text = pageAd.AdName;

            // Click 'Destination:' combo box
            Mouse.Click(uIDestinationComboBox, new Point(224, 11));

            // Select 'AFF Automation Test' in 'listView' list box
            uIListViewList.SelectedItemsAsString = System.Configuration.ConfigurationManager.AppSettings.Get("PageName");


            switch (type)
            {
                case AdType.Page_Like_Story:
                    uICbAdTypeComboBox.SelectedItem = "Sponsored Story";
                    uIAdTypeComboBox.SelectedItem = "Page Like Story";
                    break;
                case AdType.Page_Post_Story:
                    uICbAdTypeComboBox.SelectedItem = "Facebook Ads";
                    uIAdTypeComboBox.SelectedItem = "Page Post Ad";
                    uIPagePostSelectionComboBox.SelectedItem = "-Most Recent Eligible Post";
                    break;
                case AdType.Page_Post_Like_Story:
                    uICbAdTypeComboBox.SelectedItem = "Sponsored Story";
                    uIAdTypeComboBox.SelectedItem = "Page Post Like Story";
                    break;
                default:
                    break;
            }

            if (pageAd.BidType == BidType.CPC)
            {
                uIClicksRadioButton.Selected = true;
            }
            else
            {
                uIImpressionRadioButton.Selected = true;
            }

            // Click 'txtBid' text box
            Mouse.Click(uITxtBidEdit, new Point(26, 10));

            // Type '0.01' in 'txtBid' text box
            uITxtBidEdit.Text = pageAd.MaxBid.ToString();

            if (pageAd.AdStatus == AdStatus.Pendingreview)
            {
                uICbStatusComboBox.SelectedItem = "Pending review";
            }
            else
            {
                uICbStatusComboBox.SelectedItem = pageAd.AdStatus.ToString();
            }
        }

        /// <summary>
        /// AddPageLikeStoryAdvertisement - Use 'AddPageLikeStoryAdvertisementParams' to pass parameters into this method.
        /// </summary>
        public void AddPageLikeStoryAdvertisement(Advertisement pageLikeStoryAd)
        {
            addPageSponsorStoryAdvertisement(AdType.Page_Like_Story, pageLikeStoryAd);
        }

        public void AddPagePostStoryAdvertisement(Advertisement pagePostAd)
        {
            addPageSponsorStoryAdvertisement(AdType.Page_Post_Story, pagePostAd);
        }

        public void AddPagePostLikeStoryAdvertisement(Advertisement pagePostLikeStoryAd)
        {
            addPageSponsorStoryAdvertisement(AdType.Page_Post_Like_Story, pagePostLikeStoryAd);
        }

        /// <summary>
        /// addAppSponsorStoryAdvertisement - Use 'addAppSponsorStoryAdvertisementParams' to pass parameters into this method.
        /// </summary>
        private void addAppSponsorStoryAdvertisement(AdType type, Advertisement appAd)
        {
            #region Variable Declarations
            WinEdit uITxtNameEdit = this.UIHaihadsagecom4684830Window1.UITxtNameWindow.UITxtNameEdit;
            WinComboBox uIDestinationComboBox = this.UIHaihadsagecom4684830Window1.UICbContentWindow.UIDestinationComboBox;
            WinList uIListViewList = this.UIItemWindow.UIListViewWindow.UIListViewList;
            WinRadioButton uIImpressionsRadioButton = this.UIHaihadsagecom4684830Window1.UIImpressionsWindow.UIImpressionsRadioButton;
            WinEdit uITxtBidEdit = this.UIHaihadsagecom4684830Window1.UITxtBidWindow.UITxtBidEdit;
            WinComboBox uICbStatusComboBox = this.UIHaihadsagecom4684830Window3.UICbStatusWindow.UICbStatusComboBox;
            WinComboBox uICbAdTypeComboBox = this.UIHaihadsagecom4684830Window2.UICbAdTypeWindow.UICbAdTypeComboBox;
            WinComboBox uIAdTypeComboBox = this.UIHaihadsagecom4684830Window2.UICbStoryTypeWindow.UIAdTypeComboBox;
            WinComboBox uICmbBidTypeComboBox = this.UIHaihadsagecom4684830Window8.UICmbBidTypeWindow.UICmbBidTypeComboBox;
            #endregion

            // Click 'txtName' text box
            Mouse.Click(uITxtNameEdit, new Point(118, 10));

            // Type 'ad-appused' in 'txtName' text box
            uITxtNameEdit.Text = appAd.AdName;

            // Click 'Destination:' combo box
            Mouse.Click(uIDestinationComboBox, new Point(45, 7));

            // Select 'adSage Ad Editor' in 'listView' list box
            uIListViewList.SelectedItemsAsString = System.Configuration.ConfigurationManager.AppSettings.Get("AppName");

            // Select 'Sponsored Story' item 
            uICbAdTypeComboBox.SelectedItem = "Sponsored Story";

            switch (type)
            {
                case AdType.App_Used_Story:
                    // Select 'App Used Story' in 'Ad Type:' combo box
                    uIAdTypeComboBox.SelectedItem = "App Used Story";
                    break;
                case AdType.App_Share_Story:
                    // Select 'App Share Story' in 'Ad Type:' combo box
                    uIAdTypeComboBox.SelectedItem = "App Share Story";
                    break;
                default:
                    break;
            }

            if (appAd.BidType == BidType.CPC)
            {
                uICmbBidTypeComboBox.SelectedItem = "CPC";
            }
            else
            {
                uICmbBidTypeComboBox.SelectedItem = "CPM";
            }

            // Click 'txtBid' text box
            Mouse.Click(uITxtBidEdit, new Point(24, 9));

            // Type '0.01' in 'txtBid' text box
            uITxtBidEdit.Text = appAd.MaxBid.ToString();

            if (appAd.AdStatus == AdStatus.Pendingreview)
            {
                uICbStatusComboBox.SelectedItem = "Pending review";
            }
            else
            {
                uICbStatusComboBox.SelectedItem = appAd.AdStatus.ToString();
            }
        }

        public void AddAppUsedStoryAdvertisement(Advertisement appUsedStoryAd)
        {
            addAppSponsorStoryAdvertisement(AdType.App_Used_Story, appUsedStoryAd);
        }

        public void AddAppShareStoryAdvertisement(Advertisement appShareStoryAd)
        {
            addAppSponsorStoryAdvertisement(AdType.App_Share_Story, appShareStoryAd);
        }
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIFacebookAdGroupGridVWindow : WinWindow
    {

        public UIFacebookAdGroupGridVWindow(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "FacebookAdGroupGridView";
            #endregion
        }

        #region Properties
        public UIDataGridViewTable UIDataGridViewTable
        {
            get
            {
                if ((this.mUIDataGridViewTable == null))
                {
                    this.mUIDataGridViewTable = new UIDataGridViewTable(this);
                }
                return this.mUIDataGridViewTable;
            }
        }
        #endregion

        #region Fields
        private UIDataGridViewTable mUIDataGridViewTable;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIDataGridViewTable : WinTable
    {

        public UIDataGridViewTable(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTable.PropertyNames.Name] = "DataGridView";
            #endregion
        }

        #region Properties
        public UITopRowRow UITopRowRow
        {
            get
            {
                if ((this.mUITopRowRow == null))
                {
                    this.mUITopRowRow = new UITopRowRow(this);
                }
                return this.mUITopRowRow;
            }
        }

        public WinRow UIRow0Row
        {
            get
            {
                if ((this.mUIRow0Row == null))
                {
                    this.mUIRow0Row = new WinRow(this);
                    #region Search Criteria
                    this.mUIRow0Row.SearchProperties[WinRow.PropertyNames.Name] = "Row 0";
                    this.mUIRow0Row.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    #endregion
                }
                return this.mUIRow0Row;
            }
        }

        public WinScrollBar UIHorizontalScrollBarScrollBar
        {
            get
            {
                if ((this.mUIHorizontalScrollBarScrollBar == null))
                {
                    this.mUIHorizontalScrollBarScrollBar = new WinScrollBar(this);
                    #region Search Criteria
                    this.mUIHorizontalScrollBarScrollBar.SearchProperties[WinScrollBar.PropertyNames.Name] = "Horizontal Scroll Bar";
                    #endregion
                }
                return this.mUIHorizontalScrollBarScrollBar;
            }
        }
        #endregion

        #region Fields
        private UITopRowRow mUITopRowRow;

        private WinRow mUIRow0Row;

        private WinScrollBar mUIHorizontalScrollBarScrollBar;
        #endregion

    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UITopRowRow : WinRow
    {

        public UITopRowRow(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Name] = "Top Row";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            #endregion
        }

        #region Properties
        public WinColumnHeader UIItemColumnHeader
        {
            get
            {
                if ((this.mUIItemColumnHeader == null))
                {
                    this.mUIItemColumnHeader = new WinColumnHeader(this);
                }
                return this.mUIItemColumnHeader;
            }
        }

        public WinColumnHeader UIItemColumnHeader1
        {
            get
            {
                if ((this.mUIItemColumnHeader1 == null))
                {
                    this.mUIItemColumnHeader1 = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIItemColumnHeader1.SearchProperties[WinControl.PropertyNames.Instance] = "2";
                    #endregion
                }
                return this.mUIItemColumnHeader1;
            }
        }

        public WinColumnHeader UICampaignNameColumnHeader
        {
            get
            {
                if ((this.mUICampaignNameColumnHeader == null))
                {
                    this.mUICampaignNameColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICampaignNameColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Campaign Name";
                    #endregion
                }
                return this.mUICampaignNameColumnHeader;
            }
        }

        public WinColumnHeader UIAdNameColumnHeader
        {
            get
            {
                if ((this.mUIAdNameColumnHeader == null))
                {
                    this.mUIAdNameColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIAdNameColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Ad Name";
                    #endregion
                }
                return this.mUIAdNameColumnHeader;
            }
        }

        public WinColumnHeader UIAdStatusColumnHeader
        {
            get
            {
                if ((this.mUIAdStatusColumnHeader == null))
                {
                    this.mUIAdStatusColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIAdStatusColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Ad Status";
                    #endregion
                }
                return this.mUIAdStatusColumnHeader;
            }
        }

        public WinColumnHeader UIAdTypeColumnHeader
        {
            get
            {
                if ((this.mUIAdTypeColumnHeader == null))
                {
                    this.mUIAdTypeColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIAdTypeColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Ad Type";
                    #endregion
                }
                return this.mUIAdTypeColumnHeader;
            }
        }

        public WinColumnHeader UIImageColumnHeader
        {
            get
            {
                if ((this.mUIImageColumnHeader == null))
                {
                    this.mUIImageColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIImageColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Image";
                    #endregion
                }
                return this.mUIImageColumnHeader;
            }
        }

        public WinColumnHeader UIBidTypeColumnHeader
        {
            get
            {
                if ((this.mUIBidTypeColumnHeader == null))
                {
                    this.mUIBidTypeColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIBidTypeColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Bid Type";
                    #endregion
                }
                return this.mUIBidTypeColumnHeader;
            }
        }

        public WinColumnHeader UIMaxBidColumnHeader
        {
            get
            {
                if ((this.mUIMaxBidColumnHeader == null))
                {
                    this.mUIMaxBidColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIMaxBidColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Max Bid";
                    #endregion
                }
                return this.mUIMaxBidColumnHeader;
            }
        }

        public WinColumnHeader UISuggestedBidColumnHeader
        {
            get
            {
                if ((this.mUISuggestedBidColumnHeader == null))
                {
                    this.mUISuggestedBidColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUISuggestedBidColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Suggested Bid";
                    #endregion
                }
                return this.mUISuggestedBidColumnHeader;
            }
        }

        public WinColumnHeader UITargetingEstimationColumnHeader
        {
            get
            {
                if ((this.mUITargetingEstimationColumnHeader == null))
                {
                    this.mUITargetingEstimationColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUITargetingEstimationColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Targeting Estimation";
                    #endregion
                }
                return this.mUITargetingEstimationColumnHeader;
            }
        }

        public WinColumnHeader UIDestinationURLColumnHeader
        {
            get
            {
                if ((this.mUIDestinationURLColumnHeader == null))
                {
                    this.mUIDestinationURLColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIDestinationURLColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Destination URL";
                    #endregion
                }
                return this.mUIDestinationURLColumnHeader;
            }
        }

        public WinColumnHeader UITitleColumnHeader
        {
            get
            {
                if ((this.mUITitleColumnHeader == null))
                {
                    this.mUITitleColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUITitleColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Title";
                    #endregion
                }
                return this.mUITitleColumnHeader;
            }
        }

        public WinColumnHeader UIBodyColumnHeader
        {
            get
            {
                if ((this.mUIBodyColumnHeader == null))
                {
                    this.mUIBodyColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIBodyColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Body";
                    #endregion
                }
                return this.mUIBodyColumnHeader;
            }
        }
        #endregion

        #region Fields
        private WinColumnHeader mUIItemColumnHeader;

        private WinColumnHeader mUIItemColumnHeader1;

        private WinColumnHeader mUICampaignNameColumnHeader;

        private WinColumnHeader mUIAdNameColumnHeader;

        private WinColumnHeader mUIAdStatusColumnHeader;

        private WinColumnHeader mUIAdTypeColumnHeader;

        private WinColumnHeader mUIImageColumnHeader;

        private WinColumnHeader mUIBidTypeColumnHeader;

        private WinColumnHeader mUIMaxBidColumnHeader;

        private WinColumnHeader mUISuggestedBidColumnHeader;

        private WinColumnHeader mUITargetingEstimationColumnHeader;

        private WinColumnHeader mUIDestinationURLColumnHeader;

        private WinColumnHeader mUITitleColumnHeader;

        private WinColumnHeader mUIBodyColumnHeader;
        #endregion
    }
}
