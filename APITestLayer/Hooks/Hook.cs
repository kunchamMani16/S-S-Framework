using AventStack.ExtentReports.Gherkin.Model;
using FrameWorkLayer.Action;
using FrameWorkLayer.Configure;
using FrameWorkLayer.Utilities;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace APITestLayer.Hooks
{
    [Binding]
    public class Hook : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext;
        private WebAppUtilities webAppUtilities;
        private readonly TestSettings testSettings;
        private readonly LoggerUtility loggerUtility;
        private ScreenShot screenShot;
        public Hook(ScenarioContext _scenarioContext)
        {
            this._scenarioContext = _scenarioContext;
            testSettings = ConfigReader.GetConfig($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//appsetting.json");
            _scenarioContext["TestSettings"] = testSettings;
            loggerUtility = LoggerUtility.Instance;
            loggerUtility.SetFile("ConfigLogger.xml");
            loggerUtility.GetLogger<Hook>();
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            loggerUtility.LogInfo("Running Before Scenario for..." + _scenarioContext.ScenarioInfo.Title);
            _scenario = _feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            loggerUtility.LogInfo("Running After Scenario ...");
        }

        [AfterStep]
        public void AfterStep()
        {
            loggerUtility.LogInfo("Running After Step...");
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = _scenarioContext.StepContext.StepInfo.Text;
            loggerUtility.LogInfo(stepType + " " + stepName);
            if (_scenarioContext.TestError == null)
            {
                HandleSuccess(stepType, stepName);
            }
            else
            {
                loggerUtility.LogError("Error ", _scenarioContext.TestError);
                screenShot = new ScreenShot(webAppUtilities.GetDriver());
                HandleError(stepType, stepName, _scenarioContext.TestError);
                string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/ErrorScreenshot/";
                string screenshotName = $"{_scenarioContext.ScenarioInfo.Title}";
                screenShot.GetScreenshot("Error occured " + screenshotName, path, webAppUtilities);
            }
        }
    }
}