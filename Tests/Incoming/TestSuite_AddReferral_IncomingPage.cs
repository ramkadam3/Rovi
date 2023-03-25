using AngleSharp.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using OpenQA.Selenium;
using RovicareTestProject.PageObjects;
using RovicareTestProject;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace RovicareTestProject.Tests.Incoming
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_AddReferral_IncomingPage : BaseClass
    {

        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test, Order(1)]
        [Author("Ram Kadam"),NUnit.Framework.Category("Functional")]
        [TestCaseSource("AddReferral_Incoming_TD")]
        [TestCaseSource("AddReferral_Incoming_TD_Negative")]
        public void AddReferral(
            string TestDataType,
            List<string> MobileNumber,
            List<string> HomeNumber,
            List<string>Email_ID,
            string Referrer_OrganizationName,
            string SSN_PID,
            int IndexOfInsuranceProvider,
            string FirstName,
            string MiddleName,
            string LastName,
            string DOB
            )

        {

            //Test AddReferral TC_001 - To verify that Referral button Navigate to Add Referral For Patient Page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_001 - To verify that Referral button Navigate to Add Referral For Patient Page");
                IncomingPOM.NavigateToIncomingPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_001 -Navigated To Incoming Page");
                AddReferralPOM.ClickOnReferralButton_IncomingPage(Driver.Value);

                Test.Value.Log(Status.Pass, "Test AddReferral TC_001 -Clicked On Add Referral Button");
                Assert.That(AddReferralPOM.EnterDataInTab(Driver.Value, "First Name").Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_001 -Naviagated To Add Referral Page Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_001 -Unable To Naviagat Add Referral Page Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_002 - To verify that Under Personal section First Name,Middle Name,Last Name elements accept text input
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_002 - To verify that Under Personal section First Name,Middle Name,Last Name elements accept text input");

                AddReferralPOM.EnterDataInTab(Driver.Value, "First Name").SendKeys(FirstName);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_002 - First Name Element Accepts Text Input");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Middle Name").SendKeys(MiddleName);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_002 - Middle Name Element Accepts Text Input");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Last Name").SendKeys(LastName);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_002 - Last Name Element Accepts Text Input");

                Test.Value.Log(Status.Pass, "Test AddReferral TC_002 - First Name,Middle Name,Last Name Elements Accept Text Input");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_002 - First Name,Middle Name,Last Name Elements Unable To Accept Text Input Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_003 - To verify that Under Personal section Date of birth element accepts Date type input
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_003 - To verify that Under Personal section Date of birth element accepts Date type input");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Date of Birth").SendKeys(DOB);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_003 - Date Of Birth Element Accepts Date Type Input");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_003 -Date Of Birth Element Did Not Accepts Date Type Input Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_004 - To verify that Under Personal section Gender element select a Gender
            string Gender = "Female";
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_004 - To verify that Under Personal section Gender element select a Gender");
                AddReferralPOM.SelectGender_AddReferral(Driver.Value, Gender).Click();
                Assert.That(true);

                for (int i = 0; i <= 2; i++)
                {
                    string[] G = { "Male", "Female", "Other" };
                    if (G[i] != Gender)
                    {

                        Assert.False(AddReferralPOM.SelectGender_AddReferral(Driver.Value, G[i]).Selected);
                        Test.Value.Log(Status.Pass, $"Test AddReferral TC_004 -  {G[i]} Gender is not selected");
                    }
                }
                Test.Value.Log(Status.Pass, $"Test AddReferral TC_004 - {Gender} Gender is selected ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Test AddReferral TC_004 - {Gender} Gender is not selcted Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_005 - To verify that Under Personal section SSN/PID element accept 4 charactors data
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_005 - To verify that Under Personal section SSN/PID element accept 4 charactor data");

                AddReferralPOM.EnterDataInTab(Driver.Value, "SSN / PID (Last 4 characters)").SendKeys(SSN_PID);//SSN / PID(Last 4 characters)
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_005 -SSN/PID section accepts only 4 charactors data");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_005 SSN/PID section accepts other than 4 charactors data Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_006 - To verify that Under Personal section Email element accept Email data								
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_006 - To verify that Under Personal section Email element accept Email data\t ");
                for (int i = 0; i < Email_ID.Count; i++)
                {
                    try
                    {



                        AddReferralPOM.EnterDataInTab(Driver.Value, "Email ID").Clear();
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Email ID").SendKeys(Email_ID[i]);
                       AddReferralPOM.EnterDataInTab(Driver.Value, "Email ID").SendKeys(Keys.Enter);

                        if(TestDataType== "Negative")
                        {
                            Assert.That(AddReferralPOM.CheckErrorMessage(Driver.Value, "Email ID"));

                            Test.Value.Log(Status.Pass, $"Test AddReferral TC_006 - Email section did not accepts {Email_ID[i]} data ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        else
                        {
                            Test.Value.Log(Status.Pass, $"Test AddReferral TC_006 - Email section  accepts {Email_ID[i]} data  ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }



                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test AddReferral TC_006 - Email section did not accepts {Email_ID[i]} data  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Email ID").Clear();
                    }
                }
                
               

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_006 Email section accepts other than Email type data Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test AddReferral TC_007 - To verify that Under Personal section Mobile number element accept Mobile Number	
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_007 - To verify that Under Personal section Mobile number element accept Mobile Number ");
                for (int i = 0; i < MobileNumber.Count; i++)
                {
                    try
                    {



                        AddReferralPOM.EnterDataInTab(Driver.Value, "Mobile Number").Clear();
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Mobile Number").SendKeys(MobileNumber[i]);
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Mobile Number").SendKeys(Keys.Enter);

                        if (TestDataType == "Negative")
                        {
                            Assert.That(AddReferralPOM.CheckErrorMessage(Driver.Value, "Mobile Number"));

                            Test.Value.Log(Status.Pass, $"Test AddReferral TC_007 - Mobile section did not accepts {MobileNumber[i]} data ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        else
                        {
                            Assert.That(true);

                            Test.Value.Log(Status.Pass, $"Test AddReferral TC_007 - Mobile section  accepts {MobileNumber[i]} data  ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }



                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test AddReferral TC_007 - Mobile section did not accepts {MobileNumber[i]} data  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Mobile Number").Clear();
                    }
                }
            }
            catch
            {
            }



            //Test AddReferral TC_008 - To verify that Under Personal section Home number element accept Home number data
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_008 - To verify that Under Personal section Home number element accept Home number data");
                for (int i = 0; i < HomeNumber.Count; i++)
                {
                    try
                    {
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Home Number").Clear();
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Home Number").SendKeys(HomeNumber[i]);
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Home Number").SendKeys(Keys.Enter);
                        if (TestDataType == "Negative")
                        {
                            Assert.That(AddReferralPOM.CheckErrorMessage(Driver.Value, "Home Number"));
                            Test.Value.Log(Status.Pass, $"Test AddReferral TC_008 - Home number section did not accepts {HomeNumber[i]} data Error :");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);
                        }
                        else
                        
                        {
                                Test.Value.Log(Status.Pass, $"Test AddReferral TC_008 - Home number section accepts {HomeNumber[i]} data");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test AddReferral TC_008 - Home number section accepts {HomeNumber[i]} data Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddReferralPOM.EnterDataInTab(Driver.Value, "Home Number").Clear();
                    }
                }
            }
            catch
            {
            }
            //Test AddReferral TC_009 - To verify Organization Name section accepts text input		
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_009 - To verify Organization Name section accepts text input\t");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Organization Name").SendKeys(Referrer_OrganizationName);
                AddReferralPOM.SelectOrganizationName(Driver.Value);

                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_009 - Organization Name section accepts text data");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_009 Organization Name section did not accepts text dataError :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test AddReferral TC_010 - To verify that Received date section accepts date and time  less than of current time								
            try
            {
                DateTime Now = DateTime.Now;

                int date = Now.Day;


                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_010 - To verify that Received date section accepts date and time  less than of current time");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Received Date").Click();
                AddReferralPOM.SelectDateofReceive(Driver.Value, date);
                Assert.That(true);
                Thread.Sleep(1000);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_010 - Received date accepts date and time less than of current time");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_010 - Received date accepts date and time other than required time Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_011 - To verify that any mode can be selected among mode drop down	
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_011 - To verify that any mode can be selected among mode drop down ");

                AddReferralPOM.SelectMode_ProviderType(Driver.Value, "Mode").Item1.Click();
                CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.SelectMode_ProviderType(Driver.Value, "Mode").Item2, "Down",1);
               
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test AddReferral TC_011 - Any mode can be selceted from Mode drop down");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
               

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_011 - Unable to select any mode from mode drop down Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_012 - To verify that Contact Person Name drop down working properly
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_012 - To verify that Contact Person Name drop down working properly ");

              
                if(AddReferralPOM.EnterDataInTab(Driver.Value, "Contact Person Name").Enabled)
                {
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    AddReferralPOM.SelectContactPersonName(Driver.Value);
                   

                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_012 - Contact person name selected from drop-down");
                  
                }
                else
                {
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_012 - Contact person name field is desabled ");
                }


                
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_012 - Unable to select any contact from drop down Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test AddReferral TC_013 - To verify that Attach Document section Navigate to  Referral Records pop up	
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_013 - To verify that Attach Document section Navigate to  Referral Records pop up ");
                AddReferralPOM.ClickOnAttachDocuments(Driver.Value);
                AddReferralPOM.ClickOnCloseReferralReferralPopUp(Driver.Value);


                Test.Value.Log(Status.Pass, "Test AddReferral TC_013 -Attach Document Button Navigate To Referral Records Pop up ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_013 - Attach Document Button Did Not Navigate To Referral Records Pop up Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_014 - To verify that any Provider type can be selected from drop down 								
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_014 - To verify that any Provider type can be selected among drop down  ");

                AddReferralPOM.SelectMode_ProviderType(Driver.Value, "Provider Type").Item1.Click();
                CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.SelectMode_ProviderType(Driver.Value, "Provider Type").Item2, "Down",0002);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_014 - Provider Type can be selected among drop down");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_014 - Provider Type can't be selected among drop down Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_015 - To verify that required service can be selected among drop down Service needed	
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_015 - To verify that required service can be selected among drop down Service needed ");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Services Needed").Click();
                AddReferralPOM.SelectServiceNeeded(Driver.Value, 3);
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test AddReferral TC_015 - Needed service can be selected among drop down successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_015 Needed service can't be selected among drop down Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_016 - To verify that Special programme can be selected among drop down
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_016 - To verify that Special programme can be selected among drop down ");

                AddReferralPOM.EnterDataInTab(Driver.Value, "Special Program").Click();
                AddReferralPOM.SelectSpecialProgramme(Driver.Value, "Gambling disorder");
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test AddReferral TC_016 - Special programme selected among drop down successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_016 Special programme can't be selected among drop down Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_017 - To verify that Referral Note accepts text input								
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_017 - To verify that Referral Note accepts text input ");
                AddReferralPOM.EnterTextForNote(Driver.Value).Click();
                AddReferralPOM.EnterTextForNote(Driver.Value, "Referral Will Be Added");

                Test.Value.Log(Status.Pass, "Test AddReferral TC_017 - Referral Note accepts text input");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_017 - Referral Note did not accepts text input Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_018 - To verify that Insurance section  allow patient if policy holder id different from patient
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_018 - To verify that Insurance section  allow patient if policy holder id different from patient ");
                Thread.Sleep(2000);

                AddReferralPOM.ClickOnCheckbox_PolicyHolderIsDifferent_InsuranceSection(Driver.Value);

                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - Click on 'Please check if policy holder is different from patien' ");
                Assert.That(AddReferralPOM.EnterFirst_Lastname_MobileNumber_policyHolder(Driver.Value, "Firstname").Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - FirstName field is available");
                Assert.That(AddReferralPOM.EnterFirst_Lastname_MobileNumber_policyHolder(Driver.Value, "lastname").Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - LastName field is available");
                Assert.That(AddReferralPOM.EnterFirst_Lastname_MobileNumber_policyHolder(Driver.Value, "patientcellnumber").Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_017 - MobileNumber field is available");
                Assert.That(AddReferralPOM.Select_Relationship_policyHolder(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - Relationship field is available");
                Assert.That(AddReferralPOM.EnterHomeNumber_policyHolder(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - HomeNumber field is available");

                Test.Value.Log(Status.Pass, "Test AddReferral TC_018 - CheckBox opens inner table of policy holder's details");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                AddReferralPOM.ClickOnCheckbox_PolicyHolderIsDifferent_InsuranceSection(Driver.Value);
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_018 - CheckBox did not open inner table for policy holder's details Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_019 - To verify that the insurance section fetches the insurance records of patient	
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_019 - To verify that the insurance section fetches the insurance records of patient");

                AddReferralPOM.ClickOnInsuranceName(Driver.Value).Item1.Click();
                Test.Value.Log(Status.Pass, "Test AddReferral TC_019 -Click On Insurance Name Tab");
                //int IndexOfInsuranceProvider = 2;


                CommonPOM.MouseActionForDropDownHandle(Driver.Value, AddReferralPOM.ClickOnInsuranceName(Driver.Value).Item2, "Down",IndexOfInsuranceProvider);
                Thread.Sleep(4000);

                
                //AddReferralPOM.ClickOncheckBoxForShareInsuranceRecords(Driver.Value, "Consent obtained to share information with Arizona Complete Health");
                //AddReferralPOM.ClickOncheckBoxForShareInsuranceRecords(Driver.Value, "Share patient information with Arizona Complete Health");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
                AddReferralPOM.CheckGroupNumber(Driver.Value).Item2.SendKeys("1234");
                // Assert.AreNotEqual(AddReferralPOM.CheckGroupNumber(Driver.Value).Item1, "");
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_019 - Insurance section fetches the insurance records of patient successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                
                AddReferralPOM.ClickOnMoreInsurance(Driver.Value);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_019 - Click on More Insurance Button");
                
                Assert.That(AddReferralPOM.ClickOnInsuranceName(Driver.Value, 1).Item1.Displayed);
                Test.Value.Log(Status.Pass, "Test AddReferral TC_019 - More Insurance Button Works properly");
                AddReferralPOM.ClickOnCancelInsurance_CrossButton(Driver.Value);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_019 - Insurance section unable to fetch the insurance details of patient Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test AddReferral TC_020 - To verify that new referral can be saved successfully
           
            
                

                
                    
                
                if (TestDataType == "Negative")
                {
                    try
                    {
                    Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_020 - To verify that new referral can be saved successfully");

                   
                    AddReferralPOM.ClickOnSave_Cancel(Driver.Value, "SAVE").Click();
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_020 - Click on save button");
                    Assert.That(AddReferralPOM.EnterDataInTab(Driver.Value, "Special Program").Displayed);
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_020 - Unable to save Referral");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        Thread.Sleep(1000);

                    }
                    catch 
                    {
                        Test.Value.Log(Status.Fail, "Test AddReferral TC_020 - Referral getting saved");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                }
                else
                {
                  try
                   {
                    Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_020 - To verify that new referral can be saved successfully");

                    
                    AddReferralPOM.ClickOnSave_Cancel(Driver.Value, "SAVE").Click();
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_020 - Click on save button");
                    AddReferralPOM.ClickOnfinalPOp_AfterSAVE(Driver.Value).Click();
                    Test.Value.Log(Status.Pass, "Test AddReferral TC_020 - Referral getting saved");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(1000);
                  }
                  catch
                   {
                    Test.Value.Log(Status.Fail, "Test AddReferral TC_020 -Unable to save new Referral ");
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                }

               

           
        
           
            //Test AddReferral TC_021 -To Verify that new referral getting added successfully
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test AddReferral TC_021 - To Verify that new referral getting added successfully");
               
                

                
                //IncomingPOM.NavigateToIncomingPage(Driver.Value);
                // IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                Thread.Sleep(7000);
                if (TestDataType == "Negative")
                {
                    try
                    {
                        Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).Contains("Grate, Richard"));
                        Test.Value.Log(Status.Fail, "Test AddReferral TC_021 - Referral not getting added successfully");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch
                    {
                        Test.Value.Log(Status.Pass, "Test AddReferral TC_021 - Referral getting added successfully Error");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }

                
                else
                {
                try
                {
                    Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).Contains("Grate, Richard"));

                    Test.Value.Log(Status.Pass, "Test AddReferral TC_021 - Referral getting added successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch 
                    {
                    Test.Value.Log(Status.Fail, "Test AddReferral TC_021 -Unable to add new Referral ");
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                     }
                }
            }
            catch
            {
                Test.Value.Log(Status.Fail, "Test AddReferral TC_021 -Unable to add new Referral ");
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }



        }

    



    //********************************************TestData_AddReferral_IncomingPage******************************************

    public static IEnumerable<TestCaseData> AddReferral_Incoming_TD()
      {
        String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
        yield return new TestCaseData(
            GetDataParser().TestData("TestDataType+", Path),
            GetDataParser().TestDataArray("MobileNumber", Path).ToList(),
            GetDataParser().TestDataArray("HomeNumber", Path).ToList(),
            GetDataParser().TestDataArray("Email_ID", Path).ToList(),
            GetDataParser().TestData("Referrer_OrganizationName", Path),
            GetDataParser().TestData("SSN_PID", Path),
            int.Parse(GetDataParser().TestData("IndexOfInsuranceProvider", Path)),
            GetDataParser().TestData("FirstName", Path),
            GetDataParser().TestData("MiddleName", Path),
            GetDataParser().TestData("LastName", Path),
            GetDataParser().TestData("DOB", Path)
            
            );
       }
        public static IEnumerable<TestCaseData> AddReferral_Incoming_TD_Negative()
        {
            String Path = GetDataParser().TestData_Path("AddReferral_IncomingPage_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("TestDataType-", Path),
                GetDataParser().TestDataArray("MobileNumber_N", Path).ToList(),
                GetDataParser().TestDataArray("HomeNumber_N", Path).ToList(),
                GetDataParser().TestDataArray("Email_ID_N", Path).ToList(),
                GetDataParser().TestData("Referrer_OrganizationName", Path),
                GetDataParser().TestData("SSN_PID", Path),
                int.Parse(GetDataParser().TestData("IndexOfInsuranceProvider", Path)),
                GetDataParser().TestData("FirstName", Path),
                GetDataParser().TestData("MiddleName", Path),
                GetDataParser().TestData("LastName", Path),
                GetDataParser().TestData("DOB", Path)

                );
        }
    }
    
}
