using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace DataDrivenForFB
{
    public class LoginPageActions
    {
        public static ExcelOperations excel;
        public static LoginPage login;

        //Used to check title given and retived are same
        public void TitleAfterLaunching(IWebDriver driver)
        {
            string title1 = "Facebook - உள்நுழையவும் அல்லது பதிவுசெய்யவும்";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }

        //Here we are reading the data from excel
        public void ReadDataFromExcel(IWebDriver driver)
        {
            excel = new ExcelOperations();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\Data\Data.xlsx");
        }

        //Used for implementing login operations
        public void LoginToFaceBook(IWebDriver driver)
        {
            excel = new ExcelOperations();
            login = new LoginPage(driver);
            //By invoking the readdate method values in table is retrived
            login.email.SendKeys(excel.ReadData(1, "Email"));
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            login.password.SendKeys(excel.ReadData(1, "Password"));
            System.Threading.Thread.Sleep(1000);
            login.loginbutton.Click();
            System.Threading.Thread.Sleep(10000);
            //Is used to escape the notification in facebook after login 
            Actions notify = new Actions(driver);
            notify.SendKeys(Keys.Escape).Build().Perform();
            System.Threading.Thread.Sleep(10000);
        }

        //Used to check title given and retived are same
        public void TitleAfterLogin(IWebDriver driver)
        {
            string title1 = "Facebook";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }
    }
}
