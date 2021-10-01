using NUnit.Framework;

namespace DataDrivenForFB
{
    public class LoginPageActions:Base.BaseClass
    {
        public static ExcelOperations excel;
        public static LoginPage login;
        //Here we are reading the data from excel
        public void ReadDataFromExcel()
        {
            excel = new ExcelOperations();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\Data\Data.xlsx");
        }

        //Used for implementing login operations
        public void LoginToFaceBook()
        {
            excel = new ExcelOperations();
            login = new LoginPage(driver);
            try
            {
                string title1 = "Facebook - உள்நுழையவும் அல்லது பதிவுசெய்யவும்";
                string title = driver.Title;
                //AreEqual is used to compare expected and actual result
                Assert.AreEqual(title1, title);
                ReadDataFromExcel();
                TakeScreenShot();
                //By invoking the readdate method values in table is retrived
                login.email.SendKeys(excel.ReadData(1, "Email"));
                TakeScreenShot();
                //is used to wait in a particular page before taking another action
                System.Threading.Thread.Sleep(1000);
                //By invoking the readdate method values in table is retrived
                login.password.SendKeys(excel.ReadData(1, "Password"));
                TakeScreenShot();
                System.Threading.Thread.Sleep(1000);
                login.loginbutton.Click();
                System.Threading.Thread.Sleep(10000);
                string title2 = "Facebook";
                string title3 = driver.Title;
                //AreEqual is used to compare expected and actual result
                Assert.AreEqual(title2, title3);
                TakeScreenShot();
                System.Threading.Thread.Sleep(1000);
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "webdriver unable to locate the element");
            }

        }
    }
}
