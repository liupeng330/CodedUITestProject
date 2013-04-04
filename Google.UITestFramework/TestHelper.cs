using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUIMaps = Common.UITestFramework.UIMaps;
using GoogleFramework = Google.UITestFramework;
using GoogleUIMaps = Google.UITestFramework.UIMaps;
using UIMaps = Common.UITestFramework.UIMaps;
using Common.UITestFramework.Utilities;
using Google.UITestFramework.UIMaps.AdvertisementClasses;
using Common.UITestFramework;

namespace Google.UITestFramework
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
            Google.UITestFramework.UIMaps.CampaignsClasses.Campaigns campaignPanel = testBase.Get<Google.UITestFramework.UIMaps.CampaignsClasses.Campaigns>();
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

        public GoogleFramework.Object.Campaign AddCampaign(string name, Action verifyAction)
        {
            GoogleUIMaps.CampaignsClasses.Campaigns campaignUI = testBase.Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
            campaignUI.AddCampaign(name);

            GoogleFramework.Object.Campaign campaignFromEditPanel = campaignUI.GetCampaignFromEditPanel();
            WinClient gridViewContainer = campaignUI.UIWss_adsagetest163comWindow.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = campaignUI.UIWss_adsagetest163comWindow.UIItemWindow.UIItemTable.UIDataPanelClient.UINewItemRowRow;
            WinRow campaignRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, name, out campaignRow), "Fail to get campaign by name in grid view!!");

            GoogleFramework.Object.Campaign campaignFromGridView = GoogleFramework.Object.Campaign.Parse(campaignRow);
            Assert.IsTrue(campaignFromGridView.Equals(campaignFromEditPanel, true), "GridView: " + campaignFromGridView.ToString() + "--EditPanel: " + campaignFromEditPanel.ToString());
            UploadChanges(verifyAction);
            return campaignFromGridView;
        }

        public GoogleFramework.Object.Campaign AddCampaignForInit(RandomData random)
        {
            GoogleUIMaps.CampaignsClasses.Campaigns campaignUI = testBase.Get<GoogleUIMaps.CampaignsClasses.Campaigns>();
            campaignUI.ClickAddCPMCampaignButton();
            string campaignName = GoogleFramework.Object.Campaign.NextCampaignName(random);

            CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            return AddCampaign(campaignName, uploadWindow.VerifyUploadOneGoogleCampaign);
        }

        public GoogleFramework.Object.AdGroup AddAdGroup(string name, string maxCPMBid, Action verifyAction)
        {
            GoogleUIMaps.AdvertisementClasses.AdGroup adversiementUI = testBase.Get<GoogleUIMaps.AdvertisementClasses.AdGroup>();
            adversiementUI.AddAdvertisement(name, maxCPMBid);

            GoogleFramework.Object.AdGroup adFromEditPanel = adversiementUI.GetAdFromEditPanel();
            WinClient gridViewContainer = adversiementUI.UIWss_adsagetest163comWindow1.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = adversiementUI.UIWss_adsagetest163comWindow1.UIItemWindow.UINewItemRowRow;
            WinRow adRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, name, out adRow), "Fail to get ad by name in grid view!!");

            GoogleFramework.Object.AdGroup adFromGridView = GoogleFramework.Object.AdGroup.Parse(adRow);
            Assert.IsTrue(adFromGridView.Equals(adFromEditPanel, true), "GridView: " + adFromGridView.ToString() + "--EditPanel: " + adFromEditPanel.ToString());
            UploadChanges(verifyAction);
            return adFromGridView;
        }

        public GoogleFramework.Object.AdGroup AddAdGroupForInit(RandomData random)
        {
            GoogleUIMaps.AdvertisementClasses.AdGroup adversiementUI = testBase.Get<GoogleUIMaps.AdvertisementClasses.AdGroup>();
            adversiementUI.ClickAddAdGroupButton();

            CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();

            return AddAdGroup(
                GoogleFramework.Object.AdGroup.NextAdName(random),
                "10.00",
                uploadWindow.VerifyUploadOneGoogleAdvertisement);
        }

        public GoogleFramework.Object.TextAdvertisement AddTextAd(GoogleFramework.Object.TextAdvertisement textAdObject, bool isEdit, Action verifyAction)
        {
            Google.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = testBase.Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
            textAdUI.AddTextAd(textAdObject, isEdit);
            textAdUI.VerifyAdPreview(textAdObject);

            Google.UITestFramework.Object.TextAdvertisement textAdObjectFromEditPanel = textAdUI.GetTextAdFromEditPanel();

            WinClient gridViewContainer = textAdUI.UIWss_adsagetest163comWindow3.UIItemWindow.UIItemTable.UIDataPanelClient;
            WinRow headerRow = textAdUI.UIWss_adsagetest163comWindow3.UIItemWindow.UINewItemRowRow;
            WinRow textAdRow;
            Assert.IsTrue(gridViewContainer.TryGetOneRowByName(headerRow, textAdObject.Headline, out textAdRow), "Fail to get text ad by headline in grid view!!");

            Google.UITestFramework.Object.TextAdvertisement textAdFromGridView = Google.UITestFramework.Object.TextAdvertisement.Parse(textAdRow);
            Assert.IsTrue(textAdFromGridView.Equals(textAdObjectFromEditPanel, true), "GridView: " + textAdFromGridView.ToString() + "--EditPanel: " + textAdObjectFromEditPanel.ToString());

            CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            UploadChanges(verifyAction);
            return textAdFromGridView;
        }

        public GoogleFramework.Object.TextAdvertisement AddTextAdForInit(RandomData random)
        {
            Google.UITestFramework.UIMaps.TextAdClasses.TextAd textAdUI = testBase.Get<UITestFramework.UIMaps.TextAdClasses.TextAd>();
            textAdUI.ClickAddTextAdButton();

            Google.UITestFramework.Object.TextAdvertisement textAdObject = Google.UITestFramework.Object.TextAdvertisement.NextTextAd(random);

            CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload uploadWindow = testBase.Get<CommonUIMaps.DetailedInfoForUploadClasses.DetailedInfoForUpload>();
            return AddTextAd(textAdObject, false, uploadWindow.VerifyUploadOneGoogleTextAd);
        }

    }
}
