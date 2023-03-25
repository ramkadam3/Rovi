using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;


namespace RovicareTestProject.Utilities
{
    
    public class BaseClass : ExtentTestManager
    {
        public static ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();
        public static ThreadLocal<ExtentReports> Extent = new ThreadLocal<ExtentReports>();
        public static ThreadLocal<ExtentTest> Test = new ThreadLocal<ExtentTest>();
        public static ThreadLocal<ExtentTest> System_Test = new ThreadLocal<ExtentTest>();
        public static DateTime Time = DateTime.Now;
        public static String WorkingDirectory = Environment.CurrentDirectory;
        public static String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
        public static String LoginCredentials_Path = GetDataParser().TestData_Path("LoginCredentials");
        public static String Test_url = GetDataParser().TestData("Test_url", LoginCredentials_Path);
        public static String Filename = "Screenshot_" + Time.ToString("h_mm_ss") + ".png";
        public static String Origin_Email = GetDataParser().TestData("Origin_Email", LoginCredentials_Path);
        public static String Origin_Password = GetDataParser().TestData("Origin_Password", LoginCredentials_Path);
        public static String Destination_Email = GetDataParser().TestData("Destination_Email", LoginCredentials_Path);
        public static String Destination_Password = GetDataParser().TestData("Destination_Password", LoginCredentials_Path);
        public static String SuperAdmin_Email = GetDataParser().TestData("SuperAdmin_Email", LoginCredentials_Path);
        public static String SuperAdmin_Password = GetDataParser().TestData("SuperAdmin_Password", LoginCredentials_Path);
        public static String Origin_User = GetDataParser().TestData("Origin_User", LoginCredentials_Path);
        public static String Destination_User = GetDataParser().TestData("Destination_User", LoginCredentials_Path);
        public static String recipients = GetDataParser().TestData("recipients", LoginCredentials_Path);


        [OneTimeSetUp]
        public void SetUp()
        {
            //ExtentTestManager.CreateTest(GetType().Name);
           // ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        
        [TearDown]
        public void AfterTest()
        {
            Driver.Value.Close();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            ExtentManager.Instance.Flush();
        }

        public static MediaEntityModelProvider CaptureScreenShot(IWebDriver Driver, String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)Driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return  MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }


        public IWebDriver Browser(IWebDriver Driver, String Email, String Password,string? Browser="Chrome") 
        { if (Browser == "Firefox")
            {

                Driver = new FirefoxDriver();
            }
            else if (Browser.Contains("Edge"))
            {
                Driver = new EdgeDriver();
            }
            else
            {
                Driver = new ChromeDriver();

            }
            Driver.Navigate().GoToUrl(Test_url);
            Driver.Manage().Window.Maximize();
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(35));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));           
                LoginPOM.EnterUsername(Driver, Email);
                LoginPOM.EnterPassword(Driver, Password);
                             
            
            LoginPOM.ClickOnSignInButton(Driver);
            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='navbar-brand desktopLogo']//img[@alt='RoviCare']")));
            return Driver;
        }
                
        public static JSonReader GetDataParser()
        {
            return new JSonReader();
        }

        public static PatientList_JSonReader PL_GetDataParser()
        {
            return new PatientList_JSonReader();
        }

        public static void OpenLinkInNewTab(IWebDriver Driver, string URL)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='signOut']")));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='signOut']")))
            .Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("next")));
        }

        public static void WaitForSpinnerToDisappear(IWebDriver driver)
        {
            WebDriverWait WaitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            WebDriverWait WaitLong = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                WaitShort.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id = 'spinner']")));
                WaitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id = 'spinner']")));
            }
            catch
            {
                
                WaitLong.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id = 'spinner']")));
            }
        }

        public static IWebElement Success_Notification(IWebDriver Driver)
        {
            //string Xpath = "//p[@class='notifier__notification-message ng-star-inserted']";
            string Xpath = "//li[1]/notifier-notification/p";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
            IWebElement Mes = Driver.FindElement(By.XPath(Xpath));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
            return Mes;
        }
        public static void InvisibleSuccess_Notification(IWebDriver Driver)
        {
            //string Xpath = "//p[@class='notifier__notification-message ng-star-inserted']";
            string Xpath = "//li[1]/notifier-notification/p";
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
            
            
            
        }


        public static String InterpolateIntoString(String Locator, String[] Values)
        {
            String[] Fragments = Locator.Split("{{}}");
            // Guard Clause
            if (Fragments.Length != (Values.Length + 1))
                return Locator;

            String InterpolatedString = "";
            int Index = 0;
            foreach (var Fragment in Fragments)
            {
                InterpolatedString += Fragment;

                if (Index < Values.Length)
                    InterpolatedString += Values[Index];

                Index++;
            }
            return InterpolatedString;
        }
        public static void LogOutAccount(IWebDriver Driver)
        {
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='profileLetter']")));
            Driver.FindElement(By.XPath("//span[@id='profileLetter']")).Click();

            WebDriverWait Wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='signOut']")));
            Driver.FindElement(By.XPath("//*[@id='signOut']")).Click();
        }
        

    }
}
