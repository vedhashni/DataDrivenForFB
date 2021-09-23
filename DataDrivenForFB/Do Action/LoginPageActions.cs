using NUnit.Framework;
using OpenQA.Selenium;
using DataDrivenForFB.Do_Action;


namespace DataDrivenForFB
{
    public class LoginPageActions:Base.BaseClass
    {
        public static ExcelOperations excel;
        public static LoginPage login;
        HomaPageAction homepage = new HomaPageAction();
        //ScreenShotClass screenShot = new ScreenShotClass();

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
            //ScreenShotClass.TakeScreenShot(driver);
            TakeScreenShot(driver);
            //By invoking the readdate method values in table is retrived
            login.email.SendKeys(excel.ReadData(1, "Email"));
            //ScreenShotClass.TakeScreenShot(driver);
            TakeScreenShot(driver);
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            login.password.SendKeys(excel.ReadData(1, "Password"));
           TakeScreenShot(driver);
            //ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            login.loginbutton.Click();
            System.Threading.Thread.Sleep(10000);
            //Is used to escape the notification in facebook after login 
            //ScreenShotClass.TakeScreenShot(driver);
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
            homepage.UploadPhotoIntoFacebook(driver);
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
