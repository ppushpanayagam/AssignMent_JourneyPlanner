using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace BDD_JourneyPlanner_Tests.Utilities;

public class ExtentReport
{
    public static ExtentReports _ExtentReport;
    public static ExtentTest _Feature;
    public static ExtentTest _Scenario;

    public static string dir = AppDomain.CurrentDomain.BaseDirectory;
    public static string testOutPutPath = dir.Replace("bin/Debug/netcoreapp3.1", "TestResults");

    public static void ExtentReportInIt()
    {
        var htmlReporter = new ExtentHtmlReporter(testOutPutPath);
        htmlReporter.Configuration().ReportName = "Automation Test Report";
        htmlReporter.Configuration().DocumentTitle = "Journey Planner Test Report";
        htmlReporter.Configuration().Theme = Theme.Dark;

        _ExtentReport = new ExtentReports();
        _ExtentReport.AttachReporter(htmlReporter);
        _ExtentReport.AddSystemInfo("Application", "TFL Journey Planner Application");
        _ExtentReport.AddSystemInfo("Browser", "Chrome");
        _ExtentReport.AddSystemInfo("OS", "Windows");
    }

    public static void ExtentReportTestTearDown()
    {
        _ExtentReport.Flush();
    }

    public string AddScreenShot(IWebDriver driver, ScenarioContext scenarioContext)
    {
        ITakesScreenshot takeScreenShot = (ITakesScreenshot)driver;
        Screenshot screeshot = takeScreenShot.GetScreenshot();
        string screenShotLocation = Path.Combine(testOutPutPath, scenarioContext.ScenarioInfo.Title+".png");
        screeshot.SaveAsFile(screenShotLocation, ScreenshotImageFormat.Png);
        return screenShotLocation;
    }
    
    
}