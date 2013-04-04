using Common.UITestFramework.UIMaps.QuestionWindowClasses;

namespace Common.UITestFramework.UIMaps.DetailedInfoForDownloadClasses
{
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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System.Configuration;


    public partial class DetailedInfoForDownload
    {
        public UIDataGridViewTableForJob UIDataGridViewTableForJob
        {
            get
            {
                if (this.mUIDataGridViewTableForJob == null)
                {
                    this.mUIDataGridViewTableForJob = new UIDataGridViewTableForJob(this.UIDetailedInfoforDownlWindow.UISageGridViewJobsWindow);
                }
                return this.mUIDataGridViewTableForJob;
            }
        }
        private UIDataGridViewTableForJob mUIDataGridViewTableForJob;

        /// <summary>
        /// VerifyDownloadOneCampaign - Use 'VerifyDownloadOneCampaignExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignNoneAd(string campaignName)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAddownloadedsofar0Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row1.UIAddownloadedsofar0Cell;
            #endregion

            // Verify that 'haih@ad-sage.com #46848300(USD)->UFUcx' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)->UFUcx'
            Assert.AreEqual(this.VerifyDownloadOneCampaignExpectedValues.UIHaihadsagecom4684830CellValue + campaignName, this.UIDataGridViewTableForJob.GetAccountNameCellValue());

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad downloaded so far: 0' cell's property 'Value' equals 'Ad downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignExpectedValues.UIAddownloadedsofar0CellValue, uIAddownloadedsofar0Cell.Value);
        }

        public virtual VerifyDownloadOneCampaignExpectedValues VerifyDownloadOneCampaignExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignExpectedValues = new VerifyDownloadOneCampaignExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignExpectedValues mVerifyDownloadOneCampaignExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAd - Use 'VerifyDownloadOneCampaignOneAdExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAd(string campaignName)
        {
            #region Variable Declarations
            WinCell uIHaihadsagecom4684830Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewJobsWindow.UIDataGridViewTable.UIRow0Row1.UIHaihadsagecom4684830Cell;
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAddownloadedsofar1Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row2.UIAddownloadedsofar1Cell;
            #endregion

            // Verify that 'haih@ad-sage.com #46848300(USD)->JJN23PRzg' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)->JJN23PRzg'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdExpectedValues.UIHaihadsagecom4684830CellValue + campaignName, this.UIDataGridViewTableForJob.GetAccountNameCellValue());

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad downloaded so far: 1' cell's property 'Value' equals 'Ad downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdExpectedValues.UIAddownloadedsofar1CellValue, uIAddownloadedsofar1Cell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdExpectedValues VerifyDownloadOneCampaignOneAdExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdExpectedValues = new VerifyDownloadOneCampaignOneAdExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdExpectedValues mVerifyDownloadOneCampaignOneAdExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignForGoogle - Use 'VerifyDownloadOneCampaignForGoogleExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignForGoogle(string campaignName)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row3.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row.UITextadsdownloadedsofCell;
            WinCell uIPlacementsdownloadedCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow4Row.UIPlacementsdownloadedCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForGoogleExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 0' cell's property 'Value' equals 'Ad groups downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForGoogleExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForGoogleExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForGoogleExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);

            // Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForGoogleExpectedValues.UIPlacementsdownloadedCellValue, uIPlacementsdownloadedCell.Value);
        }

