using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using AutoItX3Lib;

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
            TakeScreenShot(driver);
            //By invoking the readdate method values in table is retrived
            login.email.SendKeys(excel.ReadData(1, "Email"));
            TakeScreenShot(driver);
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            login.password.SendKeys(excel.ReadData(1, "Password"));
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            login.loginbutton.Click();
            System.Threading.Thread.Sleep(10000);
            //Is used to escape the notification in facebook after login 
            TakeScreenShot(driver);
            Actions notify = new Actions(driver);
            notify.SendKeys(Keys.Escape).Build().Perform();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
            login.home.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            login.createpost.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            login.message.SendKeys("Vacation Begins!!");
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            login.photo.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(5000);
            login.addphoto.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(4000);
            //AutoIt- Handle Windows that do not belong to Browser
            AutoItX3 autoIt = new AutoItX3();
            autoIt.ControlFocus("Open", "", "Edit1");
            TakeScreenShot(driver);
            autoIt.ControlSetText("Open", "", "Edit1", @"C:\Users\vedhashni.v\Downloads\vacation.jpg");
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(2000);
            autoIt.ControlClick("Open", "", "Button1");
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(4000);
            TakeScreenShot(driver);
            login.post.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(15000);
        }

        //Used to check title given and retived are same
        public void TitleAfterLogin(IWebDriver driver)
        {
            string title1 = "Facebook";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }

        //Used to takescreenshot of the webactions done
        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\TestScreenShots\FaceBookTest" + DateTime.Now.ToString("HHmmss") + ".png");
        }
    }
}
