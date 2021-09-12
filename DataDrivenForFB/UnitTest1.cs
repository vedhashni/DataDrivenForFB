using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DataDrivenForFB
{
    public class Tests:Base.BaseClass
    {
       [Test]
       public void ReadExcelData()
        {
            ExcelOperations excel = new ExcelOperations();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\Documents\Data.xlsx");
            driver.FindElement(By.Name("email")).SendKeys(excel.ReadData(1,"Email"));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("pass")).SendKeys(excel.ReadData(1, "Password"));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Name("login")).Click();
            System.Threading.Thread.Sleep(10000);
            Actions notify = new Actions(driver);
            notify.SendKeys(Keys.Escape).Build().Perform();
            System.Threading.Thread.Sleep(10000);
        }
    }
}