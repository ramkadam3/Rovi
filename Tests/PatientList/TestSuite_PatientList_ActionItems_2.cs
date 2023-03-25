using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System.Drawing.Drawing2D;
using System.Runtime.ConstrainedExecution;
                                            

namespace RovicareTestProject.Tests.PatientList
{
                                                                       //Contains Import-patient,ScheduleTransport
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_PatientList_ActionItems_2 : BaseClass
    {
        [SetUp]
        public void SetUpe ()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value,Origin_Email,Origin_Password);
        }

        //***************************************** Test Execution  *********************************************************//

        [Test, Order(1)]
        [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("ScheduleTransport_TD")]
        public void Test_PatientList_ScheduleTransport(
            String ProviderName,
            String ReferralType,
            String ProviderType,
            String PreAuthorization,
            String ServicesNeeded,
            String SpecialPrograms,
            String Note,
            String UpdatedNote,
            String AcceptReject,
            String AppointmentDateTime_Origin,
            String UpdateAppointmentDateTime_Origin,
            String InsuranceAuthorizationStatus,
            String UpdateAppointmentDateTime_Destination)

        {
            try
            {
                //First create dummy patient and referral
                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                try {
                    FiltersPOM.ClearFilter_PatientList(Driver.Value);
                }
                catch { }
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                CommonPOM.CreateDummyReferralSend(Driver.Value, ProviderName, ReferralType);
                string PatientName=CommonPOM.GetPatientNameFromList(Driver.Value);
                
                try
                {
                    //Navigate to outgoing page - Verify that the new patient is showing up in outgoing page
                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try
                    {
                        FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                    }
                    catch { }
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000, Navigated to Outgoing Page ");

                    //Click on respond to referral button
                    OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                    OutgoingPOM.ClickOnRespondToReferralbutton_UnderInnerTable(Driver.Value, 1);
                    
                    Assert.That(ReferralResponsePopupPOM.CheckReferralResponsePopupToOpenUp(Driver.Value));
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000, Verified that Respond to referral pop up comes up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_000, " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                try
                {
                    //Enter mandatory fields and click on submit
                    ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, AcceptReject);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000, Selected Accept Patient Radio Button ");
                    if (ReferralType == "Outpatient")
                    {
                        if (AcceptReject == "accept")
                        {
                            Thread.Sleep(500);
                            ReferralResponsePopupPOM.EnterAppointmentDate(Driver.Value, AppointmentDateTime_Origin);
                            Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000, Entered Appointment Date", CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(500);
                            Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000, Selected Insurance Authorization Status successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        else
                        {
                            ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
                            Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000,Referral Cancelled successfully ", CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    else 
                    {
                        if (AcceptReject == "accept")
                        { }
                        else
                        {
                            ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
                            Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000,Referral Cancelled successfully ", CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    ReferralResponsePopupPOM.SelectInsuranceAuthorizationStatus(Driver.Value, InsuranceAuthorizationStatus);
                    ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_000,Responded to Referral successfully ", CaptureScreenShot(Driver.Value, Filename));
                   
                    OutgoingPOM.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(2000);
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_000 Failed, Unable to fill up mandatory fields in confirm referral pop up" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                /***********************************************E2E_ImportPatient_TC_001***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_001 - To verify that Arrange transport pop up comes up after clicking on arrange transport button at ORIGIN side");

                try
                {
                    //Click on confirm referral and click on submit button in the pop up
                    // Verify Arrange Transport button appears
                    //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id='Referrals']/descendant::tr[2]/descendant::action/descendant::button[contains(@title,'Transport')][1]")));
                    Assert.That(OutgoingPOM.ClickOnTransportAction(Driver.Value, 1).Displayed);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_001, Arrange transport button available in the action section");
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_001 Failed, Arrange transport button not available in the action section,  Screenshot:" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //Click on Arrange Transport button - Arrange Transport pop up will appear

                try
                {
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_001, Verified that Arrange transport pop up comes up after clicking on arrange transport button at ORIGIN side successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    OutgoingPOM.ClickOnTransportAction(Driver.Value, 1).Click();
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_001, Clicked on Arrange Transport successfully ");
                    
                    Assert.That(OutgoingPOM.CheckArrangeTransportPOPup(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_001, Verified that Arrange Transport pop ups successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_001 Failed, Arrange Transport pop up is not visible" + ex, CaptureScreenShot(Driver.Value, Filename)); }


                /***********************************************E2E_ImportPatient_TC_002***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_002 - To verify that Arrange transport pop up allow origin user to only add present or future date for appointment at ORIGIN side");
                DateTime Date = DateTime.Now;
               
                try
                {
                    //Select Date Time and enter notes
                    OutgoingPOM.EnterAppointmentDate_ArrangeTransportPopUp(Driver.Value,"Today");
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_002, Entered Appointment Date successfully");
                    OutgoingPOM.EnterNotes_ArrangeTransportPopUp(Driver.Value, Note);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_002, Entered Note successfully ", CaptureScreenShot(Driver.Value, Filename));
                    OutgoingPOM.ClickOnSubmitButton_ArrangeTransportPopUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_002, Clicked on Submit button successfully");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_002, Success message displayed successfully ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_002 Failed, Unable Scheduled Transport " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                
                
                /***********************************************  E2E_ScheduleTransport_TC_003    ***********************************************/
                
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_003 - To verify that status changes to Transport Scheduled after scheduling transport, ");
                
                try
                {
                    //Status will update to Transport Scheduled 


                    Assert.That(OutgoingPOM.CheckTransportScheduledStatus(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_003, Verified that Status got updated to Transport Scheduled successfully "); 

                    string datee = Date.ToString("MM-dd-yyyy");
                    Assert.That(OutgoingPOM.CheckDateofTransport_RequestTimeColumn(Driver.Value, datee).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_003, Verified that Appointment Date is displayed correctly  ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_003 Failed, Unable to update Transport status and date ,  Error: " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                /***********************************************  E2E_ScheduleTransport_TC_004    ***********************************************/
                
                
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_004 - To verify that the Transport can be Edited using the Edit transport button  ");
               
                
                try
                {
                    

                    Assert.That(OutgoingPOM.ClickOnTransportAction(Driver.Value, 1).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_004, Verified that Edit Transport button appears successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_004 Failed, Unable to verify Edit Transport button " + ex, CaptureScreenShot(Driver.Value, Filename)); }


                
                

                try
                {
                    OutgoingPOM.ClickOnTransportAction(Driver.Value, 1).Click();
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_004, Clicked on Edit Transport button successfully");
                    

                    Assert.That(OutgoingPOM.CheckUpdateTransportPOPup(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_004, Verified that Update Pop Up comes up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_004 Failed, Edit Tranport pop up does not come up " + ex, CaptureScreenShot(Driver.Value, Filename)); }


                

                try
                {
                    OutgoingPOM.EnterAppointmentDate_ArrangeTransportPopUp(Driver.Value, "Today+1");
                    OutgoingPOM.EnterNotes_ArrangeTransportPopUp(Driver.Value, UpdatedNote);
                    OutgoingPOM.ClickOn_SubmitButton_UpdateTransportPopUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_004, Appointment Date updated successfully  , Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                   
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_004, The success message shown below successfully , Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    //Confirm Patient pop up will appear
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_004 Failed, Unable to Edit transport  Error: " + ex, CaptureScreenShot(Driver.Value, Filename)); }


                /***********************************************   E2E_ScheduleTransport_TC_005  ***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_005 - To verify that the Edit transport date updated successfully");
                try
                {
                    string datee = Date.AddDays(1).ToString("MM-dd-yyyy");
                    Assert.That(OutgoingPOM.CheckDateofTransport_RequestTimeColumn(Driver.Value, datee).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_005, Verified that Appointment Date is updated under the Status in Outgoing page successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_005 Failed, Unable to update Edit transport date  Error: " + e, CaptureScreenShot(Driver.Value, Filename));
                
                }

                /***********************************************   E2E_ScheduleTransport_TC_006  ***********************************************/
                
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_006 - To verify that new appointment date is getting reflected at DESTINATION side ");

                try
                {
                    //18  Logout and log in with Destination login credentials     
                    LoginPOM.SwitchAccount(Driver.Value, "Destination");
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_006, Successfully logged into Destination's account,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_006, Unable to log out/in " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                
                try
                {
                    // Verify that Incoming page should open up
                    IncomingPOM.NavigateToIncomingPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try
                    {
                        FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                    }
                    catch { }
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_006, Navigated to Incoming page successfully  " , CaptureScreenShot(Driver.Value, Filename));

                    //19	Search with patient name 		Patient should get updated in the result section 	
                    IncomingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                    IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_006, Searched for Patient's Name "+ PatientName +" successfully " , CaptureScreenShot(Driver.Value, Filename));

                    Assert.IsTrue(IncomingPOM.StatusValidationInDestination(Driver.Value, "Transport Scheduled"));
                    Assert.That(IncomingPOM.CheckDateofTransport_RequestTime(Driver.Value, Date.AddDays(1).ToString("MM-dd-yyyy")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_006, Verified that " + Date.AddDays(1).ToString("MM-dd-yyyy") + " is showing under Status successfully");

                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_006, Verified that Status got updated to Transport Scheduled successfully");
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_006 Failed, Unable to verify status Error: " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                

                /***********************************************   E2E_ScheduleTransport_TC_007  ***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_007 - To verify that DESTINATION user can modify the appoinment date/time ");

                try
                {
                    //20	Navigate and Click on the Edit Transport button - Verify that Date/Time got updated at destination side as well - Edit Transfer pop up will come up.
                    IncomingPOM.ClickOn_Transport_ActionItem(Driver.Value, 1).Click();
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_007, Clicked on Edit Transport successfully");
                    Assert.That(IncomingPOM.CheckUpdateTransportPOPup(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_007, Verified that Edit Transport pop up comes up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_010 Failed, Unable to verify Edit transport pop up " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //  21  Change the date / time and click on submit - Date / Time should get updated in the main page as well       TC_010
                try
                {
                    IncomingPOM.SelectPickupDate_EditTransportPopUp(Driver.Value, "Today+2");
                    IncomingPOM.EnterNotes_ArrangeTransportPopUp(Driver.Value, UpdatedNote);
                    Test.Value.Log(Status.Info, $"E2E_ScheduleTransport_TC_007, Updated Date by destination in Edit Transport", CaptureScreenShot(Driver.Value, Filename));
                    IncomingPOM.ClickOn_SubmitButton_UpdateTransportPopUp(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Info, $"E2E_ScheduleTransport_TC_007, Updated Date success message successfully", CaptureScreenShot(Driver.Value, Filename));
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Thread.Sleep(1000);
                    string data=Date.AddDays(2).ToString("MM-dd-yyyy");
                    Assert.That(IncomingPOM.CheckApprovedDateofTransportPOPup(Driver.Value, data).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_007, Verified that PickUp date is display successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_007 Failed, Unable to update pickup date " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                
                /***********************************************   E2E_ScheduleTransport_TC_008  ***********************************************/
                
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_008 - To verify that the modified date/time is getting reflected at the ORIGIN side as well ");
                
                try
                {
                    //  22  Log out and log in back with Origin login credentials Incoming page should open up
                    LoginPOM.SwitchAccount(Driver.Value, "Origin");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(true);
                  
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_008 , Account switched to Origin successfully,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_008 Failed, Unable to logout/Log into Origin account " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                try
                {
                        OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_008, Navigated to outgoing page successfully , Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                    if (CommonPOM.GetPatientNameFromList(Driver.Value) != PatientName)
                    {
                        OutgoingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_008, Searched for patient's name , Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        //  23  Navigate to outgoing page       -Verify that Status date/ time has been updated as well        TC_011

                        Assert.IsTrue(OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Transport Scheduled"));
                        Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_008, Status gor updated successfully");
                        string DateS =OutgoingPOM.CheckRespondedDateOfTransport(Driver.Value, 1, Date.AddDays(2).ToString("MM-dd-yyyy")).Text;
                        Assert.That(true);
                        
                    Test.Value.Log(Status.Info, "E2E_ScheduleTransport_TC_008, Verified that date is changed/updated successfully", CaptureScreenShot(Driver.Value, Filename));
                    
                    

                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_008 Failed, Unable to verify Status/Date in Outgoing page " + ex, CaptureScreenShot(Driver.Value, Filename)); }


                /***********************************************   E2E_ScheduleTransport_TC_009  ***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_009 - To verify that the Transport can be completed using the transport complete feature that appears on the update transport pop-up  ");

                try
                {
                    
                    OutgoingPOM.ClickOnTransportAction(Driver.Value, 1).Click();
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_009, Pop-up opened to complete transport ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    
                    Assert.That(OutgoingPOM.ClickOnCompleteTransport_UpdateTransportPopUp(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_009, Verified that Transport Complete button is visible ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_009 Failed, Unable to verify that Transport Complete button" + ex, CaptureScreenShot(Driver.Value, Filename)); }



                try
                {
                    
                    OutgoingPOM.ClickOnCompleteTransport_UpdateTransportPopUp(Driver.Value).Click();
                    OutgoingPOM.ClickOn_SubmitButton_UpdateTransportPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_009, Clicked on Transport Complete button successfully", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_009, Transport Completed Message Displayed Successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(3000);
                    Assert.That(OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Transport Completed"));

                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_009, Verified That Transport Completed Successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_009, Unable to complete transport " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                
                /***********************************************   E2E_ScheduleTransport_TC_010  ***********************************************/
                Test.Value = ExtentTestManager.CreateTest("E2E_ScheduleTransport_TC_010 - To verify that ORIGIN user can successfully confirm completion of transport ");
                
                try
                {
                    OutgoingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    Assert.That(OutgoingPOM.CheckTransportCompletedSuccessfully(Driver.Value));
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_010, Verified that Transport process Completed successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_010 Failed, Unable to verify transport completion " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                try
                {
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    PatientListPOM.ExpandInnerTable(Driver.Value, 1);
                    Thread.Sleep(600);
                    PatientListPOM.ExpandInnerTableofInnerTable(Driver.Value, 1);
                    Assert.That(PatientListPOM.StatusValidationofTransport(Driver.Value, "Transport Completed"));
                    Test.Value.Log(Status.Pass, "E2E_ScheduleTransport_TC_010, Transport status reflected in patient list page successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "E2E_ScheduleTransport_TC_010 Failed, Unable to verify transport completion in patient list page" + e, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ScheduleTransport Failed, Error:   " + ex, CaptureScreenShot(Driver.Value, Filename)); }
        }

        //***************************************** Test Data *********************************************************//

        public static IEnumerable<TestCaseData> ScheduleTransport_TD()
        {
            String Path = GetDataParser().TestData_Path("ScheduleTransport_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("ProviderName", Path),
                GetDataParser().TestData("ReferralType", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("PreAuthorization", Path),
                GetDataParser().TestData("ServicesNeeded", Path),
                GetDataParser().TestData("SpecialPrograms", Path),
                GetDataParser().TestData("Note", Path),
                GetDataParser().TestData("UpdatedNote", Path),
                GetDataParser().TestData("AcceptReject", Path),
                GetDataParser().TestData("AppointmentDateTime_Origin", Path),
                GetDataParser().TestData("UpdateAppointmentDateTime_Origin", Path),
                GetDataParser().TestData("InsuranceAuthorizationStatus", Path),
                GetDataParser().TestData("UpdateAppointmentDateTime_Destination", Path)

               );
        }

        //***************************************** Test Execution  *********************************************************//

        [Test, Order(2)]
        [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [Author("Ram Kadam")]
        [TestCaseSource("ImportPatient_TD")]
        [TestCaseSource("ImportPatient_TDNegative")]
        public void Test_PatientList_ImportPatient(
            String DataType,
            String FileName,
            String SelectByText,
            String DownloadedFile,
            String UploadFilePath,
            String DownloadedFilePath,
            String RestrictImportMessage
                     )
        {
            try
            {//E2E_ImportPatient_TC_001 - To verify that Import Patient pop up comes up after clicking on Import Patient button



                Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_001 - To verify that Import Patient pop up comes up after clicking on Import Patient button ");
                try
                {
                    //    1   Login with Valid user credentials Incoming Page should get populated
                    //    2   Navigate to Patient List Page Patient List Page should get populated
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try
                    {
                        FiltersPOM.ClearFilter_PatientList(Driver.Value);
                    
                    }
                    catch { }
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    //    3   Click on Import Patient button on the top right side of the page Import Patient pop up should come up
                    PatientListPOM.ClickImportPatientButton(Driver.Value);
                   
                    Assert.That(PatientListPOM.Verify_ImportPatientPopUp_Opened(Driver.Value)); // Import Patient Pop up
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_001 - Import patient pop-up opned successfully", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_001 Failed, Unable to verify Import Patient pop up, Error:  " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                
                


                //E2E_ImportPatient_TC_002 - To verify that Import Patient pop up has Select File , Sample File, Import and Cancel button 


                Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_002 - To verify that Import Patient pop up has Select File , Sample File, Import and Cancel button ");
                try
                {
                    //    4   Navigate to Import Patient Pop up - Verify that Select File, Sample File, Import and Cancel button  are visible
                    Assert.That(PatientListPOM.ClickOn_SelectFileToUpload_ImportPatientPopUp(Driver.Value).Displayed);
                    Assert.That(PatientListPOM.ClickOn_SampleFile_ImportPatientPopUp(Driver.Value).Displayed);
                    Assert.That(PatientListPOM.ClickOn_ImportButton_ImportPatientPopUp(Driver.Value).Displayed);
                    Assert.That(PatientListPOM.ClickOn_CancelButton_ImportPatientPopUp(Driver.Value).Displayed);

                    WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-content/descendant::label[contains(text(),'File Type')]/following::select")));
                    Assert.That(Driver.Value.FindElement(By.XPath("//descendant::mat-dialog-content/descendant::label[contains(text(),'File Type')]/following::select")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_002, Verified that all the components are displayed successfully, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_002 Failed, Unable to find one or more element in the pop up, Error:  " + ex, CaptureScreenShot(Driver.Value, Filename)); }



                //E2E_ImportPatient_TC_003 - To verify that a sample file gets downloaded after clicking on Sample File button 


                Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_003 - To verify that a sample file gets downloaded after clicking on Sample File button ");
                try
                {
                    //String Path = @"C:\Users\User\Downloads";
                    String Path = @DownloadedFilePath;

                    //    5   Click on Sample File link and verify that Sample file gets downloaded

                    PatientListPOM.ClickOn_SelectFileType_ImportPatientPopUp(Driver.Value, SelectByText);
                    Thread.Sleep(300);
                    PatientListPOM.ClickOn_SampleFile_ImportPatientPopUp(Driver.Value).Click();
                    Thread.Sleep(1000);

                    ((IJavaScriptExecutor)Driver.Value).ExecuteScript("window.open();");
                    Driver.Value.SwitchTo().Window(Driver.Value.WindowHandles.Last());

                    IO_Methods.NavigateToDownloadFolder(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_003, Navigate to new tab");

                    Thread.Sleep(1000);
                    

                   

                    if (Directory.Exists(Path))
                    {
                        bool result = IO_Methods.CheckFile(DownloadedFile);
                        if (result == true)
                        {
                            Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_003, Verified that file got downloaded successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        else
                        {
                            Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_003 Failed, Download failed or unable to locate downloaded file ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    Driver.Value.Close();
                  
                   Driver.Value.SwitchTo().Window(Driver.Value.WindowHandles.First());

                    
                    Thread.Sleep(1000);
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_003, Navigate back to main-page");
                     Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_003 Failed, Unable to perform import tasks, Error: " + ex);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    Driver.Value.Navigate().Back();
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_003, Navigate back to main-page", CaptureScreenShot(Driver.Value, Filename));
                }

                
                //E2E_ImportPatient_TC_004 - To verify that file browse pop up comes up after clicking on Select File button
                
                
                Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_004 - To verify that file browse pop up comes up after clicking on Select File button");
                try
                {
                    PatientListPOM.ClickOn_SelectFileType_ImportPatientPopUp(Driver.Value, SelectByText);
                    //    6   Click on Select File button Verify that browse window comes up
                    PatientListPOM.ClickOn_SelectFileToUpload_ImportPatientPopUp(Driver.Value).Click();
                    
                    //    7   Browse and select sample file which got downloaded in step 6        File should uploaded successfully
                    //    8  Browse and select xls, xlsx or csv files File should uploaded successfully
                    HandleOpenDialog hndOpen = new HandleOpenDialog(); 
                    //hndOpen.fileOpenDialog("D:\\testing\\rovicaretesting\\TestData\\ImportPatient_Files", FileName);
                    //hndOpen.fileOpenDialog("C:\\Users\\prata\\Rovicare\\rovicareNew\\rovicaretesting\\TestData\\SuperAdminTD", FileName);
                    string path = @$"{ProjectDirectory}\TestData\ImportPatient_Files";
                    hndOpen.fileOpenDialog(path, $"{FileName}");

                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_004, Verified that the file got uploaded successfully, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                    //    9  Click on import button
                    PatientListPOM.ClickOn_ImportButton_ImportPatientPopUp(Driver.Value).Click();

                    //    - Patient list should get imported successfully
                    //    - Imported successfully message should pop up 

                    if(DataType== "Negative")
                    {try
                        {
                            Assert.That(Success_Notification(Driver.Value).Text.ToLower().Contains(RestrictImportMessage.ToLower()));
                            Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_004, Verified that incorrect file can not be imported,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex)
                        {
                            Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_004, Failed incorrect file can downloaded " + ex, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    else
                    {
                        try
                        {

                    Assert.That(PatientListPOM.Check_ImporsuccessMessage_ImportPatientPopUp(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_004, Verified that success message pop up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch(Exception ex)
                        {
                            Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_004, Failed to validate imported file " + ex, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }

                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_004, Failed to validate imported file " + ex, CaptureScreenShot(Driver.Value, Filename)); }
            }
            catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ImportPatient_TC_001, " + ex, CaptureScreenShot(Driver.Value, Filename)); }

            
            
            //E2E_ImportPatient_TC_005 - To verify Import completed message navigate to import patient details successfully

            

            try
            {

                try
                {
                 Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_005 - To verify Import completed message navigate to import patient details successfully");

                    // BaseClass.Success_Notification(Driver.Value).Click();
                    PatientListPOM.Check_ImporsuccessMessage_ImportPatientPopUp(Driver.Value).Click();
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    Assert.That(PatientListPOM.Check_HeadlineElement_ImportPatientPopUp(Driver.Value).Item1.ToLower().Contains("excel sheet"));
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_005 - Uploaded file type displayed successfully");


                    Assert.AreEqual("completed", PatientListPOM.Check_HeadlineElement_ImportPatientPopUp(Driver.Value).Item2.ToLower());
                    Test.Value.Log(Status.Pass, "E2E_ImportPatient_TC_005 - Import patient status updated successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, $"E2E_ImportPatient_TC_005, Missing some element's on import-patientPOP-UP  Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                IList<string> PatientPassed = PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item1;
                IList<string> PatientExist = PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item2;
                IList<string> PatientFailed = PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item3;



                foreach (var item in PatientPassed)
                {
                    Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_005,'{item}' This Patient imported successfully");
                }
                foreach (var item in PatientExist)
                {
                    Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_005,'{item}' This Patient imported but exist already");
                }
                foreach (var item in PatientFailed)
                {
                    Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_005,'{item}' This Patient import failed");
                }
                try
                {
                    Assert.That(PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item4);
                    Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_005,All headline element's on import-patientPOP-UP displayed correctly  ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
            catch(Exception e)
                {
                    if (DataType == "Negative")
                    {
                        Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_005, Missing some element's on import-patientPOP-UP  Error: " + e);
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    else
                    {
                        Test.Value.Log(Status.Fail, $"E2E_ImportPatient_TC_005, Missing some element's on import-patientPOP-UP  Error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    
                }

                //E2E_ImportPatient_TC_006 - To Verify inner table details in import patient Pop-up
              try
              {
                Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_006 - To Verify inner table details in import patient Pop-up");

                string Gender = PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item5;

                PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item6.Click();
                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Click on edit patient feature ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                    Thread.Sleep(300);
                PatientListPOM.VerifyEditPatientElement_ImportPatientPopUp(Driver.Value).Item1.Click();
                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Edit patient pop-up opened successfully ");
                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Gender changed to Other in Edit patient pop-up  ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                PatientListPOM.VerifyEditPatientElement_ImportPatientPopUp(Driver.Value).Item2.Click();
                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Clicked on Save button");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                Thread.Sleep(1000);
                Assert.AreNotEqual(Gender, PatientListPOM.Check_InnerTableElement_ImportPatientPopUp(Driver.Value).Item5);

                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Patient detailes edited successfully");
                    Thread.Sleep(5000);
                PatientListPOM.ClickOn_Done_ImportPatientPopUp(Driver.Value,"DONE");
                    Thread.Sleep(1000);
                Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, Import Patient pop-up closed ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            
            
              }
               catch(Exception e)
              {
                    if(DataType=="Negative")
                    {
                        Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, This test has been passed for Negative data ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    else
                    {
                    Test.Value.Log(Status.Fail, $"E2E_ImportPatient_TC_006, Unable to edit patient details Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

              }






                //E2E_ImportPatient_TC_007 - To verify that imported patient's were listed in patient list successfully
                try
                {
                    Test.Value = ExtentTestManager.CreateTest("E2E_ImportPatient_TC_007 - To verify that imported patient's were listed in patient list successfully");
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try
                    {
                        FiltersPOM.ClearFilter_PatientList(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                    catch { }


                    foreach (var item in PatientPassed)
                    {
                        
                        PatientListPOM.EnterPatientNameForSearch(Driver.Value, item);
                        PatientListPOM.WaitForReferralTableToBeClickable(Driver.Value);
                        Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).Contains(item));

                        Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_007,'{item}' This Patient imported and listed successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }

                    Thread.Sleep(1000);
                    foreach (var item in PatientExist)
                    {
                        PatientListPOM.EnterPatientNameForSearch(Driver.Value, item);
                        PatientListPOM.WaitForReferralTableToBeClickable(Driver.Value);
                        Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).Contains(item));

                        Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_007,'{item}' This Patient imported but already exist in the patient list");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                catch(Exception e)
                {
                    if (DataType == "Negative")
                    {
                        Test.Value.Log(Status.Pass, $"E2E_ImportPatient_TC_006, This test has been passed for Negative data ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    else
                    {
                        Test.Value.Log(Status.Fail, $"E2E_ImportPatient_TC_007, Unable to list imported patient Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

                }
            }
            catch
            {


            }


        }

        //***************************************** Test Data *********************************************************//

        public static IEnumerable<TestCaseData> ImportPatient_TD()
        { 
            String Path = GetDataParser().TestData_Path("ImportPatientTD");
            yield return new TestCaseData(
                 GetDataParser().TestData("DataType+", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("SelectByText", Path),
                 GetDataParser().TestData("DownloadedFile", Path),
                 GetDataParser().TestData("UploadFilePath", Path),
                  GetDataParser().TestData("DownloadedFilePath", Path),
                 GetDataParser().TestData("DownloadedFilePath", Path)
                 
             


               );
        }
        public static IEnumerable<TestCaseData> ImportPatient_TDNegative()
        {
            String Path = GetDataParser().TestData_Path("ImportPatientTD");
            yield return new TestCaseData(
                
                
                GetDataParser().TestData("DataType-", Path),
                GetDataParser().TestData("FileName-", Path),
                GetDataParser().TestData("SelectByText", Path),
                 GetDataParser().TestData("DownloadedFile", Path),
                 GetDataParser().TestData("UploadFilePath", Path),
                 GetDataParser().TestData("DownloadedFilePath", Path),
                  GetDataParser().TestData("RestrictImportMessage", Path)




               );
        }


        //***************************************** Test Execution  *********************************************************//


        [Test, Order(3)]
        [NUnit.Framework.Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("MedicalRecords_TD")]
        public static void Test_PatientList_AI_MedicalRecords(
            string ModuleName,
            string PatientName,
            string FileName,
            string FilenameForSearch,
            string CategoryName            
            )
        {
            try
            {
                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_001 - To verify that user can add files using add file button ");
                
                try
                {
                    if (ModuleName == "PatientList")
                    { //  2   Navigate to Patient List page Patient List page should come up
                        PatientListPOM.NavigateToPatientListPage(Driver.Value);

                        Assert.That(Driver.Value.FindElement(By.XPath("//a[contains(@title,'Patient List')]")).Displayed);
                        Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_001, Verified that Patient List page comes up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                        try
                        {
                            //  3   Search with the patient name Search result should load up
                            PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                            Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_001, Searched for Patient Name ");
                            PatientListPOM.WaitForResultToLoadUp(Driver.Value);

                            String temp1 = PatientListPOM.GetPatientInfoFromSearchResult(Driver.Value, 1);
                            if (PatientName == temp1)
                            {
                                Assert.That(PatientName, Is.EqualTo(temp1));
                                Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_001, Verified that Patient Name popped up in the search result successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                            }
                            else
                            {
                                Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001 Failed, Unable to validate patient name in search result", CaptureScreenShot(Driver.Value, Filename));
                            }
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001 Failed, Unable to validate patient name in search result" + ex, CaptureScreenShot(Driver.Value, Filename)); }


                        try
                        {
                            String temp = PatientListPOM.GetPatientInfoFromSearchResult(Driver.Value, 1);
                            //  4   Select Medical records under action items       Medical Records Pop up comes up
                            if (PatientName == temp)
                            {
                                PatientListPOM.ClickMedicalRecordAction(Driver.Value, 1);
                                Assert.That(Driver.Value.FindElement(By.XPath("//a[contains(@title,'Patient List')]")).Displayed);
                                Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_001, Verified that Medical Records pop up comes up successfully ");

                            }
                            else
                            {
                                Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, Unable to validate patient name in search result", CaptureScreenShot(Driver.Value, Filename));
                            }
                            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='popup-title ng-star-inserted']")));

                            Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='popup-title ng-star-inserted']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_001, Verified that Medical Records pop up comes up successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, Unable to validate patient name in search result " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                    }

                    else if(ModuleName == "Incoming")
                    {
                        // Navigate to IncomingPage
                        IncomingPOM.NavigateToIncomingPage(Driver.Value);
                        IncomingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                        IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                        Thread.Sleep(1000);
                        IncomingPOM.ClickOriginMedicalRecordAction(Driver.Value, 1);
                        
                        
                    }
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, Patient List does not load properly " + ex, CaptureScreenShot(Driver.Value, Filename)); }

               
                

                try
                {
                    //  5   Click on Add File button - Browse windows should comes up
                    PatientListPOM.ClickOn_AddFileButton_MedicalRecordPopUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_001, Clicked on Add File button successfully ");

                    //  6   Select the files to upload - Files should get uploaded

                    HandleOpenDialog hndOpen = new HandleOpenDialog();
                    hndOpen.fileOpenDialog("D:\\rovicaretesting\\TestData\\ImportPatient_Files", FileName);

                    Assert.That(Driver.Value.FindElement(By.XPath($"//div[@title='{FileName}']//a[@class='cursor-pointer file-name-color']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_001, Verified that the file got uploaded ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, Unable to upload file in medical records " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_002 - To verify that user can save the file ");

                try
                {
                    //  7  Click on Save button  and verify that file got saved successfully
                    PatientListPOM.ClickOn_SaveButton_MedicalRecordPopUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_002, Clicked on Save button successfully ");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    PatientListPOM.ClickMedicalRecordAction(Driver.Value, 1);

                    WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//div[@title='{FileName}']//a[@class='cursor-pointer file-name-color']")));

                    Assert.That(Driver.Value.FindElement(By.XPath($"//div[@title='{FileName}']//a[@class='cursor-pointer file-name-color']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_002, Verified that the file got saved/uploaded successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_002, Unable to verify that the file got saved/uploaded " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_003 - To verify that Search field is present, clickable and accept inputs as per requirement ");

                try
                {
                    // 8	Search the name of the file uploaded 		Verify that Search result should show up 	
                    PatientListPOM.EnterName_SearchField_MedicalRecordPopUp(Driver.Value, FilenameForSearch);
                    WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='tblattachmed']/tbody/tr/td/div[1]/div[1]/div[2]/a")));
                    string temp = Driver.Value.FindElement(By.XPath("//*[@id='tblattachmed']/tbody/tr/td/div[1]/div[1]/div[2]/a")).Text;
                    
                    Assert.That(temp.ToLower(), Is.EqualTo(FileName.ToLower()));
                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_003, Verified that Search field in Medical Records is working successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_003, Search  " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_004 - To verify that catagory field is clickable and value can be selected ");

                try
                {
                    //  9	Clear the search field and select catagory in the Search Field		Verify that Search result should show up 	
                    PatientListPOM.ClearName_SearchField_MedicalRecordPopUp(Driver.Value);
                    PatientListPOM.SelectCategory_SearchField_MedicalRecordPopUp(Driver.Value, CategoryName);
                    WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//table[@id='tblattachmed']//descendant::select[@ng-reflect-model='{CategoryName}']")));
                    Assert.That(Driver.Value.FindElement(By.XPath($"//table[@id='tblattachmed']//descendant::select[@ng-reflect-model='{CategoryName}']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_001, Verified that the search result is showing "+ CategoryName +" successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, Unable to verify that search result" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_005 - To verify that Search criteria can be cleared successfully ");

                try
                {
                    //  10	Clear the search criteria 		Verify that Search criteria is cleared	
                    PatientListPOM.SelectCategory_SearchField_MedicalRecordPopUp(Driver.Value, "All");
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_005, Search criteria cleared ", CaptureScreenShot(Driver.Value, Filename));
                    
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_005, " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_006 - To verify that Edit button is working properly ");

                try
                {
                    //  11	Click on edit button outside the table		Verify that edit options should show up for all the rows of the table	
                    PatientListPOM.ClickOn_EditButton_MedicalRecordPopUp(Driver.Value);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_006, Clicked on top edit button");
                    int count = Driver.Value.FindElements(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']")).Count();
                    Assert.That(Driver.Value.FindElement(By.Id($"editInLineFileName")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::input[@id='editInLineFileName']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::select[@name='EditFileType']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::select[@name='EditShareType']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::i[@class='fa fa-times fa-sm']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::input[@id='EditFileComment']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_006, Verified that edit options is showing up in "+ count + " rows of the table successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_006, Unable to verify edit option after clicking on top edit button " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                Test.Value = ExtentTestManager.CreateTest("E2E_MedicalRecords_TC_007 - To verify that Edit button inside the row is working properly ");

                try
                {
                    //Search for the file name
                    PatientListPOM.EnterName_SearchField_MedicalRecordPopUp(Driver.Value, FilenameForSearch);

                    //  12	Click on edit button under action column		Verify that Edit options should show up only for the that specific row	
                    //PatientListPOM.ClickOnEditButton_ActionColumn_MedicalRecordPopUp(Driver.Value, 1);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Clicked on edit button in the row 1");

                    Assert.That(Driver.Value.FindElement(By.XPath($"//input[@id='editInLineFileName']")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Edit button is clickable");

                    Assert.That(Driver.Value.FindElement(By.XPath($"(//select[@id='EditFileType0'])[1]")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Category button is clickable");

                    Assert.That(Driver.Value.FindElement(By.XPath($"(//select[@id='EditShareType0'])[1]")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Access button is clickable");

                    Assert.That(Driver.Value.FindElement(By.XPath($"//i[@class='fa fa-times fa-sm']")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Cancel Icon is visible");

                    Assert.That(Driver.Value.FindElement(By.XPath($"(//input[@id='EditFileComment'])[1]")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Description field is visible");

                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_007, Verified that all the edit options is getting displayed successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.ClickOnCancelButton_AfterEdit_MedicalRecordPopUp(Driver.Value);
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_007 Failed, Missing edit option " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                try
                {
                    // 


                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_007, Verified that   successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_007 Failed, Missing edit option " + ex, CaptureScreenShot(Driver.Value, Filename)); }


                try
                {
                    //  13	Select the file and click on Delete button		File should get deleted 	
                    PatientListPOM.ClickOnDeleteButton_ActionColumn_MedicalRecordPopUp(Driver.Value, 1);
                    WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input[@id='EditFileComment'])[1]")));
                    Assert.That(Driver.Value.FindElement(By.XPath($"(//input[@id='EditFileComment'])[1]")).Displayed);
                    Test.Value.Log(Status.Info, "E2E_MedicalRecords_TC_007, Description field is visible");

                    Test.Value.Log(Status.Pass, "E2E_MedicalRecords_TC_007, Verified that   successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_007 Failed, Missing edit option " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                

            }
            catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_MedicalRecords_TC_001, " + ex, CaptureScreenShot(Driver.Value, Filename)); }
        }
        //***************************************** Test Data *********************************************************//

        public static IEnumerable<TestCaseData> MedicalRecords_TD()
        {
            String Path = GetDataParser().TestData_Path("MedicalRecords_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("ModuleName", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path)
                
                );
        }
    }
}