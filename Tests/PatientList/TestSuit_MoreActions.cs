using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V105.Debugger;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.PatientList
{
    public class TestSuit_MoreActions:BaseClass
    {
      
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test, Order(1)]
        [Author("Ram Kadam"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        public void MoreActionsTest()
        {
            //**********************************************Test_Disable/Enable Referral***************************************************************
          

            try
            {
                int i = 1;
                int Count = 1;
                int Number = 0;
                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                string PatientName = "";
                        
                Number++;
                Test.Value = ExtentTestManager.CreateTest($"Test_DisableReferral-{Number}  To verify that Referral can be disabled by disable referral action");
                while (i <= Count)
                {

                    PatientListPOM.ExpandInnerTable(Driver.Value, Count);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    try

                    {
                        if (PatientListPOM.ClickDisableReferralActionofInnerTable(Driver.Value, Count).Displayed)
                        {
                            Test.Value.Log(Status.Pass, "Test_DisableReferral  Disable referral action available for a patient ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            PatientName = PatientListPOM.GetPatientNameFromList(Driver.Value, Count);
                            PatientListPOM.ClickDisableReferralActionofInnerTable(Driver.Value, Count).Click();
                        }
                        break;

                    }
                    catch
                    {

                        Count++;
                        Test.Value.Log(Status.Pass, "Test_DisableReferral  Disable referral action not available for a patient ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }




                }

                try
                {
                    Number++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_DisableReferral-{Number}  To verify that Referral can be canceled by cancel referral action");



                    Test.Value.Log(Status.Pass, "Test_DisableReferral- Expand more action and click on cancel referral");
                    PatientListPOM.ProvideDisableReason(Driver.Value, 4);

                    if (!PatientListPOM.ClickSubmitOnDisableReferralPopUp(Driver.Value).Enabled)
                    {

                        PatientListPOM.EnterNotes_DisableReferralPopUp(Driver.Value, "Referral has been disabled");
                        Test.Value.Log(Status.Pass, "Test_DisableReferral-Note provided for other reason", CaptureScreenShot(Driver.Value, Filename));
                    }
                    else
                    {
                        Test.Value.Log(Status.Fail, "Test_DisableReferral  Referral can be canceled without reason", CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(false);
                    }
                    PatientListPOM.ClickSubmitOnDisableReferralPopUp(Driver.Value).Click();
                    Test.Value.Log(Status.Pass, "Test_DisableReferral Status changed to Patient Preference Received ");

                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral  Success Notification is displaying ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "Test_DisableReferral  Unable to cancel referral error: " + ex);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {
                    Number++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_DisableReferral-{Number}  To verify that Referral has been disabled successfully");
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.OpenMoreActions(Driver.Value, 1);
                    PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "Referral History").Click();
                    try
                    {
                        Assert.That(PatientListPOM.ClickEnableReferral_ReferralHistoryPOPUp(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Test_DisableReferral  Enable Referral displayed on referral history pop-up ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)

                    {
                        Test.Value.Log(Status.Fail, "Test_DisableReferral  Unable to Enable referral error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    PatientListPOM.ClickEnableReferral_ReferralHistoryPOPUp(Driver.Value).Click();
                    Test.Value.Log(Status.Pass, "Test_DisableReferral  Click on enable referral button");
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral  Success Notification is displaying ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    PatientListPOM.CloseReferralHistoryPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral  Close Referral History pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_DisableReferral  Unable to cancel referral error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    PatientListPOM.CloseReferralHistoryPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral  Close Referral History pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }

            }
            catch { }
   //**********************************************Test_Disable/Enable Referral_End***************************************************************
   //**********************************************Test_Disable/Enable Patient***************************************************************
            
            
            //Test_Disable/EnablePatient-  To verify that Patient can be disabled by desable patient action
            try
            {
                    
                    Test.Value = ExtentTestManager.CreateTest($"Test_DisablePatient-  To verify that Patient can be disabled by desable patient action");
                    PatientListPOM.OpenMoreActions(Driver.Value,1);
                    PatientListPOM.MoreAction_DropDown(Driver.Value,1,"Disable Patient").Click();
                    Test.Value.Log(Status.Pass, "Test_DisableReferral - Click on Disable Patient ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.ClickOnYesButton_ConfirmPOpup(Driver.Value);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral - Confirm Disable Patient");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral - Success Notification displaying successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.Click();
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item2,"Down",2);

                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    Assert.That(PatientListPOM.ClickOnEnablepatient(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Test_DisableReferral - Enable Patient button Available for a patient");
                    Test.Value.Log(Status.Pass, "Test_DisableReferral - Patient Disabled Successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    try
                    {
                    PatientListPOM.ClickOnEnablepatient(Driver.Value).Click();
                        Test.Value.Log(Status.Pass, "Test_DisableReferral - Click on Enable patient button");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        PatientListPOM.ClickOnYesButton_ConfirmPOpup(Driver.Value);
                        Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Test_DisableReferral - Success Notification displaying successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(PatientListPOM.CheckNoRecordsFound(Driver.Value));
                        Test.Value.Log(Status.Pass, "Test_DisableReferral - Patient disabled from screen after enabling");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_DisablePatient  Unable to Enable patient error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    



            } 
           catch (Exception e)
            {

                    Test.Value.Log(Status.Fail, "Test_DisablePatient  Unable to Disable patient error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


            }

            //**********************************************Test_Disable/Enable Patient_End***************************************************************



        }



    }
}
