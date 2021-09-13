using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace DataDrivenForFB
{
    public class Tests:Base.BaseClass
    {
       [Test]
       public void ReadExcelData()
        {
            ExcelOperations excel = new ExcelOperations();
            LoginPage login = new LoginPage(driver);
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\Data.xlsx");
            login.email.SendKeys(excel.ReadData(1,"Email"));
            System.Threading.Thread.Sleep(1000);
            login.password.SendKeys(excel.ReadData(1, "Password"));
            System.Threading.Thread.Sleep(1000);
            login.loginbutton.Click();
            System.Threading.Thread.Sleep(10000);
            //var notification = driver.SwitchTo().Alert();
            //notification.Accept();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("--headless");
            //Actions notify = new Actions(driver);
            //notify.SendKeys(Keys.Escape).Build().Perform();
            System.Threading.Thread.Sleep(10000);
        }
    }
}