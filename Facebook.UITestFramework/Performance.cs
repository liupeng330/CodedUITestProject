using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    public class Performance
    {
        public string CampaignName { get; set; }
        public string Impressions { get; set; }
        public string Reach { get; set; }
        public string Freq { get; set; }
        public string SocialReach { get; set; }
        public string Connections { get; set; }
        public string Clicks { get; set; }
        public string CTR { get; set; }
        public string CPC { get; set; }
        public string CPM { get; set; }
        public string Spent { get; set; }
        public string Conversions { get; set; }
        public string CPA { get; set; }
        public string ConversionRate { get; set; }

        public static Performance Parse(WinRow row)
        {
            if (row.Cells.Count != 21)
            {
                throw new Exception("The count of cell in keyword grid should be equal to 21!");
            }
            int startIndex = 8;
            Performance performance = new Performance();
            performance.CampaignName = GridViewUtilities.GetValueProperty(row.Cells[2]);
            performance.Impressions = GridViewUtilities.GetValueProperty(row.Cells[startIndex]);
            performance.Reach = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.Freq = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.SocialReach = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.Connections = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.Clicks = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.CTR = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.CPC = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.CPM = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.Spent = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.Conversions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.CPA = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            performance.ConversionRate = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);            
            return performance;
        }        

        public static Performance FetchPerformance(DataRow[] rows)
        {
            Performance performance = null;
            if (1 == rows.Length)
            {
                performance = new Performance();
                performance.CampaignName = rows[0].Field<string>("CampaignName");
                performance.Impressions = rows[0].Field<string>("Impressions");
                performance.Reach = rows[0].Field<string>("Reach");
                performance.Freq = rows[0].Field<string>("Freq");
                performance.SocialReach = rows[0].Field<string>("SocialReach");
                performance.Connections = rows[0].Field<string>("Connections");
                performance.Clicks = rows[0].Field<string>("Clicks");
                performance.CTR = rows[0].Field<string>("CTR");
                performance.CPC = rows[0].Field<string>("CPC");
                performance.CPM = rows[0].Field<string>("CPM");
                performance.Spent = rows[0].Field<string>("Spent");
                performance.Conversions = rows[0].Field<string>("Conversions");
                performance.CPA = rows[0].Field<string>("CPA");
                performance.ConversionRate = rows[0].Field<string>("ConversionRate");
            }
            else if (0 == rows.Length)
            {
                throw new Exception("The record you find dose not exist!");
            }
            else
            {
                throw new Exception("The query result error, because only one record should be seleted!");
            }

            return performance;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }
    }
}
