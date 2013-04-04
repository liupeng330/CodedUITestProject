using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Common.UITestFramework.Utilities
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest2
    {
        [TestMethod]
        public void GenerateUIMap()
        {
            string baseUIMapFileName = @"E:\AFPSourceCode\trunk\src_test\AFPTest\TestFramework\UIMaps\";
            string uimapFileName = System.IO.Path.Combine(baseUIMapFileName, "UIMap1.uitest");
            Microsoft.VisualStudio.TestTools.UITest.Common.UITest uiTest = Microsoft.VisualStudio.TestTools.UITest.Common.UITest.Create(uimapFileName);
            UIMap newMap = new UIMap();
            newMap.Id = "UIMap";
            uiTest.Maps.Add(newMap);

            UITestControl root;
            root = new UITestControl();
            root.TechnologyName = "MSAA";
            root.SearchProperties[WinWindow.PropertyNames.Name] = "chenkzhu@meshtop.com #348004880(USD) - Campaign - adSage for Performance";
            root.SearchProperties[WinWindow.PropertyNames.ControlName] = "RibbonForm";

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