        public virtual VerifyDownloadOneCampaignForGoogleExpectedValues VerifyDownloadOneCampaignForGoogleExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignForGoogleExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignForGoogleExpectedValues = new VerifyDownloadOneCampaignForGoogleExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignForGoogleExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignForGoogleExpectedValues mVerifyDownloadOneCampaignForGoogleExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdForGoogle - Use 'VerifyDownloadOneCampaignOneAdForGoogleExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdForGoogle(string name)
        {
            #region Variable Declarations
            WinRow uIRow0Row = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row;
            WinRow uIRow1Row = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row;
            WinRow uIRow2Row1 = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row1;
            WinRow uIRow3Row1 = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row1;
            WinRow uIRow4Row1 = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow4Row1;
            #endregion

            // Verify that 'Row 0' row's property 'Value' equals 'System.Drawing.Bitmap;Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForGoogleExpectedValues.UIRow0RowValue, uIRow0Row.Value);

            // Verify that 'Row 1' row's property 'Value' equals 'System.Drawing.Bitmap;Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForGoogleExpectedValues.UIRow1RowValue, uIRow1Row.Value);

            // Verify that 'Row 2' row's property 'Value' equals 'System.Drawing.Bitmap;Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForGoogleExpectedValues.UIRow2Row1Value, uIRow2Row1.Value);

            // Verify that 'Row 3' row's property 'Value' equals 'System.Drawing.Bitmap;Text ads downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForGoogleExpectedValues.UIRow3Row1Value, uIRow3Row1.Value);

            // Verify that 'Row 4' row's property 'Value' equals 'System.Drawing.Bitmap;Placements downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForGoogleExpectedValues.UIRow4Row1Value, uIRow4Row1.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdForGoogleExpectedValues VerifyDownloadOneCampaignOneAdForGoogleExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdForGoogleExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdForGoogleExpectedValues = new VerifyDownloadOneCampaignOneAdForGoogleExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdForGoogleExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdForGoogleExpectedValues mVerifyDownloadOneCampaignOneAdForGoogleExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogle - Use 'VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogle(string name)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row4.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row2.UITextadsdownloadedsofCell;
            WinCell uIPlacementsdownloadedCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow4Row.UIPlacementsdownloadedCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);

            // Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues.UIPlacementsdownloadedCellValue, uIPlacementsdownloadedCell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues = new VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues mVerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogle - Use 'VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogle(string name)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row4.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row2.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row2.UITextadsdownloadedsofCell;
            WinCell uIPlacementsdownloadedCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow4Row.UIPlacementsdownloadedCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 1' cell's property 'Value' equals 'Keywords downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);

            // Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues.UIPlacementsdownloadedCellValue, uIPlacementsdownloadedCell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues = new VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignForAdCenter - Use 'VerifyDownloadOneCampaignForAdCenterExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignForAdCenter(string campaignName)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row3.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row.UITextadsdownloadedsofCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForAdCenterExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 0' cell's property 'Value' equals 'Ad groups downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForAdCenterExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForAdCenterExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignForAdCenterExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);
        }

        public virtual VerifyDownloadOneCampaignForAdCenterExpectedValues VerifyDownloadOneCampaignForAdCenterExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignForAdCenterExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignForAdCenterExpectedValues = new VerifyDownloadOneCampaignForAdCenterExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignForAdCenterExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignForAdCenterExpectedValues mVerifyDownloadOneCampaignForAdCenterExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdForAdCenter - Use 'VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdForAdCenter(string name)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row4.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row.UITextadsdownloadedsofCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdForAdCenterExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdForAdCenterExpectedValues = new VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdForAdCenterExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues mVerifyDownloadOneCampaignOneAdForAdCenterExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenter - Use 'VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenter(string name)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row4.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row2.UITextadsdownloadedsofCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues = new VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues mVerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenter - Use 'VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenter(string name)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdgroupsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row4.UIAdgroupsdownloadedsoCell;
            WinCell uIKeywordsdownloadedsoCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row2.UIKeywordsdownloadedsoCell;
            WinCell uITextadsdownloadedsofCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row2.UITextadsdownloadedsofCell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues.UIAdgroupsdownloadedsoCellValue, uIAdgroupsdownloadedsoCell.Value);

            // Verify that 'Keywords downloaded so far: 1' cell's property 'Value' equals 'Keywords downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues.UIKeywordsdownloadedsoCellValue, uIKeywordsdownloadedsoCell.Value);

            // Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues.UITextadsdownloadedsofCellValue, uITextadsdownloadedsofCell.Value);
        }

        public virtual VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues = new VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues mVerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues;

        /// <summary>
        /// VerifyDownloadFourCampaignWithAds - Use 'VerifyDownloadFourCampaignWithAdsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadFourCampaignWithAds()
        {
            #region Variable Declarations
            WinCell uIAccount2348004880USDCell = this.UIDetailedInfoforDownlWindow.UISageGridViewJobsWindow.UIDataGridViewTable.UIRow0Row2.UIAccount2348004880USDCell;
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row2.UICampaignsdownloadedsCell;
            WinCell uIAdsdownloadedsofar13Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row5.UIAdsdownloadedsofar13Cell;
            #endregion

            // Verify that 'Account2 #348004880(USD)' cell's property 'Value' equals 'Account2 #348004880(USD)'
            Assert.AreEqual(this.VerifyDownloadFourCampaignWithAdsExpectedValues.UIAccount2348004880USDCellValue, uIAccount2348004880USDCell.Value);

            // Verify that 'Campaigns downloaded so far: 4' cell's property 'Value' equals 'Campaigns downloaded so far: 4'
            Assert.AreEqual(this.VerifyDownloadFourCampaignWithAdsExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ads downloaded so far: 13' cell's property 'Value' equals 'Ads downloaded so far: 13'
            Assert.AreEqual(this.VerifyDownloadFourCampaignWithAdsExpectedValues.UIAdsdownloadedsofar13CellValue, uIAdsdownloadedsofar13Cell.Value);
        }

        public virtual VerifyDownloadFourCampaignWithAdsExpectedValues VerifyDownloadFourCampaignWithAdsExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadFourCampaignWithAdsExpectedValues == null))
                {
                    this.mVerifyDownloadFourCampaignWithAdsExpectedValues = new VerifyDownloadFourCampaignWithAdsExpectedValues();
                }
                return this.mVerifyDownloadFourCampaignWithAdsExpectedValues;
            }
        }

        private VerifyDownloadFourCampaignWithAdsExpectedValues mVerifyDownloadFourCampaignWithAdsExpectedValues;

        /// <summary>
        /// VerifyDownloadPerformanceData - Use 'VerifyDownloadPerformanceDataExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadPerformanceData(string dateRange)
        {
            #region Variable Declarations
            WinCell uIAccount2348004880USDCell = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row.UIAccount2348004880USDCell;
            WinCell uIAccount2348004880USDCell1 = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row.UIAccount2348004880USDCell;
            WinCell uIAccount2348004880USDCell2 = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow2Row.UIAccount2348004880USDCell;
            WinCell uIAccount2348004880USDCell3 = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow3Row.UIAccount2348004880USDCell;
            WinCell uIAccount2348004880USDCell4 = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow4Row.UIAccount2348004880USDCell;
            WinCell uIAccount2348004880USDCell5 = this.UIDetailedInfoforDownlWindow1.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow5Row.UIAccount2348004880USDCell;
            #endregion

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Downloading performance data.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo1, uIAccount2348004880USDCell.Value);

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Downloading performance data complete.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue1 + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo2, uIAccount2348004880USDCell1.Value);

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Im...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Importing performance data.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue2 + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo3, uIAccount2348004880USDCell2.Value);

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Im...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Importing performance data complete.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue3 + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo4, uIAccount2348004880USDCell3.Value);

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Pe...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Performance data processed.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue4 + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo5, uIAccount2348004880USDCell4.Value);

            // Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Download process completed.'
            Assert.AreEqual(this.VerifyDownloadPerformanceDataExpectedValues.UIAccount2348004880USDCellValue5 + dateRange + VerifyDownloadPerformanceDataExpectedValues.downloadInfo6, uIAccount2348004880USDCell5.Value);
        }

        public virtual VerifyDownloadPerformanceDataExpectedValues VerifyDownloadPerformanceDataExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadPerformanceDataExpectedValues == null))
                {
                    this.mVerifyDownloadPerformanceDataExpectedValues = new VerifyDownloadPerformanceDataExpectedValues();
                }
                return this.mVerifyDownloadPerformanceDataExpectedValues;
            }
        }

        private VerifyDownloadPerformanceDataExpectedValues mVerifyDownloadPerformanceDataExpectedValues;

        /// <summary>
        /// VerifyDownloadAllCampaignsWithAds - Use 'VerifyDownloadAllCampaignsWithAdsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadAllCampaignsWithAds()
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row3.UICampaignsdownloadedsCell;
            WinCell uIAdsdownloadedsofar53Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row6.UIAdsdownloadedsofar53Cell;
            #endregion

            // Verify that 'Campaigns downloaded so far: 105' cell's property 'Value' is not equal to 'Campaigns downloaded so far: 0'
            Assert.AreNotEqual(this.VerifyDownloadAllCampaignsWithAdsExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ads downloaded so far: 533' cell's property 'Value' is not equal to 'Ads downloaded so far: 0'
            Assert.AreNotEqual(this.VerifyDownloadAllCampaignsWithAdsExpectedValues.UIAdsdownloadedsofar53CellValue, uIAdsdownloadedsofar53Cell.Value);
        }

        public virtual VerifyDownloadAllCampaignsWithAdsExpectedValues VerifyDownloadAllCampaignsWithAdsExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadAllCampaignsWithAdsExpectedValues == null))
                {
                    this.mVerifyDownloadAllCampaignsWithAdsExpectedValues = new VerifyDownloadAllCampaignsWithAdsExpectedValues();
                }
                return this.mVerifyDownloadAllCampaignsWithAdsExpectedValues;
            }
        }

        private VerifyDownloadAllCampaignsWithAdsExpectedValues mVerifyDownloadAllCampaignsWithAdsExpectedValues;

        /// <summary>
        /// VerifyDownloadOneCampaignWithSeveralAds - Use 'VerifyDownloadOneCampaignWithSeveralAdsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void VerifyDownloadOneCampaignWithSeveralAds(string campaignName)
        {
            #region Variable Declarations
            WinCell uICampaignsdownloadedsCell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow0Row1.UICampaignsdownloadedsCell;
            WinCell uIAdsdownloadedsofar5Cell = this.UIDetailedInfoforDownlWindow.UISageGridViewInfoWindow.UIDataGridViewTable.UIRow1Row7.UIAdsdownloadedsofar5Cell;
            #endregion

            // Verify that 'haih@ad-sage.com #46848300(USD)->JJN23PRzg' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)->JJN23PRzg'
            Assert.AreEqual(this.VerifyDownloadOneCampaignOneAdExpectedValues.UIHaihadsagecom4684830CellValue + campaignName, this.UIDataGridViewTableForJob.GetAccountNameCellValue());

            // Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
            Assert.AreEqual(this.VerifyDownloadOneCampaignWithSeveralAdsExpectedValues.UICampaignsdownloadedsCellValue, uICampaignsdownloadedsCell.Value);

            // Verify that 'Ads downloaded so far: 6' cell's property 'Value' equals 'Ads downloaded so far: 6'
            Assert.AreEqual(this.VerifyDownloadOneCampaignWithSeveralAdsExpectedValues.UIAdsdownloadedsofar5CellValue, uIAdsdownloadedsofar5Cell.Value);
        }

        public virtual VerifyDownloadOneCampaignWithSeveralAdsExpectedValues VerifyDownloadOneCampaignWithSeveralAdsExpectedValues
        {
            get
            {
                if ((this.mVerifyDownloadOneCampaignWithSeveralAdsExpectedValues == null))
                {
                    this.mVerifyDownloadOneCampaignWithSeveralAdsExpectedValues = new VerifyDownloadOneCampaignWithSeveralAdsExpectedValues();
                }
                return this.mVerifyDownloadOneCampaignWithSeveralAdsExpectedValues;
            }
        }

        private VerifyDownloadOneCampaignWithSeveralAdsExpectedValues mVerifyDownloadOneCampaignWithSeveralAdsExpectedValues;
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
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
            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl statusCell = cells[1];
            statusCell.WaitForControlPropertyEqual(WinCell.PropertyNames.Value, statusValue, 1000 * 60 * 5);
        }

        public string GetAccountNameCellValue()
        {
            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl accountNameCell = cells[0];
            return accountNameCell.GetProperty(WinCell.PropertyNames.Value).ToString();
        }

        private UITestControlCollection GetCellsFromFirstRow(UITestControlCollection rows)
        {
            if (rows.Count < 1)
            {
                throw new Exception("There is no account information in job grid view!");
            }
            WinRow firstRow = rows[0] as WinRow;
            Assert.AreEqual(3, firstRow.Cells.Count, "The count of cell in job grid view should be equal to 3!");
            return firstRow.Cells;
        }


        public void WaitForPerformanceStatusPropertyEqual(string statusValue)
        {
            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl statusCell = cells[2];
            statusCell.WaitForControlPropertyEqual(WinCell.PropertyNames.Value, statusValue, 1000 * 60 * 5);
        }

        public string GetDateRangeCellValue()
        {
            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl dateRangeCell = cells[1];
            return dateRangeCell.GetProperty(WinCell.PropertyNames.Value).ToString();
        }

        public void WaitingForStatusPropertyEqual(string statusValue)
        {
            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl statusCell = cells[2];
            statusCell.WaitForControlPropertyEqual(WinCell.PropertyNames.Value, statusValue, 1000 * 60 * 23);
        }

        public void WaitingForStatusEqual(string statusValue, DetailedInfoForDownload detailedInfoForDownloadWindow)
        {
            int retryTimes = 5;
            int timeSpan = 1000 *60 * 5;
            int timer = 0;
            int limitedTime = 1000 * 60 * 30;

            UITestControlCollection cells = GetCellsFromFirstRow(this.Rows);
            UITestControl statusCell = cells[2];

            do
            {
                statusCell.WaitForControlPropertyEqual(WinCell.PropertyNames.Value, statusValue, timeSpan);
                timer += timeSpan;
            } while ((retryTimes--) != 0 && (timer < limitedTime));

            Common.UITestFramework.UIMaps.QuestionWindowClasses.QuestionWindow questionWindow = new QuestionWindow();
            questionWindow.UIQuestionWindow.WaitForControlExist();
            if (retryTimes == 0 || timer > limitedTime)
            {
                detailedInfoForDownloadWindow.ClickingCancelButton();
                questionWindow.ClickYesButton();
                questionWindow.UIQuestionWindow.WaitForControlNotExist();
            }
            else
            {
                return;
            }
        }
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
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

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UIRow0Row1ForJob : WinRow
    {

        public UIRow0Row1ForJob(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinRow.PropertyNames.Value] = "haih@ad-sage.com #46848300(USD)->jrjwpUA;Finished;(null)";
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
                    this.mUIHaihadsagecom4684830Cell.SearchProperties[WinCell.PropertyNames.Value] = "haih@ad-sage.com #46848300(USD)->jrjwpUA";
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
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaign'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignExpectedValues
    {
        #region Fields
        /// <summary>
        /// Verify that 'haih@ad-sage.com #46848300(USD)->UFUcx' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)->UFUcx'
        /// </summary>
        public string UIHaihadsagecom4684830CellValue = ConfigurationManager.AppSettings["AccountName"] + "->";

        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad downloaded so far: 0' cell's property 'Value' equals 'Ad downloaded so far: 0'
        /// </summary>
        public string UIAddownloadedsofar0CellValue = "Ads downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAd'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'haih@ad-sage.com #46848300(USD)->JJN23PRzg' cell's property 'Value' equals 'haih@ad-sage.com #46848300(USD)->JJN23PRzg'
        /// </summary>
        public string UIHaihadsagecom4684830CellValue = ConfigurationManager.AppSettings["AccountName"] + "->";

        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad downloaded so far: 1' cell's property 'Value' equals 'Ad downloaded so far: 1'
        /// </summary>
        public string UIAddownloadedsofar1CellValue = "Ads downloaded so far: 1";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignForGoogle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignForGoogleExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 0' cell's property 'Value' equals 'Ad groups downloaded so far: 0'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 0";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 0";

        /// <summary>
        /// Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
        /// </summary>
        public string UIPlacementsdownloadedCellValue = "Placements downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdForGoogle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdForGoogleExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Row 0' row's property 'Value' equals 'System.Drawing.Bitmap;Campaigns downloaded so far: 1'
        /// </summary>
        public string UIRow0RowValue = "System.Drawing.Bitmap;Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Row 1' row's property 'Value' equals 'System.Drawing.Bitmap;Ad groups downloaded so far: 1'
        /// </summary>
        public string UIRow1RowValue = "System.Drawing.Bitmap;Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Row 2' row's property 'Value' equals 'System.Drawing.Bitmap;Keywords downloaded so far: 0'
        /// </summary>
        public string UIRow2Row1Value = "System.Drawing.Bitmap;Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Row 3' row's property 'Value' equals 'System.Drawing.Bitmap;Text ads downloaded so far: 0'
        /// </summary>
        public string UIRow3Row1Value = "System.Drawing.Bitmap;Text ads downloaded so far: 0";

        /// <summary>
        /// Verify that 'Row 4' row's property 'Value' equals 'System.Drawing.Bitmap;Placements downloaded so far: 0'
        /// </summary>
        public string UIRow4Row1Value = "System.Drawing.Bitmap;Placements downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdGroupOneTextAdForGoogleExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 1";

        /// <summary>
        /// Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
        /// </summary>
        public string UIPlacementsdownloadedCellValue = "Placements downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForGoogleExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 1' cell's property 'Value' equals 'Keywords downloaded so far: 1'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 1";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 1";

        /// <summary>
        /// Verify that 'Placements downloaded so far: 0' cell's property 'Value' equals 'Placements downloaded so far: 0'
        /// </summary>
        public string UIPlacementsdownloadedCellValue = "Placements downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignForAdCenter'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignForAdCenterExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 0' cell's property 'Value' equals 'Ad groups downloaded so far: 0'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 0";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdForAdCenter'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdForAdCenterExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 0' cell's property 'Value' equals 'Text ads downloaded so far: 0'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 0";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenter'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignOneAdGroupOneTextAdForAdCenterExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 0' cell's property 'Value' equals 'Keywords downloaded so far: 0'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 0";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 1";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenter'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class VerifyDownloadOneCampaignOneAdGroupOneTextAdOneKeywordForAdCenterExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ad groups downloaded so far: 1' cell's property 'Value' equals 'Ad groups downloaded so far: 1'
        /// </summary>
        public string UIAdgroupsdownloadedsoCellValue = "Ad groups downloaded so far: 1";

        /// <summary>
        /// Verify that 'Keywords downloaded so far: 1' cell's property 'Value' equals 'Keywords downloaded so far: 1'
        /// </summary>
        public string UIKeywordsdownloadedsoCellValue = "Keywords downloaded so far: 1";

        /// <summary>
        /// Verify that 'Text ads downloaded so far: 1' cell's property 'Value' equals 'Text ads downloaded so far: 1'
        /// </summary>
        public string UITextadsdownloadedsofCellValue = "Text ads downloaded so far: 1";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadFourCampaignWithAds'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class VerifyDownloadFourCampaignWithAdsExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Account2 #348004880(USD)' cell's property 'Value' equals 'Account2 #348004880(USD)'
        /// </summary>
        public string UIAccount2348004880USDCellValue = "Account2 #348004880(USD)";

        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 4' cell's property 'Value' equals 'Campaigns downloaded so far: 4'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 4";

        /// <summary>
        /// Verify that 'Ads downloaded so far: 13' cell's property 'Value' equals 'Ads downloaded so far: 13'
        /// </summary>
        public string UIAdsdownloadedsofar13CellValue = "Ads downloaded so far: 13";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadPerformanceData'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class VerifyDownloadPerformanceDataExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Downloading performance data.'
        /// </summary>
        public string UIAccount2348004880USDCellValue = "Account2 #348004880(USD)(";
        public string downloadInfo1 = "):Downloading performance data.";

        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Downloading performance data complete.'
        /// </summary>
        public string UIAccount2348004880USDCellValue1 = "Account2 #348004880(USD)(";
        public string downloadInfo2 = "):Downloading performance data complete.";

        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Im...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Importing performance data.'
        /// </summary>
        public string UIAccount2348004880USDCellValue2 = "Account2 #348004880(USD)(";
        public string downloadInfo3 = "):Importing performance data.";

        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Im...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Importing performance data complete.'
        /// </summary>
        public string UIAccount2348004880USDCellValue3 = "Account2 #348004880(USD)(";
        public string downloadInfo4 = "):Importing performance data complete.";

        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Pe...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Performance data processed.'
        /// </summary>
        public string UIAccount2348004880USDCellValue4 = "Account2 #348004880(USD)(";
        public string downloadInfo5 = "):Performance data processed.";

        /// <summary>
        /// Verify that 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Do...' cell's property 'Value' equals 'Account2 #348004880(USD)(01/04/2012-01/04/2012):Download process completed.'
        /// </summary>
        public string UIAccount2348004880USDCellValue5 = "Account2 #348004880(USD)(";
        public string downloadInfo6 = "):Download process completed.";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadAllCampaignsWithAds'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadAllCampaignsWithAdsExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 105' cell's property 'Value' is not equal to 'Campaigns downloaded so far: 0'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 0";

        /// <summary>
        /// Verify that 'Ads downloaded so far: 533' cell's property 'Value' is not equal to 'Ads downloaded so far: 0'
        /// </summary>
        public string UIAdsdownloadedsofar53CellValue = "Ads downloaded so far: 0";
        #endregion
}
    /// <summary>
    /// Parameters to be passed into 'VerifyDownloadOneCampaignWithSeveralAds'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class VerifyDownloadOneCampaignWithSeveralAdsExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Campaigns downloaded so far: 1' cell's property 'Value' equals 'Campaigns downloaded so far: 1'
        /// </summary>
        public string UICampaignsdownloadedsCellValue = "Campaigns downloaded so far: 1";

        /// <summary>
        /// Verify that 'Ads downloaded so far: 5' cell's property 'Value' equals 'Ads downloaded so far: 5'
        /// </summary>
        public string UIAdsdownloadedsofar5CellValue = "Ads downloaded so far: 5";
        #endregion
    }
}
