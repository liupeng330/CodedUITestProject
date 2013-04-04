using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace AdCenter.UITestFramework.Object
{
    public class Performance
    {
        public string Clicks { get; set; }
        public string Impressions { get; set; }
        public string CTR { get; set; }
        public string AvgCPC { get; set; }
        public string TotalCost { get; set; }
        public string AvgPos { get; set; }
        public string ConvRate { get; set; }
        public string CPA { get; set; }
        public string Convertions { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Performance perf = obj as Performance;
            if (perf == null)
            {
                return false;
            }
            if (!string.Equals(this.Clicks, perf.Clicks, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Impressions, perf.Impressions, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.CTR, perf.CTR, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.AvgCPC, perf.AvgCPC, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.ConvRate, perf.ConvRate, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.CPA, perf.CPA, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            if (!string.Equals(this.Convertions, perf.Convertions, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public static Performance Parse(WinRow row, int startIndex)
        {
            Performance perf = new Performance
            {
                Clicks = GridViewUtilities.GetValueProperty(row.Cells[startIndex]),
                Impressions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                CTR = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                AvgCPC = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                TotalCost = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                AvgPos = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                ConvRate = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                CPA = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
                Convertions = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]),
            };
            return perf;
        }

        public override string ToString()
        {
            return this.DumpProperties();
        }
    }
}
