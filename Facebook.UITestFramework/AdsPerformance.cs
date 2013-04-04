using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    public class AdsPerformance
    {
        public string CampaignName { get; set; }
        public string AdName { get; set; }
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

        public static AdsPerformance[] Parse(List<WinRow> rows)
        {
            if (rows[0].Cells.Count != 27)
            {
                throw new Exception("The count of cell in keyword grid should be equal to 27!");
            }
            int startIndex = 14;
            AdsPerformance[] adPerformances = new AdsPerformance[rows.Count];
            for (int i = 0; i < rows.Count; i++)
            {
                startIndex = 14;
                adPerformances[i].CampaignName = GridViewUtilities.GetValueProperty(rows[i].Cells[2]);
                adPerformances[i].AdName = GridViewUtilities.GetValueProperty(rows[i].Cells[3]);
                adPerformances[i].Impressions = GridViewUtilities.GetValueProperty(rows[i].Cells[startIndex]);
                adPerformances[i].Reach = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].Freq = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].SocialReach = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].Connections = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].Clicks = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].CTR = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].CPC = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].CPM = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].Spent = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].Conversions = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].CPA = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);
                adPerformances[i].ConversionRate = GridViewUtilities.GetValueProperty(rows[i].Cells[++startIndex]);

            }
            return adPerformances;
        }

        public static AdsPerformance[] FetchPerformance(DataRow[] rows)
        {
            if (0 == rows.Length)
            {
                throw new Exception("These records you find do not exist!");
            }
            AdsPerformance[] adPerformances = new AdsPerformance[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                adPerformances[i].CampaignName = rows[i].Field<string>("CampaignName");
                adPerformances[i].AdName = rows[i].Field<string>("AdName");
                adPerformances[i].Impressions = rows[i].Field<string>("Impressions");
                adPerformances[i].Reach = rows[i].Field<string>("Reach");
                adPerformances[i].Freq = rows[i].Field<string>("Freq");
                adPerformances[i].SocialReach = rows[i].Field<string>("SocialReach");
                adPerformances[i].Connections = rows[i].Field<string>("Connections");
                adPerformances[i].Clicks = rows[i].Field<string>("Clicks");
                adPerformances[i].CTR = rows[i].Field<string>("CTR");
                adPerformances[i].CPC = rows[i].Field<string>("CPC");
                adPerformances[i].CPM = rows[i].Field<string>("CPM");
                adPerformances[i].Spent = rows[i].Field<string>("Spent");
                adPerformances[i].Conversions = rows[i].Field<string>("Conversions");
                adPerformances[i].CPA = rows[i].Field<string>("CPA");
                adPerformances[i].ConversionRate = rows[i].Field<string>("ConversionRate");
            }

            return adPerformances;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }

    }
}
