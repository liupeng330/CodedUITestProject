﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Common.UITestFramework.UIMaps.WarningWindowClasses
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
    
    
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public partial class WarningWindow
    {
        
        /// <summary>
        /// ClickYesButton
        /// </summary>
        public void ClickYesButton()
        {
            #region Variable Declarations
            WinButton uIYesButton = this.UIWarningWindow.UIYesWindow.UIYesButton;
            #endregion

            // Click '&Yes' button
            Mouse.Click(uIYesButton, new Point(28, 8));
        }
        
        #region Properties
        public UIWarningWindow UIWarningWindow
        {
            get
            {
                if ((this.mUIWarningWindow == null))
                {
                    this.mUIWarningWindow = new UIWarningWindow();
                }
                return this.mUIWarningWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIWarningWindow mUIWarningWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIWarningWindow : WinWindow
    {
        
        public UIWarningWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Warning";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Warning");
            #endregion
        }
        
        #region Properties
        public UIAlllocalchangestotheWindow UIAlllocalchangestotheWindow
        {
            get
            {
                if ((this.mUIAlllocalchangestotheWindow == null))
                {
                    this.mUIAlllocalchangestotheWindow = new UIAlllocalchangestotheWindow(this);
                }
                return this.mUIAlllocalchangestotheWindow;
            }
        }
        
        public UINOWindow UINOWindow
        {
            get
            {
                if ((this.mUINOWindow == null))
                {
                    this.mUINOWindow = new UINOWindow(this);
                }
                return this.mUINOWindow;
            }
        }
        
        public UIYesWindow UIYesWindow
        {
            get
            {
                if ((this.mUIYesWindow == null))
                {
                    this.mUIYesWindow = new UIYesWindow(this);
                }
                return this.mUIYesWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIAlllocalchangestotheWindow mUIAlllocalchangestotheWindow;
        
        private UINOWindow mUINOWindow;
        
        private UIYesWindow mUIYesWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIAlllocalchangestotheWindow : WinWindow
    {
        
        public UIAlllocalchangestotheWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "lblText";
            this.WindowTitles.Add("Warning");
            #endregion
        }
        
        #region Properties
        public WinText UIAlllocalchangestotheText
        {
            get
            {
                if ((this.mUIAlllocalchangestotheText == null))
                {
                    this.mUIAlllocalchangestotheText = new WinText(this);
                    #region Search Criteria
                    this.mUIAlllocalchangestotheText.SearchProperties[WinText.PropertyNames.Name] = "All local changes to the selected campaigns will be lost. Do you want to continue" +
                        "?";
                    this.mUIAlllocalchangestotheText.WindowTitles.Add("Warning");
                    #endregion
                }
                return this.mUIAlllocalchangestotheText;
            }
        }
        #endregion
        
        #region Fields
        private WinText mUIAlllocalchangestotheText;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UINOWindow : WinWindow
    {
        
        public UINOWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "button2";
            this.WindowTitles.Add("Warning");
            #endregion
        }
        
        #region Properties
        public WinButton UINOButton
        {
            get
            {
                if ((this.mUINOButton == null))
                {
                    this.mUINOButton = new WinButton(this);
                    #region Search Criteria
                    this.mUINOButton.SearchProperties[WinButton.PropertyNames.Name] = "No";
                    this.mUINOButton.WindowTitles.Add("Warning");
                    #endregion
                }
                return this.mUINOButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUINOButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIYesWindow : WinWindow
    {
        
        public UIYesWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "button1";
            this.WindowTitles.Add("Warning");
            #endregion
        }
        
        #region Properties
        public WinButton UIYesButton
        {
            get
            {
                if ((this.mUIYesButton == null))
                {
                    this.mUIYesButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIYesButton.SearchProperties[WinButton.PropertyNames.Name] = "Yes";
                    this.mUIYesButton.WindowTitles.Add("Warning");
                    #endregion
                }
                return this.mUIYesButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIYesButton;
        #endregion
    }
}
