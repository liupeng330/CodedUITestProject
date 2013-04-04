using System;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace AdCenter.UITestFramework.Object
{
    public class Campaign
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string BudgetType { get; set; }
        public string DailyBudget { get; set; }
        public string MonthlyBudget { get; set; }
        public Performance Performance { get; set; }

        public static Campaign Parse(WinRow row)
        {
            if (row.Cells.Count != 16)
            {
                throw new Exception("The count of cell in campaign grid should be equal to 16!");
            }

            Campaign campaign = new Campaign
            {
                Name = GridViewUtilities.GetValueProperty(row.Cells[2]),
                Status = GridViewUtilities.GetValueProperty(row.Cells[3]),
                BudgetType = GridViewUtilities.GetValueProperty(row.Cells[4]),
                DailyBudget = GridViewUtilities.GetValueProperty(row.Cells[5]),
                MonthlyBudget = GridViewUtilities.GetValueProperty(row.Cells[6]),
                Performance = Performance.Parse(row, 7),
            };
            return campaign;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public static string NextCampaignName(RandomData randomData)
        {
            return "___" + randomData.NextAsciiWord(5, 7);
        }

        public bool Equals(Campaign other, bool campareBetweenEditPanelAndGridView)
        {
            if (other == null)
            {
                return false;
            }
            if (!string.Equals(this.Name, other.Name, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Status, other.Status, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.BudgetType, other.BudgetType, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DailyBudget, other.DailyBudget, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.MonthlyBudget, other.MonthlyBudget, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!campareBetweenEditPanelAndGridView)
            {
                if (!Performance.Equals(other.Performance))
                {
                    return false;
                }
            }
            return true;
        }
    }
}