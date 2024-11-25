using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using System.IO;
using System;
using System.Reflection;
using AventStack.ExtentReports.Gherkin.Model;

namespace FrameWorkLayer.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static string path = Path.Combine(
            Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName,
            "TestResults",
            "TestResult.html"
        );

        public static void ExtentReportInit()
        {
            // Initialize the ExtentSparkReporter with the specified path
            var htmlReporter = new ExtentSparkReporter(path);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report For Application";
            htmlReporter.Config.Theme = Theme.Standard;

            // Initialize ExtentReports and attach the reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("WebApplication", "Practice");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void HandleSuccess(string stepType, string stepName)
        {
            switch (stepType.ToUpper())
            {
                case "GIVEN":
                    _scenario.CreateNode<Given>(stepName).Pass("Step passed.");
                    break;
                case "WHEN":
                    _scenario.CreateNode<When>(stepName).Pass("Step passed.");
                    break;
                case "THEN":
                    _scenario.CreateNode<Then>(stepName).Pass("Step passed.");
                    break;
                default:
                    Console.WriteLine("Unknown step type for success: " + stepType);
                    break;
            }
        }

        public static void HandleError(string stepType, string stepName, Exception error)
        {
            switch (stepType.ToUpper())
            {
                case "GIVEN":
                    _scenario.CreateNode<Given>(stepName).Fail(error.Message);
                    break;
                case "WHEN":
                    _scenario.CreateNode<When>(stepName).Fail(error.Message);
                    break;
                case "THEN":
                    _scenario.CreateNode<Then>(stepName).Fail(error.Message);
                    break;
                default:
                    Console.WriteLine("Unknown step type for error: " + stepType);
                    break;
            }
        }

        public static void ExtentReportTearDown()
        {
            
            _extentReports.Flush();
        }
    }
}
