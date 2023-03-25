using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.PreferredProviderList
{
    public class TestSuite_SearchField_PreferredProviderList:BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test, Order(1)]
        public void Test_SearchField_PreferredProviderList()
        {
            //Test SearchField_PreferredProviderListPage TC_001 To verify that Search field is available at top of Preferred Provider list
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_001 To verify that Search field is available at top of Preferred Provider list");

                PreferredProviderPOM.NavigateToPreferredProviderList_Page(Driver.Value);
                Assert.That(PreferredProviderPOM.ChecksearchField_ProviderSelectionPage(Driver.Value));


                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_001 Search Field is available at top of the Preferred provider page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_001 Search Field is not available at top of the Preferred provider page Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_PreferredProviderListPage TC_002 To verify that Search field have Provider Type,Location Type,Zipcode,Miles sections are available
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_002 To verify that Search field have Provider Type,Location Type,Zipcode,Miles sections are available");
                try
                {
                    Assert.That(PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).Enabled);

                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_002 'Provider Type' section of Search Field is enable ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_002  'Provider Type' section of Search Field is not enable Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                try
                {
                    Assert.That(PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value).Enabled);

                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_002 'Location Type' section of Search Field is enable");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_002 'Location Type' section of Search Field is not enable Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                try
                {
                    Assert.That(PreferredProviderPOM.ClickOnZipcodeTab(Driver.Value).Enabled);

                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_002 'Zipcode' section of Search Field is enable");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_002 'Zipcode' section of Search Field is not enable Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                try
                {
                    Assert.That(PreferredProviderPOM.ClickOnMileTab(Driver.Value).Enabled);

                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_002 'Mile' section of Search Field is enable");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_002 'Mile' section of Search Field is not enable Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_002 Search field do not have Provider Type or Location Type or Zipcode or Miles sections Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test SearchField_PreferredProviderListPage TC_003 To verify that Provider Type section have 5 Option in drop-down
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_003 To verify that Provider Type section have 5 Option in drop-down");
                PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).Click();
                PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, 1).Click();
                string optiontext = PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).GetAttribute("placeholder");
                Assert.AreEqual("Selected (4)", optiontext);
                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_003 Provider Type section have 5 option in drop down");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_003 Provider Type section do not have 5 option in drop down Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test SearchField_PreferredProviderListPage TC_004 To verify that Clear button is enable
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_004 To verify that Clear button is enable");


                PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "Clear");
                Assert.That(true);

                ///Below comment is alternative if 'Clear' Button will removed in devlopment
                //if (AddProviderPopupPOM.SelectOptionforProviderType(Driver.Value, 1).Enabled)
                //{

                //    AddProviderPopupPOM.SelectOptionforProviderType(Driver.Value, 1).Click();

                //}
                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_004 'Clear' button work properly ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_004 'Clear' button do not work properly Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test SearchField_PreferredProviderListPage TC_005 To verify that Provider Type section do search action for each option
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_005 To verify that Provider Type section do search action for each option");
                for (int i = 2; i <= 5; i++)
                {
                    PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).Click();
                    string ProviderTypeText = PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, i).Text;

                    PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, i).Click();
                    PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "Search");
                    Assert.AreEqual("Selected (1)", PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).GetAttribute("placeholder"));
                    Assert.That(PreferredProviderPOM.CheckProviderTypeOfAllRows(Driver.Value, ProviderTypeText));


                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_005 'Provider Type'section do action for each option properly");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    PreferredProviderPOM.ClickOnProviderTypeFilter(Driver.Value).Click();
                    if (PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, i).Enabled)
                    {
                        PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, i).Click();
                    }


                }
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_005 'Provider Type'section do not do action for each option properlyError: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test SearchField_PreferredProviderListPage TC_006 To verify that Location Type section have 7 option in drop-down
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_006 To verify that Location Type section have 7 option in drop-down");
                PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value).Click();
                PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, 1).Click();
                string Optiontext = PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value).GetAttribute("placeholder");
                Assert.AreEqual("Selected (6)", Optiontext);


                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_006 'Location Type' section have 7 options in drop down");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_006 'Location Type' section have 7 options in drop down Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test SearchField_PreferredProviderListPage TC_007 To verify that Location Type section do search action for each option
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_007 To verify that Location Type section do search action for each option");
                PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value).Click();
                Thread.Sleep(3000);
                if (PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, 1).Enabled)
                {
                    PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, 1).Click();
                    Thread.Sleep(2000);
                }
                for (int i = 2; i <= 7; i++)
                {
                    string LocationTypeText = PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, i).Text;
                    Thread.Sleep(2000);
                    PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, i).Click();

                    Assert.AreEqual("Selected (1)", PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value).GetAttribute("placeholder"));
                    //Assert.That(AddProviderPopupPOM.CheckLocationTypeOfAllRows(Driver.Value, LocationTypeText ));
                    //above Assert will use when location type included in column
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_007 'Location Type' section do search action for each option successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    PreferredProviderPOM.ClickOnLocationTypeTabFilter(Driver.Value);
                    if (PreferredProviderPOM.SelectOptionforProviderType(Driver.Value, i).Enabled)
                    {

                        PreferredProviderPOM.SelectOptionforLocationType(Driver.Value, i).Click();
                        Thread.Sleep(2000);
                    }


                }
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_007 'Location Type' section do not do search action for each option successfully Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }



            //Test SearchField_PreferredProviderListPage TC_008 To verify that Zipcode do search action for given zipcode
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_008 To verify that Zipcode do search action for given zipcode");
                string Zipcode = "85248";

                PreferredProviderPOM.ClickOnZipcodeTab(Driver.Value).Clear();
                PreferredProviderPOM.ClickOnZipcodeTab(Driver.Value).SendKeys(Zipcode);
                Thread.Sleep(2000);
                PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "Search");
                Thread.Sleep(2000);
                if (PreferredProviderPOM.CheckZipCodeOfAllRows(Driver.Value, Zipcode))
                {
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_008 'Zipcode' do search  for given code");
                }
                else if (IncomingPOM.CheckNoRecordsFound(Driver.Value))
                {
                    Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_008 'Zipcode' do search  for given code--'No Records Found");
                }
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_008 'Zipcode' do not search for given code Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test SearchField_PreferredProviderListPage TC_009 To verify that Mile section Drop-down for each option
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_009 To verify that Mile section Drop-down for each option");

                SelectElement Mile = new SelectElement(PreferredProviderPOM.ClickOnMileTab(Driver.Value));
                for (int i = 0; i < Mile.Options.Count; i++)
                {
                    Mile.SelectByIndex(i);
                    Thread.Sleep(2000);
                    string Miletext = Mile.Options.ElementAt(i).Text;
                    Thread.Sleep(2000);
                    PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "Search");
                    Assert.That(PreferredProviderPOM.ClickOnMileTab(Driver.Value).Text.Contains(Mile.Options.ElementAt(i).Text));
                    Thread.Sleep(2000);
                }
                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_009 'Mile' section do search for each drop down");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_009 'Mile' section do search for each drop down Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test SearchField_PreferredProviderListPage TC_010 To verify that More Filter button navigate to inner table
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_PreferredProviderListPage TC_010  To verify that More Filter button navigate to inner table");
                PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "More Filters");
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "CLicked on More Filter button");
                var ServiceOffered = PreferredProviderPOM.CheckServiceOffered_ORInsurance_ORCompany_Count(Driver.Value, "Service Offered", "No");
                var Insurance = PreferredProviderPOM.CheckServiceOffered_ORInsurance_ORCompany_Count(Driver.Value, "Insurance", "No");
                var Company = PreferredProviderPOM.CheckServiceOffered_ORInsurance_ORCompany_Count(Driver.Value, "Company", "No");
                Assert.That(ServiceOffered.Item1);
                Thread.Sleep(2000);
                Assert.That(Insurance.Item1);
                Thread.Sleep(2000);
                Assert.That(Company.Item1);
                Test.Value.Log(Status.Pass, "'Service Offered','Insurance','Company' Items are available on inner table");
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_010 'More filter' button navigate to inner table of search field");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
                PreferredProviderPOM.ClickOnMoreFilter_Clear_Search_LessFilters_Button(Driver.Value, "Less Filters");
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test SearchField_PreferredProviderListPage TC_010 'Less Filter' button navigate back to search field");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_PreferredProviderListPage TC_010 'More filter/Less Filter' button do not work properly Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }



        }

    }
}
