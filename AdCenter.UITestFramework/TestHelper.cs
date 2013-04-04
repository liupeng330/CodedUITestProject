using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Common.UITestFramework.Utilities;
using Common.UITestFramework;
using CommonUIMaps = Common.UITestFramework.UIMaps;

namespace AdCenter.UITestFramework
{
    public class TestHelper
    {
        public TestHelper(TestBase testBase)
        {
            this.testBase = testBase;
        }

        private TestBase testBase;

        public void UploadChanges(Action verifyMethod)
        {
            //Upload
            AdCenter.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<AdCenter.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();

            campaignPanel.UploadAccounts();

            //Wait Detailed Info for Upload windows exist
            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload detailedInfoForUploadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.WaitForControlExist();

            //Wait the status column change to "Finished"
            detailedInfoForUploadWindow.UIDataGridViewTableForJob.WaitForStatusPropertyEqual("Finished");

            //Verify information tab
            try
            {
                verifyMethod();
            }
            catch
            {
                detailedInfoForUploadWindow.ClickErrorMessageTab();
                throw;
            }

            //Click close button
            WinButton closeButtonInDetailedInfoForUploadWindow = detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.UICloseWindow.UICloseButton;
            Mouse.Click(closeButtonInDetailedInfoForUploadWindow);

            //Wait Detailed Info for upload windows not exist
            detailedInfoForUploadWindow.UIDetailedInfoforUploaWindow.WaitForControlNotExist();
        }

        public Object.Campaign AddCampaign(string name, Action verifyAction)
        {
            AdCenter.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignUI = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();

            campaignUI.AddCampaign(name);
            AdCenter.UITestFramework.Object.Campaign campaignFromEditPanel = campaignUI.GetCampaignFromEditPanel();

            WinClient gridViewContainer = campaignUI.UIMicrosoftadlabsUSDadWindow6.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = campaignUI.UIMicrosoftadlabsUSDadWindow6.UIItemWindow.UINewItemRowRow;
            WinRow campaignRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, name, out campaignRow), "Fail to get campaign by name in grid view!!");

            AdCenter.UITestFramework.Object.Campaign campaignFromGridView = AdCenter.UITestFramework.Object.Campaign.Parse(campaignRow);
            Assert.IsTrue(campaignFromGridView.Equals(campaignFromEditPanel, true), "GridView: " + campaignFromGridView.ToString() + "--EditPanel: " + campaignFromEditPanel.ToString());

            UploadChanges(verifyAction);
            return campaignFromGridView;
        }

        public AdCenter.UITestFramework.Object.Campaign AddCampaignForInit(RandomData random)
        {
            AdCenter.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignUI = testBase.Get<UIMaps.CampaignsClasses.Campaigns>();
            campaignUI.ClickAddCampaignButton();
            string campaignName = AdCenter.UITestFramework.Object.Campaign.NextCampaignName(random);

            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            return AddCampaign(campaignName, uploadWindow.VerifyUploadOneAdCenterCampaign);
        }

        public AdCenter.UITestFramework.Object.AdGroup AddAdGroup(string name, Action verifyAction)
        {
            AdCenter.UITestFramework.UIMaps.AdGroupsClasses.AdGroups adversiementUI = testBase.Get<AdCenter.UITestFramework.UIMaps.AdGroupsClasses.AdGroups>();
            adversiementUI.AddAdvertisement(name);

            AdCenter.UITestFramework.Object.AdGroup adFromEditPanel = adversiementUI.GetAdFromEditPanel();
            WinClient gridViewContainer = adversiementUI.UIMicrosoftadlabsUSDadWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = adversiementUI.UIMicrosoftadlabsUSDadWindow.UIItemWindow.UINewItemRowRow;
            WinRow adRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, name, out adRow), "Fail to get ad by name in grid view!!");

            AdCenter.UITestFramework.Object.AdGroup adFromGridView = AdCenter.UITestFramework.Object.AdGroup.Parse(adRow);
            Assert.IsTrue(adFromGridView.Equals(adFromEditPanel, true), "GridView: " + adFromGridView.ToString() + "--EditPanel: " + adFromEditPanel.ToString());
            UploadChanges(verifyAction);
            return adFromGridView;
        }

        public Object.AdGroup AddAdGroupForInit(RandomData randomData)
        {
            UIMaps.AdGroupsClasses.AdGroups adversiementUI = testBase.Get<UIMaps.AdGroupsClasses.AdGroups>();
            adversiementUI.ClickAddAdGroupButton();

            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            string adGroupName = Object.AdGroup.NextAdName(randomData);
            return AddAdGroup(adGroupName, uploadWindow.VerifyUploadOneAdCenterAdvertisement);
        }

        public Object.TextAdvertisement AddTextAd(Object.TextAdvertisement textAdObject, Action verifyAction)
        {
            UIMaps.TextAdClasses.TextAd textAdUI = testBase.Get<UIMaps.TextAdClasses.TextAd>();
            textAdUI.AddTextAd(textAdObject);
            textAdUI.VerifyAdPreview(textAdObject);

            AdCenter.UITestFramework.Object.TextAdvertisement textAdObjectFromEditPanel = textAdUI.GetTextAdFromEditPanel(textAdObject.DestinationUrl);

            WinClient gridViewContainer = textAdUI.UIMicrosoftadlabsUSD__Window.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = textAdUI.UIMicrosoftadlabsUSD__Window.UIItemWindow.UINewItemRowRow;
            WinRow textAdRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, textAdObject.Title, out textAdRow), "Fail to get text ad by title in grid view!!");

            AdCenter.UITestFramework.Object.TextAdvertisement textAdFromGridView = AdCenter.UITestFramework.Object.TextAdvertisement.Parse(textAdRow);
            Assert.IsTrue(textAdFromGridView.Equals(textAdObjectFromEditPanel, true), "GridView: " + textAdFromGridView.ToString() + "--EditPanel: " + textAdObjectFromEditPanel.ToString());

            Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<Common.UITestFramework.UIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            UploadChanges(verifyAction);
            return textAdFromGridView;
        }

        public Object.TextAdvertisement AddTextAdforInit(RandomData randomData)
        {
            AdCenter.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = testBase.Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
            textAdUI.ClickAddTextAdButton();

            AdCenter.UITestFramework.Object.TextAdvertisement textAdObject = AdCenter.UITestFramework.Object.TextAdvertisement.NextTextAd(randomData);

            CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            return AddTextAd(textAdObject, uploadWindow.VerifyUploadOneAdCenterTextAd);

        }
    }
}
