using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITest.Common;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;


namespace AFPTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void GenerateUIMap()
        {
            string baseUIMapFileName = @"C:\Users\yingzhu.SAGESGROUP\Documents\Visual Studio 2010\Projects\TestSln\CalenderDemo";
            string uimapFileName = System.IO.Path.Combine(baseUIMapFileName, "DownloadPerformanceWindow.uitest");

            UITest uiTest = UITest.Create(uimapFileName);
            UIMap newMap = new UIMap();
            newMap.Id = "UIMap";
            uiTest.Maps.Add(newMap);
            UITestControl root;
            string launchAppFileName = System.Configuration.ConfigurationManager.AppSettings["LaunchAppFileName"];
            if (!string.IsNullOrEmpty(launchAppFileName))
            {
                root = ApplicationUnderTest.Launch(System.Configuration.ConfigurationManager.AppSettings["LaunchAppFileName"]);
            }
            else
            {
                root = new UITestControl();
                root.TechnologyName = "MSAA";
                root.SearchProperties[WinWindow.PropertyNames.Name] = "Download Performance";
                root.SearchProperties[WinWindow.PropertyNames.ControlName] = "DownloadPerformanceDialog";
                root.WindowTitles.Add("Download Performance");
            }
            GetAllChildren(root, uiTest.Maps[0]);
            uiTest.Save(uimapFileName);
        }


        private void GetAllChildren(UITestControl root, UIMap uiMap)
        {
            foreach (UITestControl child in root.GetChildren())
            {
                uiMap.AddUIObject(child.GetProperty(UITestControl.PropertyNames.UITechnologyElement) as IUITechnologyElement);
                GetAllChildren(child, uiMap);
            }
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
