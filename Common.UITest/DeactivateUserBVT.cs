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
using Common.UITestFramework;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Common.UITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class DeactivateUserBVT : TestBase
    {
        private AddUserBVT AddUserBVT;

        public DeactivateUserBVT()
        {
            AddUserBVT = new AddUserBVT();
            this.RunVPN = true;
            this.RunProxy = false;
        }

        public override void OnTestInitialize()
        {
            AddUserBVT.OnTestInitialize();
        }

        private void deactivateUser(SearchEngineType type)
        {
            AddUserBVT.AddUserInit(type);

            //在账户管理窗口的左侧用户列表中，选中一个谷歌用户，点击该用户下任一账户后面的Deactive
            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();
            switch (type)
            {
                case SearchEngineType.Google:
                    accountManagementCenter.DeactivateGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    accountManagementCenter.DeactivateAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    accountManagementCenter.DeactivateFacebookUser();
                    break;
            }

            Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = new Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow();
            questionWindow.UIQuestionWindow.WaitForControlExist();
            questionWindow.ClickDeactivateButton();
            questionWindow.UIQuestionWindow.WaitForControlNotExist();

            switch (type)
            {
                case SearchEngineType.Google:
                    WinText uISynchronizeaccountsfText = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText;
                    uISynchronizeaccountsfText.WaitForControlNotExist();
                    accountManagementCenter.VerifyActivateGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    WinText uISynchronizeaccountsfText1 = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText1;
                    uISynchronizeaccountsfText1.WaitForControlNotExist();
                    accountManagementCenter.VerifyActivateAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    WinText uISynchronizeaccountsfText2 = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText2;
                    uISynchronizeaccountsfText2.WaitForControlNotExist();
                    accountManagementCenter.VerifyActivateFacebookUser();
                    break;
            }
            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow mainWindow = new Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow();
            mainWindow.VerifyNoAccount();
        }

        [TestMethod]
        public void DeactivateGoogleUser_Google()
        {
            deactivateUser(SearchEngineType.Google);
        }

        [TestMethod]
        public void DeactivateAdcenterUser_AdCenter()
        {
            deactivateUser(SearchEngineType.Adcenter);
        }

        [TestMethod]
        public void DeactivateFacebookUser_Facebook()
        {
            deactivateUser(SearchEngineType.Facebook);
        }
    }
}
