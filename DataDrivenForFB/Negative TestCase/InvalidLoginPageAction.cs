using NUnit.Framework;

namespace DataDrivenForFB.Negative_TestCase
{
    
    public class InvalidLoginPageAction:Base.BaseClass
    {
        public static ExcelOperations excel2;
        public static LoginPageActions loginPage;
        public void CheckInvalidLogin()
        {
            excel2 = new ExcelOperations();
            loginPage = new LoginPageActions();
            loginPage.ReadDataFromExcel();
            InvalidLoginPageData invalid = new InvalidLoginPageData(driver);
            invalid.email.SendKeys(excel2.ReadData(2, "Email"));
            invalid.password.SendKeys(excel2.ReadData(2, "Password"));
            invalid.loginbutton.Click();
            Assert.IsTrue(invalid.alertmessage.Displayed);
        }
    }
}
