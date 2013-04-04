using System;
using System.Linq;

namespace Facebook.UITestFramework.Object
{
    public class SuggestedBid
    {
        public double SuggestedBidFrom { get; set; }
        public double SuggestedBidTo { get; set; }
        public string Currency { get; set; }
        public bool IsEmpty { get; set; }

        public static SuggestedBid ParseWithCurrency(string bidStringFromUI)
        {
            SuggestedBid bid = new SuggestedBid();
            if (!bidStringFromUI.Contains('-'))
            {
                throw new Exception("There is no suggested bid!");
            }
            bid.Currency = bidStringFromUI.Split(' ').Last();
            string[] suggestedBid = bidStringFromUI.Replace(bid.Currency, string.Empty).Split('-');
            double from, to;
            parse(bidStringFromUI.Replace(bid.Currency, string.Empty), out from, out to);
            bid.SuggestedBidFrom = from;
            bid.SuggestedBidTo = to;
            return bid;
        }

        public static SuggestedBid Parse(string bidStringInGrid)
        {
            SuggestedBid bid = new SuggestedBid();
            if (!bidStringInGrid.Contains('-'))
            {
                throw new Exception("There is no suggested bid!");
            }
            if (bidStringInGrid == " - ")
            {
                bid.IsEmpty = true;
                return bid;
            }
            double from, to;
            parse(bidStringInGrid, out from, out to);
            bid.SuggestedBidFrom = from;
            bid.SuggestedBidTo = to;
            bid.IsEmpty = false;
            return bid;
        }

        private static void parse(string bid, out double from, out double to)
        {
            string[] suggestedBid = bid.Split('-');
            from = double.Parse(suggestedBid[0]);
            to = double.Parse(suggestedBid[1]);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            SuggestedBid bid= obj as SuggestedBid;
            if (bid == null)
            {
                return false;
            }
            if (bid.IsEmpty != this.IsEmpty)
            {
                return false;
            }
            else if(bid.IsEmpty)
            {
                return true;
            }
            if (bid.SuggestedBidTo != this.SuggestedBidTo)
            {
                return false;
            }
            if (bid.SuggestedBidFrom != this.SuggestedBidFrom)
            {
                return false;
            }
            return true;
        }
    }
}
