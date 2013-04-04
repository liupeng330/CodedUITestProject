using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Common.UITestFramework.UIMaps
{
    public class UIWaitingWindowClass
    {
        public UIWaitingWindow UIWaitingWindow
        {
            get
            {
                if (mUIWaitingWindow == null)
                {
                    mUIWaitingWindow = new UIWaitingWindow();
                }
                return mUIWaitingWindow;
            }
        }
        private UIWaitingWindow mUIWaitingWindow;
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIWaitingWindow : WinWindow
    {

        public UIWaitingWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Waiting...";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Waiting...");
            #endregion
        }

        #region Properties
        public WinTitleBar UIWaitingTitleBar
        {
            get
            {
                if ((this.mUIWaitingTitleBar == null))
                {
                    this.mUIWaitingTitleBar = new WinTitleBar(this);
                    #region Search Criteria
                    this.mUIWaitingTitleBar.WindowTitles.Add("Waiting...");
                    #endregion
                }
                return this.mUIWaitingTitleBar;
            }
        }
        #endregion

        #region Fields
        private WinTitleBar mUIWaitingTitleBar;
        #endregion
    }
}
