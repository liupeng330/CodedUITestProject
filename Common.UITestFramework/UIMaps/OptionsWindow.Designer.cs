﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Common.UITestFramework.UIMaps.OptionsWindowClasses
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
    public partial class OptionsWindow
    {
        
        /// <summary>
        /// EnterProxyInfo - Use 'EnterProxyInfoParams' to pass parameters into this method.
        /// </summary>
        public void EnterProxyInfo()
        {
            #region Variable Declarations
            WinCheckBox uIConnecttoPublishthroCheckBox = this.UIOptionsWindow.UIConnecttoPublishthroWindow.UIConnecttoPublishthroCheckBox;
            WinEdit uITxtAddressEdit = this.UIOptionsWindow.UITxtAddressWindow.UITxtAddressEdit;
            WinEdit uITxtPortEdit = this.UIOptionsWindow.UITxtPortWindow.UITxtPortEdit;
            WinButton uIOKButton = this.UIOptionsWindow.UIOKWindow.UIOKButton;
            #endregion

            // Select 'Connect to Publish through an HTTP Proxy' check box
            uIConnecttoPublishthroCheckBox.Checked = this.EnterProxyInfoParams.UIConnecttoPublishthroCheckBoxChecked;

            // Type '172.16.19.78' in 'txtAddress' text box
            uITxtAddressEdit.Text = this.EnterProxyInfoParams.UITxtAddressEditText;

            // Type '808' in 'txtPort' text box
            uITxtPortEdit.Text = this.EnterProxyInfoParams.UITxtPortEditText;

            // Click '&OK' button
            Mouse.Click(uIOKButton, new Point(50, 6));
        }
        
        #region Properties
        public virtual EnterProxyInfoParams EnterProxyInfoParams
        {
            get
            {
                if ((this.mEnterProxyInfoParams == null))
                {
                    this.mEnterProxyInfoParams = new EnterProxyInfoParams();
                }
                return this.mEnterProxyInfoParams;
            }
        }
        
        public UIOptionsWindow UIOptionsWindow
        {
            get
            {
                if ((this.mUIOptionsWindow == null))
                {
                    this.mUIOptionsWindow = new UIOptionsWindow();
                }
                return this.mUIOptionsWindow;
            }
        }
        #endregion
        
        #region Fields
        private EnterProxyInfoParams mEnterProxyInfoParams;
        
        private UIOptionsWindow mUIOptionsWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'EnterProxyInfo'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class EnterProxyInfoParams
    {
        
        #region Fields
        /// <summary>
        /// Select 'Connect to Publish through an HTTP Proxy' check box
        /// </summary>
        public bool UIConnecttoPublishthroCheckBoxChecked = true;
        
        /// <summary>
        /// Type '172.16.19.78' in 'txtAddress' text box
        /// </summary>
        public string UITxtAddressEditText = "172.16.19.78";
        
        /// <summary>
        /// Type '808' in 'txtPort' text box
        /// </summary>
        public string UITxtPortEditText = "808";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIOptionsWindow : WinWindow
    {
        
        public UIOptionsWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Options";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Options");
            #endregion
        }
        
        #region Properties
        public UIConnecttoPublishthroWindow UIConnecttoPublishthroWindow
        {
            get
            {
                if ((this.mUIConnecttoPublishthroWindow == null))
                {
                    this.mUIConnecttoPublishthroWindow = new UIConnecttoPublishthroWindow(this);
                }
                return this.mUIConnecttoPublishthroWindow;
            }
        }
        
        public UITxtAddressWindow UITxtAddressWindow
        {
            get
            {
                if ((this.mUITxtAddressWindow == null))
                {
                    this.mUITxtAddressWindow = new UITxtAddressWindow(this);
                }
                return this.mUITxtAddressWindow;
            }
        }
        
        public UITxtPortWindow UITxtPortWindow
        {
            get
            {
                if ((this.mUITxtPortWindow == null))
                {
                    this.mUITxtPortWindow = new UITxtPortWindow(this);
                }
                return this.mUITxtPortWindow;
            }
        }
        
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
        
        public UICancelWindow UICancelWindow
        {
            get
            {
                if ((this.mUICancelWindow == null))
                {
                    this.mUICancelWindow = new UICancelWindow(this);
                }
                return this.mUICancelWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIConnecttoPublishthroWindow mUIConnecttoPublishthroWindow;
        
        private UITxtAddressWindow mUITxtAddressWindow;
        
        private UITxtPortWindow mUITxtPortWindow;
        
        private UIOKWindow mUIOKWindow;
        
        private UICancelWindow mUICancelWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIConnecttoPublishthroWindow : WinWindow
    {
        
        public UIConnecttoPublishthroWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "cbxEnableProxy";
            this.WindowTitles.Add("Options");
            #endregion
        }
        
        #region Properties
        public WinCheckBox UIConnecttoPublishthroCheckBox
        {
            get
            {
                if ((this.mUIConnecttoPublishthroCheckBox == null))
                {
                    this.mUIConnecttoPublishthroCheckBox = new WinCheckBox(this);
                    #region Search Criteria
                    this.mUIConnecttoPublishthroCheckBox.SearchProperties[WinCheckBox.PropertyNames.Name] = "Connect to Publish through an HTTP Proxy";
                    this.mUIConnecttoPublishthroCheckBox.WindowTitles.Add("Options");
                    #endregion
                }
                return this.mUIConnecttoPublishthroCheckBox;
            }
        }
        #endregion
        
        #region Fields
        private WinCheckBox mUIConnecttoPublishthroCheckBox;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITxtAddressWindow : WinWindow
    {
        
        public UITxtAddressWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "txtAddress";
            this.WindowTitles.Add("Options");
            #endregion
        }
        
        #region Properties
        public WinEdit UITxtAddressEdit
        {
            get
            {
                if ((this.mUITxtAddressEdit == null))
                {
                    this.mUITxtAddressEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITxtAddressEdit.WindowTitles.Add("Options");
                    #endregion
                }
                return this.mUITxtAddressEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITxtAddressEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UITxtPortWindow : WinWindow
    {
        
        public UITxtPortWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "txtPort";
            this.WindowTitles.Add("Options");
            #endregion
        }
        
        #region Properties
        public WinEdit UITxtPortEdit
        {
            get
            {
                if ((this.mUITxtPortEdit == null))
                {
                    this.mUITxtPortEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITxtPortEdit.WindowTitles.Add("Options");
                    #endregion
                }
                return this.mUITxtPortEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITxtPortEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIOKWindow : WinWindow
    {
        
        public UIOKWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnOK";
            this.WindowTitles.Add("Options");
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
                    this.mUIOKButton.WindowTitles.Add("Options");
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
    public class UICancelWindow : WinWindow
    {
        
        public UICancelWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnCancel";
            this.WindowTitles.Add("Options");
            #endregion
        }
        
        #region Properties
        public WinButton UICancelButton
        {
            get
            {
                if ((this.mUICancelButton == null))
                {
                    this.mUICancelButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICancelButton.SearchProperties[WinButton.PropertyNames.Name] = "Cancel";
                    this.mUICancelButton.WindowTitles.Add("Options");
                    #endregion
                }
                return this.mUICancelButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUICancelButton;
        #endregion
    }
}
