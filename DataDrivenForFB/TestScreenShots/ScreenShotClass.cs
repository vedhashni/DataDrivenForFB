using OpenQA.Selenium;
using System;

namespace DataDrivenForFB.TestScreenShots
{
    public class ScreenShotClass
    {
        //Used to takescreenshot of the webactions done
        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\TestScreenShots\FaceBookTest" + DateTime.Now.ToString("HHmmss") + ".png");
        }
    }
}
