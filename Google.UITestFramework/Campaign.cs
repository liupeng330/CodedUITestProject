using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Google.UITestFramework.Object
{
    public class Campaign
    {
        public string Name { get; set; }
        public string ServingStatus { get; set; }
        public string Status { get; set; }
        public string DailyBudget { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SearchNetwork { get; set; }
        public string DisplayNetwork { get; set; }
        public string BudgetOptimizer { get; set; }
        public Performance Performance { get; set; }

        public static Campaign Parse(WinRow row)
        {
            if (row.Cells.Count != 21)
            {
                throw new Exception("The count of cell in campaign grid should be equal to 21!");
            }

            Campaign campaign = new Campaign
            {
                Name = GridViewUtilities.GetValueProperty(row.Cells[2]),
                ServingStatus = GridViewUtilities.GetValueProperty(row.Cells[3]),
                Status = GridViewUtilities.GetValueProperty(row.Cells[4]),
                DailyBudget = GridViewUtilities.GetValueProperty(row.Cells[5]),
                StartDate = GridViewUtilities.GetValueProperty(row.Cells[6]),
                EndDate = GridViewUtilities.GetValueProperty(row.Cells[7]),
                SearchNetwork = GridViewUtilities.GetValueProperty(row.Cells[8]),
                DisplayNetwork = GridViewUtilities.GetValueProperty(row.Cells[9]),
                BudgetOptimizer = GridViewUtilities.GetValueProperty(row.Cells[10]),
                Performance = Performance.Parse(row, 11, true),
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
            if (other== null)
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
            if (!string.Equals(this.DailyBudget, other.DailyBudget, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.StartDate, other.StartDate, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.EndDate, other.EndDate, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.SearchNetwork, other.SearchNetwork, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DisplayNetwork, other.DisplayNetwork, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!campareBetweenEditPanelAndGridView)
            {
                if (!string.Equals(this.ServingStatus, other.ServingStatus, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.BudgetOptimizer, other.BudgetOptimizer, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!Performance.Equals(other.Performance))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
