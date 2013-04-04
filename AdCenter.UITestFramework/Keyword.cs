using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace AdCenter.UITestFramework.Object
{
    public class Keyword
    {
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public string Keywords { get; set; }
        public string BroadMatchBid { get; set; }
        public string ExactMatchBid { get; set; }
        public string PhraseMatchBid { get; set; }
        public string ContentBid { get; set; }
        public string KeywordStatus { get; set; }
        public string DesURL { get; set; }
        public string Placeholder2 { get; set; }
        public string Placeholder3 { get; set; }
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
            keyword.Keywords = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.BroadMatchBid = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.ExactMatchBid = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.PhraseMatchBid = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.ContentBid = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.KeywordStatus = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.DesURL = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Placeholder2 = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Placeholder3 = GridViewUtilities.GetValueProperty(row.Cells[index++]);
            keyword.Performance = Performance.Parse(row, index);
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
            if (!string.Equals(this.KeywordStatus, other.KeywordStatus, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DesURL, other.DesURL, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!campareBetweenEditPanelAndGridView)
            {
                if (!string.Equals(this.BroadMatchBid, other.BroadMatchBid, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.ExactMatchBid, other.ExactMatchBid, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.PhraseMatchBid, other.PhraseMatchBid, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.ContentBid, other.ContentBid, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.Placeholder2, other.Placeholder2, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                if (!string.Equals(this.Placeholder3, other.Placeholder3, StringComparison.OrdinalIgnoreCase))
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
                DesURL = "http://www." + random.NextEnglishWordLowercase(10) + ".com",
            };
            return keyword;
        }
    }
}
