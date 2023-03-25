using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RovicareTestProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Utilities
{
    public class IO_Methods
    {
        public static bool CheckFile (string Name)
        {
            string currentFile = @"C:\Users\User\Downloads\" + Name + "";
            if(File.Exists(currentFile))
            {
                return true;
            }
            else { return false; }
        }

        public static IWebDriver NavigateToDownloadFolder(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("File:///C:/Users/User/Downloads");
            return Driver;
        }

        //public static IWebDriver UploadFile(IWebDriver Driver, String Path)
        //{
        //    IWebDriver browse = Driver.FindElement(By.XPath(""));
                
        //    return Driver;
        //}
    }
}
