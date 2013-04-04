namespace Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    public partial class DetailedInfoForUpload
    {
        public UIDataGridViewTableForJob UIDataGridViewTableForJob
        {
            get
            {
                if (this.mUIDataGridViewTableForJob == null)
                {
                    this.mUIDataGridViewTableForJob = new UIDataGridViewTableForJob(this.UIDetailedInfoforUploaWindow.UISageGridViewJobsWindow);
                }
                return this.mUIDataGridViewTableForJob;
            }
        }
        private UIDataGridViewTableForJob mUIDataGridViewTableForJob;

        /// <summary>
        /// VerifyUploadOneCampaign - Use 'VerifyUploadOneCampaignExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyUploadOneCampaign()
        {
            #region Variable Declarations
            WinCell uIHaihadsagecom4684830Cell = this.UIDataGridViewTableForJob.UIRow0Row1.UIHaihadsagecom4684830Cell;
            WinCell uIFinishedCell = this.UIDataGridViewTableForJob.UIRow0Row1.UIFinishedCell;
            WinCell uICampaigns1Cell = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaigns1Cell;
            WinCell uIItem1Succeeded0FaileCell = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UIItem1Succeeded0FaileCell;
            WinCell uIItem0Succeeded0FaileCell = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UIItem0Succeeded0FaileCell;
            WinCell uIItem0Succeeded0FaileCell1 = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UIItem0Succeeded0FaileCell1;
            WinCell uIAdgroups0Cell = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row1.UIAdgroups0Cell;
            WinCell uIItem0Succeeded0FaileCell2 = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row1.UIItem0Succeeded0FaileCell;
            WinCell uIItem0Succeeded0FaileCell11 = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row1.UIItem0Succeeded0FaileCell1;
            WinCell uIItem0Succeeded0FaileCell21 = this.UIDetailedInfoforUploaWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row1.UIItem0Succeeded0FaileCell2;
            #endregion

            // Verify that 'haih@ad-sage.com #46848300(USD)' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIHaihadsagecom4684830CellValue, uIHaihadsagecom4684830Cell.Value);

            // Verify that 'Finished' cell's property 'Value' equals 'Finished'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIFinishedCellValue, uIFinishedCell.Value);

            // Verify that 'Campaigns(1)' cell's property 'Value' equals 'Campaigns(1)'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UICampaigns1CellValue, uICampaigns1Cell.Value);

            // Verify that '1 Succeeded, 0 Failed' cell's property 'Value' equals '1 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem1Succeeded0FaileCellValue, uIItem1Succeeded0FaileCell.Value);

            // Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem0Succeeded0FaileCellValue, uIItem0Succeeded0FaileCell.Value);

            // Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem0Succeeded0FaileCell1Value, uIItem0Succeeded0FaileCell1.Value);

            // Verify that 'Ad groups(0)' cell's property 'Value' equals 'Ad groups(0)'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIAdgroups0CellValue, uIAdgroups0Cell.Value);

            // Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem0Succeeded0FaileCellValue1, uIItem0Succeeded0FaileCell2.Value);

            // Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem0Succeeded0FaileCell1Value1, uIItem0Succeeded0FaileCell11.Value);

            // Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
            Assert.AreEqual(this.VerifyUploadOneCampaignExpectedValues.UIItem0Succeeded0FaileCell2Value, uIItem0Succeeded0FaileCell21.Value);
        }

        public virtual VerifyUploadOneCampaignExpectedValues VerifyUploadOneCampaignExpectedValues
        {
            get
            {
                if ((this.mVerifyUploadOneCampaignExpectedValues == null))
                {
                    this.mVerifyUploadOneCampaignExpectedValues = new VerifyUploadOneCampaignExpectedValues();
                }
                return this.mVerifyUploadOneCampaignExpectedValues;
            }
        }

        private VerifyUploadOneCampaignExpectedValues mVerifyUploadOneCampaignExpectedValues;
    }

    /// <summary>
    /// Parameters to be passed into 'VerifyUploadOneCampaign'
    /// </summary>
    public class VerifyUploadOneCampaignExpectedValues
    {
        #region Fields
        /// <summary>
        /// Verify that 'haih@ad-sage.com #46848300(USD)' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)'
        /// </summary>
        public string UIHaihadsagecom4684830CellValue = "haih@ad-sage.com #46848300(USD)";

        /// <summary>
        /// Verify that 'Finished' cell's property 'Value' equals 'Finished'
        /// </summary>
        public string UIFinishedCellValue = "Finished";

        /// <summary>
        /// Verify that 'Campaigns(1)' cell's property 'Value' equals 'Campaigns(1)'
        /// </summary>
        public string UICampaigns1CellValue = "Campaigns(1)";

        /// <summary>
        /// Verify that '1 Succeeded, 0 Failed' cell's property 'Value' equals '1 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem1Succeeded0FaileCellValue = "1 Succeeded, 0 Failed";

        /// <summary>
        /// Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem0Succeeded0FaileCellValue = "0 Succeeded, 0 Failed";

        /// <summary>
        /// Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem0Succeeded0FaileCell1Value = "0 Succeeded, 0 Failed";

        /// <summary>
        /// Verify that 'Ad groups(0)' cell's property 'Value' equals 'Ad groups(0)'
        /// </summary>
        public string UIAdgroups0CellValue = "Ads(0)";

        /// <summary>
        /// Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem0Succeeded0FaileCellValue1 = "0 Succeeded, 0 Failed";

        /// <summary>
        /// Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem0Succeeded0FaileCell1Value1 = "0 Succeeded, 0 Failed";

        /// <summary>
        /// Verify that '0 Succeeded, 0 Failed' cell's property 'Value' equals '0 Succeeded, 0 Failed'
        /// </summary>
        public string UIItem0Succeeded0FaileCell2Value = "0 Succeeded, 0 Failed";
        #endregion
    }

    public class UIDataGridViewTableForJob : WinTable
    {

        public UIDataGridViewTableForJob(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinTable.PropertyNames.Name] = "DataGridView";
            #endregion
        }

        #region Properties
        public UITopRowRowForJob UITopRowRow
        {
            get
            {
                if ((this.mUITopRowRow == null))
                {
                    this.mUITopRowRow = new UITopRowRowForJob(this);
                }
                return this.mUITopRowRow;
            }
        }

        public WinRow UIRow0Row
        {
            get
            {
                if ((this.mUIRow0Row == null))
                {
                    this.mUIRow0Row = new WinRow(this);
                    #region Search Criteria
                    this.mUIRow0Row.SearchProperties[WinRow.PropertyNames.Name] = "Row 0";
                    this.mUIRow0Row.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
                    #endregion
                }
                return this.mUIRow0Row;
            }
        }

        public UIRow0Row1ForJob UIRow0Row1
        {
            get
            {
                if ((this.mUIRow0Row1 == null))
                {
                    this.mUIRow0Row1 = new UIRow0Row1ForJob(this);
                }
                return this.mUIRow0Row1;
            }
        }
        #endregion

        #region Fields
        private UITopRowRowForJob mUITopRowRow;

        private WinRow mUIRow0Row;

        private UIRow0Row1ForJob mUIRow0Row1;
        #endregion

        public void WaitForStatusPropertyEqual(string statusValue)
        {
            if (this.Rows.Count < 1)
            {
                throw new Exception("There is no account information in job grid view!");
            }
            WinRow firstRow = this.Rows[0] as WinRow;
            Assert.AreEqual(3, firstRow.Cells.Count, "The count of cell in job grid view should be equal to 3!");
            UITestControl statusCell = firstRow.Cells[1];
            statusCell.WaitForControlPropertyEqual(WinCell.PropertyNames.Value, statusValue);
        }
    }

    public class UITopRowRowForJob : WinRow
    {

        public UITopRowRowForJob(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Name] = "Top Row";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            #endregion
        }

        #region Properties
        public WinColumnHeader UIAccountNameColumnHeader
        {
            get
            {
                if ((this.mUIAccountNameColumnHeader == null))
                {
                    this.mUIAccountNameColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIAccountNameColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Account Name";
                    #endregion
                }
                return this.mUIAccountNameColumnHeader;
            }
        }

        public WinColumnHeader UIStatusColumnHeader
        {
            get
            {
                if ((this.mUIStatusColumnHeader == null))
                {
                    this.mUIStatusColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUIStatusColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Status";
                    #endregion
                }
                return this.mUIStatusColumnHeader;
            }
        }

        public WinColumnHeader UICurrentProgressColumnHeader
        {
            get
            {
                if ((this.mUICurrentProgressColumnHeader == null))
                {
                    this.mUICurrentProgressColumnHeader = new WinColumnHeader(this);
                    #region Search Criteria
                    this.mUICurrentProgressColumnHeader.SearchProperties[WinControl.PropertyNames.Name] = "Current Progress";
                    #endregion
                }
                return this.mUICurrentProgressColumnHeader;
            }
        }
        #endregion

        #region Fields
        private WinColumnHeader mUIAccountNameColumnHeader;

        private WinColumnHeader mUIStatusColumnHeader;

        private WinColumnHeader mUICurrentProgressColumnHeader;
        #endregion
    }

    public class UIRow0Row1ForJob : WinRow
    {

        public UIRow0Row1ForJob(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Value] = "haih@ad-sage.com #46848300(USD);Finished;(null)";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            #endregion
        }

        #region Properties
        public WinCell UIHaihadsagecom4684830Cell
        {
            get
            {
                if ((this.mUIHaihadsagecom4684830Cell == null))
                {
                    this.mUIHaihadsagecom4684830Cell = new WinCell(this);
                    #region Search Criteria
                    this.mUIHaihadsagecom4684830Cell.SearchProperties[WinCell.PropertyNames.Value] = "haih@ad-sage.com #46848300(USD)";
                    #endregion
                }
                return this.mUIHaihadsagecom4684830Cell;
            }
        }

        public WinCell UIFinishedCell
        {
            get
            {
                if ((this.mUIFinishedCell == null))
                {
                    this.mUIFinishedCell = new WinCell(this);
                    #region Search Criteria
                    this.mUIFinishedCell.SearchProperties[WinCell.PropertyNames.Value] = "Finished";
                    #endregion
                }
                return this.mUIFinishedCell;
            }
        }

        public WinCell UINullCell
        {
            get
            {
                if ((this.mUINullCell == null))
                {
                    this.mUINullCell = new WinCell(this);
                    #region Search Criteria
                    this.mUINullCell.SearchProperties[WinCell.PropertyNames.Value] = "(null)";
                    #endregion
                }
                return this.mUINullCell;
            }
        }
        #endregion

        #region Fields
        private WinCell mUIHaihadsagecom4684830Cell;

        private WinCell mUIFinishedCell;

        private WinCell mUINullCell;
        #endregion
    }
}
