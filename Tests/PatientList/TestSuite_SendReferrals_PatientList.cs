using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.PatientList
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_SendReferrals_PatientList:BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test]
        public static void SendReferralFlow()
        {
            string ProviderName= "Terros Health - Mcdowell Health Center";
            string ProviderType= "Skilled Nursing(SNF)";
            string Responsestatus = "Referral Sent";
            string ServicesNeeded = "Acute Transitional Case Care";
            string SpecialPrograms = "Geriatric Psych|Adult Women";
            string Mode = "Fax";
            string Sentstatus = "Success";
            //CommonPOM.CreateDummyReferralSend(Driver.Value, ProviderName);
            OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            string PatientName=CommonPOM.GetPatientNameFromList(Driver.Value);


            try 
            {
                System_Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral  E2E_TC_015  - To verify that a referral report can be generated of sent referral");
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_015 - To verify that a referral report can be generated of sent referral");
                OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - More action has been expandes ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
              
                OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Referral Report");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Assert.That(OutgoingPOM.CheckReferralReportPopUpHeadline(Driver.Value).Text.Contains(PatientName));
                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015,- The referral report Popup opened");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

               
                
                try
                { 
                string Name = OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item1;
                Assert.AreEqual(Name.ToLower(),ProviderName.ToLower());
                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Provider's name present on the pop-up");

                Assert.That(OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item2.Contains(ProviderType));
                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Providers type displayed correctly at the top of the pop-up");
                
                Assert.That(OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item3);
                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Status present correctly on the pop-up");
                    try
                    {
                        foreach (String Service in ServicesNeeded.Split("|"))
                        {
                            String AllText = OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item4;
                            foreach (String Text in AllText.Split(", "))
                            {
                                if (Service == Text)
                                {
                                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015,- Following Service is mentioned in the details: " + Service, CaptureScreenShot(Driver.Value, Filename));
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 -Required Service is not mentioned in the details Error:" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    try
                    {
                        foreach (String Program in SpecialPrograms.Split("|"))
                        {
                            String AllText = OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item5;
                            foreach (String Text in AllText.Split(", "))
                            {
                                if (Program == Text)
                                {
                                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015,- Following Special Programs is mentioned in the details: " + Program, CaptureScreenShot(Driver.Value, Filename));
                                }
                            }
                        }
                    }
                    catch (Exception ex)    
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 -Required program is not mentioned in the details  Error:"+ ex);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 -The referral sent section of the referral report has missing details Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }





            try
                {
                    OutgoingPOM.ClickOnProviderNameInReferralSentSection(Driver.Value, ProviderName);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Clicked to open inner table of report");
                    string Providername = OutgoingPOM.ValidateReferralSentTableElements_ReferralReportPOPUP(Driver.Value, Mode).Item1;
                    Assert.AreEqual(Providername.ToLower(), ProviderName.ToLower());
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Inner-table get opened");
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Provider's name present in report table correctly ");

                    Assert.That(OutgoingPOM.ValidateReferralSentTableElements_ReferralReportPOPUP(Driver.Value, Mode).Item2.Contains(Mode));
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Mode of referral-sent reported correctly ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    if (Mode == "Fax")
                    {

                        Assert.That(OutgoingPOM.ValidateReferralSentTableElements_ReferralReportPOPUP(Driver.Value, Mode).Item3.Contains("InProgress"));
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Status [InProgress] of  referral-sent reported correctly ");
                    }
                    else
                    {
                        Assert.That(OutgoingPOM.ValidateReferralSentTableElements_ReferralReportPOPUP(Driver.Value, Mode).Item3.Contains("Success"));
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Status [Success] of  referral-sent reported correctly ");

                    }
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 -The referral sent section of the referral report has missing details Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }

                //if(Mode=="Fax")
                //{
                //    OutgoingPOM.ValidateReferralSentTableElements_ReferralReportPOPUP(Driver.Value).Item4.Click()
                //    Assert.That(true);
                //    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Fax-file available to download under action section ");

                //}


                try
                {
                    Assert.That(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item1);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Provider's name available in response received section ");
                    string SendDate = OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item2;
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Date of referral-sent '{SendDate}' available in response received section");
                    string RespondDate = OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item3;
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - Date of referral-response '{RespondDate}' available in response received section");
                    Assert.That(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item4);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - The confirmed section available in referral-report");
                    Assert.That(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item5);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - The transport-scheduled section available in referral-report");
                    Assert.That(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item6);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - The discharge section is available in referral-report");
                    Assert.That(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value, ProviderName).Item7);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - The transport completed section available in referral-report");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 - The response received section of the referral report has missing details Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                //(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value).Item1.Contains(action));
                //(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value).Item1.Contains(action));




            }
            catch 
            {
                Test.Value.Log(Status.Fail, $" - Error :" );
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
        }



    }
}
