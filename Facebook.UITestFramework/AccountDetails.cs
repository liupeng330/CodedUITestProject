using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    public class AccountDetails
    {
        public string Name { get; set; }
        public string Impressions { get; set; }
        public string SocialImpressions { get; set; }
        public string Clicks { get; set; }
        public string SocialClicks { get; set; }
        public string UniqueClicks { get; set; }
        public string Connections { get; set; }
        public string Reach { get; set; }
        public string Freq { get; set; }
        public string Spent { get; set; }
        public string CTR { get; set; }
        public string UniqueCTR { get; set; }
        public string Conversions { get; set; }
        public string CPA { get; set; }
        public string ConversionRate { get; set; }

        public static AccountDetails Parse(WinRow row)
        {
            if (row.Cells.Count != 15)
            {
                throw new Exception("The count of cell in keyword grid should be equal to 15!");
            }
            int startIndex = 0;
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.Name = GridViewUtilities.GetValueProperty(row.Cells[startIndex]);
            accountDetails.Impressions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.SocialImpressions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Clicks = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.SocialClicks = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.UniqueClicks = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Connections = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Reach = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Freq = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Spent = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.CTR = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.UniqueCTR = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.Conversions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.CPA = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountDetails.ConversionRate = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);

            return accountDetails;
        }

        public static AccountDetails FetchPerformance(DataRow[] rows)
        {
            AccountDetails accountDetails = null;
            if (1==rows.Length)
            {
                accountDetails = new AccountDetails();
                accountDetails.Name = rows[0].Field<string>("Name");
                accountDetails.Impressions = rows[0].Field<string>("Impressions");
                accountDetails.SocialImpressions = rows[0].Field<string>("SocialImpressions");
                accountDetails.Clicks = rows[0].Field<string>("Clicks");
                accountDetails.SocialClicks = rows[0].Field<string>("SocialClicks");
                accountDetails.UniqueClicks = rows[0].Field<string>("UniqueClicks");
                accountDetails.Connections = rows[0].Field<string>("Connections");
                accountDetails.Reach = rows[0].Field<string>("Reach");
                accountDetails.Freq = rows[0].Field<string>("Freq");
                accountDetails.Spent = rows[0].Field<string>("Spent");
                accountDetails.CTR = rows[0].Field<string>("CTR");
                accountDetails.UniqueCTR = rows[0].Field<string>("UniqueCTR");
                accountDetails.Conversions = rows[0].Field<string>("Conversions");
                accountDetails.CPA = rows[0].Field<string>("CPA");
                accountDetails.ConversionRate = rows[0].Field<string>("ConversionRate");
            }
            else if (0 == rows.Length)
            {
                throw new Exception("The record you find dose not exist!");
            }
            else
            {
                throw new Exception("The query result error, because only one record should be seleted!");
            }
            return accountDetails;
        }

    }
}
