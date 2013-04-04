using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;


namespace Common.UITestFramework
{
    [CodedUITest]
    public class TestBase
    {
        private Dictionary<Type, object> typedCache = new Dictionary<Type, object>();

        public RandomData RandomData
        {
            get
            {
                if (this.randomData == null)
                {
                    this.randomData = new RandomData();
                }
                return this.randomData;
            }
        }
        private RandomData randomData;

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

        public virtual bool RunInit { get { return runInit; } protected set { runInit = value; } }
        private bool runInit;

        public virtual bool RunClean { get { return runClean; } protected set { runClean = value; } }
        private bool runClean;

        public virtual bool RunVPN { get { return runVPN; } protected set { runVPN = value; } }
        private bool runVPN;

        public virtual bool RunProxy { get { return runProxy; } protected set { runProxy = value; } }
        private bool runProxy;

        private void CleanupDBFiles()
        {
            string applicationBaseDir = Path.GetDirectoryName(ConfigurationManager.AppSettings["ExePath"]);
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "AccountStats.db"));
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "SyncDataDB.db"));
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "rpts.db"));
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "Google"), "*.db");
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "Facebook"), "*.db");
            FileUtilities.DeleteFile(Path.Combine(applicationBaseDir, "Adcenter"), "*.db");
        }

        private void CaptureIamge()
        {
            if (!System.IO.Directory.Exists(testContextInstance.TestResultsDirectory))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(testContextInstance.TestResultsDirectory));
            }
            UITestControl.Desktop.CaptureImage().Save(System.IO.Path.Combine(testContextInstance.TestResultsDirectory, Guid.NewGuid().ToString() + ".png"));
        }

        private void KillProcess()
        {
            do
            {
                Process[] processes = Process.GetProcessesByName("AFP");
                foreach (var process in processes)
                {
                    try
                    {
                        ApplicationUnderTest appUnderTest = ApplicationUnderTest.FromProcess(process);
                        appUnderTest.Close();
                    }
                    catch
                    {
                        process.Kill();
                    }
                }
            }
            while (Process.GetProcessesByName("AFP").Length != 0);
        }

        private void RunCommand(string scriptFile)
        {
            Process reConnectVpn = new Process();
            reConnectVpn.StartInfo = new ProcessStartInfo(scriptFile);
            reConnectVpn.Start();
            reConnectVpn.WaitForExit();
        }

        private bool hasRunCleanup;
        private ApplicationUnderTest adSageConcertLaunchApplication;

        protected TestBase()
        {
            RunInit = true;
            RunClean = true;
            RunVPN = false;
            RunProxy = false;
        }

        public virtual void OnTestInitialize()
        {

        }

        public virtual void OnTestCleanup()
        {

        }

        protected void OrderedTestFirstStep(Action test)
        {
            try
            {
                RunInit = true;
                MyTestInitialize();
                test();
            }
            catch
            {
                RunClean = true;
                MyTestCleanup();
                throw;
            }
        }

        protected void OrderedTestInProgress(Action test)
        {
            try
            {
                test();
            }
            catch
            {
                RunClean = true;
                MyTestCleanup();
                throw;
            }
        }

        protected void OrderedTestLastStep(Action test)
        {
            try
            {
                RunClean = true;
                test();
                MyTestCleanup();
            }
            catch
            {
                RunClean = true;
                MyTestCleanup();
                throw;
            }
        }

        public T Get<T>() where T : new()
        {
            object value;

            if (!typedCache.TryGetValue(typeof(T), out value))
            {
                ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] { });
                Assert.IsNotNull(constructor, "Unable to find a constructor for " + typeof(T).Name + ".  Must have a public default constructor.");
                value = constructor.Invoke(new object[] { });
                typedCache.Add(typeof(T), value);
            }

            return (T)value;
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (RunInit)
            {
                try
                {
                    #region Do common test initialzie
                    //Disconnect vpn first
                    RunCommand(ConfigurationManager.AppSettings["DisconnectVpnPath"]);

                    string exePath = ConfigurationManager.AppSettings["ExePath"];
                    string alternateExePath = ConfigurationManager.AppSettings["AlternateExePath"];

                    //Judge weather we need to run Facebook Beta Api
                    bool needFacebookBetaApi = bool.Parse(ConfigurationManager.AppSettings["NeedTestFacebookBetaApi"]);

                    if (needFacebookBetaApi)
                    {
                        //Change afp.exe.config to beta api if needed
                        string afpConfigFileName = Path.Combine(Path.GetDirectoryName(exePath), "AFP.exe.config");
                        string facebookBetaApiUrl = ConfigurationManager.AppSettings.Get("FacebookBetaApiUrl");
                        string facebookBetaApiUrlInAfpConfigFile = ConfigurationFileUtilities.GetAppConfigurationValue(afpConfigFileName, "ApiURL");

                        if (string.IsNullOrEmpty(facebookBetaApiUrlInAfpConfigFile))
                        {
                            ConfigurationFileUtilities.AddConfigurationItem(afpConfigFileName, Constants.XPathOfFacebookBetaApiUrl, facebookBetaApiUrl);
                        }
                        else
                        {
                            ConfigurationFileUtilities.UpdateConfigurationValue(afpConfigFileName, Constants.XPathOfFacebookBetaApiUrl, facebookBetaApiUrl);
                        }
                    }

                    //Launch App
                    adSageConcertLaunchApplication = ApplicationUnderTest.Launch(exePath, alternateExePath);

                    //Verify if we need to wait update windows pop up
                    if (!File.Exists(Path.Combine(Path.GetDirectoryName(exePath), "packages.data")))
                    {
                        Common.UITestFramework.UIMaps.AgreementWindowClasses.AgreementWindow agreementWindow = new Common.UITestFramework.UIMaps.AgreementWindowClasses.AgreementWindow();
                        agreementWindow.UIAgreementWindow.WaitForControlExist();
                        agreementWindow.ClickAgreeButton();
                        agreementWindow.UIAgreementWindow.WaitForControlNotExist();
                    }

                    //Wait MainWindow Exist
                    Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow mainWindow = new Common.UITestFramework.UIMaps.MainWindowClasses.MainWindow();
                    mainWindow.UIAdSageforPerformanceWindow.WaitForControlExist();

                    //Reconnect VPN
                    if (this.RunVPN)
                    {
                        RunCommand(ConfigurationManager.AppSettings["ReconnectVpnPath"]);
                    }
                    else
                    {
                        RunCommand(ConfigurationManager.AppSettings["DisconnectVpnPath"]);
                    }

                    if (RunProxy)
                    {
                        mainWindow.ClickOptionsButton();

                        Common.UITestFramework.UIMaps.OptionsWindowClasses.OptionsWindow optionsWindow = new UIMaps.OptionsWindowClasses.OptionsWindow();
                        optionsWindow.UIOptionsWindow.WaitForControlExist();

                        optionsWindow.EnterProxyInfoParams.UIConnecttoPublishthroCheckBoxChecked = true;
                        optionsWindow.EnterProxyInfoParams.UITxtAddressEditText = ConfigurationManager.AppSettings["ProxyAddress"];
                        optionsWindow.EnterProxyInfoParams.UITxtPortEditText = ConfigurationManager.AppSettings["ProxyPort"];
                        optionsWindow.EnterProxyInfo();

                        optionsWindow.UIOptionsWindow.WaitForControlNotExist();
                    }
                    #region debug
                    //else
                    //{
                    //    mainWindow.ClickOptionsButton();

                    //    Common.UITestFramework.UIMaps.OptionsWindowClasses.OptionsWindow optionsWindow = new UIMaps.OptionsWindowClasses.OptionsWindow();
                    //    optionsWindow.UIOptionsWindow.WaitForControlExist();
                    //    optionsWindow.TearDownProxyParams.UIConnecttoPublishthroCheckBoxChecked = false;
                    //    optionsWindow.TearDownProxy();

                    //    optionsWindow.UIOptionsWindow.WaitForControlNotExist();
                    //}
                    #endregion

                    //Click UIManageAccountsButton
                    Common.UITestFramework.UIMaps.MainWindowClasses.UIRibbonToolBar2 ribbonToolBar = mainWindow.UIAdSageforPerformanceWindow.UIRibbonToolBar2;
                    WinButton manageAccountsButton = ribbonToolBar.UIManageAccountsButton;
                    Mouse.Click(manageAccountsButton);

                    //Wait AccountManagementCenter Exist
                    Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter accountManagementCenter = new Common.UITestFramework.UIMaps.AccountManagementCenterClasses.AccountManagementCenter();
                    accountManagementCenter.UIAccountManagementCenWindow.WaitForControlExist();
                    #endregion

                    OnTestInitialize();
                }
                catch
                {
                    RunClean = true;
                    MyTestCleanup();
                    throw;
                }
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (!hasRunCleanup)
            {
                hasRunCleanup = true;
                if (RunClean)
                {
                    try
                    {
                        OnTestCleanup();
                    }
                    catch
                    {
                        CaptureIamge();
                        throw;
                    }
                    finally
                    {
                        if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                        {
                            CaptureIamge();
                        }
                        if (this.adSageConcertLaunchApplication != null)
                        {
                            this.adSageConcertLaunchApplication.Close();
                        }
                        else
                        {
                            this.KillProcess();
                        }
                        this.CleanupDBFiles();
                    }
                }
            }
        }
    }
}
