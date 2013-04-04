﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace AdCenter.UITestFramework.UIMaps.KeywordClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public partial class Keyword
    {
        
        /// <summary>
        /// ClickAddKeywordButton
        /// </summary>
        public void ClickAddKeywordButton()
        {
            #region Variable Declarations
            WinTabPage uIKeywords0TabPage = this.UIMicrosoftadlabsUSDadWindow.UIItemTabList.UIKeywords0TabPage;
            WinButton uIAddKeywordButton = this.UIMicrosoftadlabsUSDadWindow.UIRibbonToolBar.UIAddKeywordButton;
            WinButton uIOKButton = this.UIChoosetheAdGroupWindow.UIOKWindow.UIOKButton;
            #endregion

            // Click 'Keywords(0)' tab
            Mouse.Click(uIKeywords0TabPage, new Point(37, 11));

            // Click 'Add Keyword' button
            Mouse.Click(uIAddKeywordButton, new Point(47, 38));

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(37, 10));
        }
        
        /// <summary>
        /// ClickCampaignTab
        /// </summary>
        public void ClickCampaignTab()
        {
            #region Variable Declarations
            WinTabPage uICampaigns1TabPage = this.UIMicrosoftadlabsUSDadWindow.UIItemTabList.UICampaigns1TabPage;
            #endregion

            // Click 'Campaigns(1)' tab
            Mouse.Click(uICampaigns1TabPage, new Point(45, 10));
        }
        
        /// <summary>
        /// ClickDeleteKeywordButton
        /// </summary>
        public void ClickDeleteKeywordButton()
        {
            #region Variable Declarations
            WinTabPage uIKeywordsTabPage = this.UIMicrosoftadlabsUSDadWindow.UIRibbonTabsTabList.UIKeywordsTabPage;
            WinTabPage uIKeywords1TabPage = this.UIMicrosoftadlabsUSDadWindow.UIItemTabList.UIKeywords1TabPage;
            WinButton uIDeleteButton = this.UIMicrosoftadlabsUSDadWindow.UIRibbonToolBar1.UIDeleteButton;
            #endregion

            // Click 'Keywords' tab
            Mouse.Click(uIKeywordsTabPage, new Point(25, 6));

            // Click 'Keywords(1)' tab
            Mouse.Click(uIKeywords1TabPage, new Point(38, 10));

            // Click 'Delete' button
            Mouse.Click(uIDeleteButton, new Point(19, 31));
        }
        
        #region Properties
        public UIMicrosoftadlabsUSDadWindow UIMicrosoftadlabsUSDadWindow
        {
            get
            {
                if ((this.mUIMicrosoftadlabsUSDadWindow == null))
                {
                    this.mUIMicrosoftadlabsUSDadWindow = new UIMicrosoftadlabsUSDadWindow();
                }
                return this.mUIMicrosoftadlabsUSDadWindow;
            }
        }
        
        public UIChoosetheAdGroupWindow UIChoosetheAdGroupWindow
        {
            get
            {
                if ((this.mUIChoosetheAdGroupWindow == null))
                {
                    this.mUIChoosetheAdGroupWindow = new UIChoosetheAdGroupWindow();
                }
                return this.mUIChoosetheAdGroupWindow;
            }
        }
        
        public UIMicrosoftadlabsUSDdgWindow UIMicrosoftadlabsUSDdgWindow
        {
            get
            {
                if ((this.mUIMicrosoftadlabsUSDdgWindow == null))
                {
                    this.mUIMicrosoftadlabsUSDdgWindow = new UIMicrosoftadlabsUSDdgWindow();
                }
                return this.mUIMicrosoftadlabsUSDdgWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIMicrosoftadlabsUSDadWindow mUIMicrosoftadlabsUSDadWindow;
        
        private UIChoosetheAdGroupWindow mUIChoosetheAdGroupWindow;
        
        private UIMicrosoftadlabsUSDdgWindow mUIMicrosoftadlabsUSDdgWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIMicrosoftadlabsUSDadWindow : WinWindow
    {
        
        public UIMicrosoftadlabsUSDadWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Microsoft adlabs(USD) - adSage for Performance";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public UIItemTabList UIItemTabList
        {
            get
            {
                if ((this.mUIItemTabList == null))
                {
                    this.mUIItemTabList = new UIItemTabList(this);
                }
                return this.mUIItemTabList;
            }
        }
        
        public UIRibbonToolBar UIRibbonToolBar
        {
            get
            {
                if ((this.mUIRibbonToolBar == null))
                {
                    this.mUIRibbonToolBar = new UIRibbonToolBar(this);
                }
                return this.mUIRibbonToolBar;
            }
        }
        
        public UIAdCenterOrderItemEdiWindow UIAdCenterOrderItemEdiWindow
        {
            get
            {
                if ((this.mUIAdCenterOrderItemEdiWindow == null))
                {
                    this.mUIAdCenterOrderItemEdiWindow = new UIAdCenterOrderItemEdiWindow(this);
                }
                return this.mUIAdCenterOrderItemEdiWindow;
            }
        }
        
        public UITBNameWindow UITBNameWindow
        {
            get
            {
                if ((this.mUITBNameWindow == null))
                {
                    this.mUITBNameWindow = new UITBNameWindow(this);
                }
                return this.mUITBNameWindow;
            }
        }
        
        public UICBStatusWindow UICBStatusWindow
        {
            get
            {
                if ((this.mUICBStatusWindow == null))
                {
                    this.mUICBStatusWindow = new UICBStatusWindow(this);
                }
                return this.mUICBStatusWindow;
            }
        }
        
        public UITBBroadMatchBidWindow UITBBroadMatchBidWindow
        {
            get
            {
                if ((this.mUITBBroadMatchBidWindow == null))
                {
                    this.mUITBBroadMatchBidWindow = new UITBBroadMatchBidWindow(this);
                }
                return this.mUITBBroadMatchBidWindow;
            }
        }
        
        public UITBExactMatchBidWindow UITBExactMatchBidWindow
        {
            get
            {
                if ((this.mUITBExactMatchBidWindow == null))
                {
                    this.mUITBExactMatchBidWindow = new UITBExactMatchBidWindow(this);
                }
                return this.mUITBExactMatchBidWindow;
            }
        }
        
        public UITBPhraseMatchBidWindow UITBPhraseMatchBidWindow
        {
            get
            {
                if ((this.mUITBPhraseMatchBidWindow == null))
                {
                    this.mUITBPhraseMatchBidWindow = new UITBPhraseMatchBidWindow(this);
                }
                return this.mUITBPhraseMatchBidWindow;
            }
        }
        
        public UIRibbonTabsTabList UIRibbonTabsTabList
        {
            get
            {
                if ((this.mUIRibbonTabsTabList == null))
                {
                    this.mUIRibbonTabsTabList = new UIRibbonTabsTabList(this);
                }
                return this.mUIRibbonTabsTabList;
            }
        }
        
        public UIRibbonToolBar1 UIRibbonToolBar1
        {
            get
            {
                if ((this.mUIRibbonToolBar1 == null))
                {
                    this.mUIRibbonToolBar1 = new UIRibbonToolBar1(this);
                }
                return this.mUIRibbonToolBar1;
            }
        }
        #endregion
        
        #region Fields
        private UIItemTabList mUIItemTabList;
        
        private UIRibbonToolBar mUIRibbonToolBar;
        
        private UIAdCenterOrderItemEdiWindow mUIAdCenterOrderItemEdiWindow;
        
        private UITBNameWindow mUITBNameWindow;
        
        private UICBStatusWindow mUICBStatusWindow;
        
        private UITBBroadMatchBidWindow mUITBBroadMatchBidWindow;
        
        private UITBExactMatchBidWindow mUITBExactMatchBidWindow;
        
        private UITBPhraseMatchBidWindow mUITBPhraseMatchBidWindow;
        
        private UIRibbonTabsTabList mUIRibbonTabsTabList;
        
        private UIRibbonToolBar1 mUIRibbonToolBar1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIItemTabList : WinTabList
    {
        
        public UIItemTabList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinTabPage UIKeywords0TabPage
        {
            get
            {
                if ((this.mUIKeywords0TabPage == null))
                {
                    this.mUIKeywords0TabPage = new WinTabPage(this);
                    #region Search Criteria
                    this.mUIKeywords0TabPage.SearchProperties.Add(new PropertyExpression(WinTabPage.PropertyNames.Name, "Keywords", PropertyExpressionOperator.Contains));
                    this.mUIKeywords0TabPage.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUIKeywords0TabPage;
            }
        }
        
        public WinTabPage UIKeywords1TabPage
        {
            get
            {
                if ((this.mUIKeywords1TabPage == null))
                {
                    this.mUIKeywords1TabPage = new WinTabPage(this);
                    #region Search Criteria
                    this.mUIKeywords1TabPage.SearchProperties[WinTabPage.PropertyNames.Name] = "Keywords(1)";
                    this.mUIKeywords1TabPage.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUIKeywords1TabPage;
            }
        }
        
        public WinTabPage UICampaigns1TabPage
        {
            get
            {
                if ((this.mUICampaigns1TabPage == null))
                {
                    this.mUICampaigns1TabPage = new WinTabPage(this);
                    #region Search Criteria
                    this.mUICampaigns1TabPage.SearchProperties[WinTabPage.PropertyNames.Name] = "Campaigns(1)";
                    this.mUICampaigns1TabPage.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUICampaigns1TabPage;
            }
        }
        #endregion
        
        #region Fields
        private WinTabPage mUIKeywords0TabPage;
        
        private WinTabPage mUIKeywords1TabPage;
        
        private WinTabPage mUICampaigns1TabPage;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRibbonToolBar : WinToolBar
    {
        
        public UIRibbonToolBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinToolBar.PropertyNames.Name] = "New";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinButton UIAddKeywordButton
        {
            get
            {
                if ((this.mUIAddKeywordButton == null))
                {
                    this.mUIAddKeywordButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIAddKeywordButton.SearchProperties[WinButton.PropertyNames.Name] = "Add Keyword";
                    this.mUIAddKeywordButton.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUIAddKeywordButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIAddKeywordButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAdCenterOrderItemEdiWindow : WinWindow
    {
        
        public UIAdCenterOrderItemEdiWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "AdCenterOrderItemEditor";
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinClient UIAdCenterOrderItemEdiClient
        {
            get
            {
                if ((this.mUIAdCenterOrderItemEdiClient == null))
                {
                    this.mUIAdCenterOrderItemEdiClient = new WinClient(this);
                    #region Search Criteria
                    this.mUIAdCenterOrderItemEdiClient.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
                    #endregion
                }
                return this.mUIAdCenterOrderItemEdiClient;
            }
        }
        
        public UIButtonEditDestinatioEdit UIButtonEditDestinatioEdit
        {
            get
            {
                if ((this.mUIButtonEditDestinatioEdit == null))
                {
                    this.mUIButtonEditDestinatioEdit = new UIButtonEditDestinatioEdit(this);
                }
                return this.mUIButtonEditDestinatioEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIAdCenterOrderItemEdiClient;
        
        private UIButtonEditDestinatioEdit mUIButtonEditDestinatioEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIButtonEditDestinatioEdit : WinEdit
    {
        
        public UIButtonEditDestinatioEdit(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinEdit.PropertyNames.Instance] = "6";
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinEdit UIButtonEditDestinatioEdit1
        {
            get
            {
                if ((this.mUIButtonEditDestinatioEdit1 == null))
                {
                    this.mUIButtonEditDestinatioEdit1 = new WinEdit(this);
                    #region Search Criteria
                    this.mUIButtonEditDestinatioEdit1.SearchProperties[WinEdit.PropertyNames.Instance] = "6";
                    this.mUIButtonEditDestinatioEdit1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIButtonEditDestinatioEdit1.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
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
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITBNameWindow : WinWindow
    {
        
        public UITBNameWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "TBName";
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinEdit UITBNameEdit
        {
            get
            {
                if ((this.mUITBNameEdit == null))
                {
                    this.mUITBNameEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITBNameEdit.SearchProperties[WinEdit.PropertyNames.Name] = "TBName";
                    this.mUITBNameEdit.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
                    #endregion
                }
                return this.mUITBNameEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITBNameEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UICBStatusWindow : WinWindow
    {
        
        public UICBStatusWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "CBStatus";
            this.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinComboBox UICBStatusComboBox
        {
            get
            {
                if ((this.mUICBStatusComboBox == null))
                {
                    this.mUICBStatusComboBox = new WinComboBox(this);
                    #region Search Criteria
                    this.mUICBStatusComboBox.SearchProperties[WinComboBox.PropertyNames.Name] = "CBStatus";
                    this.mUICBStatusComboBox.WindowTitles.Add("Microsoft adlabs(USD) - TestCompaign - TestGroup - adSage for Performance");
                    #endregion
                }
                return this.mUICBStatusComboBox;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mUICBStatusComboBox;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITBBroadMatchBidWindow : WinWindow
    {
        
        public UITBBroadMatchBidWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "TBBroadMatchBid";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinEdit UITBBroadMatchBidEdit
        {
            get
            {
                if ((this.mUITBBroadMatchBidEdit == null))
                {
                    this.mUITBBroadMatchBidEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITBBroadMatchBidEdit.SearchProperties[WinEdit.PropertyNames.Name] = "TBBroadMatchBid";
                    this.mUITBBroadMatchBidEdit.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUITBBroadMatchBidEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITBBroadMatchBidEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITBExactMatchBidWindow : WinWindow
    {
        
        public UITBExactMatchBidWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "TBExactMatchBid";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinEdit UITBExactMatchBidEdit
        {
            get
            {
                if ((this.mUITBExactMatchBidEdit == null))
                {
                    this.mUITBExactMatchBidEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITBExactMatchBidEdit.SearchProperties[WinEdit.PropertyNames.Name] = "TBExactMatchBid";
                    this.mUITBExactMatchBidEdit.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUITBExactMatchBidEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITBExactMatchBidEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITBPhraseMatchBidWindow : WinWindow
    {
        
        public UITBPhraseMatchBidWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "TBPhraseMatchBid";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinEdit UITBPhraseMatchBidEdit
        {
            get
            {
                if ((this.mUITBPhraseMatchBidEdit == null))
                {
                    this.mUITBPhraseMatchBidEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITBPhraseMatchBidEdit.SearchProperties[WinEdit.PropertyNames.Name] = "TBPhraseMatchBid";
                    this.mUITBPhraseMatchBidEdit.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUITBPhraseMatchBidEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITBPhraseMatchBidEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRibbonTabsTabList : WinTabList
    {
        
        public UIRibbonTabsTabList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTabList.PropertyNames.Name] = "Ribbon Tabs";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinTabPage UIKeywordsTabPage
        {
            get
            {
                if ((this.mUIKeywordsTabPage == null))
                {
                    this.mUIKeywordsTabPage = new WinTabPage(this);
                    #region Search Criteria
                    this.mUIKeywordsTabPage.SearchProperties[WinTabPage.PropertyNames.Name] = "Keywords";
                    this.mUIKeywordsTabPage.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUIKeywordsTabPage;
            }
        }
        #endregion
        
        #region Fields
        private WinTabPage mUIKeywordsTabPage;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRibbonToolBar1 : WinToolBar
    {
        
        public UIRibbonToolBar1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinToolBar.PropertyNames.Name] = "Delete";
            this.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinButton UIDeleteButton
        {
            get
            {
                if ((this.mUIDeleteButton == null))
                {
                    this.mUIDeleteButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIDeleteButton.SearchProperties[WinButton.PropertyNames.Name] = "Delete";
                    this.mUIDeleteButton.WindowTitles.Add("Microsoft adlabs(USD) - adSage for Performance");
                    #endregion
                }
                return this.mUIDeleteButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIDeleteButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIChoosetheAdGroupWindow : WinWindow
    {
        
        public UIChoosetheAdGroupWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Choose the Ad Group";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Choose the Ad Group");
            #endregion
        }
        
        #region Properties
        public UIOKWindow UIOKWindow
        {
            get
            {
                if ((this.mUIOKWindow == null))
                {
                    this.mUIOKWindow = new UIOKWindow(this);
                }
                return this.mUIOKWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIOKWindow mUIOKWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIOKWindow : WinWindow
    {
        
        public UIOKWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "BTOK";
            this.WindowTitles.Add("Choose the Ad Group");
            #endregion
        }
        
        #region Properties
        public WinButton UIOKButton
        {
            get
            {
                if ((this.mUIOKButton == null))
                {
                    this.mUIOKButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIOKButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mUIOKButton.WindowTitles.Add("Choose the Ad Group");
                    #endregion
                }
                return this.mUIOKButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIOKButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIMicrosoftadlabsUSDdgWindow : WinWindow
    {
        
        public UIMicrosoftadlabsUSDdgWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow(this);
                }
                return this.mUIItemWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIItemWindow mUIItemWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIItemWindow : WinWindow
    {
        
        public UIItemWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.SearchProperties[WinWindow.PropertyNames.Instance] = "17";
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public UIItemTable UIItemTable
        {
            get
            {
                if ((this.mUIItemTable == null))
                {
                    this.mUIItemTable = new UIItemTable(this);
                }
                return this.mUIItemTable;
            }
        }
        
        public UIRow1Row UIRow1Row
        {
            get
            {
                if ((this.mUIRow1Row == null))
                {
                    this.mUIRow1Row = new UIRow1Row(this);
                }
                return this.mUIRow1Row;
            }
        }
        
        public UINewItemRowRow UINewItemRowRow
        {
            get
            {
                if ((this.mUINewItemRowRow == null))
                {
                    this.mUINewItemRowRow = new UINewItemRowRow(this);
                }
                return this.mUINewItemRowRow;
            }
        }
        #endregion
        
        #region Fields
        private UIItemTable mUIItemTable;
        
        private UIRow1Row mUIRow1Row;
        
        private UINewItemRowRow mUINewItemRowRow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIItemTable : WinTable
    {
        
        public UIItemTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public UIDataPanelClient UIDataPanelClient
        {
            get
            {
                if ((this.mUIDataPanelClient == null))
                {
                    this.mUIDataPanelClient = new UIDataPanelClient(this);
                }
                return this.mUIDataPanelClient;
            }
        }
        #endregion
        
        #region Fields
        private UIDataPanelClient mUIDataPanelClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDataPanelClient : WinClient
    {
        
        public UIDataPanelClient(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinControl.PropertyNames.Name] = "Data Panel";
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinRow UINewItemRowRow
        {
            get
            {
                if ((this.mUINewItemRowRow == null))
                {
                    this.mUINewItemRowRow = new WinRow(this);
                    #region Search Criteria
                    this.mUINewItemRowRow.SearchProperties[WinRow.PropertyNames.Name] = "NewItem Row";
                    this.mUINewItemRowRow.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    this.mUINewItemRowRow.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
                    #endregion
                }
                return this.mUINewItemRowRow;
            }
        }
        #endregion
        
        #region Fields
        private WinRow mUINewItemRowRow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRow1Row : WinRow
    {
        
        public UIRow1Row(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Name] = "Row 1";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinCell UIASDgsdCell
        {
            get
            {
                if ((this.mUIASDgsdCell == null))
                {
                    this.mUIASDgsdCell = new WinCell(this);
                    #region Search Criteria
                    this.mUIASDgsdCell.SearchProperties[WinCell.PropertyNames.Value] = "ASDgsd";
                    this.mUIASDgsdCell.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
                    #endregion
                }
                return this.mUIASDgsdCell;
            }
        }
        #endregion
        
        #region Fields
        private WinCell mUIASDgsdCell;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UINewItemRowRow : WinRow
    {
        
        public UINewItemRowRow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Name] = "NewItem Row";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
            #endregion
        }
        
        #region Properties
        public WinCell UICampaignrow214748364Cell
        {
            get
            {
                if ((this.mUICampaignrow214748364Cell == null))
                {
                    this.mUICampaignrow214748364Cell = new WinCell(this);
                    #region Search Criteria
                    this.mUICampaignrow214748364Cell.WindowTitles.Add("Microsoft adlabs(USD) - dgfsdfsdfd - ergergerger - adSage for Performance");
                    #endregion
                }
                return this.mUICampaignrow214748364Cell;
            }
        }
        #endregion
        
        #region Fields
        private WinCell mUICampaignrow214748364Cell;
        #endregion
    }
}
