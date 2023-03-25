using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;

namespace RovicareTestProject.Utilities
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> Extent = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return Extent.Value; } }

        static ExtentManager()
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            var HtmlReporter = new ExtentV3HtmlReporter(ProjectDirectory + $"\\ExtentReports\\EReport{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.html");
            Extent.Value.AttachReporter(HtmlReporter);
            Extent.Value.AddSystemInfo("Host Name", "Local Host");
            Extent.Value.AddSystemInfo("Environment", "Test Environment");
            Extent.Value.AddSystemInfo("os", "Windows 10");
            HtmlReporter.Config.DocumentTitle = "Extent Reports";
            HtmlReporter.Config.ReportName = "Extent Reports";
            HtmlReporter.Config.Theme = Theme.Standard;
            Instance.AttachReporter(HtmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}
