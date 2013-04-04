using System;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Google.UITestFramework.Object
{
    public class TextAdvertisement
    {
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public string AdGroupStatus { get; set; }
        public string Headline { get; set; }
        public string DisplayUrl { get; set; }
        public string DestinationUrl { get; set; }
        public string Status { get; set; }
        public string ApprovalStatus { get; set; }
        public string DescriptionLine1 { get; set; }
        public string DescriptionLine2 { get; set; }
        public Performance Performance { get; set; }

        public static TextAdvertisement Parse(WinRow row)
        {
            if (row.Cells.Count != 21)
            {
                throw new Exception("The count of cell in text ad grid should be equal to 20!");
            }
            TextAdvertisement textAd = new TextAdvertisement
            {
                CampaignName = GridViewUtilities.GetValueProperty(row.Cells[2]),
                AdGroupName = GridViewUtilities.GetValueProperty(row.Cells[3]),
                AdGroupStatus = GridViewUtilities.GetValueProperty(row.Cells[4]),
                Headline = GridViewUtilities.GetValueProperty(row.Cells[5]),
                DisplayUrl = GridViewUtilities.GetValueProperty(row.Cells[6]),
                DestinationUrl = GridViewUtilities.GetValueProperty(row.Cells[7]),
                Status = GridViewUtilities.GetValueProperty(row.Cells[8]),
                ApprovalStatus=GridViewUtilities.GetValueProperty(row.Cells[9]),
                DescriptionLine1 = GridViewUtilities.GetValueProperty(row.Cells[10]),
                DescriptionLine2 = GridViewUtilities.GetValueProperty(row.Cells[11]),
                Performance = Performance.Parse(row, 12, false),
            };
            return textAd;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public bool Equals(TextAdvertisement other, bool campareBetweenEditPanelAndGridView)
        {
            if (other == null)
            {
                return false;
            }
            if (!string.Equals(this.Headline, other.Headline, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DisplayUrl, other.DisplayUrl, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DestinationUrl, other.DestinationUrl, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Status, other.Status, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DescriptionLine1, other.DescriptionLine1, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.DescriptionLine2, other.DescriptionLine2, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!campareBetweenEditPanelAndGridView)
            {
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
                if (!string.Equals(this.ApprovalStatus, other.ApprovalStatus, StringComparison.OrdinalIgnoreCase))
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

        public static TextAdvertisement NextTextAd(RandomData random)
        {
            TextAdvertisement textAd = new TextAdvertisement
            {
                Headline = random.NextEnglishWordLowercase(25),
                DescriptionLine1 = random.NextEnglishWordLowercase(35),
                DescriptionLine2 = random.NextEnglishWordLowercase(35),
                DisplayUrl = "www." + random.NextEnglishWordLowercase(10) + ".com",
                DestinationUrl = "www." + random.NextEnglishWordLowercase(10) + ".com",
            };
            return textAd;
        }
    }
}