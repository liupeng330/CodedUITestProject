using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Common.UITestFramework.Utilities
{
    public static class CSVFileUtilities
    {
        public static bool ReadDatasFromCSVFile(ref DataTable myCSVTable, string filePath)
        {
            //CSV file path
            string path = filePath;
            bool isReadSuccess = false;
            try
            {
                int colCount = 0;
                bool hasColName = false;

                DataColumn myColumn;
                DataRow myDataRow;

                string strLine;
                string[] arrLine;
                StreamReader reader = new StreamReader(path, System.Text.Encoding.Default);

                while ((strLine = reader.ReadLine()) != null)
                {
                    arrLine = strLine.Split(new char[] { ',' });

                    //Add column Name for DataTable
                    if (!hasColName)
                    {
                        colCount = arrLine.Length;
                        for (int i = 0; i < colCount; i++)
                        {
                            myColumn = new DataColumn(arrLine[i]);
                            myCSVTable.Columns.Add(myColumn);
                        }
                        hasColName = true;
                    }

                    //Fill out data to CSV DataTable
                    myDataRow = myCSVTable.NewRow();
                    for (int i = 0; i < colCount; i++)
                    {
                        myDataRow[i] = arrLine[i];
                    }
                    myCSVTable.Rows.Add(myDataRow);
                }
                isReadSuccess = true;
            }
            catch
            {
                isReadSuccess = false;
                throw;
            }
            return isReadSuccess;
        }        

    }
}
