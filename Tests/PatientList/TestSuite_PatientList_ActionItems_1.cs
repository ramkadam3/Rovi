using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System.Diagnostics;

namespace RovicareTestProject.Tests.PatientList
{
    //[Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_PatientList_ActionItems_1 : BaseClass
    {
        [SetUp]
        public void setUp()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value,Origin_Email,Origin_Password);

        }
        //*************************************************Test Execution E2E_ShortlistFacilityTest *********************************************************//

        [Test, Order(1)]
        [Author("Samarth S Gaur"), Category("Functional")]
        [TestCaseSource("ShortListFacility_TD")]
        public static void Test_PatientList_AI_ShortlistFacilityTest(
            String FacilityType,
            String Zipcode,
            String Miles,
            String ProviderType,
            String ServicesNeeded,
            String Insurance,
            String Genders,
            String AgeGroups,
            String SpecialPrograms,
            String SaveSearchName

            )
        {
                        WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
            try
            {
                // Navigate to Patient Page
                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                try
                {
                    FiltersPOM.ClearFilter_PatientList(Driver.Value);
                }
                catch { }

                //Test_ShortlistFacility_TC_001 - Click on the blue funnel icon under action item of one the patients
                try
                {
                    Test.Value = ExtentTestManager.CreateTest("Test_ShortlistFacility_TC_001 - To verify that Shortlist Facility icon navigate to Shortlist Filter page");
                    PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
                   // WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Go']")));
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_001 - Page redirected to ShortList Provider Page Successfully ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "Test_ShortlistFacility_TC_001 -  Failed, ShortList Provider Page does not load,  Error: " + ex);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }

                //Test_ShortlistFacility_TC_003 - Select Behavioral option under Facility Type

                try
                {
                    Test.Value = ExtentTestManager.CreateTest("Test_ShortlistFacility_TC_003 - To verify that selecting Medical/Behavioral under Facility type shows different options as per requirements");
                    ShortlistFacilityPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, FacilityType);

                    if (FacilityType == "Medical")
                    {
                        //Select Medical option under Facility Type
                        //Verify only following section shows up -Provider Type, Services Needed, Insurance
                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Provider Type']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Provider Type section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Services Needed']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Services Needed section is visible");

                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }

                    //Verify following section shows up - Provider Type,  Services Needed, Insurance, Gender, Age Group, Special Program
                    else if (FacilityType == "Behavioral")
                    {
                        //ShortlistFilterPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, FacilityType);
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[normalize-space()='Gender']")));

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[contains(normalize-space(),'Provider Type')]"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Provider Type section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Services Needed']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Services Needed section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Insurance']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Insurance section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Gender']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Gender section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Age Group']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Age Group section is visible");

                        Assert.That((Driver.Value.FindElement(By.XPath("//label[normalize-space()='Special Program']"))).Displayed);
                        Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_003 - Special Program section is visible");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "Test_ShortlistFacility_TC_003 -  Failed, filter section missing,  Error: " + ex);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {
                    Test.Value = ExtentTestManager.CreateTest("Test_ShortlistFacility_TC_004 - To verify that Save Search, Clear and Go functionality is working as per requirement");
                    try
                    {
                        ShortlistFacilityPOM.SelectProviderTypesInFilter(Driver.Value, ProviderType).Click();
                        ShortlistFacilityPOM.SelectServicesNeededInFilter(Driver.Value, ServicesNeeded.Split("|"));
                        ShortlistFacilityPOM.SelectInsurancesInFilter(Driver.Value, Insurance.Split("|"));
                        ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                        ShortlistFacilityPOM.EnterSaveSearchNameInFilter(Driver.Value, SaveSearchName);
                        Thread.Sleep(500);
                        ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        Thread.Sleep(500);

                        try
                        {
                            if (Driver.Value.FindElement(By.XPath($"//div[contains(text(),'Search name already exist.')]|//div[contains(@class,'save-search-clip')]")).Displayed)
                            {
                                //Driver.Value.FindElement(By.XPath("//button[normalize-space()='Ok']")).Click();
                                int temp = Driver.Value.FindElements(By.XPath("(//i[@title='Delete'])")).Count;
                                for (int i = 1; i <= temp; i++)
                                {
                                    Driver.Value.FindElement(By.XPath($"(//i[@title='Delete'])[{i}]")).Click();
                                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='deleteSavedSearchModal']/div/div/div[3]/div[1]/button")));
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Confirm Delete Pop Up comes up", CaptureScreenShot(Driver.Value, Filename));
                                    Driver.Value.FindElement(By.XPath("//*[@id='deleteSavedSearchModal']/div/div/div[3]/div[1]/button")).Click();
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Fav search deleted successfully", CaptureScreenShot(Driver.Value, Filename));
                                }
                            }
                            
                           
                            
                        }
                        catch
                        {
                            ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                            ShortlistFacilityPOM.EnterSaveSearchNameInFilter(Driver.Value, SaveSearchName);
                            Thread.Sleep(500);
                            ShortlistFacilityPOM.ClickSaveButton(Driver.Value);
                            Thread.Sleep(500);
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Fav search saved successfully", CaptureScreenShot(Driver.Value, Filename));
                            Assert.That(Driver.Value.FindElement(By.XPath($"//div[@title='{SaveSearchName}']")).Displayed);
                            ShortlistFacilityPOM.ClickSavedSearchDeleteButton(Driver.Value);
                            Thread.Sleep(2000);
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Confirm Delete Pop Up comes up", CaptureScreenShot(Driver.Value, Filename));
                            ShortlistFacilityPOM.ClickOnDeleteButtonInDeleteSearchPopUp(Driver.Value);
                            Thread.Sleep(2000);
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Fav search deleted successfully", CaptureScreenShot(Driver.Value, Filename));
                        }
                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//div[@title='{SaveSearchName}']")).Displayed);
                        }
                        catch (NoSuchElementException ex)
                        {
                            Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_004 - Passed, Save Search and Delete Saved Search functionality is working fine"+ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, "Test_ShortlistFacility_TC_004 - Failed, Saved Search is not deleted");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }

                    //Test_ShortlistFacility_TC_004 - To verify that the zipcode Field accepts number and alphabets , user can select 5 to 50 miles as range
                    Test.Value = ExtentTestManager.CreateTest("Test_ShortlistFacility_TC_005 - To verify that the zipcode Field accepts number and alphabets , user can select 5 to 50 miles as range");
                    Thread.Sleep(2000);
                    ShortlistFacilityPOM.EnterZipCodeInFilter(Driver.Value, Zipcode);
                    ShortlistFacilityPOM.SelectMilesInFilter(Driver.Value, int.Parse(Miles));

                    Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_005 - Zipcode and miles entered successfully", CaptureScreenShot(Driver.Value, Filename));

                    //Test_ShortlistFacility_TC_006 - To verify  that after selecting Provider Type (for both Medical/Behavioral)
                    //all other options (Service Needed, Age group, Special Program) gets updated as per requirements
                    ShortlistFacilityPOM.SelectProviderTypesInFilter(Driver.Value, ProviderType).Click();
                    ShortlistFacilityPOM.SelectServicesNeededInFilter(Driver.Value, ServicesNeeded.Split("|"));
                    ShortlistFacilityPOM.SelectInsurancesInFilter(Driver.Value, Insurance.Split("|"));

                    if (FacilityType == "Behavioral")
                    {
                        //Thread.Sleep(2000);
                        ShortlistFacilityPOM.SelectGenderInFilter(Driver.Value, Genders.Split("|"));
                        ShortlistFacilityPOM.SelectAgeGroupsInFilters(Driver.Value, AgeGroups.Split("|"));
                        ShortlistFacilityPOM.SelectSpecialProgramsInFilter(Driver.Value, SpecialPrograms.Split("|"));
                    }

                    Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_005 - Filter Criteria entered successfully", CaptureScreenShot(Driver.Value, Filename));

                    ShortlistFacilityPOM.ClickGoButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    ShortlistFacilityPOM.WaitForShortlistFilterPageToLoadUp(Driver.Value);
                    //Thread.Sleep(2000);

                    Test.Value = ExtentTestManager.CreateTest("Test_ShortlistFacility_TC_006 - To verify that same search criteria is select as before");
                    //Verify that same search criteria is select as before
                    Test.Value.Log(Status.Pass, "Test_ShortlistFacility_TC_006 - Shortlist Provider page loads up successfully", CaptureScreenShot(Driver.Value, Filename));

                    try
                    {
                        Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='Zipcode: {Zipcode} In {Miles} Miles']")).Displayed);
                        Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{ProviderType}']")).Displayed);

                        foreach (var Service in ServicesNeeded.Split("|"))
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{Service}']")).Displayed);
                        }

                        foreach (var Insurer in Insurance.Split("|"))
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{Insurer}']")).Displayed);
                        }

                        if (FacilityType == "Behavioral")
                        {
                            foreach (var Gender in Genders.Split("|"))
                            {
                                Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{Gender}']")).Displayed);
                            }
                            foreach (var Age in AgeGroups.Split("|"))
                            {
                                Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{Age}']")).Displayed);
                            }
                            foreach (var Program in SpecialPrograms.Split("|"))
                            {
                                Assert.That(Driver.Value.FindElement(By.XPath($"//span[@title='{Program}']")).Displayed);
                            }
                        }
                        Thread.Sleep(3000);
                        Test.Value.Log(Status.Pass, " Test_ShortlistFacility_TC_006 - Verified that same search criteria is showing up in the Shortlist Provider Page", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, "Test_ShortlistFacility_TC_006 - Failed, Missing search parameter");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, "Test_ShortlistFacility - Failed, filter section missing,  Error: " + ex);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test_ShortlistFacility - Failed, filter section missing,  Error: " + ex);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
        }

        /***************************************** Test Data *****************************************/

        public static IEnumerable<TestCaseData> ShortListFacility_TD()
        {
            String Path = GetDataParser().TestData_Path("ShortListFacility_TD");
            yield return new TestCaseData(

                  GetDataParser().TestData("TD1_FacilityType", Path),
                  GetDataParser().TestData("TD1_Zipcode", Path),
                  GetDataParser().TestData("TD1_Miles", Path),
                  GetDataParser().TestData("TD1_ProviderType", Path),
                  GetDataParser().TestData("TD1_ServicesNeeded", Path),
                  GetDataParser().TestData("Insurance", Path),
                  GetDataParser().TestData("Genders", Path),
                  GetDataParser().TestData("AgeGroups", Path),
                  GetDataParser().TestData("SpecialPrograms", Path),
                  GetDataParser().TestData("SaveSearchName", Path)

                );
        }

        //*************************************************Test Execution E2E_SendReferralTest *********************************************************//

        // Send referral from patient list:
        // Login -> Patient Page -> Search Patient -> Click on Green Send Referral Icon
        // -> Click on Send Referral Icon without shortlisting -> Fill Mandatory fields ->Send
        // Validating patient list is updated with the above changes (Screenshot)
        // Verify in outgoing page -> Verify in patient list -> Verify in Referral Report

        //[Parallelizable(ParallelScope.All)]
        //[Serializable(SerializableAttribute.all)]
        [Test, Order(2)]
        [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("SendReferral_TD_Flow1")]
        [TestCaseSource("SendReferral_TD_Flow2")]
        [Author("Ram Kadam"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("SendReferral_TD_Flow3")]
        public void Test_PatientList_AI_SendReferralTest(
            String Flow,
            String ShortlistPageSendReferral,
            String ShortlistPageSendMultipleReferral,
            String PateintListPatientDetailsSendReferral,
            String FacilityType,
            String Zipcode,
            String SearchFacility,
            String Miles,
            String ProviderType,
            String ProviderName,
            String ServicesNeeded,
            String Insurance,
            String Gender,
            String AgeGroups,
            String SpecialPrograms,
            String MultipleReferrals,
            String PatientAttributes,
            String ReferralType1,
            String ReferralType2,
            String Note,
            String MoreReferral,
            String PreAuthorization,
            String AcceptReject,
            String InsuranceAuthorizationStatus,
            String AppointmentDateTime,
            String StatusToBeVerified,
            String StatusToBeVerified_AfterReferralConfirmation,
            String Mode,
            String Responsestatus

            )
         {
            

            
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"E2E_SendReferralTest -{Flow}- Creating dummy patient to perform test");
                //Navigate to Patient List page
                PatientListPOM.NavigateToPatientListPage(Driver.Value);

                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                try
                {
                    FiltersPOM.ClearFilter_PatientList(Driver.Value);
                }
                catch { }
                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                Test.Value.Log(Status.Pass, $"E2E_SendReferralTest,-{Flow}- Navigated to Patient Page");
                //if you do not want to create dummy patient then comment out below four line
                PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
               PatientListPOM.WaitForDummyPatientConfirmation(Driver.Value);
                BaseClass.InvisibleSuccess_Notification(Driver.Value);
                Test.Value.Log(Status.Pass, $"E2E_SendReferralTest, -{Flow}-Dummy Patient Created Successfully", CaptureScreenShot(Driver.Value, Filename));
                
                Thread.Sleep(5000);
            }
            catch (Exception ex) { Test.Value.Log(Status.Fail, $"E2E_SendReferralTest, -{Flow}-Unable to create dummy patient" + ex, CaptureScreenShot(Driver.Value, Filename)); }


            String PatientName = PatientListPOM.GetDummyPatientName(Driver.Value);
            try
            {
                if (bool.Parse(ShortlistPageSendReferral) == true)
                {
                    System_Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral  E2E_TC_001 -{Flow}- To verify that user can send referral via Green icon from shortlist provider page");

                    Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_001 -{Flow}- To verify that Send Referral button in Shortlist Provider Page is redirecting to Send Referral Pop Up");

                    try
                    {
                        // Navigating to Patient Page
                        PatientListPOM.NavigateToPatientListPage(Driver.Value);
                      PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                      Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001,- Navigated to Patient Page", CaptureScreenShot(Driver.Value, Filename));

                        // Searching for the patient by Search By name Filter
                       
                        
                                            
                       
                       
                        PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);


                        PatientListPOM.WaitForReferralTableToBeClickable(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001,-{Flow}- Search the patient name successfully", CaptureScreenShot(Driver.Value, Filename));

                        // Clicking on Send Referral icon under action items in Patient List
                        PatientListPOM.ClickSendReferral(Driver.Value, 1);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        


                        // Validating that Shortlist page gets populated
                        Assert.That(Driver.Value.FindElement(By.XPath("//tbody/tr[2]/td[1]/div[1]/div[2]")).Displayed);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001,- Validated Shortlist Result Page gets populated, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_001,- Test Case Failed, ShortList Provider Page does not load, Error:       " + ex);
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }

                    // Enter the search criteria and click on go

                    ShortListPOM.EnterZipCodeInFilter(Driver.Value, Zipcode);
                    ShortListPOM.SelectOptionInSearchFacilitiesInFilter(Driver.Value, SearchFacility);
                    ShortListPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, FacilityType);
                    ShortListPOM.SelectProviderTypesInFilter(Driver.Value, ProviderType);
                    ShortListPOM.SelectServicesNeededInFilter(Driver.Value, ServicesNeeded.Split("|"));
                    ShortListPOM.SelectInsuranceInFilter(Driver.Value, Insurance.Split("|"));

                    if (FacilityType == "Behavioral")
                    {
                        ShortListPOM.SelectSpecialProgramsInFilter(Driver.Value, SpecialPrograms.Split("|"));
                        ShortListPOM.SelectGenderInFilter(Driver.Value, Gender.Split("|"));
                        ShortListPOM.SelectAgeGroupsInFilters(Driver.Value, AgeGroups.Split("|"));
                    }

                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001, Filter Criteria entered successfully", CaptureScreenShot(Driver.Value, Filename));

                    ShortListPOM.ClickGoButtonInFilter(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    ShortListPOM.WaitForSortListResultToLoad(Driver.Value);     
                    //ShortListPOM.SearchProviderByName(Driver.Value, ProviderName);
                   // WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                   // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//tr[2]/td[1]")));
                    //Thread.Sleep(3000);

                    // Click on Send Referral icon under row 1 action items in Shotlist Page

                    ShortListPOM.ClickSendReferralAction(Driver.Value, 1);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    //Send Referral Pop Up should open up
                    try
                    {
                        WebDriverWait wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                        wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//descendant::mat-dialog-content/descendant::h4[@class='color-header-dark margin-record ng-star-inserted']")));
                        wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//descendant::mat-dialog-content/descendant::h4[@class='color-header-dark margin-record ng-star-inserted']")));
                        Thread.Sleep(2000);
                        Assert.That(ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value).Displayed);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001 Passed,- Verified that Send Referral button in Shortlist Provider Page is redirecting to Send Referral Pop Up", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_001 Failed,- Send Referral button in Shortlist Provider Page is NOT redirecting to Send Referral Pop Up" + ex, CaptureScreenShot(Driver.Value, Filename));
                    }
                }

                //****************************************************************************************************************************************//
                else if (bool.Parse(ShortlistPageSendMultipleReferral) == true)
                {
                    System_Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral  E2E_TC_002 -{Flow}- To verify that origin user can send referral via Orange icon from shortlist provider page");

                    //Test_SendReferral_TC_002 - To verify that Orange Send Referral button  in Shortlist Provider Page is redirecting to Send Referral Pop Up
                    Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_002 -{Flow}-To verify that Orange Send Referral button  in Shortlist Provider Page is redirecting to Send Referral Pop Up");
                    try
                    {
                        // Navigating to Patient Page
                        PatientListPOM.NavigateToPatientListPage(Driver.Value);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Navigated to Patient Page", CaptureScreenShot(Driver.Value, Filename));

                        // Searching for the patient by Search By name Filter
                        PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Search the patient name successfully", CaptureScreenShot(Driver.Value, Filename));

                        // Clicking on Send Referral icon under action items in Patient List
                        PatientListPOM.ClickSendReferral(Driver.Value, 1);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        ShortListPOM.WaitForSortListResultToLoad(Driver.Value);

                        // Validating that Shortlist page gets populated
                        Assert.That(Driver.Value.FindElement(By.XPath("//tbody/tr[2]/td[1]/div[1]/div[2]")).Displayed);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Validated Shortlist Result Page gets populated, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                        // Enter the search criteria and click on go

                        ShortListPOM.EnterZipCodeInFilter(Driver.Value, Zipcode);
                        ShortListPOM.SelectOptionInSearchFacilitiesInFilter(Driver.Value, SearchFacility);
                        ShortListPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, FacilityType);
                        ShortListPOM.SelectProviderTypesInFilter(Driver.Value, ProviderType);
                        ShortListPOM.SelectServicesNeededInFilter(Driver.Value, ServicesNeeded.Split("|"));
                        ShortListPOM.SelectInsuranceInFilter(Driver.Value, Insurance.Split("|"));

                        if (FacilityType == "Behavioral")
                        {
                            ShortListPOM.SelectSpecialProgramsInFilter(Driver.Value, SpecialPrograms.Split("|"));
                            ShortListPOM.SelectGenderInFilter(Driver.Value, Gender.Split("|"));
                            ShortListPOM.SelectAgeGroupsInFilters(Driver.Value, AgeGroups.Split("|"));
                        }

                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Filter Criteria entered successfully", CaptureScreenShot(Driver.Value, Filename));

                        ShortListPOM.ClickGoButtonInFilter(Driver.Value);
                        ShortListPOM.WaitForShortlistTableToBeClickable(Driver.Value);
                        //ShortListPOM.SearchProviderByName(Driver.Value, ProviderName);
                       
                        Thread.Sleep(3000);

                        ShortListPOM.SelectProvidersByCheckboxes(Driver.Value, MultipleReferrals);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Multiple providers selected");
                        ShortListPOM.ClickTopSendReferralButton(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002,- Clicked on Send Referral button on the top right corner of the window", CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value).Displayed);
                        //Assert.That(Driver.Value.FindElement(By.XPath("//h4[@class='color-header-dark margin-record ng-star-inserted']")).Displayed);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_002 Passed,- Verified that send referral pop up is getting populated when multiple providers are selected by clicking on orange Send Referral button");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_002 Failed,- Unable to send referral to multiple providers, Error:   " + ex, CaptureScreenShot(Driver.Value, Filename));
                    }
                }

                //****************************************************************************************************************************************//
                else if (bool.Parse(PateintListPatientDetailsSendReferral) == true)

                {
                    System_Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral  E2E_TC_003 -{Flow}- To verify that origin user can send referral via Patient Details after adding providers in provider section");
                    try
                    {
                        PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        PatientListPOM.WaitForReferralTableToBeClickable(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_001,-{Flow}- Search the patient name successfully", CaptureScreenShot(Driver.Value, Filename));
                        CommonPOM.ClickOnPatientNameInList(Driver.Value).Click();

                        //CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        Thread.Sleep(7000);
                        Assert.That(ViewPatientPOM.HeadlineOfPatientdetail_POPUp(Driver.Value).ToLower().Contains(PatientName.ToLower()));
                        ViewPatientPOM.ClickAddProvidersButton(Driver.Value);
                        ViewPatientPOM.SelectProviderType_AddProviderPOPUP(Driver.Value, ProviderType);
                        ViewPatientPOM.ClickOnSearchButton_AddProviderPOPUP(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        ViewPatientPOM.SelectProviderFromTable_AddProviderPOPUP(Driver.Value);
                        ViewPatientPOM.ClickOnSaveButton_AddProviderPOPUP(Driver.Value);
                        Assert.That(Success_Notification(Driver.Value).Displayed);
                        ViewPatientPOM.ClickOnSendReferralButton_ViewPatient(Driver.Value);
                        ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                        //CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                        ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);
                        Thread.Sleep(1000);
                        ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split("|"));
                        Thread.Sleep(1000);
                        ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_003 Failed,- Error:   " + ex, CaptureScreenShot(Driver.Value, Filename));
                    }
                    //ShortListPOM.ClickSendButton(Driver.Value);
                    //BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    //Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));

                }

                //Verify that all required checkboxes under Patient information section of the pop up is visible and checked
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_004 -{Flow}- To verify that Send Referral Pop Up contains all required checkboxes");

                try
                {
                    WebDriverWait wait1 = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                    wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h4[@class='color-header-dark margin-record ng-star-inserted']")));
                    Thread.Sleep(2000);
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='selectAllSettings']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='insuranceCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='careCoordinationCheck']")).Selected);
                    }catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='allergyCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='diagnosisCheck']")).Selected);
                    }catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='emergencyContactCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='immunizationCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='medicalRecordCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='progressNoteCheck']")).Selected);
                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//div[@class='col-md-3']//div[@id='PInfo']//patient-attributes-checkbox//div//input[@id='facesheet-check']")).Selected);
                    }
                    catch { }
                    
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_004,- Verified that Send Referral Pop Up contains all required checkboxes, by default all the checkboxex are selected, Care Cordination is checked and is greyed out", CaptureScreenShot(Driver.Value, Filename));

                    ShortListPOM.SelectPatientAttributes(Driver.Value, PatientAttributes);
                    Thread.Sleep(1000);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_004 Passed,- Verified that checkboxes are enabled to check under patient information ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_004 Failed,- Error:   " + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                // Verify that search criteria is getting carried forward in Provider Type, Services  Needed and Special Program
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_005 -{Flow}- To verify that Provider Type, Special Program and Services Needed option is already selected with the search criteria");
                try
                {
                    Thread.Sleep(1000);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_005,- Verified that Provider Type is available to select from the drowdown");
                    ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);

                    foreach (String Services in ServicesNeeded.Split("|"))
                    {//label[contains(text(),'Services Needed')]/following::input[]
                        try
                        {

                            Assert.That(Driver.Value.FindElement(By.XPath($"//descendant::search-and-select/descendant::span[contains(text(),'{Services}')]")).Displayed);
                        }
                        catch { }
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_005,- Verified {Services} is selected");
                    }
                    foreach (String Program in SpecialPrograms.Split("|"))
                    {try
                        {

                        Assert.That(Driver.Value.FindElement(By.XPath($"//descendant::search-and-select/descendant::span[contains(text(),'{Program}')]")).Displayed);
                        }catch { }
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_005,- Verified {Program} is selected");
                    
                    }
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_005 Passed,- Verified that Provider Type, Special Program and Services Needed option is already selected with the search criteria ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_005 Failed,- Missing search parameter, Error = " + ex);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //Verify that after selecting Outpatient under Referral , makes Auto Confirm option appears
                //Verify that after selecting Inpatient under Referral , makes Auto Confirm option disappears
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_006 -{Flow}- To verify that selecting Outpatient also validate Auto Confirm check box can be checked off/on and pre-authoriazation required is enabled and can be checked/unchecked ");
                try
                {
                    ShortListPOM.SelectReferralType(Driver.Value, ReferralType2);

                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath("//descendant::label[contains(text(),'Referral Type')]/following::input[2]")).Selected);
                    }
                    catch { }
                    try
                    {
                        Assert.That(Driver.Value.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input")).Displayed);

                    }
                    catch { }
                    try
                    {

                        Assert.That(Driver.Value.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input")).Selected);
                    }
                    catch { }

                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_006,- Verified that after selecting Outpatient under Referral , auto Confirm option is displayed and is checked by default", CaptureScreenShot(Driver.Value, Filename));

                        Driver.Value.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input")).Click();
                        Thread.Sleep(1000);

                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_006,- Verified that Auto Cofirm option is enabled and can be unchecked", CaptureScreenShot(Driver.Value, Filename));

                        ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, true);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_006,- Verified that Pre-Authorization checkbox can be checked", CaptureScreenShot(Driver.Value, Filename));
                        Assert.That(Driver.Value.FindElement(By.XPath("//label[contains(text(),'Pre-Authorization Required')]/following-sibling::input")).Selected);
                    
                            ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, false);
                    Thread.Sleep(2000);

                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_006 Passed,- Verified that Pre-Authorization Required checkbox is enabled ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_006 Failed,- Pre-Authorization Required checkbox is not working as expected ", CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.SelectReferralType(Driver.Value, ReferralType2);
                }

                
                try
                { 
                   Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_007 -{Flow}- To verify that after selecting Inpatient under Referral Type makes Auto Confirm option disappears and vise versa ");
                    try
                    {

                        ShortListPOM.SelectReferralType(Driver.Value, ReferralType1); // Selecting InPatient
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        Thread.Sleep(3000);
                        Assert.That(Driver.Value.FindElement(By.XPath("//label[contains(text(),'Auto Confirm')]/following-sibling::input")).Displayed);
                        Test.Value.Log(Status.Fail, "Test_SendReferral_TC_007 Failed,- Verify that after selecting Inpatient under Referral , Auto Confirm option disappears", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch (Exception ex)
                    {
                        Test.Value.Log(Status.Pass, "Test_SendReferral_TC_007 Passed,- Verify that after selecting Inpatient under Referral , Auto Confirm option disappears", CaptureScreenShot(Driver.Value, Filename));
                        ShortListPOM.SelectReferralType(Driver.Value, ReferralType2);
                    }

                   
                    
                        //Enter notes and click on Send button
                        ShortListPOM.EnterNoteSendReferralDialog(Driver.Value, Note);
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    ShortListPOM.ClickSendButton(Driver.Value);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    
                       
                        ///Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                        try
                    {

                        ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                    }
                    catch { }

                        Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                        // Assert.That(Driver.Value.FindElement(By.XPath("//notifier-notification[@class='notifier__notification notifier__notification--info notifier__notification--material']")).Displayed);
                        if (bool.Parse(ShortlistPageSendReferral) == true)
                            System_Test.Value.Log(Status.Pass, "Test_SendReferral  E2E_TC_001 Passed,- Verified that origin user can send referral via Green icon from shortlist provider page", CaptureScreenShot(Driver.Value, Filename));
                        else if (bool.Parse(ShortlistPageSendMultipleReferral) == true)
                            System_Test.Value.Log(Status.Pass, "Test_SendReferral  E2E_TC_002 Passed,- Verified that origin user can send referral via Orange icon from shortlist provider page", CaptureScreenShot(Driver.Value, Filename));
                        else if (bool.Parse(PateintListPatientDetailsSendReferral) == true)
                        {
                            System_Test.Value.Log(Status.Pass, "Test_SendReferral  E2E_TC_003 Passed,- Verified that origin user can send referral via Patient Details after adding providers in provider section", CaptureScreenShot(Driver.Value, Filename));
                            ViewPatientPOM.ClosePatientDetailsPOPUp(Driver.Value);
                        }

                    }
                    catch (Exception ex)
                    {
                        if (bool.Parse(ShortlistPageSendReferral) == true)
                            System_Test.Value.Log(Status.Pass, $"Test_SendReferral  E2E_TC_001 Failed,- Unable to send referral from origin via Green icon from shortlist provider page", CaptureScreenShot(Driver.Value, Filename));
                        else if (bool.Parse(ShortlistPageSendMultipleReferral) == true)
                            System_Test.Value.Log(Status.Pass, $"Test_SendReferral  E2E_TC_002 Failed,- Unable to send referral from origin via Orange icon from shortlist provider page", CaptureScreenShot(Driver.Value, Filename));
                        else if (bool.Parse(PateintListPatientDetailsSendReferral) == true)
                            System_Test.Value.Log(Status.Pass, $"Test_SendReferral  E2E_TC_003 Failed,- Unable to send referral from origin via Patient Details after adding providers in provider section", CaptureScreenShot(Driver.Value, Filename));
                    }
                
                
                // Navigate to Outgoing Page Verify that the first row under Referral section should show our patient and status as Referral Sent
                // TC_012 - To verify that after sending referral , the outgoing page gets updated with all the recent outgoing referrals

                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_008 --{Flow}- To verify that after sending referral , the outgoing page gets updated with all the recent outgoing referrals ");

                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                try
                {
                    FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                }
                catch { }


                CommonPOM.WaitForSpinnerToDisappear(Driver.Value);
                
                
                try


                {
                    String temp = CommonPOM.GetPatientNameFromList(Driver.Value);
                    if (temp == PatientName)
                    {
                        Assert.That(Driver.Value.FindElement(By.XPath("//tr[2]/td/descendant::status-labels")).Displayed);

                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_008,- Patient info showing up successfully under outgoing page with status as Referral Sent, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                        OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                        //int AddedSentReferral = OutgoingPOM.CountNumberOfReferralSentInnerTable(Driver.Value, 1);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_008 Passed,- Total Count of Referral sent: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_008 Failed,- Patient info is not showing up, Screenshot: " + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                //Click on the plus (+) icon under action items - Shortlist Page should open up
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_009 -{Flow}- To verify that user can send more referral from outgoing + plus icon , navigating through the shortlist provider page again");
                try
                {
                    OutgoingPOM.ClickOnSendMoreReferral(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Driver.Value.FindElement(By.XPath("//span[normalize-space()='Shortlist Provider']")).Displayed);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_009,- ShortList page gets populated, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));

                    // Clearing the search criteria and click on go

                    ShortListPOM.ClickClearFiltersButton(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_009,- Cleared Filter Criteria successfully");

                    ShortListPOM.ClickGoButtonInFilter(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(3000);
                    // Selecting multiple providers

                    ShortListPOM.SelectProvidersByCheckboxesInCards(Driver.Value, MoreReferral);
                    try
                    {
                        Assert.That(BaseClass.Success_Notification(Driver.Value).Displayed);

                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_009,- Multiple providers checked", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch { }
                    

                        ShortListPOM.ClickTopSendReferralButton(Driver.Value);
                        Thread.Sleep(500);
                        ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                        Thread.Sleep(4000);
                        ShortListPOM.ClickSendButton(Driver.Value);
                        // ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value);
                        try
                        {

                            ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                        }
                        catch { }
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                   
                    
                    
                    

                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                    
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);




                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);    
                    OutgoingPOM.WaitForReferralTableToBeClickable(Driver.Value);
                    OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                    try
                    {
                        Assert.That(Driver.Value.FindElement(By.XPath("//*[@id='innerTable0']/span[1]/descendant::label[1]")).Displayed);
                        Assert.That(Driver.Value.FindElement(By.XPath("//*[@id='innerTable0']/span[1]/descendant::label[2]")).Displayed);
                        foreach(string service in ServicesNeeded.Split("|"))
                        {
                            try
                            {
                                if (Driver.Value.FindElement(By.XPath("//*[@id='innerTable0']/span[1]/descendant::label[1]")).ToString().Contains(service))
                                {
                            Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_009,- Service Needed and Special Program contains all the information as required");

                                }
                            }

                            catch {
                                Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_009,- Service Needed '{service}' is not displaying on outgoing page", CaptureScreenShot(Driver.Value, Filename));
                            }
                        }
                        {
                        }
                    }
                    catch (Exception ex) { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_010,-{Flow}- Service Needed and Special Program's info is missing " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_009 - Passed, Multiple Referral sent", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_009 - Failed, Patient info is not showing up, Screenshot:        " + ex, CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.Clickoncancel(Driver.Value);
                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    OutgoingPOM.WaitForReferralTableToBeClickable(Driver.Value);
                    OutgoingPOM.ExpandInnerTable(Driver.Value, 1);
                }

                //TC_014 - To verify that origin user can resend referral by clicking on  green paper plane icon under patient details (>) action item

                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_010 -{Flow}- To verify that origin user can resend referral by clicking on  green paper plane icon under patient details (>) action item");

                try
                {
                    OutgoingPOM.ClickOnResendReferralButton(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_010,- Resend Referral pop up opens up successfully,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    OutgoingPOM.SelectReceiveingContact(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_010,- Selected Receiving Contact successfully,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    OutgoingPOM.ClickOnSendButton_UnderResendReferralPopUp(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_010,- Referral Resent Successfully,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_010 - Failed, Unable to resend referral " + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                //TC_011- To verify that origin user can respond to referral (Accept/Reject) by clicking on doctor icon under patient details (>) icon

                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_011 -{Flow}- To verify that origin user can respond to referral (Accept/Reject) by clicking on doctor icon under patient details (>) icon");

                try
                {
                    OutgoingPOM.ClickOnRespondToReferralbutton_UnderInnerTable(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Clicked on Respond to referral button, Referral Requested pop up opens up successfully,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    
                    ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, AcceptReject);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Selected Accept Patient Radio Button");
                    if (AcceptReject == "accept")
                    {
                        ReferralResponsePopupPOM.EnterAppointmentDate(Driver.Value, AppointmentDateTime);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Entered Appointment Date", CaptureScreenShot(Driver.Value, Filename));
                    }
                    else
                    {
                        ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Rejection reason provided", CaptureScreenShot(Driver.Value, Filename));
                    }
                        ReferralResponsePopupPOM.SelectInsuranceAuthorizationStatus(Driver.Value, InsuranceAuthorizationStatus);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Selected Insurance Authorization Status successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
                    OutgoingPOM.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(500);
                    Assert.That(Driver.Value.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[2]/td/div[1]/div[6]/div[2]/status-labels/div/span")).Displayed);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_011,- Verified that origin user can respond to referral by clicking on doctor icon successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_011 Failed,- Unable to respond to referral " + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                // Test_SendReferral_TC_012 - To verify that destination user receives referral in the incoming page with all the recent incoming referrals

                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_012 -{Flow}- To verify that destination user receives referral in the incoming page with all the recent incoming referrals");

                try
                {
                    // Navigating to Patient Page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Navigated to Patient Page", CaptureScreenShot(Driver.Value, Filename));

                    // Searching for the patient by Search By name Filter
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForReferralTableToBeClickable(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Search the patient name successfully", CaptureScreenShot(Driver.Value, Filename));

                    // Clicking on Send Referral icon under action items in Patient List
                    PatientListPOM.ClickSendReferral(Driver.Value, 1);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);

                    //Search with provider name
                    ShortListPOM.SearchProviderByName(Driver.Value, ProviderName);
                    ShortListPOM.WaitForSortListResultToLoad(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Searched with provider name", CaptureScreenShot(Driver.Value, Filename));

                    //Check the checkbox next to the provider name
                    ShortListPOM.SelectProvidersByCheckboxes(Driver.Value, "1");
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Checked the checkbox next to the provider name");

                    //Click on paper plane icon under action item to send referral
                    ShortListPOM.ClickSendReferralAction(Driver.Value, 1);
                    ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Clicked on paper plane icon under action item to send referral");

                    //Select mandatory fields and click on Send button
                    ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);
                    ShortListPOM.SelectReferralType(Driver.Value, ReferralType2);
                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split("|"));
                    ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                    ShortListPOM.ChooseAutoConfirm(Driver.Value);
                    ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, bool.Parse(PreAuthorization));

                    ShortListPOM.EnterNoteSendReferralDialog(Driver.Value, Note);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Entered mandatory fields ", CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.ClickSendButton(Driver.Value);



                    try
                    {

                        ShortListPOM.ClickOnContinueWithoutSharing(Driver.Value).Click();
                    }
                    catch { }



                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Clicked on Send button, Referral sent successfully ", CaptureScreenShot(Driver.Value, Filename));

                    
                    // Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Destination User credentials entered and clicked on SignIn button");
                    LoginPOM.SwitchAccount(Driver.Value, "Destination");
                    //vaidating through incoming page
                    IncomingPOM.NavigateToIncomingPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);


                    try
                    {
                        FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                    }
                    catch { }





                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Navigated to Incoming Page");

                    if (IncomingPOM.ValidatePatientStatusGotUpdated(Driver.Value, PatientName))
                    {
                        Thread.Sleep(2000);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012,- Validated Patient Status got updated", CaptureScreenShot(Driver.Value, Filename));
                    }
                    else
                    {
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_012,- Patient Status did NOT get updated , Screenshot:");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }
                    IncomingPOM.ValidatePatientNameInDestination(Driver.Value, PatientName);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_012 - Passed, Verified that destination user receives the sent referral from origin", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_012 - Failed, Referral not received at destination " + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                // Test_SendReferral_TC_013 - To verify that destination user can respond to the incoming referral from incoming page by clicking on doctor icon under patient details (>) icon

                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_013 -{Flow}- To verify that destination user can respond to the incoming referral from incoming page by clicking on doctor icon under patient details (>) icon");
                try
                {
                    try
                    {
                        IncomingPOM.ClickOnRespondToReferralButton(Driver.Value, 1);
                        Thread.Sleep(2000);
                        try
                        {
                            if (Driver.Value.FindElement(By.XPath("//*[@id='referralResponseForm']/descendant::label[contains(text(),'Provider Type')]/following::strong[1]")).Text == ProviderType)
                            {
                                Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Following Service is mentioned in the details: " + ProviderType);
                            }
                        }
                        catch { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_013 - Failed, Provider Type is not mention in the details ", CaptureScreenShot(Driver.Value, Filename)); }

                        foreach (String Service in ServicesNeeded.Split("|"))
                        {
                            String AllText = Driver.Value.FindElement(By.XPath("//*[@id='servicesNeededText']")).Text;
                            foreach (String Text in AllText.Split(", "))
                            {
                                if (Service == Text)
                                {
                                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Following Service is mentioned in the details: " + Service, CaptureScreenShot(Driver.Value, Filename));
                                }
                            }
                        }
                        try
                        {

                        foreach (String Program in SpecialPrograms.Split("|"))
                        {
                            String AllText = Driver.Value.FindElement(By.XPath("//*[@id='specialProgramNeededText']")).Text;
                                try
                                {

                            foreach (String Text in AllText.Split(", "))
                            {
                                if (Program == Text)
                                {
                                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Following Special Programs is mentioned in the details: " + Program, CaptureScreenShot(Driver.Value, Filename));
                                }
                            }
                                }
                                catch { }
                        }
                        }
                        catch { }
                    }
                    catch (Exception ex) { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_013 - Failed, Received referral have missing/incorrect information " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                    ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, AcceptReject);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Selected Accept Patient Radio Button");
                    Thread.Sleep(1000);
                    if (AcceptReject == "accept")
                    {
                        ReferralResponsePopupPOM.EnterAppointmentDate(Driver.Value, AppointmentDateTime);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Entered Appointment Date", CaptureScreenShot(Driver.Value, Filename));

                    }
                    else
                    {
                        ReferralResponsePopupPOM.EnterRejectionReason(Driver.Value);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Rejection reason provided", CaptureScreenShot(Driver.Value, Filename));
                    }

                        Thread.Sleep(1000);
                        ReferralResponsePopupPOM.SelectInsuranceAuthorizationStatus(Driver.Value, InsuranceAuthorizationStatus);
                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Selected Insurance Authorization Status successfully");
                        //ReferralResponsePopupPOM.ClickBackgroundOfReferralResponseDialog(Driver.Value);
                        ReferralResponsePopupPOM.EnterNotes(Driver.Value, Note);
                        ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
                        BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                        try
                        {
                            Assert.That(IncomingPOM.ValidatePatientStatusGotUpdated(Driver.Value, PatientName));
                            IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                            Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_013,- Status and Insurance Status got updated successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_013,- Status and insurance status did not get updated, Error " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    } 
                catch (Exception ex) 
                { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_013 -Failed, Origin referral is NOT showing up properly at the destination side " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //Test_SendReferral_TC_014 - To verify that , if accepted the origin user can confirm referral by clicking on lock icon under patient details (>) icon
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_014 -{Flow}- To verify that , if accepted the origin user can confirm referral by clicking on lock icon under patient details (>) icon");
                try
                {
                  
                    //Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,-{Flow}- Origin User credentials entered and clicked on SignIn button");
                    LoginPOM.SwitchAccount(Driver.Value, "Origin");
                    //Navigating to Patient List Page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,- Navigate to Patient List page");
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,- Searched patient name successfully");
                    PatientListPOM.ExpandInnerTable(Driver.Value, 1);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    int temp = Driver.Value.FindElements(By.XPath("//*[@id='ReferralsInnerTableId']/tbody/tr")).Count();
                    for (int i = 1; i <= temp; i++)
                    {
                        try
                        {
                            PatientListPOM.ExpandInnerTableofInnerTable(Driver.Value, i);
                            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                            int temp1 = Driver.Value.FindElements(By.XPath("//*[@id='ReferralsInnerTable']/descendant::tr")).Count();
                            for (int j = 1; j < temp1; j++)
                            {//Rejected
                                try
                                {
                                    if (AcceptReject== "accept")
                                    {
                                        Assert.That(Driver.Value.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[{j + 1}]/td/descendant::span[contains(text(),'Confirmed')]")).Displayed);
                                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,- Referral Status updated to confirmed", CaptureScreenShot(Driver.Value, Filename));

                                        Assert.That(Driver.Value.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[{j + 1}]/td/descendant::span[contains(text(),'Confirmed')]/following::app-date-time[1]")).Displayed);
                                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,- Appointment Date updated successfully ", CaptureScreenShot(Driver.Value, Filename));
                                    }
                                    else
                                    {
                                        Assert.That(Driver.Value.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[{j + 1}]/td/descendant::span[contains(text(),'Rejected')]")).Displayed);
                                        Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_014,- Referral Status updated to Rejected", CaptureScreenShot(Driver.Value, Filename));


                                    }
                                        Thread.Sleep(2000);
                                    //Driver.Value.FindElement(By.XPath($"//*[@name='acceptpatient']")).Click();
                                    //ReferralResponsePopupPOM.EnterDataForAcceptPatientRadio(Driver.Value, AcceptReject);
                                    //ReferralResponsePopupPOM.EnterAppointmentDate(Driver.Value, AppointmentDateTime);
                                    //ReferralResponsePopupPOM.SelectInsuranceAuthorizationStatus(Driver.Value, InsuranceAuthorizationStatus);
                                    //ReferralResponsePopupPOM.ClickSubmitFormButton(Driver.Value);
                                    //Driver.Value.FindElement(By.XPath($"//*[@id='submitBtn']")).Click();
                                   // Driver.Value.FindElement(By.XPath($"//*[@id='submitBtn']")).Click();
                                    //Assert.That(Driver.Value.FindElement(By.XPath($"//*[@id='ReferralsInnerTable']/tbody/tr[{j + 1}]/td/div[1]/div[7]/action/div/span[1]/a/button/i")).Displayed);
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_014 - Failed, Origin user cannot confirm referral " + ex, CaptureScreenShot(Driver.Value, Filename)); }
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"Test_SendReferral - Failed, ShortList Provider Page does not load,  Error: " + ex);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_SendReferral_TC_015 - To verify that a referral report can be generated of sent referral	
            try
            {
                System_Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral  E2E_TC_015 -{Flow}-  To verify that a referral report can be generated of sent referral");
                Test.Value = ExtentTestManager.CreateTest($"Test_SendReferral_TC_015 -{Flow}-  To verify that a referral report can be generated of sent referral");

                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                try
                {

                    OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015 - More action has been expanded ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, "Referral Report");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Assert.That(OutgoingPOM.CheckReferralReportPopUpHeadline(Driver.Value).Text.Contains(PatientName));
                    Test.Value.Log(Status.Pass, $"Test_SendReferral_TC_015,- The referral report Popup opened");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch
                { }
                    
                try
                {
                    string Name = OutgoingPOM.ValidateHeadlineElement_ReferralReportPOPUP(Driver.Value).Item1;
                    Assert.AreEqual(Name.ToLower(), ProviderName.ToLower());
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
                    catch (Exception e)
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
                        Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 -Required program is not mentioned in the details  Error:" + ex);
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
                catch (Exception e)
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
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test_SendReferral_TC_015 - The response received section of the referral report has missing details Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                //(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value).Item1.Contains(action));
                //(OutgoingPOM.ValidateResponseReceivedTableElements_ReferralReportPOPUP(Driver.Value).Item1.Contains(action));
                System_Test.Value.Log(Status.Pass, $"Test_SendReferral E2E_TC_015 - Referral report created of referral-report successfully");
                System_Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch
            {
                System_Test.Value.Log(Status.Fail, $"Test_SendReferral  E2E_TC_015 - Unable to create referral report of sent referral successfully Error :");
                System_Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }







            
        }

        public static IEnumerable<TestCaseData> SendReferral_TD_Flow1()
        {
            String Path = GetDataParser().TestData_Path("SendReferral_TD_Flow1");
            yield return new TestCaseData(
                GetDataParser().TestData("Flow", Path),
                GetDataParser().TestData("ShortlistPageSendReferral", Path),
                GetDataParser().TestData("ShortlistPageSendMultipleReferral", Path),
                GetDataParser().TestData("PateintListPatientDetailsSendReferral", Path),
                GetDataParser().TestData("FacilityType", Path),
                GetDataParser().TestData("Zipcode", Path),
                GetDataParser().TestData("SearchFacility", Path),
                GetDataParser().TestData("Miles", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("ProviderName", Path),
                GetDataParser().TestData("ServicesNeeded", Path),
                GetDataParser().TestData("Insurance", Path),
                GetDataParser().TestData("Gender", Path),
                GetDataParser().TestData("AgeGroups", Path),
                GetDataParser().TestData("SpecialPrograms", Path),
                GetDataParser().TestData("MultipleReferrals", Path),
                GetDataParser().TestData("PatientAttributes", Path),
                GetDataParser().TestData("ReferralType1", Path),
                GetDataParser().TestData("ReferralType2", Path),
                GetDataParser().TestData("Note", Path),
                GetDataParser().TestData("MoreReferral", Path),
                GetDataParser().TestData("PreAuthorization", Path),
                GetDataParser().TestData("AcceptReject", Path),
                GetDataParser().TestData("InsuranceAuthorizationStatus", Path),
                GetDataParser().TestData("AppointmentDateTime", Path),
                GetDataParser().TestData("StatusToBeVerified", Path),
                GetDataParser().TestData("StatusToBeVerified_AfterReferralConfirmation", Path),
                 GetDataParser().TestData("Mode", Path),
                 GetDataParser().TestData("Responsestatus", Path)

               );
        }

        public static IEnumerable<TestCaseData> SendReferral_TD_Flow2()
        {
            String Path = GetDataParser().TestData_Path("SendReferral_TD_Flow2");
            yield return new TestCaseData(
                GetDataParser().TestData("Flow", Path),
                GetDataParser().TestData("ShortlistPageSendReferral", Path),
                GetDataParser().TestData("ShortlistPageSendMultipleReferral", Path),
                GetDataParser().TestData("PateintListPatientDetailsSendReferral", Path),
                GetDataParser().TestData("FacilityType", Path),
                GetDataParser().TestData("Zipcode", Path),
                GetDataParser().TestData("SearchFacility", Path),
                GetDataParser().TestData("Miles", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("ProviderName", Path),
                GetDataParser().TestData("ServicesNeeded", Path),
                GetDataParser().TestData("Insurance", Path),
                GetDataParser().TestData("Gender", Path),
                GetDataParser().TestData("AgeGroups", Path),
                GetDataParser().TestData("SpecialPrograms", Path),
                GetDataParser().TestData("MultipleReferrals", Path),
                GetDataParser().TestData("PatientAttributes", Path),
                GetDataParser().TestData("ReferralType1", Path),
                GetDataParser().TestData("ReferralType2", Path),
                GetDataParser().TestData("Note", Path),
                GetDataParser().TestData("MoreReferral", Path),
                GetDataParser().TestData("PreAuthorization", Path),
                GetDataParser().TestData("AcceptReject", Path),
                GetDataParser().TestData("InsuranceAuthorizationStatus", Path),
                GetDataParser().TestData("AppointmentDateTime", Path),
                GetDataParser().TestData("StatusToBeVerified", Path),
                GetDataParser().TestData("StatusToBeVerified_AfterReferralConfirmation", Path),
                 GetDataParser().TestData("Mode", Path),
                 GetDataParser().TestData("Responsestatus", Path)

               );
        }
        public static IEnumerable<TestCaseData> SendReferral_TD_Flow3()
        {
            String Path = GetDataParser().TestData_Path("SendReferral_TD_Flow3");
            yield return new TestCaseData(
                GetDataParser().TestData("Flow", Path),
                GetDataParser().TestData("ShortlistPageSendReferral", Path),
                GetDataParser().TestData("ShortlistPageSendMultipleReferral", Path),
                GetDataParser().TestData("PateintListPatientDetailsSendReferral", Path),
                GetDataParser().TestData("FacilityType", Path),
                GetDataParser().TestData("Zipcode", Path),
                GetDataParser().TestData("SearchFacility", Path),
                GetDataParser().TestData("Miles", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("ProviderName", Path),
                GetDataParser().TestData("ServicesNeeded", Path),
                GetDataParser().TestData("Insurance", Path),
                GetDataParser().TestData("Gender", Path),
                GetDataParser().TestData("AgeGroups", Path),
                GetDataParser().TestData("SpecialPrograms", Path),
                GetDataParser().TestData("MultipleReferrals", Path),
                GetDataParser().TestData("PatientAttributes", Path),
                GetDataParser().TestData("ReferralType1", Path),
                GetDataParser().TestData("ReferralType2", Path),
                GetDataParser().TestData("Note", Path),
                GetDataParser().TestData("MoreReferral", Path),
                GetDataParser().TestData("PreAuthorization", Path),
                GetDataParser().TestData("AcceptReject", Path),
                GetDataParser().TestData("InsuranceAuthorizationStatus", Path),
                GetDataParser().TestData("AppointmentDateTime", Path),
                GetDataParser().TestData("StatusToBeVerified", Path),
                GetDataParser().TestData("StatusToBeVerified_AfterReferralConfirmation", Path),
                GetDataParser().TestData("Mode", Path),
                GetDataParser().TestData("Responsestatus", Path)

               );
        }

        //***************************************** Test Execution  *********************************************************//

        [Test, Order(3)]
        [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("Chat_TD")]


        public void Test_PatientList_AI_ChatTest(
            String ProviderName,
            String ReferralType,
            String PreAuthorization,
            String ProviderType,
            String ServicesNeeded,
            String SpecialPrograms,
            String Note,
            String ChatMessage,
            String DestinationReply,
            String OriginReply)
        {
            Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_001 - To verify that chat pop up comes up after clicking on chat icon under action items");
            try
            {
                try
                {
                    //Navigate to Patient List page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    PatientListPOM.WaitForDummyPatientConfirmation(Driver.Value);
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "Unable to create dummy patient" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                String PatientName = PatientListPOM.GetDummyPatientName(Driver.Value);
                try
                {
                    //Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_001 - To verify that chat pop up comes up after clicking on chat icon under action items");
                    

                    //Search with the patient name
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_001, Searched with the patient name");

                    //Click on chat icon under action items
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);  
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_001, Clicked on chat icon under action items");
                    PatientListPOM.WaitForChatPopUp(Driver.Value);
                    Assert.That(Driver.Value.FindElement(By.XPath("//div[@class='popup-title Comment-header']")).Displayed);

                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_001 Passed, Verified that chat pop up comes up after clicking on chat icon under action items", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_001 Failed, Chat does not show up" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_002 - To verify when no referral is sent for a patient, chat pop up should display: Referral has not been sent for patient (Patient Name)");
                try
                {
                    //Verify following message comes up: Referral has not been sent for patient "Patient Name"
                    WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='pac-comment show-no-faciliy ng-star-inserted']")));
                    String temp = Driver.Value.FindElement(By.XPath("//div[@class='pac-comment show-no-faciliy ng-star-inserted']")).Text;
                    Assert.That(temp == ($"Referral has not been sent for patient \"{PatientName} \""));
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_002 Passed, Verified that when no referral is sent for a patient, chat pop up displays: Referral has not been sent for patient (Patient Name) ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                }
                catch (OpenQA.Selenium.WebDriverTimeoutException)
                {
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='pac-comment detailSubHeader padding-top-12 ng-star-inserted']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='chat-print-icon']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class=' chat-copy-all-icon']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@id= 'scriptBox']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class = 'fa fa-paper-plane send-paper-icon ng-star-inserted' and @title='Send Message']")).Displayed);
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_002 Passed, Referral already sent for the user, Verified that chat section have provider name at the top , Print and copy all button , a text field and send button", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex)
                {
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_002 Failed, Missing/incorrect message displayed" + ex, CaptureScreenShot(Driver.Value, Filename));
                }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_003 - To verify that chat pop up have providers list and chat sections");
                try
                {
                    //Click on paper plane icon under action item to send referral
                    PatientListPOM.ClickSendReferral(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Clicked on paper plane icon under action item to send referral");

                    //Search with provider name
                    ShortListPOM.SearchProviderByName(Driver.Value, ProviderName);
                    ShortListPOM.WaitForSortListResultToLoad(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Searched with provider name", CaptureScreenShot(Driver.Value, Filename));

                    //Check the checkbox next to the provider name
                    ShortListPOM.SelectProvidersByCheckboxes(Driver.Value, "1");
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Checked the checkbox next to the provider name");

                    //Click on paper plane icon under action item to send referral
                    ShortListPOM.ClickSendReferralAction(Driver.Value, 1);
                    ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Clicked on paper plane icon under action item to send referral");

                    //Select mandatory fields and click on Send button
                    ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);
                    ShortListPOM.SelectReferralType(Driver.Value, ReferralType);
                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split("|"));
                    ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                    ShortListPOM.ChooseAutoConfirm(Driver.Value);
                    ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, bool.Parse(PreAuthorization));
                    ShortListPOM.EnterNoteSendReferralDialog(Driver.Value, Note);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Entered mandatory fields ", CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.ClickSendButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Clicked on Send button, Referral sent successfully ", CaptureScreenShot(Driver.Value, Filename));

                    //Navigate to Patient List page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Navigated to Patient List page  ", CaptureScreenShot(Driver.Value, Filename));

                    //Search with the patient name
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Searched with the patient name", CaptureScreenShot(Driver.Value, Filename));
                    //Click on (>) icon to open patient details
                    PatientListPOM.ExpandInnerTable(Driver.Value, 1);
                    //Click on (>) icon to open more details
                    PatientListPOM.ExpandInnerTableofInnerTable(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Patient List page got updated successfully ", CaptureScreenShot(Driver.Value, Filename));

                    //Click on chat icon under action items
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    PatientListPOM.WaitForChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003, Clicked on chat icon under action items", CaptureScreenShot(Driver.Value, Filename));

                    //Verify that chat pop up have providers list and chat sections
                    Assert.That(Driver.Value.FindElement(By.XPath("//div[@class='pac-name detailSubHeader']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//div[@class='pac-comment detailSubHeader padding-top-12 ng-star-inserted']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_003 Passed, Verified that chat pop up have providers list and chat sections", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_003 Failed, Error: " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_004 - To verify that chat pop up shows single/multiple providers (Name) in providers list section based on number of referrals sent and when");
                //Navigate Providers list section
                try
                {
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='list-group-item active-facility' and @id='setActive0']")).Displayed);
                    String temp = Driver.Value.FindElement(By.XPath("//*[@class='list-group-item active-facility' and @id='setActive0']")).Text;
                    Assert.That(ProviderName == temp);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_004 Passed, Verified that Provider name got updated in chat pop up", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_004 Failed, Missing component in chat pop up, Error:    " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_005 - To verify that chat section have provider name at the top , Print and copy all button , and a text field to enter the message to be sent with send button (paper plane icon)");
                //Navigate to Chat section of the pop up
                try
                {
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='pac-comment detailSubHeader padding-top-12 ng-star-inserted']")).Displayed);
                    String temp = Driver.Value.FindElement(By.XPath("//*[@class='list-group-item active-facility' and @id='setActive0']")).Text;
                    Assert.That(ProviderName == temp);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='chat-print-icon']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class=' chat-copy-all-icon']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@id= 'scriptBox']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//*[@class = 'fa fa-paper-plane send-paper-icon ng-star-inserted' and @title='Send Message']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_005 Passed, Verified that chat section have provider name at the top , Print and copy all button , a text field and send button", CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_005 Failed, Missing component in chat pop up, Error:  " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_006 - To verify that origin user can send chat by clicking on paper plane icon in the chat pop up");
                //Click on paper plane icon
                try
                {
                    foreach (String message in ChatMessage.Split("|"))
                    {
                        PatientListPOM.EnterChatMessage_ChatPopUp(Driver.Value, message);
                        Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_006, Message entered successfully", CaptureScreenShot(Driver.Value, Filename));

                        //int MessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);

                        try
                        {
                            PatientListPOM.ClickOnSendButton_ChatPopUp(Driver.Value);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_006, Clicked on sent button");
                            Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{message}']")).Displayed);

                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_006 Passed, Verified that chat message sent successfully", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_006 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //*********************************************************************************************************************************//

                        Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_007 - To verify that text box validate the data before sending, like charactor limit, type of data");
                        //Enter the test data (valid and invalid) in the text field

                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"(//label[contains(@ng-reflect-ng-class,'[object Object]')][normalize-space()='{Origin_User}'])[1]")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_007, Validated Names in the message is same as the account name");
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_007 Failed, Sender name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath("//*[@class='speech-bubble-ds round right-top ng-star-inserted']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_007 Passed, Message sent successfully, total count of messages:   " + PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value), CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_007 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //*********************************************************************************************************************************//

                        Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_008 - To verify that each message has user's name with a timestamp next to it showing correct time stamp as per local timezone ");
                        //Navigate to the name in the message
                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//span[normalize-space()='{(DateTime.Now.ToString("h:mm tt")).ToLower()}']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_008 Passed, Validated timestamp is showing up successfully", CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_008 Failed, Timestamp is not a match" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //*********************************************************************************************************************************//

                        Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_009 - To verify that all the messages are catagorized as per day/date of when they were sent");
                        //Navigate to the top of the chat section
                        try
                        {
                            String temp = Driver.Value.FindElement(By.XPath("//*[@class='sticky-date-bg ng-star-inserted']")).Text;
                            Assert.That(temp, Is.EqualTo("Today"));
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_009 Passed, Validated that messages are under Day/Date category ie, " + temp);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_009, Sender name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    }
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_009 Failed, Text box accepts invalid data" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                //Test = ExtentTestManager.CreateTest("TC_010 - To verify that origin user can print the chat by clicking on print button");
                ////Click on print button
                //try
                //{
                //    String currentWindowHandle1 = Driver.Value.CurrentWindowHandle;
                //    PatientListPOM.ClickOnPrintButton_ChatPopUp(Driver.Value);
                //    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                //    Thread.Sleep(2000);
                //    Test.Value.Log(Status.Pass, "TC_010 Passed, Validated that origin user can print the chat by clicking on print button", CaptureScreenShot(Driver.Value, Filename));
                //    Actions action = new Actions(Driver.Value);

                //    action.SendKeys(OpenQA.Selenium.Keys.Escape);

                //    Test.Value.Log(Status.Pass, "TC_010 Passed, Validated that origin user can print the chat by clicking on print button", CaptureScreenShot(Driver.Value, Filename));
                //}
                //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_018 Failed, Origin user cannot confirm referral " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                ////*********************************************************************************************************************************//

                //Test = ExtentTestManager.CreateTest("TC_011 - To verify that origin user can copy all the text from chat by clicking on copy all button under chat section ");
                ////Click on copy all button and input the same in the chat text box
                //try
                //{
                //    PatientListPOM.ClickOnCopyAllButton_ChatPopUp(Driver.Value);

                //    Thread.Sleep(2000);
                //    Test.Value.Log(Status.Pass, "TC_011 Passed, Validated that Copy All button is working fine", CaptureScreenShot(Driver.Value, Filename));

                //}
                //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_018 Failed, Origin user cannot confirm referral " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                //Test = ExtentTestManager.CreateTest("TC_012 - To verify that origin user can copy the message by clicking on copy button next to the message");
                ////Click on copy button next to every message and input the same in the chat text box
                //try
                //{
                //}
                //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_012 Failed, Origin user cannot confirm referral " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_013 - To verify that destination user receives chat messages sent from origin user and also other details (User name, message) are correct");

                try
                {
                    //Click on logout button
                    BaseClass.LogOutAccount(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013, Destination logged out successfully");

                    //Login with destination login credentials
                    LoginPOM.EnterUsername(Driver.Value, Destination_Email);
                    LoginPOM.EnterPassword(Driver.Value, Destination_Password);
                    LoginPOM.ClickOnSignInButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013, Destination User credentials entered and clicked on SignIn button");

                    //Search with the patient name
                    IncomingPOM.NavigateToIncomingPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013, Navigate to Incoming page");
                    IncomingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013, Searched patient name successfully");
                    IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                    Thread.Sleep(3000);

                    //Click on chat icon under action items
                    IncomingPOM.ClickChatAction(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013, Clicked on chat icon under action items");
                    IncomingPOM.WaitForChatPopUp(Driver.Value);

                    // Navigate to Chat section of the pop up
                    // Validate that all the info is received by the destination user

                    foreach (String message in ChatMessage.Split("|"))
                    {
                        WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(20));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//p[normalize-space()='{message}']")));

                        int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);

                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{message}']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013 Passed, Message RECEIVED successfully, total count of messages" + DestinationMessageCount);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_013 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"(//label[contains(@ng-reflect-ng-class,'[object Object]')][normalize-space()='{Origin_User}'])[4]")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013 Passed, Validated Names in the message is same as the origin's account name");
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_013 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //try
                        //{
                        //    Assert.That(Driver.Value.FindElement(By.XPath($"//span[normalize-space()='{DateTime.Now.ToString("HH:mm t")}']")).Displayed);
                        //    Test.Value.Log(Status.Pass, "TC_013 Passed, Validated timestamp is showing up successfully", CaptureScreenShot(Driver.Value, Filename));

                        //}
                        //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_013 Failed, Timestamp is not a match" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            String temp = Driver.Value.FindElement(By.XPath("//*[@class='sticky-date-bg ng-star-inserted']")).Text;
                            Assert.That(temp, Is.EqualTo("Today"));
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_013 Passed, Validated that messages are under Day/Date category ie, " + temp);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_013 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    }
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_013 Failed, Error :   " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_014 - To verify that destination user can reply to the incoming chat message ");
                try
                {
                    //Navigate to chat text box
                    PatientListPOM.EnterChatMessage_ChatPopUp(Driver.Value, DestinationReply);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_014, Message entered successfully");
                    PatientListPOM.ClickOnSendButton_ChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_014, Clicked on sent button");
                    try
                    {
                        int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);
                        Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{DestinationReply}']")).Displayed);
                        String temp = Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{DestinationReply}']")).Text;
                        Test.Value.Log(Status.Pass, $"E2E_ChatTest_TC_014 Passed, Destination user able to reply message:{temp} successfully, Total count of messaged: " + DestinationMessageCount);
                        IncomingPOM.ClickCloseIconInChat(Driver.Value);
                    }
                    catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_014 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_014 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_015 - To verify that the origin user receives the reply message from destination user");

                try
                {
                    //Log out and login back to origin account
                    // Click on logout button
                    BaseClass.LogOutAccount(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015, User logged out successfully");

                    //Login with origin login credentials
                    LoginPOM.EnterUsername(Driver.Value, Origin_Email);
                    LoginPOM.EnterPassword(Driver.Value, Origin_Password);
                    LoginPOM.ClickOnSignInButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015, Destination User credentials entered and clicked on SignIn button");

                    //Navigate to Patient List page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015, Navigate to Patient List page");
                    //Search with the patient name
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015, Searched patient name successfully");

                    //Click on the chat icon
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    PatientListPOM.WaitForChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015, Clicked on chat icon under action items");

                    //Navigate to provider list
                    //Click on the privder name
                    //Navigate to Chat section
                    foreach (String message in ChatMessage.Split("|"))
                    {
                        int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);

                        try
                        {
                            Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{message}']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015 Passed, Message RECEIVED successfully, total count of messages" + DestinationMessageCount);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_015 Failed, Chat message not received/different " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //try
                        //{
                        //    Assert.That(Driver.Value.FindElement(By.XPath($"//span[normalize-space()='{DateTime.Now.ToString("h:mm tt")}']")).Displayed);
                        //    Test.Value.Log(Status.Pass, "TC_015 Passed, Validated timestamp is showing up successfully", CaptureScreenShot(Driver.Value, Filename));

                        //}
                        //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_015 Failed, Timestamp is not a match" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            String temp = Driver.Value.FindElement(By.XPath("//*[@class='sticky-date-bg ng-star-inserted']")).Text;
                            Assert.That(temp, Is.EqualTo("Today"));
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015 Passed, Validated that messages are under Day/Date category ie, " + temp);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_015 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    }

                    try
                    {
                        IList<IWebElement> userList = Driver.Value.FindElements(By.Id($"hospitalPacfCommentBy"));
                        String[] allUser = new String[userList.Count];
                        int i = 0;
                        foreach (IWebElement element in userList)
                            allUser[i++] = element.Text;

                        for (int j = 0; j < allUser.Length; j++)
                        {
                            if (allUser[j] == Destination_User)
                                Assert.That(Driver.Value.FindElement(By.XPath($"(//label[@id='hospitalPacfCommentBy'])[{j + 1}]")).Displayed);
                            else if (allUser[j] == Origin_User)
                                Assert.That(Driver.Value.FindElement(By.XPath($"(//label[@id='hospitalPacfCommentBy'])[{j + 1}]")).Displayed);
                        }
                        Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_015 Passed, Validated Names in the message is same as the destination's account name");
                    }
                    catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_015 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_015 Failed, Error:    " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_016 - To verify that origin user can get multiple providers in the chat pop up");
                try
                {
                    //Click on paper plane icon under action item to send referral
                    PatientListPOM.ClickSendReferral(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Clicked on paper plane icon under action item to send referral");

                    //Search with provider name
                    ShortListPOM.SearchProviderByName(Driver.Value, ProviderName);
                    ShortListPOM.WaitForSortListResultToLoad(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Searched with provider name", CaptureScreenShot(Driver.Value, Filename));

                    //Check the checkbox next to the provider name
                    ShortListPOM.SelectProvidersByCheckboxes(Driver.Value, "1");
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Checked the checkbox next to the provider name");

                    //Click on paper plane icon under action item to send referral
                    ShortListPOM.ClickSendReferralAction(Driver.Value, 1);
                    ShortListPOM.WaitForSendReferralDialogToOpen(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Clicked on paper plane icon under action item to send referral");

                    //Select mandatory fields and click on Send button
                    ShortListPOM.SelectProviderTypeSendReferralDialog(Driver.Value, ProviderType);
                    ShortListPOM.SelectReferralType(Driver.Value, ReferralType);
                    ShortListPOM.SelectServicesNeededSendReferralDialog(Driver.Value, ServicesNeeded.Split("|"));
                    ShortListPOM.SelectSpecialProgramsSendReferralDialog(Driver.Value, SpecialPrograms.Split("|"));
                    ShortListPOM.ChooseAutoConfirm(Driver.Value);
                    ShortListPOM.ChoosePreAuthorizationRequired(Driver.Value, bool.Parse(PreAuthorization));

                    ShortListPOM.EnterNoteSendReferralDialog(Driver.Value, Note);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Entered mandatory fields ", CaptureScreenShot(Driver.Value, Filename));
                    ShortListPOM.ClickSendButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(PatientListPOM.WaitForSendReferralConfirmation(Driver.Value));
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Clicked on Send button, Referral sent successfully ", CaptureScreenShot(Driver.Value, Filename));

                    //Navigate to Patient List page
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);

                    //Search with the patient name
                    PatientListPOM.EnterPatientNameForSearch(Driver.Value, PatientName);
                    PatientListPOM.WaitForResultToLoadUp(Driver.Value);

                    //Click on (>) icon to open patient details
                    PatientListPOM.ExpandInnerTable(Driver.Value, 1);
                    //Click on (>) icon to open more details
                    PatientListPOM.ExpandInnerTableofInnerTable(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Patient List page got updated successfully ", CaptureScreenShot(Driver.Value, Filename));

                    //Click on chat icon under action items
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    PatientListPOM.WaitForChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016, Clicked on chat icon under action items");

                    //Navigate to providers list
                    //Verify that chat pop up have providers list and chat sections
                    int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);
                    Assert.That(Driver.Value.FindElement(By.XPath("//div[@class='pac-name detailSubHeader']")).Displayed);
                    Assert.That(Driver.Value.FindElement(By.XPath("//div[@class='pac-comment detailSubHeader padding-top-12 ng-star-inserted']")).Displayed);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_016 Passed, Verified that chat pop up have multiple providers list, Total Count: " + DestinationMessageCount, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_016 Failed, Missing Providers in the provider list" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                //Test = ExtentTestManager.CreateTest("TC_017 - To verify that provider tab of the most latest sent referral is at the top of the list");
                ////Click on the second tab
                ////Click on the first tab
                //try
                //{
                //}
                //catch (Exception ex) { Test.Value.Log(Status.Fail, "TC_018 Failed, Origin user cannot confirm referral " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_018 - To verify that origin user can reply back to the destination user");
                //Navigate to chat text box
                try
                {
                    //Navigate to chat text box
                    PatientListPOM.EnterChatMessage_ChatPopUp(Driver.Value, OriginReply);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_018, Message entered successfully");
                    PatientListPOM.ClickOnSendButton_ChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_018, Clicked on sent button");
                    try
                    {
                        int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);
                        Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{OriginReply}']")).Displayed);
                        String temp = Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{OriginReply}']")).Text;
                        Test.Value.Log(Status.Pass, $"E2E_ChatTest_TC_018 Passed, Destination user able to reply message:{temp} successfully, Total count of messaged: " + DestinationMessageCount);
                    }
                    catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_018 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    PatientListPOM.CloseChatPopUp(Driver.Value);
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_018 Failed, Chat message not sent  " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                //*********************************************************************************************************************************//

                Test.Value = ExtentTestManager.CreateTest("E2E_ChatTest_TC_019 - To verify that desitnation user received the reply from origin user successfully, also in separate tabs with the same name based on different referral sent from the origin");
                //Log out and login back to destination account
                //Search with the patient name
                //Navigate to result section
                //Navigate to chat icon of the first one
                try
                {
                    //Click on logout button
                    BaseClass.LogOutAccount(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, User logged out successfully");

                    //Login with destination login credentials
                    LoginPOM.EnterUsername(Driver.Value, Destination_Email);
                    LoginPOM.EnterPassword(Driver.Value, Destination_Password);
                    LoginPOM.ClickOnSignInButton(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, Destination User credentials entered and clicked on SignIn button");

                    //Search with the patient name
                    IncomingPOM.NavigateToIncomingPage(Driver.Value);
                    IncomingPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, Navigate to Incoming page");
                    IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, Searched patient name successfully");

                    //Click on chat icon under action items
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, Clicked on chat icon under action items");
                    Thread.Sleep(1000);

                    //Navigate to Chat section of the pop up
                    String temp = PatientListPOM.LatestMessageVerification__ChatPopUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019, Latest Message received on :" + temp);

                    // Validate that all the info is received by the destination user

                    foreach (String message in OriginReply.Split("|"))
                    {
                        int DestinationMessageCount = PatientListPOM.CountNumberOfMessages_ChatPopUp(Driver.Value);

                        try
                        {
                            WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//p[normalize-space()='{message}']")));
                            Assert.That(Driver.Value.FindElement(By.XPath($"//p[normalize-space()='{message}']")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019 Passed, Message RECEIVED successfully, total count of messages" + DestinationMessageCount);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_019 Failed, Chat message not sent " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            Thread.Sleep(1000);
                            WebDriverWait wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"(//p[normalize-space()='{OriginReply}'])[1]")));
                            Assert.That(Driver.Value.FindElement(By.XPath($"(//p[normalize-space()='{OriginReply}'])[1]")).Displayed);
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019 Passed, Validated Names in the message is same as the origin's account name");
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_019 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        //try
                        //{
                        //    Assert.That(Driver.Value.FindElement(By.XPath($"//span[normalize-space()='{DateTime.Now.ToString("h:mm tt")}']")).Displayed);
                        //    Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019 Passed, Validated timestamp is showing up successfully", CaptureScreenShot(Driver.Value, Filename));
                        //}
                        //catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_019 Failed, Timestamp is not a match" + ex, CaptureScreenShot(Driver.Value, Filename)); }

                        try
                        {
                            String temp1 = Driver.Value.FindElement(By.XPath("//*[@class='sticky-date-bg ng-star-inserted']")).Text;
                            Assert.That(temp1, Is.EqualTo("Today"));
                            Test.Value.Log(Status.Pass, "E2E_ChatTest_TC_019 Passed, Validated that messages are under Day/Date category ie, " + temp);
                        }
                        catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_019 Failed, Sender/Destination name is incorrect " + ex, CaptureScreenShot(Driver.Value, Filename)); }
                    }
                }
                catch (Exception ex) { Test.Value.Log(Status.Fail, "E2E_ChatTest_TC_019 Failed, Error:   " + ex, CaptureScreenShot(Driver.Value, Filename)); }
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "E2E_ChatTest Failed, Error: " + ex, CaptureScreenShot(Driver.Value, Filename));
            }
        }

        //***************************************** Test Data *********************************************************//

        public static IEnumerable<TestCaseData> Chat_TD()
        {
            String Path = GetDataParser().TestData_Path("Chat_TD");
            yield return new TestCaseData(

                //GetDataParser().Chat_TD("PatientName"),
                GetDataParser().TestData("ProviderName",Path),
                GetDataParser().TestData("ReferralType", Path),
                GetDataParser().TestData("PreAuthorization", Path),
                GetDataParser().TestData("ProviderType", Path),
                GetDataParser().TestData("ServicesNeeded", Path),
                GetDataParser().TestData("SpecialPrograms", Path),
                GetDataParser().TestData("Note", Path),
                GetDataParser().TestData("ChatMessage", Path),
                GetDataParser().TestData("DestinationReply", Path),
                GetDataParser().TestData("OriginReply", Path)

               );
        }
         
    }
}