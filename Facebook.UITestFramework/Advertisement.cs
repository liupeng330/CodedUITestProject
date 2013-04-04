using System;
using System.Collections.Generic;
using Common.UITestFramework.Utilities;
using Facebook.UITestFramework.Enums;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System.Configuration;

namespace Facebook.UITestFramework.Object
{
    public class Advertisement
    {
        public string CampaignName { get; set; }
        public string AdName { get; set; }
        public AdStatus AdStatus { get; set; }
        public AdType AdType { get; set; }
        public BidType BidType { get; set; }
        public double MaxBid { get; set; }
        public SuggestedBid SuggestedBid { get; set; }
        public long TargetingEstimation { get; set; }
        public Uri DestinationUrl { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Advertisement ad = obj as Advertisement;
            if (ad == null)
            {
                return false;
            }
            if (!string.Equals(this.CampaignName, ad.CampaignName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.AdName, ad.AdName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (this.AdStatus != ad.AdStatus)
            {
                return false;
            }
            if (this.AdType != ad.AdType)
            {
                return false;
            }
            if (this.BidType != ad.BidType)
            {
                return false;
            }
            if (this.MaxBid != ad.MaxBid)
            {
                return false;
            }
            if (!this.SuggestedBid.Equals(ad.SuggestedBid))
            {
                return false;
            }
            if (this.TargetingEstimation != ad.TargetingEstimation)
            {
                return false;
            }
            if (this.DestinationUrl != null && ad.DestinationUrl != null)
            {
                if (!this.DestinationUrl.Equals(ad.DestinationUrl))
                {
                    return false;
                }
            }
            else if (!(this.DestinationUrl == null && ad.DestinationUrl == null))
            {
                return false;
            }
            if (!string.Equals(this.Title, ad.Title, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Body, ad.Body, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

        public static Advertisement NextExternalAdvertisement(RandomData randomData)
        {
            return new Facebook.UITestFramework.Object.Advertisement
            {
                AdName = "Automation_" + randomData.NextAsciiWord(2, 3),
                AdStatus = AdStatus.Scheduled,
                AdType = AdType.External_URL,
                BidType = BidType.CPC,
                MaxBid = 0.01,
                DestinationUrl = new Uri("http://www.ad-sage.com"),
                Title = "Manage your ads?",
                Body = "Get the latest updates on adSage for Facebook's powerful ad manager. Click like now!",
                SuggestedBid = new SuggestedBid(),
            };
        }

        public static Advertisement NextPageLikeStoryAdvertisement(RandomData randomData)
        {
            return nextPageSponsorStoryAdvertisement(randomData, AdType.Page_Like_Story);
        }

        public static Advertisement NextPagePostStoryAdvertisement(RandomData randomData)
        {
            return nextPagePostAdvertisement(randomData, AdType.Page_Post_Story);
        }

        private static Advertisement nextPagePostAdvertisement(RandomData randomData, AdType type)
        {
            Advertisement ad = nextSponsorStoryAdvertisement(randomData, type);
            ad.Title = ConfigurationManager.AppSettings.Get("PagePostName");
            return ad;
        }

        public static Advertisement NextPagePostLikeStoryAdvertisement(RandomData randomData)
        {
            return nextPageSponsorStoryAdvertisement(randomData, AdType.Page_Post_Like_Story);
        }

        private static Advertisement nextPageSponsorStoryAdvertisement(RandomData randomData, AdType type)
        {
            Advertisement ad=nextSponsorStoryAdvertisement(randomData, type);
            ad.Title = ConfigurationManager.AppSettings.Get("PageName");
            return ad;
        }

        public static Advertisement NextAppUsedStoryAdvertisement(RandomData randomData)
        {
            return nextAppSponsorStoryAdvertisement(randomData, AdType.App_Used_Story);
        }

        public static Advertisement NextAppShareStoryAdvertisement(RandomData randomData)
        {
            return nextAppSponsorStoryAdvertisement(randomData, AdType.App_Share_Story);
        }

        private static Advertisement nextAppSponsorStoryAdvertisement(RandomData randomData, AdType type)
        {
            Advertisement ad=nextSponsorStoryAdvertisement(randomData, type);
            ad.Title = ConfigurationManager.AppSettings.Get("AppName");
            return ad;
        }

        private static Advertisement nextSponsorStoryAdvertisement(RandomData randomData, AdType type)
        {
            return new Facebook.UITestFramework.Object.Advertisement
            {
                AdName = "Automation_" + randomData.NextAsciiWord(2, 3),
                AdStatus = AdStatus.Scheduled,
                BidType = BidType.CPC,
                MaxBid = 0.01,
                DestinationUrl = null,//new Uri(ConfigurationManager.AppSettings.Get("PageUrl")),
                Body = string.Empty,
                SuggestedBid = new SuggestedBid(),
                AdType = type,
            };
        }

        public static Advertisement Parse(WinRow oneRowInAdGrid)
        {
            if (oneRowInAdGrid.Cells.Count != 27)
            {
                throw new Exception("The count of cell in ad grid should be equal to 27!");
            }
            Advertisement ad = new Advertisement();
            int index = 2;
            ad.CampaignName = GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]);
            ad.AdName = GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]);
            ad.AdStatus = (AdStatus)Enum.Parse(typeof(AdStatus), transferAdStatus(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++])));
            ad.AdType = (AdType)Enum.Parse(typeof(AdType), transferAdType(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++])));
            index++;
            ad.BidType = (BidType)Enum.Parse(typeof(BidType), GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]));
            ad.MaxBid = double.Parse(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]));
            ad.SuggestedBid = SuggestedBid.Parse(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]));
            ad.TargetingEstimation = parseTargetingEstimation(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]).Replace(",", string.Empty));
            ad.DestinationUrl = string.IsNullOrEmpty(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index])) ? null : new Uri(GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index]));
            index++;
            ad.Title = GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]);
            ad.Body = GridViewUtilities.GetValueProperty(oneRowInAdGrid.Cells[index++]);
            return ad;
        }

        private static long parseTargetingEstimation(string estimation)
        {
            if (estimation == " - ")
            {
                return 0;
            }
            return long.Parse(estimation);
        }

        private static string transferAdType(string typeInAdGrid)
        {
            if (typeInAdGrid.Contains(" "))
            {
                return typeInAdGrid.Replace(' ', '_');
            }
            return typeInAdGrid;
        }

        private static string transferAdStatus(string statusInAdGrid)
        {
            if (statusInAdGrid.Contains(" "))
            {
                return statusInAdGrid.Replace(" ", string.Empty);
            }
            return statusInAdGrid;
        }

        public static List<Advertisement> Parse(List<WinRow> advertisementRows)
        {
            if (advertisementRows[0].Cells.Count != 27)
            {
                throw new Exception("The count of cell in ad grid should be equal to 27!");
            }
            if (advertisementRows.Count != 5)
            {
                throw new Exception("The count of row in ad grid should be equal to 6!");
            }
            List<Advertisement> ads = new List<Advertisement>();
            int index = 2;
            for (int i = 0; i < advertisementRows.Count; i++)
            {
                index = 2;
                Advertisement ad = new Advertisement();
                ad.CampaignName = GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]);
                ad.AdName = GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]);
                ad.AdStatus = (AdStatus)Enum.Parse(typeof(AdStatus), transferAdStatus(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++])));
                ad.AdType = (AdType)Enum.Parse(typeof(AdType), transferAdType(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++])));
                index++;
                ad.BidType = (BidType)Enum.Parse(typeof(BidType), GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]));
                ad.MaxBid = double.Parse(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]));
                ad.SuggestedBid = SuggestedBid.Parse(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]));
                ad.TargetingEstimation = parseTargetingEstimation(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]).Replace(",", string.Empty));
                ad.DestinationUrl = string.IsNullOrEmpty(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index])) ? null : new Uri(GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index]));
                index++;
                ad.Title = GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]);
                ad.Body = GridViewUtilities.GetValueProperty(advertisementRows[i].Cells[index++]);
                ads.Add(ad);
            }
            return ads;
        }
    }
}
