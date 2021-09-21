using OpenQA.Selenium;
using AutoItX3Lib;
using DataDrivenForFB.Data;
using DataDrivenForFB.TestScreenShots;
using NUnit.Framework;

namespace DataDrivenForFB.Do_Action
{
    public class HomaPageAction
    {
        public static HomePageData data;
        public static void UploadPhotoIntoFacebook(IWebDriver driver)
        {
            data.home.Click();
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            data.createpost.Click();
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            data.message.SendKeys("Vacation Begins!!");
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(9000);
            data.photo.Click();
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(5000);
            data.addphoto.Click();
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(4000);
            //AutoIt- Handle Windows that do not belong to Browser
            AutoItX3 autoIt = new AutoItX3();
            autoIt.ControlFocus("Open", "", "Edit1");
            ScreenShotClass.TakeScreenShot(driver);
            var picture = autoIt.ControlSetText("Open", "", "Edit1", @"C:\Users\vedhashni.v\Downloads\vacation.jpg");
            Assert.NotNull(picture);
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(2000);
            autoIt.ControlClick("Open", "", "Button1");
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(4000);
            ScreenShotClass.TakeScreenShot(driver);
            data.post.Click();
            ScreenShotClass.TakeScreenShot(driver);
            System.Threading.Thread.Sleep(15000);
        }
    }
}
