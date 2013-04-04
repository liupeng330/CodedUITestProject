using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    public class AccountSummary
    {
        public string PerformanceName { get; set; }
        public string Total { get; set; }
        public string Average { get; set; }
        public string DateTime { get; set; }

        public static AccountSummary Parse(WinRow row)
        {
            if (row.Cells.Count != 4)
            {
                throw new Exception("The count of cell in keyword grid should be equal to 4!");
            }
            int startIndex = 0;
            AccountSummary accountSummary = new AccountSummary();
            accountSummary.PerformanceName = GridViewUtilities.GetValueProperty(row.Cells[startIndex]);
            accountSummary.Total = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountSummary.Average = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);
            accountSummary.DateTime = GridViewUtilities.GetValueProperty(row.Cells[++startIndex]);

            return accountSummary;
        }

        public static AccountSummary FetchPerformance(DataRow[] rows)
        {
            AccountSummary accountSummary = null;
            if (1 == rows.Length)
            {
                accountSummary = new AccountSummary();
                accountSummary.PerformanceName = rows[0].Field<string>("PerformanceName");
                accountSummary.Total = rows[0].Field<string>("Total");
                accountSummary.Average = rows[0].Field<string>("Average");
                accountSummary.DateTime = rows[0].Field<string>("DateTime");

            }
            else if (0 == rows.Length)
            {
                throw new Exception("The record you find dose not exist!");
            }
            else
            {
                throw new Exception("The query result error, because only one record should be seleted!");
            }

            return accountSummary;
        }

    }
}
