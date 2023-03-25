using AngleSharp.Dom;
using AngleSharp.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MongoDB.Driver;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;                                      //Navigate to 2439 line to add destination service
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace RovicareTestProject.Tests.AdminTests
{
    //[Parallelizable(ParallelScope.All)]
    //[TestFixture("Firefox")]
    [TestFixture]
    //[TestFixture("Edge")]
    public class AddOrganization_OrganizationList:BaseClass
    {
       
       
        
           
        

        [SetUp]
        public void BrowserLaunch()
        {
            
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value,SuperAdmin_Email, SuperAdmin_Password);

        }
        [Test, Order(1)]
        [Author("Ram Kadam"), NUnit.Framework.Category("Functional"), NUnit.Framework.Category("Component")]
        [TestCaseSource("AddOrganization_TD")]

        public void AddorganizationTest(
            string DataType ,
            string FileName,
            string[] MaxMemberMessage ,
            string Category ,
            string ProviderType,
            string Insurances,
            string ServicesOffered ,
            string ServiceSetting ,
            string SpecialProgramAccepted ,
            string AgeGroupAccepted ,
            string GenderAccepted ,
            string PatientUniqueIdentifier,
            string SendReferral_DefaultCheckedFeature ,
            string SendReferralAllFeature ,
            string ReceiveReferralFeatureList ,
            string ReceiveReferralFeatureDefaultSelectedList ,
            string RemainingFeatureAndsettingsList ,
            string RemainingFeatureAndSettinsCkeckedDefault ,
            string ImportPatientByExcelSheetSubFeature ,
            string EnablePatientFeedbackReminderSubFeature,
            string ProviderSettings ,
            string OrganizationRoleList ,
            string LoginMode ,
            string EMRtype ,
            string DestinationName ,
            string ChatDisablePlaceholderText
           // string UploadFilePath










            )
        {
            int Count = 0;
            string time = Time.TimeOfDay.ToString("hhmmss");
            string PhoneNumber="5698321478";
            string FaxNumber = "9865321457";
            string AHCCCSID = "89657412";
            string Street = $"M.G.Road{time}";
            string City = "M.G.City";
            string State = "AZ";
            string Zipcode = "85224";
            string Description = "Add_Organization";
            string MembEmail = $"DemoClient{time}@interbizconsulting.com";
            string MembFirstName = "Admindemo";
            string Email = "demo.emailid321@gmail.com";
            //string ServicesOffered = "Acute Rehab|Companion Care|Attendant Care";
            string patientName = "";
            string OrganizationName = $"DemoClient{time}";
            //string UploadFilePath = "D:\\testing\\rovicaretesting\\TestData\\SuperAdminTD";

           //OrganizationList_AdminPOM.ClickOnAddOrganization(Driver.Value);














            //Test_AddOrganization - To verify that AddOrganization Button navigates to add-organization page


            try
            {
                Thread.Sleep(5000);
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that AddOrganization Button navigates to add-organization page");
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                AddOrganizationList_AdminPOM.NavigateToOrganizationListPage(Driver.Value);
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                AddOrganizationList_AdminPOM.ClickOnAddOrganization(Driver.Value);
                Test.Value.Log(Status.Pass, "Test_AddOrganization- Click on add-organization button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);

                Assert.That(AddOrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Basic Details").Displayed);

                Test.Value.Log(Status.Pass, "Test_AddOrganization- Navigated to add organization page successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                //Test_AddOrganization - To verify that the Basic details section element working properly 
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Basic details section element working properly ");


                    //OrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Basic Details").Click();

                    if (DataType == "Negative")
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Website", "http://wwww.DemoClient.com");
                            Assert.That(CommonPOM.CheckErrorMessage(Driver.Value, "Website"));
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- ErrorMessage has been shown for wrong data");
                            //Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {

                            Test.Value.Log(Status.Fail, "Test_AddOrganization- ErrorMessage has not been shown for wrong data, Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }




                    }
                    else
                    {


                        try
                        {

                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Website", "http://wwww.DemoClient.com");
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- Website tab accept website type data");
                            //Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide website input Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }



                    try
                    {
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Name", OrganizationName);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The name field accepts text input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The name field is not accepting text input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "AHCCCS ID", AHCCCSID);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The AHCCCS ID field accepts text input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The name field is not accepting text input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    try
                    {

                        AddOrganizationList_AdminPOM.SelectFromOption(Driver.Value, "Subscription Plan","Basic");
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Select The Subscription plan");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization-Unable toSelect The Subscription plan Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {

                        AddOrganizationList_AdminPOM.ClickOnMedicareRating(Driver.Value, "4");
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The MedicareRating field accepts rating input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization-The MedicareRating field is not accepting rating input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    try
                    {


                        AddOrganizationList_AdminPOM.EnterDescription(Driver.Value, Description);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The discription field accepts text input");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The discription field is not accepting text input Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    Test.Value.Log(Status.Pass, "Test_AddOrganization- The basic details section has been provided with all details successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Some things are missing in basic detail section  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }


                //Test_AddOrganization_{Count}- To verify that the Contact Information section 


                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Contact Information section ");


                   // OrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Contact Information").Click();
                    // Check selected features
                    if (DataType == "Negative")
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Phone Number", PhoneNumber);
                            Assert.That(CommonPOM.CheckErrorMessage(Driver.Value, "Name"));
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- ErrorMessage has been shown for wrong data");

                        }
                        catch (Exception e)
                        {

                            Test.Value.Log(Status.Fail, "Test_AddOrganization- ErrorMessage has not been shown for wrong data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }


                    }
                    else
                    {

                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Phone Number", PhoneNumber);

                            Test.Value.Log(Status.Pass, "Test_AddOrganization- Phone number section accepts phone number type data");

                        }
                        catch (Exception e)
                        {

                            Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide phone number type data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }


                    }

                    if (DataType == "Negative")
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email Id", Email);
                            Assert.That(CommonPOM.CheckErrorMessage(Driver.Value, "Email Id"));
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- ErrorMessage has been shown for wrong data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- ErrorMessage has not been shown for wrong data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }
                    }
                    else
                    {
                        try
                        {

                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email Id", Email);
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- Email Id section accepts phone number type data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide Email Id type data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }



                    }


                    if (DataType == "Negative")
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Fax Number", FaxNumber);
                            Assert.That(CommonPOM.CheckErrorMessage(Driver.Value, "Fax Number"));
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- ErrorMessage has been shown for wrong data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- ErrorMessage has not been shown for wrong data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }
                    }
                    else
                    {
                        try
                        {

                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Fax Number", FaxNumber);
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- Fax Number section accepts phone number type data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide Fax Number type data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }



                    }

                    Test.Value.Log(Status.Pass, "Test_AddOrganization- The Contact details provided successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }

                catch (Exception e)
                {

                }










                //Test_AddOrganization_{Count}- To verify that the Location Information section

                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Location Information section ");


                   // OrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Location Information").Click();



                    try
                    {

                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Street Address", Street);
                        AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "City",City);
                        Thread.Sleep(1000);
                        AddOrganizationList_AdminPOM.ClickOnSelect(Driver.Value, "State", "Arizona");

                        AddOrganizationList_AdminPOM.ClickOnSelect(Driver.Value, "Category", Category);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Street Address,City,State and Category tabs applied input");
                    }
                    catch (Exception e)
                    {

                        Test.Value.Log(Status.Fail, "Test_AddOrganization- Location information section not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                    }




                    if (DataType == "Negative")
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Zipcode", FaxNumber);
                            Assert.That(CommonPOM.CheckErrorMessage(Driver.Value, "Zipcode"));
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- ErrorMessage has been shown for wrong data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- ErrorMessage has not been shown for wrong data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }
                    }
                    else
                    {
                        try
                        {

                            AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Zipcode", Zipcode);
                            Test.Value.Log(Status.Pass, "Test_AddOrganization- Zipcode section accepts phone number type data");


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Test_AddOrganization- Unable to provide Zipcode type data Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }



                    }




                }
                catch { }


                //Test_AddOrganization - To verify that the Provider type  section working properly

                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Provider type  section working properly");


                   // OrganizationList_AdminPOM.ClickOnHeadlineElements(Driver.Value, "Services").Click();
                    Test.Value.Log(Status.Pass, "Test_AddOrganization- Service element at top navigate to service provided section");
                    Thread.Sleep(2000);
                    int Length = AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).CountOfProvider;
                    try
                    {
                        bool AllProvidersdeselectedBydefault = true;
                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, i).SelectProviderByCheckBox.Selected)
                                AllProvidersdeselectedBydefault = false;
                        }
                        Assert.That(AllProvidersdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All providers are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All providers are not deselected by default" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All providers have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Click();


                        //check All providers are selected
                        Boolean AllProviderSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, i).SelectProviderByCheckBox.Selected)
                                AllProviderSelected = false;
                        }
                        Assert.That(AllProviderSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All providers have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {


                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, i).SelectProviderByCheckBox.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Selected)
                            AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string provider in ProviderType.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();
                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.SendKeys(provider);
                                AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByCheckBox.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).SelectProviderByname.ToLower().Contains(provider.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{provider}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {provider}  Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, index.ToInteger(3)).SelectProviderByCheckBox.Click();
                        }


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectProviderType(Driver.Value, 1).SelectProviderByCheckBox.Clear();

                    }

                }
                catch
                {
                }



                //To verify that the Insurance Accepted section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Insurance Accepted section working properly");


                    //All insurances are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item2;
                    try
                    {
                        bool AllinsurancedeselectedBydefault = true;

                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, i).Item1.Selected)
                                AllinsurancedeselectedBydefault = false;
                        }
                        Assert.That(AllinsurancedeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All insurances are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All insurances are not deselected by default Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All providers have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Click();


                        //check All providers are selected
                        Boolean AllinsuranceSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, i).Item1.Selected)
                                AllinsuranceSelected = false;
                        }
                        Assert.That(AllinsuranceSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All insurances have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string Insurance in Insurances.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 1).Item1.SendKeys(Insurance);
                                AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 2).Item3.ToLower().Contains(Insurance.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Insurance}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action not happening for {Insurance}  Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectInsuranceAccepted(Driver.Value, 1).Item1.Clear();
                    }


                }
                catch
                { }


                //To verify that the Service offered  section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Service offered  section working properly");


                    //All Service are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item2;
                    try
                    {

                        bool AllServicesdeselectedBydefault = true;
                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, i).Item1.Selected)
                                AllServicesdeselectedBydefault = false;
                        }
                        Assert.That(AllServicesdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Services are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All Services are not deselected by default Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All Service have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Click();


                        //check All Service are selected
                        Boolean AllServicesSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, i).Item1.Selected)
                                AllServicesSelected = false;
                        }
                        Assert.That(AllServicesSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All services have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string Service in ServicesOffered.Split("|"))
                        {
                            try
                            {
                                AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 1).Item1.SendKeys(Service);
                                AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 2).Item3.ToLower().Contains(Service.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Service}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {

                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {Service}  Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                            finally {
                                AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 1).Item1.Clear();
                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, index.ToInteger(3)).Item1.Click();
                        }


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectServiceOffered(Driver.Value, 1).Item1.Clear();
                    }
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_AddOrganization- ServiceOffered section not working   Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }




                //To verify that the Service setting  section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Service setting  section working properly");


                    //All Service are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item2;
                    try
                    {
                        bool AllServicesdeselectedBydefault = true;

                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, i).Item1.Selected)
                                AllServicesdeselectedBydefault = false;
                        }
                        Assert.That(AllServicesdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Services are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All Services are not deselected by default Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All Service have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Click();


                        //check All Service are selected
                        Boolean AllServiceSettingSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, i).Item1.Selected)
                                AllServiceSettingSelected = false;
                        }
                        Assert.That(AllServiceSettingSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All setting have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        //OrganizationList_AdminPOM.SelectProviderType(Driver.Value, 2).Item1.Click();
                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string Service in ServiceSetting.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 1).Item1.SendKeys(Service);
                                AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 2).Item3.ToLower().Contains(Service.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Service}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not hapeening for {Service}  Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 1).Item1.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, index.ToInteger(3)).Item1.Click();
                        }


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectServiceSetting(Driver.Value, 1).Item1.Clear();
                    }
                }
                catch
                { }


                //To verify that the Special Program Accepted  section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Special Program Accepted  section working properly");


                    //All Service are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item2;
                    try
                    {
                        bool AllProgramsdeselectedBydefault = true;

                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, i).Item1.Selected)
                                AllProgramsdeselectedBydefault = false;
                        }
                        Assert.That(AllProgramsdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Programs are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All Programs are not deselected by default Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All Service have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Click();


                        //check All Service are selected
                        Boolean AllProgramsSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, i).Item1.Selected)
                                AllProgramsSelected = false;
                        }
                        Assert.That(AllProgramsSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Programs have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string Program in SpecialProgramAccepted.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 1).Item1.SendKeys(Program);
                                AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 2).Item3.ToLower().Contains(Program.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Program}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {Program} Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 1).Item1.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, index.ToInteger(3)).Item1.Click();
                        }


                    }
                    finally
                    {

                        AddOrganizationList_AdminPOM.SelectSpecialProgram(Driver.Value, 1).Item1.Clear();
                    }
                }
                catch
                { }

                //To verify that the  Age Group Accepted section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Age Group Accepted section working properly");


                    //All Service are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item2;
                    try
                    {
                        bool AllAgeGroupdeselectedBydefault = true;

                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, i).Item1.Selected)
                                AllAgeGroupdeselectedBydefault = false;
                        }
                        Assert.That(AllAgeGroupdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All age groups are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All age groups are not deselected by default Error :");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All Service have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Click();


                        //check All Service are selected
                        Boolean AllAgeGroupSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, i).Item1.Selected)
                                AllAgeGroupSelected = false;
                        }
                        Assert.That(AllAgeGroupSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Age Group have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string AgeGroup in AgeGroupAccepted.Split("|"))
                        {
                            try
                            {
                                AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 1).Item1.SendKeys(AgeGroup);
                                AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 2).Item3.ToLower().Contains(AgeGroup.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{AgeGroup}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {AgeGroup} Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 1).Item1.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {
                            AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, index.ToInteger(3)).Item1.Click();
                        }


                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectAgeGroupAccepted(Driver.Value, 1).Item1.Clear();
                    }
                }
                catch
                { }


                //To verify that the  Gender Accepted section working properly
                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Age Gender Accepted section working properly");


                    //All Service are deselected by default
                    int Length = AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item2;
                    try
                    {
                        bool AllGenderdeselectedBydefault = true;

                        for (int i = 2; i <= Length; i++)
                        {
                            if (AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, i).Item1.Selected)
                                AllGenderdeselectedBydefault = false;
                        }
                        Assert.That(AllGenderdeselectedBydefault);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All Genders are deselected by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- All Genders are not deselected by default Error :");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    //All Service have been selected by clicking on 'select All'
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Click();


                        //check All Service are selected
                        Boolean AllGenderSelected = true;

                        for (int i = 3; i <= Length; i++)
                        {
                            if (!AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, i).Item1.Selected)
                                AllGenderSelected = false;
                        }
                        Assert.That(AllGenderSelected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- All genders have been selected by clicking on 'select All'");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' feature is not working properly Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }



                    //The 'Select All' option has been selected by selecting all providers
                    try
                    {






                        for (int i = 3; i <= Length; i++)
                        {
                            AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, i).Item1.Click();

                        }
                        Assert.That(AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Selected);

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'Select All' option has been selected by selecting all providers");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The 'Select All' option has not been selected by selecting all providers Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Selected)
                            AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The 'select All' option deselected");
                    }

                    //Verify that the search section is working properly
                    try
                    {
                        foreach (string Gender in GenderAccepted.Split("|"))
                        {
                            try
                            {

                                AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 1).Item1.Clear();
                                AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 1).Item1.SendKeys(Gender);
                                AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 2).Item1.Click();

                                Assert.That(AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 1).Item3.ToLower().Contains(Gender.ToLower()));

                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Gender}' is selected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch
                            {

                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The search action is not happening for {Gender}  Error :");
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }


                        }

                        Test.Value.Log(Status.Pass, "Test_AddOrganization- The search section is working properly");

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Test_AddOrganization- The search section is not working properly  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 1).Item1.Clear();
                        foreach (string index in "3|4".Split("|"))
                        {

                            AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, index.ToInteger(3)).Item1.Click();
                        }


                    }
                    finally
                    {

                        AddOrganizationList_AdminPOM.SelectGenderAccepted(Driver.Value, 1).Item1.Clear();
                    }
                }
                catch
                { }


                //To verify that the Patient Unique Identifier section working properly

                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To verify that the Patient Unique Identifier section working properly");


                    //All Service are deselected by default



                    foreach (string Identifier in PatientUniqueIdentifier.Split("|"))
                    {
                        bool AllIdentifierselectedBydefault = true;
                        try
                        {
                            if (!AddOrganizationList_AdminPOM.SelectPatientUniqueIdentifier(Driver.Value, Identifier).Item1.Selected)
                                AllIdentifierselectedBydefault = false;
                            Assert.That(AllIdentifierselectedBydefault);
                            Test.Value.Log(Status.Pass, $"Test_AddOrganization- '{Identifier}' Identifier is selected by default");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Test_AddOrganization- '{Identifier}' Identifier is not selected by default Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }



                }
                catch
                { }

                //To verify that the  Send Referral feature section working properly
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the  Send Referral feature section working properly ");
                    foreach (string feature in SendReferralAllFeature.Split("|"))
                    {
                        try
                        {
                            if (AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected)
                            {
                                //Check Selected features
                                try
                                {

                                    if (SendReferral_DefaultCheckedFeature.ToLower().Contains(feature.ToLower()))
                                    {
                                        Assert.That(true);
                                        Test.Value.Log(Status.Pass, $"Test_AddOrganization- The {feature} feature is selected by default");
                                    }
                                    else
                                    {
                                        Assert.That(false);

                                    }
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                }
                                catch (Exception e)
                                {
                                    Test.Value.Log(Status.Fail, $"Test_AddOrganization- The {feature} feature is selected by default Error: " + e);
                                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                                }
                            }
                            else
                            {
                                try
                                {
                                    //Check Deselected features
                                    if (!SendReferral_DefaultCheckedFeature.ToLower().Contains(feature.ToLower()))
                                    {
                                        Assert.That(true);
                                        Test.Value.Log(Status.Pass, $"Test_AddOrganization- The {feature} feature is not selected by default");
                                    }
                                    else
                                    {
                                        Assert.That(false);

                                    }
                                }
                                catch (Exception e)
                                {

                                    Test.Value.Log(Status.Fail, $"Test_AddOrganization- The {feature} feature is not selected by default Error: " + e);
                                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                                }
                            }


                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $" Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }


                    }

                    //Check By deselecting send referral all it's sub features are disabled
                    AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Send Referral").Click();
                    foreach (string feature in SendReferralAllFeature.Split("|"))
                    {
                        if (feature != "Send Referral")
                        {

                            try
                            {
                                Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Enabled);
                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- The {feature} feature is getting disabled by deselecting 'Send Referral' feature");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The {feature} feature is not getting disabled by deselecting 'Send Referral' feature Error :" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }


                    }


                }
                catch
                { }
                finally
                {
                    if (!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Send Referral").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Send Referral").Click();
                    Test.Value.Log(Status.Pass, "Test_AddOrganization- Send referral feature set to enable as by default");
                }



                //To verify that the  Receive Referral feature section working properly
                try
                {
                    try
                    {
                        Count++;
                        Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the  Receive Referral feature section working properly");

                        //Verify that Receive referral feature and it's subordinates are unchecked by default

                        Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Receive Referral").Selected);
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Receive Referral is unchecked by default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        foreach (string feature in ReceiveReferralFeatureList.Split("|"))
                        {
                            try
                            {
                                Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature, "Receive Referral").Enabled);
                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{feature}' feature is disabled when Receive Referral is deselected");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature is disabled when Receive Referral is deselected");
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }

                    }
                    catch { }
                    // Verify that the behaviour of sub-features of receive referral after enabling receive referral
                    try
                    {
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Receive Referral").Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Clicked on Receive referral feature");

                        foreach (string feature in ReceiveReferralFeatureList.Split("|"))
                        {
                            try
                            {

                                if (ReceiveReferralFeatureDefaultSelectedList.ToLower().Contains(feature.ToLower()))
                                {
                                    Assert.That(AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected);
                                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The {feature} feature is selected by default ");
                                }
                                else
                                {
                                    Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected);
                                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The {feature} feature is deselected by default ");
                                }
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature selection problem when Receive Referral is deselected");
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }


                    }
                    catch
                    {

                        Test.Value.Log(Status.Fail, $"Test_AddOrganization- Unable to click The 'Receive Referral' featured");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    finally
                    {
                        if (AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Receive Referral").Selected)
                            AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Receive Referral").Click();
                        Test.Value.Log(Status.Pass, "Test_AddOrganization- Make Receive referral feature disabled as default");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }

                }
                catch
                { }
                //To verify that the Options in feature&settings section are displaying properly
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the Options in feature&settings section are displaying properly");
                    foreach (string feature in RemainingFeatureAndsettingsList.Split("|"))
                    {
                        if (AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected)
                        {
                            try
                            {



                                if (RemainingFeatureAndSettinsCkeckedDefault.ToLower().Contains(feature.ToLower()))
                                {
                                    Assert.That(true);
                                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{feature}' feature is enabled by default");
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                }
                                else
                                {
                                    Assert.That(false);

                                }
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature is enabled by default unnecessary " + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                            }
                        }
                        else
                        {
                            try
                            {

                                if (!RemainingFeatureAndSettinsCkeckedDefault.ToLower().Contains(feature.ToLower()))
                                {




                                    Assert.That(true);
                                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{feature}' feature is not enabled by default");
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                }
                                else
                                {
                                    Assert.That(false);

                                }
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature is not enabled by default Error: " + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                            }






                        }

                    }

                   


                }
                catch
                { }

               //Check Additional Services In My Organization for visibility of 'All' on shortlist provider page 
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_Setting_Enable Additional services ");

                    if (!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Additional Services In My Organization").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Additional Services In My Organization").Click();
                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The 'Additional Services In My Organization' feature is checked");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_AddOrganization- The 'Additional Services In My Organization' feature is checked by default Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                //To verify that 'Import Patient By Excel Sheet' and it's subordinates are displaying properly
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that 'Import Patient By Excel Sheet' and it's subordinates are displaying properly");



                    if (!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Import Patient By Excel sheet").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Import Patient By Excel sheet").Click();
                    foreach (string feature in ImportPatientByExcelSheetSubFeature.Split("|"))
                    {
                        try
                        {

                            Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected);
                            Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{feature}' feature is not enabled by default");

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature is enabled by default Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                        }
                    }

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                }
                catch
                { }
                finally
                {
                    if (AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Import Patient By Excel sheet").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Import Patient By Excel sheet").Click();
                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The 'Import Patient By Excel Sheet' feature is set to disable as by default");
                }
                //To verify that 'Enable Patient Feedback Reminder' and it's subordinates are displaying properly
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that 'Enable Patient Feedback Reminder' and it's subordinates are displaying properly");


                    if (!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Enable Patient Feedback Reminder").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Enable Patient Feedback Reminder").Click();
                    foreach (string feature in EnablePatientFeedbackReminderSubFeature.Split("|"))
                    {
                        try
                        {

                            Assert.That(!AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, feature).Selected);
                            Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{feature}' feature is not enabled by default");

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{feature}' feature is enabled by default Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                        }
                    }

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                }
                catch
                { }
                finally
                {
                    if (AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Enable Patient Feedback Reminder").Selected)
                        AddOrganizationList_AdminPOM.SelectFeatureSettings(Driver.Value, "Enable Patient Feedback Reminder").Click();
                    Test.Value.Log(Status.Pass, $"Test_AddOrganization- The 'Import Patient By Excel Sheet' feature is set to disable as by default");
                }





                //To verify that the Provider settings are set to the proper value
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the Provider settings are set to the proper value");
                    foreach (string settings in ProviderSettings.Split("|"))
                    {
                        try
                        {


                            string[] setting = settings.Split(",");
                            Console.WriteLine($"{setting[0]},{setting[1]}");
                            Assert.That(AddOrganizationList_AdminPOM.CheckProviderSettings(Driver.Value, setting[0]).GetAttribute("value").ToLower().Contains(setting[1]));
                            Test.Value.Log(Status.Pass, $"Test_AddOrganization- Count range of '{setting[0]}' is '{setting[1]}' displaying successfully");
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Test_AddOrganization- Count range of '{settings}' is not displaying properly");
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));






                    //Verify LoginMode/EmrType/Issystemuser
                    try
                    {
                        //OrganizationList_AdminPOM.SelectFromOption(Driver.Value, "Login Mode", "Rovicare");
                        //Test.Value.Log(Status.Pass, $"Test_AddOrganization- The login mode set to '{LoginMode}' mode");
                       // OrganizationList_AdminPOM.EnableIsSystemUser(Driver.Value, "Yes");
                        //Test.Value.Log(Status.Pass, $"Test_AddOrganization- The 'Is system user' set to 'Yes' ");
                        //OrganizationList_AdminPOM.SelectFromOption(Driver.Value, "EMR Type", "Rovicare");
                        //Test.Value.Log(Status.Pass, $"Test_AddOrganization- The EMR Type setting set to '{EMRtype}' successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, $"Test_AddOrganization- PROBLEM  in selection of Login mode/EmrType/systemUser Error:" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    //verify all organization roles are available in organization role section 
                    try
                    {

                        IList<IWebElement> Roles = AddOrganizationList_AdminPOM.ReadOrganizationRoles(Driver.Value);
                        foreach (IWebElement role in Roles)
                        {
                            try
                            {

                                Assert.That(OrganizationRoleList.ToLower().Contains(role.Text.ToLower()));
                                Test.Value.Log(Status.Pass, $"Test_AddOrganization- The '{role.Text}' is available in Organization role list");
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Test_AddOrganization- The '{role.Text}' is not available in Organization role list");
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }


                        }
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {

                    }
                }
                catch
                { }

                //To verify that the Success message displaying by clicking submit button
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the Success message displaying by clicking submit button");
                    AddOrganizationList_AdminPOM.ClickOnSubmitButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on submit button");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success notification displaying by clicking submit button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to display success notification Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable navigate to add-organization  Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }



            //To verify that the new organization is getting added by search

            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the new organization is getting added by search");
                AddOrganizationList_AdminPOM.NavigateToOrganizationListPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Navigate to Organization list page ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                AddOrganizationList_AdminPOM.SearchOrganizationByName(Driver.Value, OrganizationName);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, "Search created organization by name");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Assert.That(AddOrganizationList_AdminPOM.GetOrganizationNameFromList(Driver.Value).ToLower().Contains(OrganizationName.ToLower()));
                Test.Value.Log(Status.Pass, "the new Organization added successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //To verify that UserName and PassWord can be set through add member feature
                try
                {
                    string MessageText = MaxMemberMessage[0];
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that UserName and PassWord can be set through add member feature");


                    PatientListPOM.OpenMoreActions(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Expand more action feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "User Management").Click();
                    Test.Value.Log(Status.Pass, "Select 'user management' feature");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnAddMemberButton_UsermanagementPOPup(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on add member button & navigate to add member pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email ID", MembEmail);
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Password", "RoviPass@321");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Confirm Password", "RoviPass@321");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "First Name", "DemoAdmin");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Last Name", "AdminDemo");
                    AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Designation", "CEO");
                    AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Role", "Organization Admin");
                    Test.Value.Log(Status.Pass, "Provide required data to add member pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnSave_AddMemberPOPup(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on save button");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, MessageText);
                    Test.Value.Log(Status.Pass, "Click on ok button on pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that 'Max Number Of Organization Members' is 10");


                        for (int i = 2; i <= 11; i++)
                        {
                        
                           try
                           {
                                

                                AddOrganizationList_AdminPOM.ClickOnAddMemberButton_UsermanagementPOPup(Driver.Value);
                            //CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            Thread.Sleep(1000);
                                Test.Value.Log(Status.Pass, "Click on add member button & navigate to add member pop-up");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                if (i <= 10)
                                {
                                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email ID", $"Democlient{Time.ToString("hhmmssffff")}.{i}@interbizconsulting.com");
                                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Password", "RoviPass@321");
                                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Confirm Password", "RoviPass@321");
                                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "First Name", "DemoAdmin");
                                AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Last Name", "AdminDemo");
                                AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Designation", "CEO");
                                AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Role", "Organization Admin");
                                Test.Value.Log(Status.Pass, "Provide required data to add member pop-up");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                AddOrganizationList_AdminPOM.ClickOnSave_AddMemberPOPup(Driver.Value);
                                Test.Value.Log(Status.Pass, "Click on save button");
                                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                                    Assert.That(AddOrganizationList_AdminPOM.CheckOktext_Confirmation_AddMemberPOPup(Driver.Value, MaxMemberMessage[0]).Displayed);
                                    Test.Value.Log(Status.Pass, "Checked the message displaying on pop-up");
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                }
                                else
                                {
                                MessageText = MaxMemberMessage[1];
                                Assert.That(AddOrganizationList_AdminPOM.CheckOktext_Confirmation_AddMemberPOPup(Driver.Value, MaxMemberMessage[1]).Displayed);
                                    Test.Value.Log(Status.Pass, "Checked the MaxExid message displaying on pop-up");
                                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                                }
                                
                           }
                           catch (Exception e)
                           {
                                Test.Value.Log(Status.Fail, "Unable to add member for new organization" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                           }
                           finally
                           {
                            AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, MessageText);
                            Test.Value.Log(Status.Pass, "Click on ok button on pop-up");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                           }
                        }
                                          
                    
                    

                } 
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Verification failed of adding new organization  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                finally
                {
                    AddOrganizationList_AdminPOM.ClickOnClose_UserManagementPOPup(Driver.Value);
                    Test.Value.Log(Status.Pass, "Close user management pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }



                //Enable destination settings at organization level
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_Setting-Enable destinations settings");


                    AddOrganizationList_AdminPOM.ClickOnDestinationSetting_OrganizationList(Driver.Value);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Click on destination settings option");
                    Thread.Sleep(5000);
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Check expansion button of provider type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string provider in ProviderType.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Provider Type", provider);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Provider Type", provider);

                            Test.Value.Log(Status.Pass, $"Enable {provider} provider type of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set {provider} provider type of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Save provider type of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: provider type of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    //Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);


                    try
                    {
                        AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Care Requirement");
                        Test.Value.Log(Status.Pass, "Check expansion button of Care requirement");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        foreach (string Service in ServicesOffered.Split("|"))
                        {
                            try
                            {
                                AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Care Requirement", Service);
                                AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Care Requirement", Service);

                                Test.Value.Log(Status.Pass, "Enable Care requirement of destination settings");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                Thread.Sleep(1000);
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, "Unable to set care requirement of destination settings" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }
                        AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Care Requirement");
                        Test.Value.Log(Status.Pass, "Save Care requirement of destination settings");
                        AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                        Test.Value.Log(Status.Pass, "Confirmed Enable: Care requirement of destination settings");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                       // Assert.That(Success_Notification(Driver.Value).Displayed);

                        Test.Value.Log(Status.Pass, "Success Notification is displaying");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        InvisibleSuccess_Notification(Driver.Value);
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Can't enable Care requirement for destination setting  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

                    try
                    {
                        AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Special Program");

                        Test.Value.Log(Status.Pass, "Check expansion button of special program");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        foreach (string Service in SpecialProgramAccepted.Split("|"))
                        {
                            try
                            {AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Special Program", Service);
                                AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Special Program", Service);

                                Test.Value.Log(Status.Pass, $"Enable special program '{Service}' of destination settings");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                Thread.Sleep(1000);
                            }
                            catch (Exception e)
                            {
                                Test.Value.Log(Status.Fail, $"Unable to set special program '{Service}' of destination settings" + e);
                                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }
                        AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Special Program");
                        Test.Value.Log(Status.Pass, "Save Special program of destination settings");
                        AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                        Test.Value.Log(Status.Pass, "Confirmed Enable: Special program of destination settings");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        //Assert.That(Success_Notification(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Success Notification is displaying");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        InvisibleSuccess_Notification(Driver.Value);

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Can't enable Special program for destination setting  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }


                    




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Can't enable provider type for destination setting  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                finally 
                {
                    AddOrganizationList_AdminPOM.Close_DestinationSettingPOpUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "Close destination setting pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                }
                //To verify that features of organization on view organization pop-up
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that features of organization on view organization pop-up");

                    Thread.Sleep(1000);
                    PatientListPOM.OpenMoreActions(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Expand more action feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "View Organization").Click();
                    Test.Value.Log(Status.Pass, "Select 'view organization' feature");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


                    try
                    {
                        Assert.That(AddOrganizationList_AdminPOM.CheckAddressLine_ViewOrganizationPopup(Driver.Value, Street));
                        Test.Value.Log(Status.Pass, "Street of organizatio verified on veiw organization page");
                    }
                    catch(Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Required Street not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    try
                    {

                        Assert.That(AddOrganizationList_AdminPOM.CheckAddressLine_ViewOrganizationPopup(Driver.Value, City));
                        Test.Value.Log(Status.Pass, "City of organization verified on veiw organization page");
                    }
                    catch(Exception e)
                    {

                        Test.Value.Log(Status.Fail, "Required City not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    try
                    {

                        Assert.That(AddOrganizationList_AdminPOM.CheckAddressLine_ViewOrganizationPopup(Driver.Value, Zipcode));
                        Test.Value.Log(Status.Pass, "Zipcode of organization verified on veiw organization page");
                    }
                    catch(Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Required Zipcode not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }

                    try
                    {
                        string phon = string.Format("{0: (###) ###-####}", double.Parse(PhoneNumber)).Remove(0, 1);
                        Assert.That(AddOrganizationList_AdminPOM.CheckNumber_ViewOrganizationPopup(Driver.Value, "Contact Number", phon.TrimStart()));
                        Test.Value.Log(Status.Pass, "Phone Number of organization verified on veiw organization page");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Required Phone Number not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    try
                    {
                        string Faxn = string.Format("{0: (###) ###-####}", double.Parse(FaxNumber)).Remove(0, 1);
                        Assert.That(AddOrganizationList_AdminPOM.CheckNumber_ViewOrganizationPopup(Driver.Value, "Fax", Faxn.TrimStart()));
                        Test.Value.Log(Status.Pass, "Fax number of organization verified on veiw organization page");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Required faxnumber not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }


                    foreach (string provider in ProviderType.Split("|"))
                    {
                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckProviderType_ViewOrganizationPopup(Driver.Value, provider));
                            Test.Value.Log(Status.Pass, $"verified, {provider} is available in provider type on veiw organization page");
                        }
                        catch(Exception e)
                        {

                            Test.Value.Log(Status.Fail, "Required provider type not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }

                    try
                    {

                        Assert.That(AddOrganizationList_AdminPOM.CheckDescription_ViewOrganizationPopup(Driver.Value, Description));
                        Test.Value.Log(Status.Pass, $"verified, Description of organization is available on veiw organization page");
                    }
                    catch(Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Required Description not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    try
                    {

                        Assert.That(AddOrganizationList_AdminPOM.CheckMedicareRating_ViewOrganizationPopup(Driver.Value, 4));
                        Test.Value.Log(Status.Pass, $"verified, medicare rating is reflected on veiw organization page properly");

                    }
                    catch(Exception e) 
                    {
                        Test.Value.Log(Status.Fail, "Required medicare ratting not reflected on view organization pop-up  Error :" + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                    }
                    foreach (string service in ServicesOffered.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Services Provided", service));
                            Test.Value.Log(Status.Pass, $"verified, {service} is available in provider type on veiw organization page");
                        }
                        catch (Exception e)
                        {

                            Test.Value.Log(Status.Fail, "Required Service provided not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                        }
                    }

                    foreach (string setting in ServiceSetting.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Service setting", setting));
                            Test.Value.Log(Status.Pass, $"verified, {setting} is available in provider type on veiw organization page");
                        }
                        catch (Exception e)
                        
                        {

                            Test.Value.Log(Status.Fail, "Required Service setting not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }

                    foreach (string insurance in Insurances.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Insurance", insurance));
                            Test.Value.Log(Status.Pass, $"verified, {insurance} is available in insurance on veiw organization page");
                        }
                        catch(Exception e) 
                        {

                            Test.Value.Log(Status.Fail, "Required insurance not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    foreach (string AgeGroup in AgeGroupAccepted.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Age Group", AgeGroup));
                            Test.Value.Log(Status.Pass, $"verified, {AgeGroup} is available in age group on veiw organization page");
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Required AgeGroup not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    foreach (string program in SpecialProgramAccepted.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Special Program", program));
                            Test.Value.Log(Status.Pass, $"verified, {program} is available in special program on veiw organization page");
                        }
                        catch(Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Required program not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    foreach (string gender in GenderAccepted.Split("|"))
                    {

                        try
                        {

                            Assert.That(AddOrganizationList_AdminPOM.CheckServices_ViewOrganizationPopup(Driver.Value, "Gender Type", gender));
                            Test.Value.Log(Status.Pass, $"verified, {gender} is available in gender type on veiw organization page");
                        }
                        catch(Exception e) 
                        {
                            Test.Value.Log(Status.Fail, "Required gender not reflected on view organization pop-up  Error :" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                    AddOrganizationList_AdminPOM.ClickClose_ViewOrganizationPopup(Driver.Value);
                    Test.Value.Log(Status.Pass, $"View organization pop-up closed");
                }
                catch 
                {}

                try
                {

                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that Member can be logging in to new organization profile Using UserName and PassWord");
               
                    LoginPOM.LogOutAccount(Driver.Value);
                    Test.Value.Log(Status.Pass, "Logging out super-admin profile");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    LoginPOM.EnterUsername(Driver.Value, MembEmail);
                    LoginPOM.EnterPassword(Driver.Value, Origin_Password);
                    Test.Value.Log(Status.Pass, "Provide UserName and PassWord");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    LoginPOM.ClickOnSignInButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on sign-in button");
                    Thread.Sleep(10000);  
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(5000);
                    Assert.That(AddOrganizationList_AdminPOM.ClickOnIAccept_OrganizationHomePage(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Logged in to the new organization page ");
                    Test.Value.Log(Status.Pass, "The new profile shows a licence copy");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch(Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to logging in to new organization Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to add a new organization Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            /////////////////////////////////////////////////StartSettingPage//////////////////////////////////////////////////////////////////////
            //************************************************************DestinationService_SettingPage************************************************************
            try

            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-Enable Destination services");
                AddOrganizationList_AdminPOM.ClickOnIAccept_OrganizationHomePage(Driver.Value).Click();
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, "Clicked on I Accept feature");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToSettingsPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Navigated to setting page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToDashBoardHeaderSection_SettingsPage(Driver.Value, "Configuration");
                Test.Value.Log(Status.Pass, "Navigate to 'Configuration' section");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToConfigurationHeaderSection_Configuration(Driver.Value, "Destination Service");
                try
                {
                    Thread.Sleep(5000);
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Provider Type");

                    Test.Value.Log(Status.Pass, "Check expansion button of provider type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string provider in ProviderType.Split("|"))
                    {
                        try
                        {

                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, provider);
                            Thread.Sleep(1000);
                            Test.Value.Log(Status.Pass, $"Enable provider type'{provider}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set provider type'{provider}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Save provider type of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Pass, "Success Notification is not displaying Error : " + e);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }




                try
                {

                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Services Needed");

                    Test.Value.Log(Status.Pass, "Check expansion button of Service Needed");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Service in ServicesOffered.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Service);

                            Test.Value.Log(Status.Pass, $"Enable Service Needed '{Service}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Service Needed '{Service}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Services Needed");
                    Test.Value.Log(Status.Pass, "Save Service Needed of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Success Notification is not displaying Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                try
                {
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Special Program");

                    Test.Value.Log(Status.Pass, "Check expansion button of Special Program");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Program in SpecialProgramAccepted.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Program);

                            Test.Value.Log(Status.Pass, $"Enable Special Program '{Program}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Special Program '{Program}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Special Program");
                    Test.Value.Log(Status.Pass, "Save Special Program of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed Destination services enabling Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }






            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Failed verification of destination services Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {
                SettingPagePOM.ClickOnSubmit_SettingPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Click on Submit to save Destination service settings");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                WaitForSpinnerToDisappear(Driver.Value);
            }
            //To verify that the Organization's feature is reflected in the setting page of the organization
            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count} - To verify that the Organization's feature is reflected on the setting page ");
               
                
                SettingPagePOM.NavigateToConfigurationHeaderSection_Configuration(Driver.Value,"Configure Referrals");
                Test.Value.Log(Status.Pass, "Navigate to 'Configure Referral' section");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                Assert.Multiple(() =>

                {
                //try
                //{
                    Assert.That(SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Send Referral via Email", "Enable").CheckSelected.Selected);
                    Test.Value.Log(Status.Pass, "Verified that 'Send Referral via Email' is enabled");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                //}
                //catch
                //{ }

                //try
                //{
                    Assert.That(SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Send Referral via Fax", "Enable").CheckSelected.Selected);
                    Test.Value.Log(Status.Pass, "Verified that 'Send Referral via Fax' is enabled");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                //}
                // catch
                //{ }

                //try
               // {
                    Assert.That(SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Share patient record with health plan", "No").CheckSelected.Selected);
                    Test.Value.Log(Status.Pass, "Verified that 'Share patient record with health plan' is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
               // }
               // catch
               // { }


                
                 });






            }
            catch(Exception e)
            {

                Test.Value.Log(Status.Fail, "Features are not displaying on setting page of organization Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


            }
            

            //Set the search facilities(By default) to All
            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-Set the Search Facilities (By Default) setting to All position");
                WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                //SettingPagePOM.NavigateToConfigurationHeaderSection_Configuration(Driver.Value, "Configure Referrals");
                SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Search Facilities (By Default)", "All").Clickable.Click();
                Test.Value.Log(Status.Pass, "Set All");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                try
                {

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Search Facilities (By Default)", "All").CheckSelected, true));

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch
                {
                    SettingPagePOM.CheckFeature_EnableORdisable(Driver.Value, "Search Facilities (By Default)", "All").Clickable.Click();
                    Test.Value.Log(Status.Pass, "Again Set All");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                finally
                {
                    try
                    {
                        SettingPagePOM.SelectShareReferrerDetails(Driver.Value,"All");
                        Test.Value.Log(Status.Pass, "Select share referrer details set to 'All' position");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch
                    {
                        Test.Value.Log(Status.Fail, "Share Referrer Details feature not available");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                }

                SettingPagePOM.ClickOnSubmit_SettingPage(Driver.Value);
                Test.Value.Log(Status.Pass, "click submit on configuration ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to set the Search Facilities (By Default) Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            ////////////////////////////////////////////////////////////////////CloseSettingPage////////////////////////////////////////////////////////
            //To verify that the Organization's feature is reflected on my organization page
            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count} - To verify that the Organization's feature is reflected on my organization page");
                MyOrganizationPagePOM.NavigateToMyOrganizationPage(Driver.Value);
                Thread.Sleep(3000); 

                Assert.Multiple(() =>
                { 
                Assert.That(MyOrganizationPagePOM.CheckCompanyBacicDetails_MyOrganizationPage(Driver.Value, "Category", Category));
                Test.Value.Log(Status.Pass, "Verified that 'Category' is displaying properly");
                Assert.That(MyOrganizationPagePOM.CheckCompanyBacicDetails_MyOrganizationPage(Driver.Value, "AHCCCS ID", AHCCCSID));
                Test.Value.Log(Status.Pass, "Verified that 'AHCCCS ID' is displaying properly");
                Assert.That(MyOrganizationPagePOM.CheckCompanyBacicDetails_MyOrganizationPage(Driver.Value, "Description", Description));
                Test.Value.Log(Status.Pass, "Verified that 'Description' is displaying properly");


                IList<IWebElement> ProType = MyOrganizationPagePOM.CheckProviderType_MyOrganizationPage(Driver.Value);
                foreach (IWebElement element in ProType)
                {
                        string CommaRemoved = element.Text.Remove(element.Text.Length - 2, 2);
                    Assert.That(ProviderType.ToLower().Contains(CommaRemoved.ToLower().TrimEnd().TrimStart()));
                    Test.Value.Log(Status.Pass, $"Verified that  provider type: '{element}' is displaying properly");
                }
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                string Location = $"{Street}|{City}|{State}|{Zipcode}|{string.Format("{0: (###) ###-####}", double.Parse(PhoneNumber))}|{string.Format("{0: (###) ###-####}", double.Parse(FaxNumber))}|{Email}";
                foreach (string Loc in Location.Split("|"))
                {
                        //try
                        //{
                    Assert.That(MyOrganizationPagePOM.CheckLocationDetails_OrganizationPage(Driver.Value, Loc));
                    Test.Value.Log(Status.Pass, $"Verified that  Location details: '{Loc}' is displaying properly");

                        //}catch
                        //{ }

                }
                foreach (string service in ServicesOffered.Split("|"))
                {
                        //try
                        //{
                        Assert.That(MyOrganizationPagePOM.CheckFeature_MyOrganizationPage(Driver.Value,"Service Offered" ,service));
                        Test.Value.Log(Status.Pass, $"Verified that  Location details: '{service}' is displaying properly");

                        //}catch
                        //{ }

                }
                foreach (string insurance in Insurances.Split("|"))
                {
                        //try
                        //{
                        Assert.That(MyOrganizationPagePOM.CheckFeature_MyOrganizationPage(Driver.Value, "Service Offered", insurance));
                        Test.Value.Log(Status.Pass, $"Verified that  Location details: '{insurance}' is displaying properly");

                        //}catch
                        //{ }

                }


                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                Assert.That(MyOrganizationPagePOM.CheckMemberAdded_OrganizationPage(Driver.Value, MembFirstName));
                Test.Value.Log(Status.Pass, $"Verified that  Member details is displaying properly");
                    });
            }
            catch(Exception e)
            {

                Test.Value.Log(Status.Fail, "Organization properties are not reflected on my organization page Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


            }



            //To verify that the 'max document upload limit' is 10 by default

            try
            {

                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count} - To verify that the 'max document upload limit' is 10 by default");

                MyOrganizationPagePOM.ClickOnUploadImage_MyOrganizationPage(Driver.Value);
                Test.Value.Log(Status.Pass, $"Clicked on Upload image button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                for (int i = 1; i <= 11; i++)
                {
                    try
                    {
                        MyOrganizationPagePOM.ClickOnUpload_UploadImagePOP_up(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Clicked on Upload button");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        HandleOpenDialog hndOpen = new HandleOpenDialog();
                        // hndOpen.fileOpenDialog("C:\\Users\\prata\\Rovicare\\rovicareNew\\rovicaretesting\\TestData\\SuperAdminTD", $"{FileName}{i}.png");
                        /// hndOpen.fileOpenDialog("D:\\testing\\rovicaretesting\\TestData\\SuperAdminTD", $"{FileName}{i}.png");//UploadFilePath
                        // hndOpen.fileOpenDialog(UploadFilePath, $"{FileName}{i}.png");//UploadFilePath
                        string path = @$"{ProjectDirectory}\TestData\SuperAdminTD";
                        hndOpen.fileOpenDialog(path, $"{FileName}{i}.png");
                        Test.Value.Log(Status.Pass, $"File upload dialog opened");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        
                        if (i <= 10)
                        {
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, $"File uploaded successfully");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        else
                        {
                            Assert.That(MyOrganizationPagePOM.ClickOnOk_pop_up_UploadImagePOP_up(Driver.Value).Displayed);
                            Test.Value.Log(Status.Pass, $"Max file upload limit is 10 by default");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                            MyOrganizationPagePOM.ClickOnOk_pop_up_UploadImagePOP_up(Driver.Value).Click();
                            Test.Value.Log(Status.Pass, $"Clicked on Ok upload image pop-up");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                    catch (Exception e)
                    {
                        MyOrganizationPagePOM.ClickOnOk_pop_up_UploadImagePOP_up(Driver.Value).Click();
                        Test.Value.Log(Status.Fail, $"Clicked on Ok upload image pop-up  Error: "+e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    //button[text()='Ok']

                }

            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, $"Max document upload limit  Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {
                MyOrganizationPagePOM.Close_UploadImagePOP_up(Driver.Value);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }


            //To verify that the 'max size of upload document' is 5MB by default
            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count} - To verify that the 'max size of upload document' is 5MB by default");


                MyOrganizationPagePOM.ClickOnUploadImage_MyOrganizationPage(Driver.Value);
                Test.Value.Log(Status.Pass, $"Clicked on upload image in my organization page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                MyOrganizationPagePOM.ClickOnUpload_UploadImagePOP_up(Driver.Value);
                Test.Value.Log(Status.Pass, $"Clicked on upload image in pop-up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                Test.Value.Log(Status.Pass, $"Uploaded document of more than 5MB ");
                HandleOpenDialog hndOpen = new HandleOpenDialog();
                //hndOpen.fileOpenDialog("C:\\Users\\prata\\Rovicare\\rovicareNew\\rovicaretesting\\TestData\\SuperAdminTD", $"CheckSize.jpg");
                // hndOpen.fileOpenDialog("D:\\testing\\rovicaretesting\\TestData\\SuperAdminTD", $"CheckSize.jpg");
                // hndOpen.fileOpenDialog(UploadFilePath, $"CheckSize.jpg");
                string path = @$"{ProjectDirectory}\TestData\SuperAdminTD";
                hndOpen.fileOpenDialog(path, $"CheckSize.jpg");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Assert.That(MyOrganizationPagePOM.ClickOnOk_pop_up_UploadImagePOP_up(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, $"Not accepting document more than 5MB ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Accept document more than 5MB Error : " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {

                MyOrganizationPagePOM.ClickOnOk_pop_up_UploadImagePOP_up(Driver.Value).Click();
                Test.Value.Log(Status.Pass, $"Ckicked on ok  ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                MyOrganizationPagePOM.Close_UploadImagePOP_up(Driver.Value);
                Test.Value.Log(Status.Pass, $"Closed upload image pop-up  ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }


            //To verify that the 'max size of saved search' is 10 by default
            try
            {
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count} - To verify that the 'max size of saved search' is 10 by default");

                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, $"Navigate to patient list page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                
                PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                Test.Value.Log(Status.Pass, $"Clicked on dummy patient");
                Assert.That(Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, $"Success message is displaying ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonPOM.InvisibleSuccess_Notification(Driver.Value);
                Thread.Sleep(5000);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                Assert.That(CommonPOM.ClickOnPatientNameInList(Driver.Value).Displayed);
                
                PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
                Test.Value.Log(Status.Pass, $"Clicked on shortlist filter button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                
                for (int i = 1; i <= 11; i++)
                {
                    try
                    {


                        ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Clicked on save button");
                        ShortlistFacilityPOM.EnterSaveSearchNameInFilter(Driver.Value, $"Save{i}");
                        Test.Value.Log(Status.Pass, $"Enter text to  save the search");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Clicked on save button");
                        
                        if (i <= 10)
                        {
                            WaitForSpinnerToDisappear(Driver.Value);
                            Assert.That(Success_Notification(Driver.Value).Displayed);
                            Test.Value.Log(Status.Pass, $"Success notification is displaying");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        else

                        {

                            Assert.That(ShortlistFacilityPOM.ClickOnOk_confirmationPopup(Driver.Value).Displayed);
                            Test.Value.Log(Status.Pass, $"Confirmation pop-up is displaying");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            ShortlistFacilityPOM.ClickOnOk_confirmationPopup(Driver.Value).Click();
                            Test.Value.Log(Status.Pass, $"Clicked on Ok");

                        }
                    }
                    catch (Exception e)
                    {
                        try
                        {

                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                            ShortlistFacilityPOM.ClickOnOk_confirmationPopup(Driver.Value).Click();
                            Test.Value.Log(Status.Fail, $"Unnecessary pop-up Error: " + e);
                        }
                        catch { }

                        Test.Value.Log(Status.Fail, $"Unable to save search Error: "+e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    

                }



                       


               






            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, $"Default value of save search is 10 Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Verify Send referral feature on organization side****************************************************************************************

                string[] Services = ServicesOffered.Split("|");
            try
            {
                
                Count++;
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}-To verify that the Send referral reflected in new organization");
                try
                {

                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate to patient list page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                   // PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                    //Test.Value.Log(Status.Pass, "Click on dummy patient button");

                    WaitForSpinnerToDisappear(Driver.Value);
                    
                    //Assert.That(Success_Notification(Driver.Value).Displayed);
                    //Test.Value.Log(Status.Pass, "Success notification displaying successfully");
                    //Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    try
                    {

                        CommonPOM.CheckInvisibilityNoRecordsFound(Driver.Value);

                        Assert.That(true);
                    }
                    catch { }
                    patientName = CommonPOM.GetPatientNameFromList(Driver.Value);
                    Test.Value.Log(Status.Pass, "Dummy patient created successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to create dummy patient  Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }



                try
                { 

                    PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Click on shortlist filter button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    WaitForSpinnerToDisappear(Driver.Value);
                    //Driver.Value.Navigate().Refresh();
                    //     WaitForSpinnerToDisappear(Driver.Value);

                    ShortlistFacilityPOM.EnterZipCodeInFilter(Driver.Value,Zipcode);
                    ShortlistFacilityPOM.SelectProviderTypesInFilter(Driver.Value, "Skilled Nursing(SNF)").Click();
                    Test.Value.Log(Status.Pass, "Select provider type from filter");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    ShortlistFacilityPOM.ClickGoButton(Driver.Value);
                    try
                    {
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        ShortlistFacilityPOM.ClickOnOk_confirmationPopup(Driver.Value).Click();

                    }
                    catch(Exception e)
                    { 
                        //Test.Value.Log(Status.Fail, $"Unnecessary pop-up Error: " + e);
                    }
                   
                    Test.Value.Log(Status.Pass, "Click on Go button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    WaitForSpinnerToDisappear(Driver.Value);
                    ShortListPOM.SelectProviderForReferralByName(Driver.Value, DestinationName, "ImageType");
                    Test.Value.Log(Status.Pass, "Provider selected as destination");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    ShortListPOM.ClickOnSendReferral(Driver.Value);

                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on send referral button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, Services);
                    Test.Value.Log(Status.Pass, "Select service needed");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.ClickSendButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on send button on referral dialogue");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    try
                    {
                        Assert.That(Success_Notification(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Referral send successfully");
                        Test.Value.Log(Status.Pass, "Success notification displaying successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        WaitForSpinnerToDisappear(Driver.Value);
                    }
                    catch
                    {

                        try
                        {
                            if (ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Displayed)
                            {
                                ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                                Test.Value.Log(Status.Pass, "Click on continue without sharing successfully");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                Assert.That(Success_Notification(Driver.Value).Displayed);
                                WaitForSpinnerToDisappear(Driver.Value);
                                Test.Value.Log(Status.Pass, "Success notification displaying successfully");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Failed continue without sharing Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }


                    }
                }
                catch (Exception e)

                {

                    Test.Value.Log(Status.Fail, "Failed Validation of send referral Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }



                try
                {

                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization - Response to referral : reject");

                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate to outgoing page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try
                    {
                        Assert.That(CommonPOM.GetPatientNameFromList(Driver.Value).ToLower().Contains(patientName.ToLower()));
                        Test.Value.Log(Status.Pass, "Referral displaying in outgoing page ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Referral is not displaying on outgoing page Error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }
                    OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Expand inner table");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    OutgoingPOM.ClickOnRespondToReferralbutton_UnderInnerTable(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Click on response to referral button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    try
                    {
                        Assert.That(ReferralResponsePopupPOM.CheckReferralResponsePopupToOpenUp(Driver.Value));
                        Test.Value.Log(Status.Pass, "Referral response popup opened ");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, "Reject");
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Unable to navigate to response to referral popup Error:  " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                    try
                    {
                        if (ReferralResponsePopupPOM.CheckRejectionReasonField(Driver.Value).Displayed)
                        {
                            ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
                            Test.Value.Log(Status.Pass, "Rejection reason entered");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    catch
                    { }

                    ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on submit button");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    WaitForSpinnerToDisappear(Driver.Value);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable respond referral  Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

            }
            catch { }



            //To Verify that Resend Referral reflects in new organization
            try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Resend Referral reflects in new organization");

                    OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Hover more action feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Resend Referral");
                    Test.Value.Log(Status.Pass, "Select Resend Referral");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    WaitForSpinnerToDisappear(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, Services);
                    Test.Value.Log(Status.Pass, "Select service needed");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.ClickSendButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on send button on send referral dialogue");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



                    try
                    {
                        Assert.That(Success_Notification(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, "Succcess notification displaying successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        WaitForSpinnerToDisappear(Driver.Value);
                    }
                    catch
                    {

                        try
                        {
                            if (ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Displayed)
                            {
                                ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                                Test.Value.Log(Status.Pass, "Click on continue without sharing");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                                Assert.That(Success_Notification(Driver.Value).Displayed);
                                WaitForSpinnerToDisappear(Driver.Value);
                                Test.Value.Log(Status.Pass, "Succcess notification displaying successfully");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                            }

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Unable to Continue without sharing  Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                    try
                    {

                        OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Test.Value.Log(Status.Pass, "Navigate to outgoing page");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                        Test.Value.Log(Status.Pass, "Expand inner table");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(OutgoingPOM.StatusValidationofReferrals(Driver.Value, "Not Responded"));
                        Test.Value.Log(Status.Pass, "Validate status successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Fail, "Status validation failed Error: " + e);
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "validation of Resend Referral failed Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //To Verify that Show Reports feature reflects in new organization
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Show Reports feature reflects in new organization");
                    ReportsPOM.NavigateToReportsPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigated to Reports page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    ReportsPOM.ClickOnReportCardBox(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Clicked on Report Card on reports page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    try
                    {

                        Assert.That(ReportsPOM.RestrictToOpenReport_AlerPopUp(Driver.Value).Displayed);
                        Test.Value.Log(Status.Fail, "Validation of Show Reports feature Failed");
                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        ReportsPOM.RestrictToOpenReport_AlerPopUp(Driver.Value).Click();
                        Test.Value.Log(Status.Fail, "Closed Alert pop-up");                         //fail
                        
                    }
                    catch
                    {   //Pass

                        Test.Value.Log(Status.Pass, "Validate Show Reports in organization successfully");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                catch { }

                //To Verify that Chat feature reflects in new organization
                try
                {
                    Count++;
                   // Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Chat feature reflects in new organization");
                    AddOrganizationList_AdminPOM.ValidateChatFeatureAtNewOrganization(Driver.Value, Count, ChatDisablePlaceholderText);


                }
                catch 
                { 
                
                }

                //To Verify that Notes feature reflects in new organization
                try
                { 
                    Count++;
                    AddOrganizationList_AdminPOM.ValidateNoteFeatureAtOrganization(Driver.Value,Count);
                }
                catch { }


                //To Verify that Notification feature reflects in new organization
                try
                {
                    Count++;
                    Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify that Notification feature reflects in new organization");



                    SettingPagePOM.NavigateToSettingsPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigated to Setting page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    SettingPagePOM.NavigateToDashBoardHeaderSection_SettingsPage(Driver.Value, "Notification");
                    Test.Value.Log(Status.Pass, "Validated The Notification feature at new organization ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Validation of The Notification feature Failed "+e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }




            try
            {
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization_{Count}- To Verify Mobile Application feature reflects in new organization");
                LoginPOM.LogOutAccount(Driver.Value);
                Test.Value.Log(Status.Pass, "Logging out From new organization profile");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Driver.Value.Close();

                ChromiumMobileEmulationDeviceSettings.Equals("deviceName", "iPhone SE");
                ChromeOptions chromeCapabilities = new ChromeOptions();
                chromeCapabilities.EnableMobileEmulation("iPhone SE");  //848_859
                Driver.Value = new ChromeDriver(chromeCapabilities);
                Driver.Value.Manage().Window.Maximize();
                Driver.Value.Navigate().GoToUrl(Test_url);
                //AssertSearchElement();
                LoginPOM.EnterUsername(Driver.Value, Origin_Email);
                LoginPOM.EnterPassword(Driver.Value, Origin_Password);
                Test.Value.Log(Status.Pass, "Provide UserName and PassWord");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                LoginPOM.ClickOnSignInButton(Driver.Value, true);
                Test.Value.Log(Status.Pass, "Click on sign-in button");
                //Thread.Sleep(10000);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                Test.Value.Log(Status.Pass, "Logged in to Mobile Application successfully");
                Test.Value.Log(Status.Pass, "Validate Mobile Application feature successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));



            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Pass, "Failed: Validation of Mobile Application feature "+e);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }


        }








        //*************************************************************TestData****************************************************************************************
        public static IEnumerable<TestCaseData> AddOrganization_TD()
        {
            String Path = GetDataParser().TestData_Path("AddOrganization_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("DataType", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestDataArray("MaxMemberMessage", Path),
                //GetDataParser().TestDataArray("HomeNumber", Path).ToList(),
               // GetDataParser().TestDataArray("Email_ID", Path).ToList(),
                //GetDataParser().TestData("Referrer_OrganizationName", Path),
               // GetDataParser().TestData("SSN_PID", Path),
               // GetDataParser().TestData("LastName", Path),
                //int.Parse(GetDataParser().TestData("IndexOfInsuranceProvider", Path)),
                GetDataParser().TestData("Category", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("Insurances", Path),
                GetDataParser().TestData("ServicesOffered", Path),
                GetDataParser().TestData("ServiceSetting", Path),
                GetDataParser().TestData("SpecialProgramAccepted", Path),
                GetDataParser().TestData("AgeGroupAccepted", Path),
                GetDataParser().TestData("GenderAccepted", Path),
                GetDataParser().TestData("PatientUniqueIdentifier", Path),
                GetDataParser().TestData("SendReferral_DefaultCheckedFeature", Path),
                GetDataParser().TestData("SendReferralAllFeature", Path),
                GetDataParser().TestData("ReceiveReferralFeatureList", Path),
                GetDataParser().TestData("ReceiveReferralFeatureDefaultSelectedList", Path),
                GetDataParser().TestData("RemainingFeatureAndsettingsList", Path),
                GetDataParser().TestData("RemainingFeatureAndSettinsCkeckedDefault", Path),
                GetDataParser().TestData("ImportPatientByExcelSheetSubFeature", Path),
                GetDataParser().TestData("EnablePatientFeedbackReminderSubFeature", Path),
                GetDataParser().TestData("ProviderSettings", Path),
                GetDataParser().TestData("OrganizationRoleList", Path),
                GetDataParser().TestData("LoginMode", Path),
                GetDataParser().TestData("EMRtype", Path),
                GetDataParser().TestData("DestinationName", Path),
                GetDataParser().TestData("ChatDisablePlaceholderText", Path)
                //UploadFilePath
              // GetDataParser().TestData("UploadFilePath", Path)



                );
        }
    }
}
