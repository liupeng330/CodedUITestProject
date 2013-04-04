using System;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Facebook.UITestFramework.Object
{
    public class Campaign
    {
        public string Name { get; set; }
        public string RunStatus { get; set; }
        public string Budget { get; set; }
        public string BudgetType { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Campaign campaign = obj as Campaign;
            if (campaign == null)
            {
                return false;
            }
            if (!string.Equals(this.Name, campaign.Name, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.RunStatus, campaign.RunStatus, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Budget, campaign.Budget, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.BudgetType, campaign.BudgetType, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            //if (!string.Equals(this.StartTime, campaign.StartTime, StringComparison.OrdinalIgnoreCase))
            //{
            //    return false;
            //}
            //if (!string.Equals(this.StopTime, campaign.StopTime, StringComparison.OrdinalIgnoreCase))
            //{
            //    return false;
            //}
            return true;
        }

        public static Campaign Parse(WinRow oneRowInCampaign)
        {
            string runStatusInCell;
            if (oneRowInCampaign.Cells.Count != 21)
            {
                throw new Exception("The count of cell in campaign grid should be equal to 21!");
            }
            if (GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[3]).Contains("Active"))
            {
                runStatusInCell = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[3]).Substring(0, 6);
            }
            else 
            {
                runStatusInCell = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[3]);
            }
            Campaign campaign = new Campaign
            {
                Name = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[2]),
                RunStatus = runStatusInCell,
                Budget = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[4]),
                BudgetType = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[5]),
                StartTime = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[6]),
                StopTime = GridViewUtilities.GetValueProperty(oneRowInCampaign.Cells[7]),
            };
            return campaign;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public static Campaign NextCampaign(RandomData randomData)
        {
            Facebook.UITestFramework.Object.Campaign addCampaign = new Object.Campaign
            {
                Name = "CampaignForAFPBVT_" + randomData.NextAsciiWord(2, 3),
                RunStatus = "Active",
                Budget = "1.00",
                BudgetType = "Daily",
                StartTime = DateTime.UtcNow.ToString(),
                StopTime = "0",
            };
            return addCampaign;
        }

        public static string[] GetCampaignArray()
        {
            //Initialize four specified Campaigns for displaying Performance data of Facebook 
            string[] campaignArray = new string[4];
            campaignArray[0] = "US_AFP_November_2011";
            campaignArray[1] = "UK_AFP_November_2011";
            campaignArray[2] = "US_adSage agency_ December_2011";
            campaignArray[3] = "Uk_adSage Page Fans_AFP_November_2011";
            return campaignArray;
        }
    }
}
