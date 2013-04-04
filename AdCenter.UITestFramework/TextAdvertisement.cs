using System;
using Common.UITestFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace AdCenter.UITestFramework.Object
{
    public class TextAdvertisement
    {
        public string CampaignName { get; set; }
        public string AdGroupName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DisplayUrl { get; set; }
        public string DestinationUrl { get; set; }
        public string AdGroupStatus { get; set; }
        public Performance Performance { get; set; }

        public static TextAdvertisement Parse(WinRow row)
        {
            if (row.Cells.Count != 18)
            {
                throw new Exception("The count of cell in text ad grid should be equal to 18!");
            }
            TextAdvertisement textAd = new TextAdvertisement
            {
                CampaignName = GridViewUtilities.GetValueProperty(row.Cells[2]),
                AdGroupName = GridViewUtilities.GetValueProperty(row.Cells[3]),
                Title = GridViewUtilities.GetValueProperty(row.Cells[4]),
                Text = GridViewUtilities.GetValueProperty(row.Cells[5]),
                DisplayUrl = GridViewUtilities.GetValueProperty(row.Cells[6]),
                DestinationUrl = GridViewUtilities.GetValueProperty(row.Cells[7]),
                AdGroupStatus = GridViewUtilities.GetValueProperty(row.Cells[8]),
                Performance = Performance.Parse(row, 9),
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
            if (!string.Equals(this.Title, other.Title, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Text, other.Text, StringComparison.OrdinalIgnoreCase))
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
            if (!string.Equals(this.AdGroupStatus, other.AdGroupStatus, StringComparison.OrdinalIgnoreCase))
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
                Title = random.NextEnglishWordsLowercase(5, 4),
                Text = random.NextEnglishWordsLowercase(5, 10),
                DisplayUrl = "www." + random.NextEnglishWordLowercase(10) + ".com",
                DestinationUrl = "http://www." + random.NextEnglishWordLowercase(10, 15) + ".com",
            };
            return textAd;
        }
    }
}