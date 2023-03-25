using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.Utilities;
using RovicareTestProject.PageObjects;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using System;

namespace RovicareTestProject.Tests.Login
{

    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class Test_Login : BaseClass
    {

        [SetUp]
        public void SetUp()
        {
            Driver.Value = new ChromeDriver();
            Driver.Value.Navigate().GoToUrl(Test_url);
            Driver.Value.Manage().Window.Maximize();
            WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));
            

        }


        [Test, Order(1)]
        [TestCaseSource("AddLoginInfo_Valid")]
        [TestCaseSource("AddLoginInfo_Invalid1")]
        [TestCaseSource("AddLoginInfo_Invalid2")]
        [TestCaseSource("AddLoginInfo_Invalid3")]
        [TestCaseSource("AddLoginInfo_Invalid4")]
        public void Login(string username, string password)
        {
            //try
            //{

            //Test.Value = ExtentTestManager.CreateParentTest("Login test", "Testing the login functionality with multiple valid and invalid credentials");
            Test.Value = ExtentTestManager.CreateTest("Login test", "Testing the login functionality with following credentials= " + username + "   Password =" + password);
            //Test.Value = Extent.Value.CreateTest("Test_Login Username = " + username + "   Password =" + password);

                LoginPOM.EnterUsername(Driver.Value, username);
                LoginPOM.EnterPassword(Driver.Value, password);
                Test.Value.Log(Status.Info, "Credential Entered");
                LoginPOM.ClickOnSignInButton(Driver.Value);
                Thread.Sleep(1500);
                try
                {
                    WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(15));
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addPatientDetail")));
                    string ActualResult = Driver.Value.FindElement(By.Id("addPatientDetail")).GetAttribute("Id");
                    string ExpectedResult = "addPatientDetail";
                    Test.Value.Log(Status.Info, "Correct Credential, User Logged in successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.AreEqual(ActualResult, ExpectedResult);
                }
                catch (WebDriverTimeoutException)
                {
                    try
                    {
                        WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@aria-hidden='false']")));
                        try
                        {
                            string ActualResult = Driver.Value.FindElement(By.XPath("//div[@aria-hidden='false']")).Text;
                            string ExpectedResult = "Your password is incorrect, please try again or use forgot password link to reset it.";
                            string ExpectedResult2 = "We can't seem to find your account.";
                            string ExpectedResult3 = "Please enter a valid email address.";
                            if (ActualResult == ExpectedResult)
                            {
                                Assert.AreEqual(ActualResult, ExpectedResult);
                                Test.Value.Log(Status.Info, "Incorrect Password, LogIn Denied");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                            else if (ActualResult == ExpectedResult2)
                            {
                                Assert.AreEqual(ActualResult, ExpectedResult2);
                                Test.Value.Log(Status.Info, "User Not Found, LogIn Denied");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                            }
                            else if (ActualResult == ExpectedResult3)
                            {
                                Assert.AreEqual(ActualResult, ExpectedResult3);
                                Test.Value.Log(Status.Info, "Invlid username format, LogIn Denied");
                                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            }
                        }
                        catch (WebDriverTimeoutException) { }
                    }
                    catch (Exception) { }
                }
            //}
            //catch (Exception) {  }
        }


        //*********************************************** Test Data *********************************************************
        static string Path = "\\TestData\\AddLoginInfo.json";
        public static IEnumerable<TestCaseData> AddLoginInfo_Valid()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_valid", Test_Login.Path), GetDataParser().TestData("password_valid", Test_Login.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid1()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid1", Test_Login.Path), GetDataParser().TestData("password_invalid1", Test_Login.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid2()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid2", Test_Login.Path), GetDataParser().TestData("password_invalid2", Test_Login.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid3()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid3", Test_Login.Path), GetDataParser().TestData("password_invalid3", Test_Login.Path));
        }

        public static IEnumerable<TestCaseData> AddLoginInfo_Invalid4()
        {
            yield return new TestCaseData(GetDataParser().TestData("username_invalid4", Test_Login.Path), GetDataParser().TestData("password_invalid4", Test_Login.Path));
        }
    }

}