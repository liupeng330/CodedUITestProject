using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Input;
using AdCenter.UITestFramework.Object;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdCenter.UITestFramework.Object
{
    public class AdGroup
    {
        public string CampaignName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SearchBid { get; set; }
        public string ContentBid { get; set; }
        public Performance Performance { get; set; }

        public static AdGroup Parse(WinRow row)
        {
            if (row.Cells.Count != 18)
            {
                throw new Exception("The count of cell in ad group grid should be equal to 18!");
            }
            AdGroup ad = new AdGroup
            {
                CampaignName = GridViewUtilities.GetValueProperty(row.Cells[2]),
                Name = GridViewUtilities.GetValueProperty(row.Cells[3]),
                Status = GridViewUtilities.GetValueProperty(row.Cells[4]),
                StartDate = GridViewUtilities.GetValueProperty(row.Cells[5]),
                EndDate = GridViewUtilities.GetValueProperty(row.Cells[6]),
                SearchBid = GridViewUtilities.GetValueProperty(row.Cells[7]),
                ContentBid = GridViewUtilities.GetValueProperty(row.Cells[8]),
                Performance = Performance.Parse(row, 9),
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
            if (!string.Equals(this.StartDate, other.StartDate, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.EndDate, other.EndDate, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.SearchBid, other.SearchBid, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.ContentBid, other.ContentBid, StringComparison.OrdinalIgnoreCase))
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
