using OpenQA.Selenium;
using AutoItX3Lib;
using DataDrivenForFB.Data;
using NUnit.Framework;
using System;

namespace DataDrivenForFB.Do_Action
{
    public class HomaPageAction:Base.BaseClass
    {
        public static HomePageData data;
        public static LoginPageActions login;
        public void UploadPhotoIntoFacebook()
        {
            data = new HomePageData(driver);
            login = new LoginPageActions();
            login.LoginToFaceBook();
            try
            {
                data.home.Click();
                System.Threading.Thread.Sleep(9000);
                data.createpost.Click();
                //TakeScreenShot();
                System.Threading.Thread.Sleep(9000);
                data.message.SendKeys("Vacation Begins!!");
                System.Threading.Thread.Sleep(9000);
                data.photo.Click();
                System.Threading.Thread.Sleep(9000);
                data.addphoto.Click();
                System.Threading.Thread.Sleep(9000);
                //AutoIt- Handle Windows that do not belong to Browser
                AutoItX3 autoIt = new AutoItX3();
                autoIt.ControlFocus("Open", "", "Edit1");
                var picture = autoIt.ControlSetText("Open", "", "Edit1", @"C:\Users\vedhashni.v\Downloads\vacation.jpg");
                Assert.NotNull(picture);
                System.Threading.Thread.Sleep(3000);
                autoIt.ControlClick("Open", "", "Button1");
                System.Threading.Thread.Sleep(4000);
                TakeScreenShot();
                data.post.Click();
                TakeScreenShot();
                System.Threading.Thread.Sleep(1000);
                if (data.successfulpost.Displayed)
                {
                    Console.WriteLine("Photo Uploaded successfully");
                }
                else
                {
                    Console.WriteLine("Photo Not Uploaded successfully");
                }
                ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0,1500)");
                System.Threading.Thread.Sleep(2000);
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElementException, "unable to lacate the element");
            }
        }
    }
}
