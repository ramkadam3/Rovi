using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chromium;

namespace RovicareTestProject.Tests
{
    class ClassFilter : BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test]
        public void Cilter()
        {


            int Count = 0;
            string time = Time.TimeOfDay.ToString("hhmmss");
            string PhoneNumber = "5698321478";
            string FaxNumber = "9865321457";
            string AHCCCSID = "89657412";
            string Street = $"M.G.Road{time}";
            string City = "M.G.City";
            string State = "AZ";
            string Zipcode = "85264";
            string Description = "Add_Organization";
            string MembEmail = $"DemoClient{time}@interbizconsulting.com";
            string MembFirstName = "Admindemo";
            string Email = "demo.emailid321@gmail.com";
            //string ServicesOffered = "Acute Rehab|Companion Care|Attendant Care";
            string patientName = "";
            string OrganizationName = $"DemoClient{time}";
            string ServicesOffered = "Acupuncture|Alzheimer or Dementia|Case management";
            string DestinationName = "Chandler Post Acute And Rehabilitation";
            //try
            //{

            //    string[] Services = ServicesOffered.Split("|");
            //    Count++;
            //    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the Send referral reflected in new organization");
            //    try
            //    {

            //        PatientListPOM.NavigateToPatientListPage(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Navigate to patient list page");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        // PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on dummy patient button");

            //        WaitForSpinnerToDisappear(Driver.Value);

            //        //Assert.That(Success_Notification(Driver.Value).Displayed);
            //        Test.Value.Log(Status.Pass, "Success notification displaying successfully");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        try
            //        {

            //            CommonPOM.CheckInvisibilityNoRecordsFound(Driver.Value);

                        
            //        }
            //        catch { }
            //        patientName = CommonPOM.GetPatientNameFromList(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Dummy patient created successfully");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //    }
            //    catch (Exception e)
            //    {
            //        Test.Value.Log(Status.Fail, "Unable to create dummy patient  Error: " + e);
            //        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //    }



            //    try
            //    {

            //        PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
            //        Test.Value.Log(Status.Pass, "Click on shortlist filter button");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        WaitForSpinnerToDisappear(Driver.Value);
            //        //Driver.Value.Navigate().Refresh();
            //        //     WaitForSpinnerToDisappear(Driver.Value);


            //        ShortlistFacilityPOM.SelectProviderTypesInFilter(Driver.Value, "Skilled Nursing(SNF)");
            //        Test.Value.Log(Status.Pass, "Select provider type from filter");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        ShortlistFacilityPOM.ClickGoButton(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on Go button");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        WaitForSpinnerToDisappear(Driver.Value);
            //        ShortListPOM.SelectProviderForReferralByName(Driver.Value, DestinationName,"ImageType");  //////Correction
            //        Test.Value.Log(Status.Pass, "Provider selected as destination");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            //        ShortListPOM.ClickOnSendReferral(Driver.Value);

            //        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on send referral button");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, Services);
            //        Test.Value.Log(Status.Pass, "Select service needed");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        ShortListPOM.ClickSendButton(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on send button on referral dialogue");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        try
            //        {
            //            Assert.That(Success_Notification(Driver.Value).Displayed);
            //            Test.Value.Log(Status.Pass, "Referral send successfully");
            //            Test.Value.Log(Status.Pass, "Success notification displaying successfully");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //            WaitForSpinnerToDisappear(Driver.Value);
            //        }
            //        catch
            //        {

            //            try
            //            {
            //                if (ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Displayed)
            //                {
            //                    ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
            //                    Test.Value.Log(Status.Pass, "Click on continue without sharing successfully");
            //                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //                    Assert.That(Success_Notification(Driver.Value).Displayed);                                   //Correction
            //                    WaitForSpinnerToDisappear(Driver.Value);
            //                    Test.Value.Log(Status.Pass, "Success notification displaying successfully");
            //                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //                }

            //            }
            //            catch (Exception e)
            //            {
            //                Test.Value.Log(Status.Fail, "Failed continue without sharing Error: " + e);
            //                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //            }


            //        }
            //    }
            //    catch (Exception e)

            //    {

            //        Test.Value.Log(Status.Fail, "Failed Validation of send referral Error: " + e);
            //        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            //    }



            //    try
            //    {

            //        Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization - Response to referral : reject");

            //        OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Navigate to outgoing page ");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            //        try
            //        {
            //            Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).ToLower().Contains(patientName.ToLower()));
            //            Test.Value.Log(Status.Pass, "Referral displaying in outgoing page ");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        }
            //        catch (Exception e)
            //        {
            //            Test.Value.Log(Status.Fail, "Referral is not displaying on outgoing page Error: " + e);
            //            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //        }
            //        OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
            //        Test.Value.Log(Status.Pass, "Expand inner table");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        OutgoingPOM.ClickOnRespondToReferralbutton_UnderInnerTable(Driver.Value, 1);
            //        Test.Value.Log(Status.Pass, "Click on response to referral button");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        try
            //        {
            //            Assert.That(ReferralResponsePopupPOM.CheckReferralResponsePopupToOpenUp(Driver.Value));
            //            Test.Value.Log(Status.Pass, "Referral response popup opened ");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            //            ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, "Reject");
            //        }
            //        catch (Exception e)
            //        {
            //            Test.Value.Log(Status.Fail, "Unable to navigate to response to referral popup Error:  " + e);
            //            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //        }

            //        try
            //        {
            //            if (ReferralResponsePopupPOM.CheckRejectionReasonField(Driver.Value).Displayed)
            //            {
            //                ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
            //                Test.Value.Log(Status.Pass, "Rejection reason entered");
            //                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //            }
            //        }
            //        catch
            //        { }

            //        ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on submit button");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        WaitForSpinnerToDisappear(Driver.Value);
            //    }
            //    catch (Exception e)
            //    {
            //        Test.Value.Log(Status.Fail, "Unable respond referral  Error: " + e);
            //        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //    }




            //    //To Verify that Resend Referral reflects in new organization
            //    try
            //    {
            //        Count++;
            //        Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Resend Referral reflects in new organization");

            //        OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
            //        Test.Value.Log(Status.Pass, "Hover more action feature");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            //        OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Resend Referral");
            //        Test.Value.Log(Status.Pass, "Select Resend Referral");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        WaitForSpinnerToDisappear(Driver.Value);
            //        CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            //        ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, Services);
            //        Test.Value.Log(Status.Pass, "Select service needed");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        ShortListPOM.ClickSendButton(Driver.Value);
            //        Test.Value.Log(Status.Pass, "Click on send button on send referral dialogue");
            //        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



            //        try
            //        {
            //            Assert.That(Success_Notification(Driver.Value).Displayed);
            //            Test.Value.Log(Status.Pass, "Succcess notification displaying successfully");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //            WaitForSpinnerToDisappear(Driver.Value);
            //        }
            //        catch
            //        {

            //            try
            //            {
            //                if (ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Displayed)
            //                {
            //                    ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
            //                    Test.Value.Log(Status.Pass, "Click on continue without sharing");
            //                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //                    Assert.That(Success_Notification(Driver.Value).Displayed);
            //                    WaitForSpinnerToDisappear(Driver.Value);
            //                    Test.Value.Log(Status.Pass, "Succcess notification displaying successfully");
            //                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            //                }

            //            }
            //            catch (Exception e)
            //            {
            //                Test.Value.Log(Status.Fail, "Unable to Continue without sharing  Error: " + e);
            //                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //            }
            //        }


            //        try
            //        {

            //            OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
            //            CommonPOM.WaitForTableToGetLoaded(Driver.Value);                        //Correction
            //            Test.Value.Log(Status.Pass, "Navigate to outgoing page");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            //            OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
            //            Test.Value.Log(Status.Pass, "Expand inner table");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //            Assert.That(OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Not Responded"));
            //            Test.Value.Log(Status.Pass, "Validate status successfully");
            //            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            //        }
            //        catch (Exception e)
            //        {
            //            Test.Value.Log(Status.Fail, "Status validation failed Error: " + e);
            //            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //        }

            //    }
            //    catch (Exception e)
            //    {
            //        Test.Value.Log(Status.Fail, "validation of Resend Referral failed Error: " + e);
            //        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            //    }

            //    //To Verify that Show Reports feature reflects in new organization
                

            //}
            //catch { }

            try 
            {
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Resend Referral reflects in new organization");
                LoginPOM.LogOutAccount(Driver.Value);
                Test.Value.Log(Status.Pass, "Logging out super-admin profile");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Driver.Value.Close();

                ChromiumMobileEmulationDeviceSettings.Equals("deviceName", "iPhone SE");
                ChromeOptions chromeCapabilities = new ChromeOptions();
                chromeCapabilities.EnableMobileEmulation("iPhone SE");  //848_859
                 Driver.Value= new ChromeDriver(chromeCapabilities);
                Driver.Value.Manage().Window.Maximize();
                Driver.Value.Navigate().GoToUrl(Test_url);
                //AssertSearchElement();
                LoginPOM.EnterUsername(Driver.Value, Origin_Email);
                LoginPOM.EnterPassword(Driver.Value, Origin_Password);
                 Test.Value.Log(Status.Pass, "Provide UserName and PassWord");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                LoginPOM.ClickOnSignInButton(Driver.Value,true);
                 Test.Value.Log(Status.Pass, "Click on sign-in button");
                //Thread.Sleep(10000);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



            }
            catch { }
        }
    }
}
