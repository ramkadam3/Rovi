using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Routing;
using AventStack.ExtentReports.Gherkin.Model;
using RovicareTestProject.TestMethods;

namespace RovicareTestProject.Tests.OutgoingChat
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuit_ProviderSelectionList_Outgoing : BaseClass
    {
        [SetUp]                        //included features: Shortlist,patient notification,view patient portal,cancel referral
        public void BrowLaunch()
        {
            BaseClass Base=new BaseClass();
            Driver.Value=Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        //*******************************Test Execution E2E_OutgoingPage Provider_Selection_List****************************************

        [Test ,Order(1)]
        [TestCaseSource("ProviderSelectionListTD")]
        public void ProviderSelectionList(string PatientEmail,string CancelationReason)
        {
            ExtentReports ExtentTestManager = new ExtentReports();
            
            // Navigate to PatientList
            PatientListPOM.NavigateToPatientListPage(Driver.Value);
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            try
            {
                FiltersPOM.ClearFilter_PatientList(Driver.Value);

            }
            catch { }
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
            BaseClass.WaitForSpinnerToDisappear(Driver.Value);
            PatientListPOM.WaitForDummyPatientConfirmation(Driver.Value);
            string PatientName=CommonPOM.GetPatientNameFromList(Driver.Value);


            PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            //Test_ProviderSelectionList TC_001 To verify that paper plane button in patient list page naviagte to shortlist provider page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_001 To verify that paper plane button in patient list page naviagte to shortlist provider page");
                PatientListPOM.ClickSendReferral(Driver.Value, 1);
                Assert.That(true);


                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_001 Paper plane buttone Navigate to Shortlist provider page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_001 Paper plane buttone did not Navigate to Shortlist provider page  Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_ProviderSelectionList TC_002 To verify that can we select single/multiple provider and save that action

            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_002 To verify that can we select single/multiple provider and save that action");
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                for(int i=1; i<=2;i++)
                {

                ShortlistFacilityPOM.ClickOnCheckBox(Driver.Value,i);

                }
                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_002 Success message displayed successfully ,Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_002 Success message displayed successfully ,Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                


                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_002 Single/Multiple provider selected then save that action Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_002 Fail,Single/Multiple provider selection & save that action   Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_003 To verify that Provider selection for a patient getting added into the provider Selection list in Outgoing page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_003 To verify that Provider selection for a patient getting added into the provider Selection list in Outgoing page");
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Thread.Sleep(1000);
                
                
                
             Assert.AreEqual(PatientName.ToLower(),CommonPOM.GetPatientNameFromList(Driver.Value).ToLower());


                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_003 New provider selection gets added to the referral list successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_003 New provider selection not gets added to the referral list  Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_004  To verify that status of provider list is Shortlisted
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_004 To verify that status of provider list is Shortlisted");
                OutgoingPOM.ExpandInnerTable(Driver.Value,1);
                Assert.That( OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Shortlisted"));


                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_004  Status of Respective provider list is Shortlisted");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_004  Status of Respective provider list is not Shortlisted Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_ProviderSelectionList TC_005  To verify that Provider list can send to patient from provider selection page using share button
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_005 To verify that Provider list can send to patient from provider selection page using share button");
                OutgoingPOM.ClickOnSendList_ReferralTable(Driver.Value, 1);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_005  Clicked on send list button");
                Assert.That(OutgoingPOM.CheckSendPreferredListPopUpOpened(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_005  Preferred list send to patient opened successfully");

                OutgoingPOM.EnterPatientEmail_OnPopUp(Driver.Value, PatientEmail);
                OutgoingPOM.ClickOnSendButtonOnPopup_SendListTopatient(Driver.Value);
                Assert.That( BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_005  Success Notification is displaying ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(1000);
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                OutgoingPOM.ExpandInnerTable(Driver.Value,1);



                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_005  Provider list can be shared with patient Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "test_providerselectionlist tc_005  provider list can not be shared with patient error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_providerselectionlist tc_006 to verify that status goes changed to shortlist sent to patient

            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_006 To verify that Status goes changed to Shortlist sent to patient");

                //OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                //OutgoingPOM.WaitForReferralTableToBeClickable(Driver.Value);
                //Thread.Sleep(1000);
                Assert.That( OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Shortlist Sent To Patient"));
               

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_006  Status goes changed to Shortlist sent to patient");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_006  Status did not change Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_007 To verify that "view patients portal" button under action section navigate to a pop up
            try
            {

                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_007 To verify that \"view patients portal\" button under action section navigate to a pop up");
                OutgoingPOM.ClickOnViewPatientPortal_ReferralTable(Driver.Value, 1);
                Assert.That(OutgoingPOM.ClickOnPatientPortalLinkPopUp(Driver.Value).Displayed);//window popup open
               //popup open

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_007  View patient portal button navigate to Pop up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_007  View patient portal button did not navigate to Pop up Error: " + ex);
            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_008 To verify that clicking on displaying url navigate to patient's portal page(Care transition page)

            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_008 To verify that clicking on url navigate to patient's portal page(Care transition page)");
                OutgoingPOM.ClickOnPatientPortalLinkPopUp(Driver.Value).Click();



                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_008  Link on pop up Navigate to Patient's portal page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList tc_008  Link on pop up did not navigate to patient's portal page error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
           // test_providerselectionlist tc_009 to veriify that patient can do action through  button send preference
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_009 To veriify that patient can do action through  button send preference");
                Thread.Sleep(3000);
                List<string> address =new List<string>(Driver.Value.WindowHandles);

                Console.WriteLine(address.Count);
                Driver.Value.SwitchTo().Window(address[1]);
               
                try
                {

                    OutgoingPOM.ClickOnSendPreferenceButton(Driver.Value);
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_009  Success Notification is displaying");
                    Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_009  Patient can do Action through Send Preference button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Driver.Value.Close();
                    Driver.Value.SwitchTo().Window(address[0]);
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_009  Patient can't do Action through Send Preference button Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    Driver.Value.Close();
                    Driver.Value.SwitchTo().Window(address[0]);
                    
                }
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_009  Patient can't do Action through Send Preference button Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_010  To verify that status goes changed to Patient Preference Received in provider selection page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList TC_010  To verify that status goes changed to Patient Preference Received in provider selection page");
                OutgoingPOM.ClosePopup_ViewPatientPortal(Driver.Value);
            Thread.Sleep(1000);
            Assert.That(OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Patient Preference Received"));

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_010  Status changed to Patient Preference Received ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
               
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "test_providerselectionlist tc_010  satus did not changed to patient preference received error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList CancelReferral  To verify that Referral can be canceled by cancel referral action
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelection-CancelReferral-  To verify that Referral can be canceled by cancel referral action");
                

                OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Cancel Referral");
                Test.Value.Log(Status.Pass, "Test_ProviderSelection-CancelReferral- Expand more action and click on cancel referral");
                OutgoingPOM.ProvideCancelationReason(Driver.Value, 4);
               
                if (!OutgoingPOM.ClickSubmitOnCancelationPopUp(Driver.Value).Enabled)
                {

                    OutgoingPOM.EnterNotes_CancelReferralPopUp(Driver.Value, "Referral has been canceled");
                    Test.Value.Log(Status.Pass,"Note provided for other reason" ,CaptureScreenShot(Driver.Value, Filename));
                }
                else 
                { 
                    Test.Value.Log(Status.Pass, "Test_CancelReferral  Referral can be canceled without reason", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(true);
                }
                OutgoingPOM.ClickSubmitOnCancelationPopUp(Driver.Value).Click();    
                Test.Value.Log(Status.Pass, "Test_CancelReferral Status changed to Patient Preference Received ");

                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_CancelReferral  Success Notification is displaying ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_CancelReferral  Unable to cancel referral error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }


            //***********************************FirstFlow_Completed***************************************************

        }

        [Test, Order(2)]
        [TestCaseSource("ProviderSelectionListTD")]
        public static void ProviderSelectionList_SecondFlow(string PatientEmail,string CancelationReason) 
        {
           
            // Navigate to PatientList
            PatientListPOM.NavigateToPatientListPage(Driver.Value);
            Thread.Sleep(2000);
            BaseClass.WaitForSpinnerToDisappear(Driver.Value);
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            try
            {
                FiltersPOM.ClearFilter_PatientList(Driver.Value);

            }
            catch { }
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            string PatientName = CommonPOM.GetPatientNameFromList(Driver.Value);

            //Test_ProviderSelectionList TC_011 To verify that Selection facility button under action section in patient list page navigate to new search page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_011 To verify that Selection facility button under action section in patient list page navigate to new search page");
                PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
                Assert.That(true);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_011  Selection Facility button navigate to New search page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_011  Selection Facility button do not navigate to New search page error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_ProviderSelectionList TC_012 To verify that after providing provider criateria GO button navigate to shortlist provider page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_012 To verify that after providing provider criateria GO button navigate to shortlist provider page");
                
                ShortlistFacilityPOM.SelectProviderTypesInFilter(Driver.Value, "Skilled Nursing(SNF)").Click();
                ShortlistFacilityPOM.SelectServicesNeededInFilter(Driver.Value, new string[] { "Acute Transitional Case Care" });
                ShortlistFacilityPOM.ClickGoButton(Driver.Value);
                
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);  
                
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_012  GO button Navigate to shortlist provider page ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist TC_012 GO button do not navigate to shortlist provider page Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_ProviderSelectionList TC_013 To verify that can we select single/multiple provider  and send to the patient 
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_013 To verify that can we select single/multiple provider  and send to the patient ");
            try
            {
                
                Thread.Sleep(4000);


                
                
                for(int i = 1; i <=2; i++)
                {
                ShortListPOM.SelectProviderShortlisted(Driver.Value, i);

                }
                Thread.Sleep(2000);
                ShortListPOM.ClickTopSendToPatientButton(Driver.Value);
                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_013  Success Notification is displaying");
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_013  Sent Provider list to patient successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist TC_013 Can't Send Provider list to patient Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_ProviderSelectionList TC_014  To verify that provider selection list getting updated with new records in outgoing page
            
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_014 To verify that can we select single/multiple provider  and send to the patient ");


                Thread.Sleep(3000); 
                OutgoingPOM.EnterPatientEmail_OnPopUp(Driver.Value,PatientEmail);
                Thread.Sleep(2000);
                OutgoingPOM.ClickOnSendButtonOnPopup_SendListTopatient(Driver.Value);
                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_014 Success Notification is displaying");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);  
                
                Thread.Sleep(5000);

                

                Assert.AreEqual(PatientName.ToLower(), CommonPOM.GetPatientNameFromList(Driver.Value).ToLower());


                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_014  Provider selection Updated successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist TC_014  Unable to update Provider selection Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_ProviderSelectionList TC_015  To verify that view patients portal button under action section navigate to a pop up
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_014 To verify that view patients portal button under action section navigate to a pop up ");


                OutgoingPOM.ClickOnViewPatientPortal_ReferralTable(Driver.Value, 1);
                Assert.That(true);//popup open
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_015   View Patient portal button navigate to pop up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist TC_015  View Patient portal button do not navigate to pop up Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_ProviderSelectionList TC_016 To verify that clicking on Displayed url navigate to patient's portal page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_016 To verify that clicking on Displayed url navigate to patient's portal page");

                OutgoingPOM.ClickOnPatientPortalLinkPopUp(Driver.Value).Click();
                Assert.That(true);//window popup open

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_016  Link on pop up Navigate to Patient's portal page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist tc_016  link on pop up did not navigate to patient's portal page error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_017 To veriify that patient can do action through save button
            
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_017 To veriify that patient can do action through Save button ce");
                Thread.Sleep(3000);
                List<string> address = new List<string>(Driver.Value.WindowHandles);

                Console.WriteLine(address.Count);
                Driver.Value.SwitchTo().Window(address[1]);


                try
                {
                    OutgoingPOM.ClickOnSavePreferenceButton(Driver.Value);
                    
                    Thread.Sleep(4000);
                    Driver.Value.FindElement(By.XPath("//div[@class='ajs-dialog']/descendant::button[contains(@class,'ok')]")).Click();

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(true);


                    
                    Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_017  Patient can do Action through Save button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Driver.Value.Close();
                    Driver.Value.SwitchTo().Window(address[0]);
                    
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_017  Patient can't do Action through Save button Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    Driver.Value.Close();
                    Driver.Value.SwitchTo().Window(address[0]);
                    Console.WriteLine("Error : "+e);
                }
            }
            catch (Exception ex)
            { 
                Test.Value.Log(Status.Fail, "Test_ProviderSelectionList TC_017  Patient can't do Action through Save button Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                
            }
           
            //Test_ProviderSelectionList TC_018  To verify that status goes changed to Under Patient Review in provider selection page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_018  To verify that status goes changed to Under Patient Review in provider selection page");
                
                Thread.Sleep(4000);
                OutgoingPOM.ClosePopup_ViewPatientPortal(Driver.Value);
                Thread.Sleep(3000);

                OutgoingPOM.ExpandInnerTable(Driver.Value,1);
                Assert.That( OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Under Patient Review"));

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_018  Status changed to Under Patient Review ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
               
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "test_providerselectionlist TC_018  Status did not changed to Under Patient Review error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_ProviderSelectionList TC_021 To verify that cancel button delete the item from list
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_ProviderSelectionList (Second) TC_021  To verify that cancel button delete the item from list");

                OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Cancel Referral");
                // OutgoingPOM.ClickOnCancelReferral_CrossButton(Driver.Value, 1);
                OutgoingPOM.ProvideCancelationReason(Driver.Value, 1);

                OutgoingPOM.ClickSubmitOnCancelationPopUp(Driver.Value).Click();


                
                Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);

                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_021  Success Notification is displaying ");
                Test.Value.Log(Status.Pass, "Test_ProviderSelectionList TC_021  Provider Selection Canceled From List Successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_providerselectionlist TC_021  Provider Selection Could Not Canceled From List Error: " + ex);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Acute Transitional Case Care


        }

//***************************************************TestData_ProviderSelectionList******************************************************
        public static IEnumerable<TestCaseData> ProviderSelectionListTD()
        {
            String Path = GetDataParser().TestData_Path("ProviderSelectionList_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("PatientEmail", Path),
                GetDataParser().TestData("CancelationReason", Path)
                //GetDataParser().TestData("DestinationName", Path)

                );
        }




    }
}
