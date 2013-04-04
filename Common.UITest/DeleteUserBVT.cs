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
using Common.UITest;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Common.UITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class DeleteUserBVT : TestBase
    {
        private AddUserBVT AddUserBVT;

        public DeleteUserBVT()
        {
            AddUserBVT = new AddUserBVT();
            this.RunVPN = true;
            this.RunProxy = false;
        }

        public override void OnTestInitialize()
        {
            AddUserBVT.OnTestInitialize();
        }

        private void deleteUser(SearchEngineType type)
        {
            AddUserBVT.AddUserInit(type);

            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();
            accountManagementCenter.DeleteUser();

            Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = new Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow();
            questionWindow.UIQuestionWindow.WaitForControlExist();
            questionWindow.ClickDeactivateButton();
            questionWindow.UIQuestionWindow.WaitForControlNotExist();

            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow mainWindow = new Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow();
            mainWindow.VerifyNoAccount();
        }

        [TestMethod]
        public void DeleteGoogleUser_Google()
        {
            deleteUser(SearchEngineType.Google);
        }

        [TestMethod]
        public void DeleteAdcenterUser_AdCenter()
        {
            deleteUser(SearchEngineType.Adcenter);
        }

        [TestMethod]
        public void DeleteFacebookUser_Facebook()
        {
            deleteUser(SearchEngineType.Facebook);
        }
    }
}
