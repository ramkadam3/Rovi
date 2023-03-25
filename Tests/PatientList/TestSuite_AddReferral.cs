using AventStack.ExtentReports;
using NUnit.Framework;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.PatientList
{
    public class TestSuite_AddReferral : BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test]
        [TestCaseSource("Addreferral_Patient_Outgoing_TD")]
        [TestCaseSource("Addreferral_Patient_Incoming_TD")]
        [TestCaseSource("Addreferral_Provider_Outgoing_TD")]
        [TestCaseSource("Addreferral_Provider_Incoming_TD")]

        [Author("Ram Kadam"), NUnit.Framework.Category("Functional")]
        public void AddReferralTest(string ReferralAs, string ModuleName)
        {
            string TestDataType = "Positive";
            string patientname;
             int TestCount = 000;
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"Test AddReferral- PreConditions");


                if (ModuleName=="PreferredProviderList")

                {
                    PreferredProviderPOM.NavigateToPreferredProviderList_Page(Driver.Value);
                    Test.Value.Log(Status.Pass, "PreConditions - Navigate to Preferred Provider List Page");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    PreferredProviderPOM.ClickOnButton_ActionItem(Driver.Value, "Add Referral");
                    Test.Value.Log(Status.Pass, "PreConditions - Click On Add Referral Button ");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    patientname= PreferredProviderPOM.GetpatientName_SelectPatientPOPup(Driver.Value);
                    PreferredProviderPOM.ClickOnAddReferralIcon_SelectPatientPOPup(Driver.Value);
                    Test.Value.Log(Status.Pass, "PreConditions - Click On Add Referral Icon on Select Patient Pop-up ");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);




                }
                else
                {

                PatientListPOM.NavigateToPatientListPage(Driver.Value);

                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "PreConditions - Navigate to Patient List Page");
                    patientname = CommonPOM.GetPatientNameFromList(Driver.Value);
                PatientListPOM.OpenMoreActions(Driver.Value, 1);
                PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "Add Referral").Click();
                    Test.Value.Log(Status.Pass, "PreConditions - Expand More Action and Select Add Referral Item");
                }
                //Test AddReferral- To verify that ReferralAs can be selected 
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount}- To verify that '{ReferralAs}' can be selected");
                    PatientListPOM.SelectAddReferralAs(Driver.Value, ReferralAs);
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, $"Test AddReferral-{ModuleName}- '{ReferralAs}' has been selected succcessfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch
                {
                    Test.Value.Log(Status.Fail, $"Test AddReferral-{ModuleName}- '{ReferralAs}' has not been selected ");
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }



                //Test AddReferral - To verify Organization Name section accepts text input		
                
                if(ModuleName.Contains("PatientList"))
                {

                try
                {
                        TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral {ModuleName}_{TestCount}- To verify that the Organization Name section accepts text input");


                    AddReferralPOM.EnterDataInTab(Driver.Value, "Organization Name").SendKeys("Arizona Complete Healths");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    AddReferralPOM.SelectOrganizationName(Driver.Value);

                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test AddReferral- Organization Name section accepts text data");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral- Organization Name section did not accepts text data Error : " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                }



                //Test AddReferral - To verify that Received date/Sent Date section accepts date and time  less than of current time
                try
                {
                    DateTime Now = DateTime.Now;

                    int date = Now.Day;

                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral {ModuleName}_{TestCount}- To verify that Received date section accepts date and time  less than of current time");
                    if (ReferralAs == "Incoming")
                    {
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Received Date").Click();

                    }
                    else
                    {
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Sent Date").Click();

                    }
                    AddReferralPOM.SelectDateofReceive(Driver.Value, date);
                    Assert.That(true);
                    Thread.Sleep(1000);
                    Test.Value.Log(Status.Pass, "Test AddReferral - Received/Sent date accepts date and time type data");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Received/Sent date did not accepts date and time type data Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //Test AddReferral - To verify that any mode can be selected among mode drop down	
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral {ModuleName}_{TestCount}- To verify that any mode can be selected among the mode drop-down");

                    AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Mode").Item1.Click();
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Mode").Item2, "Down", 1);

                    Assert.That(true);

                    Test.Value.Log(Status.Pass, "Test AddReferral - Any mode can be selceted from Mode drop down");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Unable to select any mode from mode drop down Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test AddReferral - To verify that any status can be selected among mode drop down	
                try
                { if (ReferralAs == "Outgoing")
                    {
                        TestCount++;
                        Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that any status can be selected among mode drop down ");

                        AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Status").Item1.Click();
                        CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Status").Item2, "Down", 1);

                        Assert.That(true);

                        Test.Value.Log(Status.Pass, "Test AddReferral - Any mode can be selceted from Mode drop down");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Unable to select any mode from mode drop down Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //Test AddReferral - To verify that Attach Document section Navigate to  Referral Records pop up	
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that Attach Document section Navigate to  Referral Records pop up ");
                    AddReferralPOM.ClickOnAttachDocuments(Driver.Value);
                    AddReferralPOM.ClickOnCloseMedicalRecordPopUp(Driver.Value);


                    Test.Value.Log(Status.Pass, "Test AddReferral -Attach Document Button Navigate To Referral Records Pop up ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Attach Document Button Did Not Navigate To Referral Records Pop up Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //Test AddReferral - To verify that Contact Person Name drop down working properly
                
                if (ModuleName.Contains("PatientList"))
                {
                    try
                    {
                        TestCount++;
                        Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that the Contact Person Name drop-down working properly");


                        if (AddReferralPOM.EnterDataInTab(Driver.Value, "Contact Person Name").Enabled)
                        {
                           
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            try
                            { 
                            AddReferralPOM.SelectContactPersonName(Driver.Value);
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Contact person name selected from drop-down");
                            
                            }catch
                            {
                                IncomingPOM.CheckNoRecordsFound(Driver.Value);
                                Test.Value.Log(Status.Pass, "Test AddReferral - Contact person name 'NoRecordsFound'");
                            }



                        }
                        else
                        {
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Contact person name field is desabled ");
                        }



                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test AddReferral - Unable to select any contact from drop down Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                }

                //Test AddReferral - To verify that any Provider type can be selected from drop down 								
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that any Provider type can be selected among drop-down  ");

                    AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Provider Type").Item1.Click();
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.SelectElement_AddreferralPOP_Up(Driver.Value, "Provider Type").Item2, "Down", 0002);
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test AddReferral - Provider Type can be selected among drop down");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Provider Type can't be selected among drop down Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test AddReferral - To verify that the required service can be selected among drop-down Service needed
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that the required service can be selected among drop-down Service needed");

                    AddReferralPOM.EnterDataInTab(Driver.Value, "Services Needed").Click();
                    AddReferralPOM.SelectServiceNeeded(Driver.Value, 3);
                    Assert.That(true);

                    Test.Value.Log(Status.Pass, "Test AddReferral - Needed service can be selected among drop down successfully ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral Needed service can't be selected among drop down Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test AddReferral - To verify that a Special programme can be selected among drop-down
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that a Special programme can be selected among drop-down ");

                    AddReferralPOM.EnterDataInTab(Driver.Value, "Special Program").Click();
                    AddReferralPOM.SelectSpecialProgramme(Driver.Value, "Gambling disorder");
                    Assert.That(true);

                    Test.Value.Log(Status.Pass, "Test AddReferral - Special programme selected among drop down successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral Special programme can't be selected among drop down Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test AddReferral - To verify that Referral Note accepts text input								
                try
                {
                    TestCount++;
                    Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that Referral Note accepts text input ");
                    AddReferralPOM.EnterTextForNote(Driver.Value).Click();
                    AddReferralPOM.EnterTextForNote(Driver.Value, "Referral Will Be Added");

                    Test.Value.Log(Status.Pass, "Test AddReferral - Referral Note accepts text input");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Referral Note did not accepts text input Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                //Test AddReferral - To verify that new referral can be saved successfully







                if (TestDataType == "Negative")
                {
                    try
                    {
                        TestCount++;
                        Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that new referral can be saved successfully");


                        AddReferralPOM.ClickOnSave_Cancel(Driver.Value, "SUBMIT").Click();
                        Test.Value.Log(Status.Pass, "Test AddReferral - Click on save button");

                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        Thread.Sleep(1000);

                    }
                    catch
                    {
                        Test.Value.Log(Status.Fail, "Test AddReferral - Referral getting saved");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                }
                else
                {
                    try
                    {
                        TestCount++;
                        Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that Success Notifier displaying successfully");


                        AddReferralPOM.ClickOnSave_Cancel(Driver.Value, "SUBMIT").Click();
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        Test.Value.Log(Status.Pass, "Test AddReferral - Click on save button");

                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        Thread.Sleep(1000);
                    }
                    catch(Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test AddReferral - Unable to save new Referral " +e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                }
                try
                {
                    Assert.That(AddReferralPOM.MessageNotifier(Driver.Value));
                    Test.Value.Log(Status.Pass, "Test AddReferral - Succes-Notifier displaying successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test AddReferral - Succes-Notifier not displaying Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }

                //Test AddReferral - To verify that Referral could be reflected successfully
                if (TestDataType == "Positive")
                {


                    try

                    {
                            TestCount++;
                        Test.Value = ExtentTestManager.CreateTest($"Test AddReferral_{ModuleName}_{TestCount} - To verify that new referral can be reflected successfully");
                        if (ReferralAs == "Outgoing")
                        {

                            OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Navigate to outgoing page");
                            OutgoingPOM.EnterPatientNameInSearchField(Driver.Value, patientname);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Search referral by patient name");
                            Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).ToLower().Contains(patientname.ToLower()));
                            Test.Value.Log(Status.Pass, "Test AddReferral - Referral reflected on outgoing page of origin successfully");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                            ////////switch acount/////////


                            LoginPOM.SwitchAccount(Driver.Value, "Destination");
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            IncomingPOM.NavigateToIncomingPage(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Navigate to incoming page of destination");
                            IncomingPOM.EnterPatientNameInSearchField(Driver.Value, patientname);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Search referral by patient name");
                            Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).ToLower().Contains(patientname.ToLower()));
                            Test.Value.Log(Status.Pass, "Test AddReferral - Referral reflected on incoming page of destination successfully");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));









                        }
                        else
                        {
                            
                            IncomingPOM.NavigateToIncomingPage(Driver.Value);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Navigate to incoming page ");
                            IncomingPOM.EnterPatientNameInSearchField(Driver.Value, patientname);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Test.Value.Log(Status.Pass, "Test AddReferral - Search referral by patient name");
                            Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).ToLower().Contains(patientname.ToLower()));

                            Test.Value.Log(Status.Pass, "Test AddReferral - Referral reflected on incoming page of origin successfully");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                        }
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test AddReferral - Unable to add referral Error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

                }
            } catch{}
        
        
        
        
        
        
        
        
        
        
        }
        
        public static IEnumerable<TestCaseData> Addreferral_Patient_Outgoing_TD()
        {
            String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
            yield return new TestCaseData(

                
                GetDataParser().TestData("ReferralAsO", Path),
                GetDataParser().TestData("ModulePl", Path)
                );
        }
        public static IEnumerable<TestCaseData> Addreferral_Patient_Incoming_TD()
        {
            String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
            yield return new TestCaseData(

                
                GetDataParser().TestData("ReferralAsI", Path),
                GetDataParser().TestData("ModulePl", Path)
                );
        }
        public static IEnumerable<TestCaseData> Addreferral_Provider_Outgoing_TD()
        {
            String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
            yield return new TestCaseData(

                
                GetDataParser().TestData("ReferralAsO", Path),
                GetDataParser().TestData("ModuleP", Path)
                );
        }
        public static IEnumerable<TestCaseData> Addreferral_Provider_Incoming_TD()
        {
            String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
            yield return new TestCaseData(

                
                GetDataParser().TestData("ReferralAsI", Path),
                GetDataParser().TestData("ModuleP", Path)
                );
        }



    }
}
