using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using APIAutomationBDD.Utility.GenericMethods;

namespace APIAutomationBDD.Library
{
    public class ExtentReport
    {
        public static ExtentReports? extentReport;
        public static ExtentTest? feature;
        public static ExtentTest? Scenario;
        public static string? ReportPath = null;
        public static string? fullpath = null;
        public static string? ModuleName = null;
        public static string? check;
        public static string? time;
        public static string? path;

        public static void ExtentReportInit()
        {
            try
            {
                if (check == null)
                {
                    time = GenericMethods.GetDateTimeRelpaceSlashWithUnderscore();
                    path = GenericMethods.DirectoryPat() + "\\Output\\ExtentReports\\";

                    ReportPath = path + "Results " + time;
                    Directory.CreateDirectory(ReportPath);
                }

                fullpath = ReportPath + "\\" + time + ".html";
                //var htmlReporter = new ExtentSparkReporter(fullpath);
                //var htmlReporter = new ExtentHtmlReporter();
                extentReport = new ExtentReports();
                var spark = new ExtentSparkReporter(fullpath);
                extentReport.AttachReporter(spark);
                extentReport.AddSystemInfo("Host Name", "Automation Practice");
                extentReport.AddSystemInfo("Environment", "QA");
                extentReport.AddSystemInfo("Application", "reqres.in");
                extentReport.AddSystemInfo("Owner", "Automation Team");

                check = "Created";

            }
            catch (Exception e)
            {
                Assert.Fail("problem in setting extent report" + e);

            }
        }

        public static void closeExtentReport()
        {
            ExtentReport.extentReport!.Flush();
        }

        public static void ExtentPass(String details)
        {
            try
            {
                Scenario!.Log(Status.Pass, details);

            }
            catch (Exception)
            {

            }
        }

        public static void ExtentModuleName(String module)
        {
            ModuleName = module;
        }

    }
}
