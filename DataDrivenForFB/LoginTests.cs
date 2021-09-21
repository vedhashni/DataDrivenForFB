/*summary :DataDriven and PageFactory Automation Of FaceBook
  Author: Vedhashni V
  Date  : 11-09-21
*/

using AventStack.ExtentReports;
using NUnit.Framework;

namespace DataDrivenForFB
{
    public class LoginTests : Base.BaseClass
    {
        LoginPageActions pageActions = new LoginPageActions();

        ExtentReports report = ReportClass.report();
        ExtentTest test;

        //Used to test the tile after launcing the browser
        [Test, Order(0)]
        public void TestMethodForTitleAfterLaunching()
        {
            pageActions.TitleAfterLaunching(driver);
        }

        //Used to read the data from excel
        [Test, Order(1)]
        public void TestMethodForReadDataFromExcel()
        {
            pageActions.ReadDataFromExcel(driver);
        }

        //Used to login into facebook with credentials given in the excel
        [Test, Order(2)]
        public void TestMethodForLoginIntoFaceBook()
        {
            test = report.CreateTest("FaceBookTests");
            test.Log(Status.Info, "FaceBook Automation");
            pageActions.LoginToFaceBook(driver);
            pageActions.TitleAfterLogin(driver);
            test.Log(Status.Pass, "TestCases Passed");
            report.Flush();
        }

        [Test]
        public void TestMethodForEmailSending()
        {
            Email.EmailClass.ReadDataFromExcel();
            Email.EmailClass.email_send();
        }
    }
}