using APIAutomationBDD.Library;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.Utility.SpecflowHooks
{
    [Binding]
    public class Hooks : ExtentReport
    {
        private readonly IObjectContainer? container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run..");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run..");
            closeExtentReport();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature..");
            //feature = extentReport!.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature..");
        }

        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running before scenario...");
            Scenario = extentReport!.CreateTest(scenarioContext.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    Scenario!.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    Scenario!.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    Scenario!.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    Scenario!.CreateNode<And>(stepName);
                }
            }

        }

    }
}

