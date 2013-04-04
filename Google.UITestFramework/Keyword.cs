using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace Google.UITestFramework.Object
{
    public class Keyword
    {
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public string AdGroupStatus { get; set; }
        public string Keywords{ get; set; }
        public string MatchType { get; set; }
        public string Status { get; set; }
        public string ApprovalStatus { get; set; }
        public string MaxCPC { get; set; }
        public string FirstPageBidEst { get; set; }
        public string QualityScore { get; set; }
        public string DestinationUrl { get; set; }
        public Performance Performance { get; set; }

        public static Keyword Parse(WinRow row)
        {
            if (row.Cells.Count != 22)
            {
                throw new Exception("The count of cell in keyword grid should be equal to 22!");
            }
            int index = 2;
            Keyword keyword = new Keyword();
            keyword.CampaignName = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.AdGroupName = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.AdGroupStatus = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Keywords = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.MatchType = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Status = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.ApprovalStatus = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.MaxCPC = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.FirstPageBidEst = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.QualityScore = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.DestinationUrl = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Performance = Performance.Parse(row, index, false);
            return keyword;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public bool Equals(Keyword other, bool campareBetweenEditPanelAndGridView)
        {
            if (other == null)
            {
                return false;
            }
            if (!string.Equals(this.Keywords, other.Keywords, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.MatchType, other.MatchType, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Status, other.Status, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DestinationUrl, other.DestinationUrl, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!campareBetweenEditPanelAndGridView)
            {
                if (!string.Equals(this.MaxCPC, other.MaxCPC, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.FirstPageBidEst, other.FirstPageBidEst, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.QualityScore, other.QualityScore, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.CampaignName, other.CampaignName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.AdGroupName, other.AdGroupName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.AdGroupStatus, other.AdGroupStatus, StringComparison.OrdinalIgnoreCase))
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

        public static Keyword NextKeyword(RandomData random)
        {
            Keyword keyword = new Keyword
            {
                Keywords = random.NextEnglishWordLowercase(10),
                DestinationUrl = "http://www." + random.NextEnglishWordLowercase(10) + ".com",
            };
            return keyword;
        }
    }
}