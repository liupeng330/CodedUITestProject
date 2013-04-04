using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Common.UITestFramework;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Configuration;

namespace Common.UITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class AddUserBVT : TestBase
    {
        public AddUserBVT()
        {
            this.RunVPN = true;
            this.RunProxy = false;
        }

        public override void OnTestInitialize()
        {
            base.OnTestInitialize();

            //Click Add New User button
            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();
            WinButton addNewUserButton = accountManagementCenter.UIAccountManagementCenWindow.UISageToolStrip1ToolBar.UIAddNewUserButton;
            Mouse.Click(addNewUserButton);

            //Wait Add User Window Exist
            Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers addUser = new Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers();
            addUser.UIAddUserWindow.WaitForControlExist();
        }

        public void AddUserInit(SearchEngineType type)
        {
            Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers addUser = new UITestFramework.UIMaps.AddUsersClasses.AddUsers();
            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();

            switch (type)
            {
                case SearchEngineType.Google:
                    addUser.AddGoogleUser();
                    addUser.UIAddUserWindow.WaitForControlNotExist();
                    accountManagementCenter.VerifyActiveGoogleAccount();
                    accountManagementCenter.ActivateGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    addUser.AddAdcenterUser();
                    addUser.UIAddUserWindow.WaitForControlNotExist();
                    accountManagementCenter.VerifyActiveAdcenterAccount();
                    accountManagementCenter.ActivateAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    //Click Add New User
                    addUser.AddFacebookUser();

                    //Wait Facebook Login Windows Exist
                    Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin facbookLogin = new Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin();
                    facbookLogin.UIFacebookLoginWindow.WaitForControlExist();

                    //facbookLogin.Login();
                    Common.UITestFramework.UIMaps.LoginWindow loginWindow = new UITestFramework.UIMaps.LoginWindow();
                    loginWindow.Login(
                        ConfigurationManager.AppSettings["Email"],
                        ConfigurationManager.AppSettings["Password"]);

                    addUser.UIAddUserWindow.WaitForControlNotExist();
                    accountManagementCenter.VerifyActiveFacebookAccount();
                    accountManagementCenter.ActivateFacebookUser();
                    break;
            }
        }
        
        private void AddUser(SearchEngineType type)
        {
            //在账户管理窗口中点击 Add New User，弹出添加用户窗口，online Media 选择 Google，输入用户名、密码、token ，点击OK。
            Common.UITestFramework.UIMaps.AddUsersClasses.AddUsers addUser = new UITestFramework.UIMaps.AddUsersClasses.AddUsers();
            switch (type)
            {
                case SearchEngineType.Google:
                    addUser.AddGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    addUser.AddAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    ////Click Add New User
                    addUser.AddFacebookUser();

                    ////Wait Facebook Login Windows Exist
                    Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin facbookLogin = new Common.UITestFramework.UIMaps.FacebookLoginClasses.FacebookLogin();
                    facbookLogin.UIFacebookLoginWindow.WaitForControlExist();

                    ////facbookLogin.Login();
                    Common.UITestFramework.UIMaps.LoginWindow loginWindow = new UITestFramework.UIMaps.LoginWindow();
                    loginWindow.Login(
                        ConfigurationManager.AppSettings["Email"],
                        ConfigurationManager.AppSettings["Password"]);

                    break;
            }
            addUser.UIAddUserWindow.WaitForControlNotExist();

            //添加用户成功，可以看到新添加的用户出现在左侧的用户列表中
            Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();
            switch (type)
            {
                case SearchEngineType.Google:
                    accountManagementCenter.VerifyActiveGoogleAccount();
                    break;
                case SearchEngineType.Adcenter:
                    accountManagementCenter.VerifyActiveAdcenterAccount();
                    break;
                case SearchEngineType.Facebook:
                    accountManagementCenter.VerifyActiveFacebookAccount();
                    break;
            }

            //关闭账户管理窗口
            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            //在account view中看不到新添加用户下的账户
            Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow mainWindow = new Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow();
            mainWindow.VerifyNoAccount();

            Common.UITestFramework.UIMaps.MainWindowClasses.UIRibbonToolBar2 ribbonToolBar = mainWindow.UIAdSageforPerformanceWindow.UIRibbonToolBar2;

            //再次打开账户管理窗口，在左侧用户列表中，选中刚刚添加的用户，在其下属账户后点击 Active按钮
            WinButton manageAccountsButton = ribbonToolBar.UIManageAccountsButton;
            Mouse.Click(manageAccountsButton);

            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlExist();
            switch (type)
            {
                case SearchEngineType.Google:
                    WinText uISynchronizeaccountsfText = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText;
                    uISynchronizeaccountsfText.WaitForControlNotExist();
                    accountManagementCenter.ActivateGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    WinText uISynchronizeaccountsfText1 = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText1;
                    uISynchronizeaccountsfText1.WaitForControlNotExist();
                    accountManagementCenter.ActivateAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    WinText uISynchronizeaccountsfText2 = accountManagementCenter.UIAccountManagementCenWindow.UILabel1Window.UISynchronizeaccountsfText2;
                    uISynchronizeaccountsfText2.WaitForControlNotExist();
                    accountManagementCenter.ActivateFacebookUser();
                    break;
            }
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlReady();

            //账户激活成功，账户后面的active按钮变为deactive按钮
            switch (type)
            {
                case SearchEngineType.Google:
                    accountManagementCenter.VerifyDeactivateGoogleUser();
                    break;
                case SearchEngineType.Adcenter:
                    accountManagementCenter.VerifyDeactivateAdcenterUser();
                    break;
                case SearchEngineType.Facebook:
                    break;
            }

            //关闭账户管理窗口，新添加用户下的账户出现在account view中
            Thread.Sleep(5 * 1000);
            accountManagementCenter.ClickCloseWindowButton();
            accountManagementCenter.UIAccountManagementCenWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = new Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow();
            questionWindow.UIQuestionWindow.WaitForControlExist();
            questionWindow.ClickNoButton();
            questionWindow.UIQuestionWindow.WaitForControlNotExist();

            //被激活的账户出现在account view中
            mainWindow.ExpandAccountsView();
            switch (type)
            {
                case SearchEngineType.Google:
                    mainWindow.VerifyGoogleAccountTree();
                    break;
                case SearchEngineType.Adcenter:
                    mainWindow.VerifyAdcenterAccountTree();
                    break;
                case SearchEngineType.Facebook:
                    break;
            }
        }

        [TestMethod]
        public void AddGoogleUser_Google()
        {
            AddUser(SearchEngineType.Google);
        }

        [TestMethod]
        public void AddAdcenterUser_AdCenter()
        {
            AddUser(SearchEngineType.Adcenter);
        }

        [TestMethod]
        public void AddFacebookUser_Facebook()
        {
            AddUser(SearchEngineType.Facebook);
        }
    }
}
