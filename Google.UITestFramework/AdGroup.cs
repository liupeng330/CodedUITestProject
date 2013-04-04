using System;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Google.UITestFramework.Object
{
    public class AdGroup
    {
        public string CampaignName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string DefaultMaxCPCBid { get; set; }
        public string MaxCPMBid { get; set; }
        public string DisplaytNetworkMaxCPCBid { get; set; }
        public string CPABid { get; set; }
        public Performance Performance { get; set; }

        public static AdGroup Parse(WinRow row)
        {
            if (row.Cells.Count != 19)
            {
                throw new Exception("The count of cell in ad group grid should be equal to 19!");
            }
            AdGroup ad = new AdGroup
            {
                CampaignName = GridViewUtilities.GetValueProperty(row.Cells[2]),
                Name = GridViewUtilities.GetValueProperty(row.Cells[3]),
                Status = GridViewUtilities.GetValueProperty(row.Cells[4]),
                DefaultMaxCPCBid = GridViewUtilities.GetValueProperty(row.Cells[5]),
                DisplaytNetworkMaxCPCBid = GridViewUtilities.GetValueProperty(row.Cells[6]),
                MaxCPMBid = GridViewUtilities.GetValueProperty(row.Cells[7]),
                CPABid = GridViewUtilities.GetValueProperty(row.Cells[8]),
                Performance = Performance.Parse(row, 9, true),
            };
            return ad;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public static string NextAdName(RandomData randomData)
        {
            return "___" + randomData.NextAsciiWord(5, 7);
        }

        public bool Equals(AdGroup other, bool campareBetweenEditPanelAndGridView)
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
            if (!string.Equals(this.DefaultMaxCPCBid, other.DefaultMaxCPCBid, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.MaxCPMBid, other.MaxCPMBid, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DisplaytNetworkMaxCPCBid, other.DisplaytNetworkMaxCPCBid, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.CPABid, other.CPABid, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!campareBetweenEditPanelAndGridView)
            {
                if (!string.Equals(this.CampaignName, other.CampaignName, StringComparison.OrdinalIgnoreCase))
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
