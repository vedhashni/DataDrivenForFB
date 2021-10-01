/*summary :Hybrid Framework Automation Of FaceBook with screenshot, report generating and email sending
  Author: Vedhashni V
  Date  : 11-09-21
*/

using AventStack.ExtentReports;
using DataDrivenForFB.Do_Action;
using DataDrivenForFB.Negative_TestCase;
using NUnit.Framework;

namespace DataDrivenForFB
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTests : Base.BaseClass
    {
        public LoginTests(string browser) : base(browser)
        {

        }

        LoginPageActions pageActions = new LoginPageActions();
        SignUpPageAction sign = new SignUpPageAction();
        HomaPageAction home = new HomaPageAction();
        InvalidLoginPageAction invalidLogin = new InvalidLoginPageAction();
        ExtentReports report = ReportClass.report();
        ExtentTest test;

        //used to signup in facebook
        [Test, Order(0)]
        public void TestMethodForSignUpIntoFaceBook()
        {
            sign.RegisterIntoFaceBook();
        }

        //Used to login into facebook with credentials given in the excel
        [Test, Order(1)]
        public void TestMethodForLoginIntoFaceBook()
        {
            test = report.CreateTest("FaceBookTests");
            test.Log(Status.Info, "FaceBook Automation");
            pageActions.LoginToFaceBook();
            TakeScreenShot();
            System.Threading.Thread.Sleep(200);
            test.Info("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\TestScreenShots\FaceBookTest.png").Build());
            test.Log(Status.Pass, "TestCases Passed");
            report.Flush();
        }

        [Test, Order(3)]
        public void TestMethodForUploadPhoto()
        {
            home.UploadPhotoIntoFacebook();
        }

        [Test, Order(4)]
        public void TestMethodForEmailSending()
        {
            Email.EmailClass.ReadDataFromExcel();
            Email.EmailClass.email_send();
        }

        [Test, Order(5)]
        public void TestMethodForInvalidLogin()
        {
            invalidLogin.CheckInvalidLogin();
        }
    }
}