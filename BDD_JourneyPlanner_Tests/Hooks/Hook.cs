using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BDD_JourneyPlanner_Tests.Utilities;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BDD_JourneyPlanner_Tests.Hooks
{
    [Binding]
    public class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            this._container = container;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _Feature = _ExtentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _Scenario = _Feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInIt();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [AfterTestRun]
        public void AfterTestRun()
        {
            ExtentReportTestTearDown();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var driver = _container.Resolve<IWebDriver>();
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _Scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _Scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _Scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _Scenario.CreateNode<And>(stepName);
                }
            }
            else
            {
                if (stepType == "Given")
                {
                    _Scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, 
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenShot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _Scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, 
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenShot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _Scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, 
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenShot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _Scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message, 
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenShot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}