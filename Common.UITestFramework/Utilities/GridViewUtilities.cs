using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace Common.UITestFramework.Utilities
{
    public static class GridViewUtilities
    {
        public static bool TryGetOneRowByName(this UITestControl containerControl, WinRow headerRow, string name, out WinRow row)
        {
            foreach (UITestControl oneRow in containerControl.GetChildren())
            {
                if (oneRow.Equals(headerRow))
                {
                    continue;
                }
                foreach (UITestControl oneCell in oneRow.GetChildren())
                {
                    string actualName = oneCell.GetProperty(WinCell.PropertyNames.Value) as string;
                    if (string.Equals(actualName, name, StringComparison.OrdinalIgnoreCase))
                    {
                        row = oneRow as WinRow;
                        return true;
                    }
                }
            }
            row = null;
            return false;
        }

        public static bool TryGetSomeRowsByName(this UITestControl containerControl, WinRow headerRow, string name, List<WinRow> rows)
        {
            WinRow row = null;
            foreach (UITestControl oneRow in containerControl.GetChildren())
            {
                if (oneRow.Equals(headerRow))
                {
                    continue;
                }
                foreach (UITestControl oneCell in oneRow.GetChildren())
                {
                    string actualName = oneCell.GetProperty(WinCell.PropertyNames.Value) as string;
                    if (string.Equals(actualName, name, StringComparison.OrdinalIgnoreCase))
                    {
                        row = oneRow as WinRow;
                        rows.Add(row);
                        continue;
                    }
                }
            }
            if (rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }     
        }

        public static int GetRowCount(this UITestControl containerControl, WinRow headerRow)
        {
            int rowCount = 0;
            foreach (UITestControl oneRow in containerControl.GetChildren())
            {
                if (oneRow.Equals(headerRow))
                {
                    continue;
                }
                rowCount++;
            }
            return rowCount;
        }

        public static string GetValueProperty(UITestControl control)
        {
            string value = control.GetProperty(WinCell.PropertyNames.Value) as string;
            return string.Equals(value, Constants.NullInGrid, StringComparison.OrdinalIgnoreCase) ? string.Empty : value;
        }

        public static void WaitCountNotEqualTo(int notExpectedCount, UITestControlCollection collection)
        {
            int retryTimes = int.Parse(ConfigurationManager.AppSettings["DefaultPollingRetryTime"]);
            while ((collection.Count == notExpectedCount) && (retryTimes--) != 0)
            {
                System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["DefaultPollingRetryWaitTime"]));
            }
            if (retryTimes == 0)
            {
                throw new UITestException("Fail to wait the count of collection not equal to " + notExpectedCount);
            }
        }

        public static void GetCampaignUI(string campaignName, Action<string> verifyMethod)
        {
            int retryTimes = 10;
            Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow downloadAccountWindow = new Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow();

            do
            {
                //Select campaign in Download Account Window
                downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlExist();

                System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["DefaultPollingRetryWaitTime"]));
            }
            while (!downloadAccountWindow.SelectCampaign(campaignName) && (retryTimes--) != 0);

            if (retryTimes == 0)
            {
                throw new Exception("Fail to select campaign name '" + campaignName + "' in download account window!!");
            }

            //Click Yes Button on Warning Window
            Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow warningWindow = new Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow();
            bool worningWindowExist = warningWindow.UIWarningWindow.WaitForControlExist();
            if (worningWindowExist)
            {
                warningWindow.ClickYesButton();
                warningWindow.UIWarningWindow.WaitForControlNotExist();
            }
            downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlExist();
            detailedInfoForDownloadWindow.UIDataGridViewTableForJob.WaitForStatusPropertyEqual("Finished");

            //Verify Account Name -> Campaign Name and Information panel
            verifyMethod(campaignName);

            //Click close button
            detailedInfoForDownloadWindow.ClickCloseButton();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlNotExist();
        }

        public static void GetCampaignArray(string[] campaignArrayName, Action verifyMethod)
        {
            int retryTimes = 10;
            Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow downloadAccountWindow = new Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow();

            do
            {
                //Select campaign in Download Account Window
                downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlExist();

                System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["DefaultPollingRetryWaitTime"]));
            }
            while (!downloadAccountWindow.SelectCampaign(campaignArrayName) && (retryTimes--) != 0);

            if (retryTimes == 0)
            {
                StringBuilder campaignNames = new StringBuilder();
                foreach (string campaignName in campaignArrayName)
                {
                    campaignNames.Append(campaignName).Append(" ");
                }
                throw new Exception("Fail to select campaign name '" + campaignNames.ToString() + "' in download account window!!");
            }

            //Click Yes Button on Warning Window
            Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow warningWindow = new Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow();
            bool worningWindowExist = warningWindow.UIWarningWindow.WaitForControlExist();
            if (worningWindowExist)
            {
                warningWindow.ClickYesButton();
                warningWindow.UIWarningWindow.WaitForControlNotExist();
            }

            downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlExist();
            detailedInfoForDownloadWindow.UIDataGridViewTableForJob.WaitingForStatusPropertyEqual("Finished");

            //Verify Account Name and Information panel
            verifyMethod();

            //Click close button
            detailedInfoForDownloadWindow.ClickCloseButton();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlNotExist();
        }


        public static void GetAllCampaignsUI(Action verifyMethod)
        {
            int retryTimes = 10;
            Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow downloadAccountWindow = new Common.UITestFramework.UIMaps.DownloadAccountWindowClasses.DownloadAccountWindow();

            do
            {
                //Select campaign in Download Account Window
                downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlExist();

                System.Threading.Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["DefaultPollingRetryWaitTime"]));
            }
            while (!downloadAccountWindow.SelectAllCampaigns() && (retryTimes--) != 0);

            if (retryTimes == 0)
            {
                throw new Exception("Fail to select all campaigns in download account window!!");
            }

            //Click Yes Button on Warning Window
            Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow warningWindow = new Common.UITestFramework.UIMaps.WarningWindowClasses.WarningWindow();
            bool worningWindowExist = warningWindow.UIWarningWindow.WaitForControlExist();
            if (worningWindowExist)
            {
                warningWindow.ClickYesButton();
                warningWindow.UIWarningWindow.WaitForControlNotExist();
            }
            downloadAccountWindow.UIDownloadAccounthaihaWindow.WaitForControlNotExist();

            Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload detailedInfoForDownloadWindow = new Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses.DetailedInfoForDownload();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlExist();
            detailedInfoForDownloadWindow.UIDataGridViewTableForJob.WaitingForStatusEqual("Finished", detailedInfoForDownloadWindow);

            //Verify Account Name -> Campaign Name and Information panel
            verifyMethod();

            //Click close button
            detailedInfoForDownloadWindow.ClickCloseButton();
            detailedInfoForDownloadWindow.UIDetailedInfoforDownlWindow.WaitForControlNotExist();
        }
    }
}
