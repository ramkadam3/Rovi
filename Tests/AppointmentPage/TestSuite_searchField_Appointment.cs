using AngleSharp.Dom;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using RovicareTestProject.PageObjects;
using RovicareTestProject;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace RovicareTestProject.Tests.AppointmentPage
{
    [TestFixture]
    public class Searchfield_AppointmentPage : BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        [Test, Order(1)]
        public void TestSuite_SearchField_AppointmentPage()

        {
            AppointmentPagePOM.NaviagateToAppointmentPage(Driver.Value);
            AppointmentPagePOM.WaitForAppointmentPage_loading(Driver.Value);









            //Test SearchField_AppointmentPage TC_001 To verify that Search field is available at top of Appointment page
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_001 To verify that Search field is available at top of Appointment Page");
                Assert.That(AppointmentPagePOM.CheckSearchField(Driver.Value));//1

                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_001 Search Field is available in Appointment page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_001 Search Field is not available in Appointment page Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_002 To verify that Search field have By Patient Name,From,To,Appointment Status,Follow Up Status sections 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_002 To verify that Search field have By Patient Name,From,To,Appointment Status,Follow Up Status sections ");
                Assert.That(AppointmentPagePOM.ClickonByPatientName(Driver.Value).Enabled);
                Test.Value.Log(Status.Pass, "Search Field has By patient Name section");
                Assert.That(AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "From").Enabled);
                Test.Value.Log(Status.Pass, "Search Field has 'From' section");
                Assert.That(AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "To").Enabled);
                Test.Value.Log(Status.Pass, "Search Field has 'To' section");
                Assert.That(AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.Enabled);
                Test.Value.Log(Status.Pass, "Search Field has 'AppointmentStatus' section");
                Assert.That(AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1.Enabled);//2
                Test.Value.Log(Status.Pass, "Search Field has 'FollowUpStatus' section");

                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_002 Search field have By Patient Name,From,To,Appointment Status,Follow Up Status sections ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_002 Search field do not have By Patient Name Or From Or To Or Appointment Status Or Follow Up Status sections Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_003 To verify that By patient name section do search action by patient name
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_003 To verify that By patient name section do action by patient name");
                string PatientName = CommonPOM.GetPatientNameFromList(Driver.Value);
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).SendKeys(PatientName);
                Assert.AreEqual(CommonPOM.GetPatientNameFromList(Driver.Value), PatientName);//3

                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_003 Search action done with Patient name");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_003 Unable to do Search action with Patient Name  Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_004 To verify that By patient name section provide 'No Records found' as output for not listed Name
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_004 To verify that By patient name section provide 'No Records found' as output for not listed Name");
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).Clear();
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).SendKeys("Limbya");
                Assert.That(IncomingPOM.CheckNoRecordsFound(Driver.Value));//4


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_004 'No Records Found' if Patient Name is not listed");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).Clear();
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_004 'No Records Found' Not found for non listedd patient name Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_005 To verify that 'From' section shows  date a month before by default
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_005 To verify that 'From' section shows  date a month before by default");
                DateTime dateToday = DateTime.Now;
                int Day = dateToday.Day;
                dynamic Month = dateToday.Month;
                Month = dateToday.Month - 1;
                if (Month < 10)
                {
                    Month = "0" + Convert.ToString(Month);
                }
                else
                {
                    Month = Convert.ToString(Month);
                }
                int Year = dateToday.Year;
                string ActualDate = ($"{Month}-{Day}-{Year}");
                var date = AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "From").GetAttribute("value");
                Assert.AreEqual(date, ActualDate);                                       //5


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_005 'From' Section shows date a month before by default");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_005 'From' Section do not show date a month before by default  Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_006 To verify that 'From' section shows Calender drop-down after click
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_006 To verify that 'From' section shows Calender drop-down after click");
                AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "From").Click();
                Assert.That(AppointmentPagePOM.SelectDateForFrom_OR_To(Driver.Value, "From", "20").Enabled);//6


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_006 'From' section shows drop-down after Click");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_006 'From' section do not shows drop-down after Click Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_007 To verify that 'From' section do search action for given date
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_007 To verify that 'From' section do search action for given date");
                AppointmentPagePOM.SelectDateForFrom_OR_To(Driver.Value, "From", "20").Click();
                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_007 Date selected from calender of 'From'");
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).SendKeys(" ");
                Thread.Sleep(4000);
                Assert.That(AppointmentPagePOM.CheckDateOfAllRows(Driver.Value, AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "From").GetAttribute("value"), AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "To").GetAttribute("value")));//7


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_007 'From' section do search action for given date successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_007 'From' section do not search for given date  Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_008 To verify that 'To' section shows Todays date by default
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_008 To verify that 'To' section shows Todays date by default");

                Assert.AreEqual(DateTime.Now.Date, DateTime.Parse(AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "To").GetAttribute("value")));//8

                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_008 'To' section shows Today's date by default");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_008 'To' section do not show Today's date by default  Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_009 To verify that 'To' section do search action for given date 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_009 To verify that 'To' section do search action for given date ");

                AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "To").Click();
                AppointmentPagePOM.SelectDateForFrom_OR_To(Driver.Value, "To", "20").Click();
                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_009  Date selected for search from calender of 'To' section");
                AppointmentPagePOM.ClickonByPatientName(Driver.Value).SendKeys(" ");
                Thread.Sleep(4000);
                Assert.That(AppointmentPagePOM.CheckDateOfAllRows(Driver.Value, AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "From").GetAttribute("value"), AppointmentPagePOM.ClickOnFrom_ToTab(Driver.Value, "To").GetAttribute("value")));//9


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_009 'To' section do search action for given date successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_009  'To' section unable to do search action for given date Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_010 To verify that 'Appoinntment Status' is at 'All' Position by default
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_010 To verify that 'Appoinntment Status' is at 'All' Position by default");
                Assert.That(AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.Text.Contains("All"));//10


                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_010 'Appointment Status' is at 'All' position by default");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_010 'Appointment Status' is not at 'All' position by default Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test SearchField_AppointmentPage TC_011 To verify that search action done for each option in drop-down in Appointment status section
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_011 To verify that search action done for each option in drop-down in Appointment status section");
                SelectElement AppointmentStatus = new SelectElement(AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1);






                for (int i = 0; i < AppointmentStatus.Options.Count; i++)//make count <=
                {
                    if (!AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.Selected)
                    {
                        AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.Click();

                    }
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item2);
                    //AppointmentPagePOM.MouseActionForDropDownOf_AppointmentStatus(Driver.Value, i);

                    string AppointmentStatusText = AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.Text;



                    try
                    {

                        if (AppointmentPagePOM.CheckStatusOfAllRows(Driver.Value, AppointmentStatusText))//11
                        {
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, $"Test SearchField_Appointment Page TC_011 'Appointment Status' section do search action for Option '{AppointmentStatusText}' Successfully ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        else if (IncomingPOM.CheckNoRecordsFound(Driver.Value))
                        {

                            Assert.That(true);
                            Test.Value.Log(Status.Pass, $"Test SearchField_Appointment Page TC_011 'Appointment Status' section do search action for Option '{AppointmentStatusText}' : 'No Records Found' ");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }

                    }
                    catch (Exception e)

                    {


                        Test.Value.Log(Status.Fail, $"Test SearchField_Appointment page TC_011 'Appointment Status' do not perform search action for Option '{AppointmentStatusText}' Error: " + e);

                        Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                    }









                }

                AppointmentPagePOM.ClickOnAppointmentStatus(Driver.Value).Item1.SendKeys("All");





            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test SearchField_AppointmentPage TC_012 To verify that 'Follow Up Status' is at 'All' position by default
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_012 To verify that 'Follow Up Status' is at 'All' position by default");
                Assert.That(AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1.Text.Contains("All"));      //12

                Test.Value.Log(Status.Pass, "Test SearchField_Appointment Page TC_012 'Follow Up status' is at 'All' position by default ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_Appointment page TC_012 'Follow Up Status' is not at 'All' position by default Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test SearchField_AppointmentPage TC_013 To verify that search action done for each option in drop-down in Follow Up status section


            Test.Value = ExtentTestManager.CreateTest("Test SearchField_AppointmentPage TC_013 To verify that search action done for each option in drop-down in Follow Up status section");
            SelectElement FollowUpStatus = new SelectElement(AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1);

            for (int j = 0; j < FollowUpStatus.Options.Count - 1; j++)
            {
                if (!AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1.Selected)
                {
                    AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1.Click();

                }


                CommonPOM.MouseActionForDropDownHandle(Driver.Value, AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item2);
                //AppointmentPagePOM.MouseActionForDropDownOfFollowUpStatus(Driver.Value,j);
                string FollowUpStatusText = AppointmentPagePOM.ClickOnFollowUpStatus(Driver.Value).Item1.Text;

                try
                {
                    if (AppointmentPagePOM.CheckFollowUpOfAllRows(Driver.Value, new string[] { FollowUpStatusText }))
                    {
                        Assert.That(true); //13
                        Test.Value.Log(Status.Pass, $"Test SearchField_Appointment Page TC_013 'Follow Up status' of All rows are same'");
                    }
                    else if (IncomingPOM.CheckNoRecordsFound(Driver.Value))
                    {

                        Assert.That(true);
                    }
                    Thread.Sleep(2000);

                    Test.Value.Log(Status.Pass, $"Test SearchField_Appointment Page TC_013 'Follow Up status' do search action for option '{FollowUpStatusText}' successfully ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {



                    Test.Value.Log(Status.Fail, $"Test SearchField_Appointment page TC_013 'Follow Up Status' do not perform search for option '{FollowUpStatusText}' Error: " + e);

                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));


                }


            }
            FollowUpStatus.SelectByIndex(0);




































        }































    }
}
