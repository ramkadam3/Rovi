using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.PatientList
{
    [TestFixture]
    public class TestSuite_SendMultipleReferral:BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test]
        public void SendMultiReferral()
        {
            int NumberOfTimes = 5;
            string ServiceNeeded = "Acute Rehab";
            string ProgrammNeeded = "Adult Women";

            Test.Value = ExtentTestManager.CreateTest("Test_SendMultipleReferral_TC - To verify that load ability of Origin for sending multiple referrals ");
            for (int i = 0; i < NumberOfTimes; i++)
            {
                try
                {
                    // Navigating to Patient Page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);

                    Test.Value.Log(Status.Pass, "Test_SendMultipleReferral_TC, Navigated to Patient Page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



                    // Clicking on Send Referral icon under action items in Patient List
                    PatientListPOM.ClickSendReferral(Driver.Value, 1);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);

                    

                    // Select All providers
                    ShortListPOM.SelectProviderTypesInFilter(Driver.Value, "Skilled Nursing(SNF)");
                    ShortListPOM.ClickGoButtonInFilter(Driver.Value);
                    ShortListPOM.WaitForShortlistTableToBeClickable(Driver.Value);


                    ShortListPOM.SelectAllProvider(Driver.Value);


                    //Check the checkbox next to the provider name
                    Test.Value.Log(Status.Pass, "Test_SendMultipleReferral_TC, All providers have been selected");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    //Click on top orange send referral button
                    ShortListPOM.ClickTopSendReferralButton(Driver.Value);
                    ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                    Test.Value.Log(Status.Pass, "Test_SendMultipleReferral_TC, Clicked on top send referral button");

                    //Select mandatory fields and click on Send button


                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, new string[] { ServiceNeeded });
                    ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, new string[] { ProgrammNeeded });




                    Test.Value.Log(Status.Pass, "Test_SendMultipleReferral_TC, Entered mandatory fields ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    ShortListPOM.ClickSendButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);

                    Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));

                    Test.Value.Log(Status.Pass, "Test_SendMultipleReferral_TC, Clicked on Send button, Referral sent successfully ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "Test_SendMultipleReferral_TC Failed, Referral not received at destination " + ex);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }

        }




    }
}
