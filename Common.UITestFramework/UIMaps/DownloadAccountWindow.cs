namespace Common.UITestFramework.UIMaps.DownloadAccountWindowClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Common.UITestFramework.Utilities;


    public partial class DownloadAccountWindow
    {
        public bool TrySelectCampaignByName(string name)
        {
            UIDataGridViewTable uiDataGridViewTable = this.UIDownloadAccounthaihaWindow.UICampaignsDataGridVieWindow.UIDataGridViewTable;
            GridViewUtilities.WaitCountNotEqualTo(0, uiDataGridViewTable.Rows);

            Console.WriteLine("The count of campaign is " + uiDataGridViewTable.Rows.Count);
            
            foreach (WinRow row in uiDataGridViewTable.Rows)
            {
                if (name.Equals(row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Getting cmapaign '" + row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString() + "'!!");
                    Mouse.Click(row.Cells[0], MouseButtons.Left);
                    return true;
                }
                Console.WriteLine("Don't get campaign, the current campaign is '" + row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString() + "'");
            }
            return false;
        }

        /// <summary>
        /// RecordedMethod1 - Use 'RecordedMethod1Params' to pass parameters into this method.
        /// </summary>
        public bool SelectCampaign(string name)
        {
            #region Variable Declarations
            WinRadioButton uIOverwriteselectedcamRadioButton = this.UIDownloadAccounthaihaWindow.UIOverwriteselectedcamWindow.UIOverwriteselectedcamRadioButton;
            WinButton uIOKButton = this.UIDownloadAccounthaihaWindow.UIOKWindow.UIOKButton;
            WinButton uICancelButton = this.UIDownloadAccounthaihaWindow.UICancelWindow.UICancelButton;
            UIDataGridViewTable uiDataGridViewTable = this.UIDownloadAccounthaihaWindow.UICampaignsDataGridVieWindow.UIDataGridViewTable;
            #endregion

            // Select '&Overwrite selected campaigns' radio button
            uIOverwriteselectedcamRadioButton.Selected = true;

            uiDataGridViewTable.WaitForControlExist();
            //uiDataGridViewTable.WaitForControlReady();
            //uiDataGridViewTable.WaitForControlEnabled();

            if (TrySelectCampaignByName(name))
            {
                // Click 'OK' button
                Mouse.Click(uIOKButton, new Point(28, 12));
                return true;
            }
            else
            {
                Console.WriteLine("Can not get campaign '" + name + "'!!");
                // Click 'Cancel' button
                Mouse.Click(uICancelButton, new Point(28, 12));
                this.UIDownloadAccounthaihaWindow.WaitForControlNotExist();
                return false;
            }
        }

        public bool SelectCampaign(string[] campaignArrayName)
        {
            #region Variable Declarations
            WinRadioButton uIOverwriteselectedcamRadioButton = this.UIDownloadAccounthaihaWindow.UIOverwriteselectedcamWindow.UIOverwriteselectedcamRadioButton;
            WinButton uIOKButton = this.UIDownloadAccounthaihaWindow.UIOKWindow.UIOKButton;
            WinButton uICancelButton = this.UIDownloadAccounthaihaWindow.UICancelWindow.UICancelButton;
            UIDataGridViewTable uiDataGridViewTable = this.UIDownloadAccounthaihaWindow.UICampaignsDataGridVieWindow.UIDataGridViewTable;
            #endregion

            // Select '&Overwrite selected campaigns' radio button
            uIOverwriteselectedcamRadioButton.Selected = true;

            uiDataGridViewTable.WaitForControlExist();

            if (TrySelectCampaignByName(campaignArrayName))
            {
                // Click 'OK' button
                Mouse.Click(uIOKButton, new Point(28, 12));
                return true;
            }
            else
            {
                StringBuilder campaignNames = new StringBuilder();
                foreach (string campaignName in campaignArrayName)
                {
                    campaignNames.Append(campaignName).Append(" ");
                }
                Console.WriteLine("Can not get these four campaigns '" + campaignNames.ToString() + "'!!");
                // Click 'Cancel' button
                Mouse.Click(uICancelButton, new Point(28, 12));
                this.UIDownloadAccounthaihaWindow.WaitForControlNotExist();
                return false;
            }
        }

        public bool TrySelectCampaignByName(string[] campaignArrayName)
        {
            int campaignAmount = 0;
            UIDataGridViewTable uiDataGridViewTable = this.UIDownloadAccounthaihaWindow.UICampaignsDataGridVieWindow.UIDataGridViewTable;
            GridViewUtilities.WaitCountNotEqualTo(0, uiDataGridViewTable.Rows);

            Console.WriteLine("The count of campaign is " + uiDataGridViewTable.Rows.Count);

            foreach (string campaignName in campaignArrayName)
            {
                foreach (WinRow row in uiDataGridViewTable.Rows)
                {
                    if (campaignName.Equals(row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Getting cmapaign '" + row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString() + "'!!");
                        Mouse.Click(row.Cells[0], MouseButtons.Left);
                        campaignAmount++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Don't get campaign, the current campaign is '" + row.Cells[1].GetProperty(WinCell.PropertyNames.Value).ToString() + "'");
                    }
                }
            }

            if (campaignAmount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// SelectAllCampaigns
        /// </summary>
        public bool SelectAllCampaigns()
        {
            #region Variable Declarations
            WinRadioButton uIAllcampaignsRadioButton = this.UIDownloadAccounthaihaWindow1.UIAllcampaignsWindow.UIAllcampaignsRadioButton;
            WinButton uIOKButton = this.UIDownloadAccounthaihaWindow1.UIOKWindow.UIOKButton;
            #endregion

            // Click '&All campaigns' radio button
            uIAllcampaignsRadioButton.Selected = true;

            // Click 'OK' button
            Mouse.Click(uIOKButton, new Point(39, 7));
            return true;
        }
    }
}
