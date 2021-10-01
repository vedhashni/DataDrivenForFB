using DataDrivenForFB.Data;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenForFB.Do_Action
{
    public class SignUpPageAction:Base.BaseClass
    {
        public static SignUpPage signUp;
        public static ExcelOperationForSignUp excel1;

        public void ReadDataFromExcelForSignUp()
        {
            excel1 = new ExcelOperationForSignUp();
            excel1.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\Data\SignUpData.xlsx");
        }

        public void RegisterIntoFaceBook()
        {
            excel1 = new ExcelOperationForSignUp();
            signUp = new SignUpPage(driver);
            signUp.createnewaccountbtn.Click();
            System.Threading.Thread.Sleep(1000);
            ReadDataFromExcelForSignUp();
            System.Threading.Thread.Sleep(1000);
            signUp.FirstName.SendKeys(excel1.ReadData(1, "FirstName"));
            signUp.SurName.SendKeys(excel1.ReadData(1, "SurName"));
            signUp.Email.SendKeys(excel1.ReadData(1, "Email"));
            signUp.ReConfirmEmail.SendKeys(excel1.ReadData(1, "ConfirmEmail"));
            signUp.Password.SendKeys(excel1.ReadData(1, "Password"));
            SelectElement element = new SelectElement(signUp.Date);
            Assert.IsFalse(element.IsMultiple);
            element.SelectByText("12");
            SelectElement element1 = new SelectElement(signUp.Month);
            Assert.IsFalse(element.IsMultiple);
            element1.SelectByValue("1");
            SelectElement element2 = new SelectElement(signUp.Year);
            Assert.IsFalse(element.IsMultiple);
            element2.SelectByValue("1999");
            signUp.Gender.Click();
            Assert.IsTrue(signUp.Gender.Enabled);
            signUp.SignUp.Click();
        }
    }
}
