using log4net;
using log4net.Config;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace DataDrivenForFB.Base
{
    [TestFixture]
   public  class BaseClass
    {
        private string browser;
        public BaseClass()
        {

        }
        public BaseClass(string browser)
        {
            this.browser = browser;
        }

        public static IWebDriver driver;
        //Get Logger for fully qualified name for type of 'AlertTests' class
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginTests));

        //Get the default ILoggingRepository
        private static readonly ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

        [SetUp]
        public void BrowserTest()
        {
            //BasicConfigurator.Configure();
            // Valid XML file with Log4Net Configurations
            var fileInfo = new FileInfo(@"log4net.config");

            // Configure default logging repository with Log4Net configurations
            XmlConfigurator.Configure(repository, fileInfo);
            try
            {
                log.Info("Configured");
                ChromeOptions options = new ChromeOptions();
                //notification is disabled once the browser is launched
                options.AddArgument("--disable-notifications");
                //switch(browser)
                //{
                //    case "chrome":
                //        driver = new ChromeDriver();
                //        break;
                //    case "firefox":
                //        driver = new FirefoxDriver();
                //        break;
                //}
                driver = new ChromeDriver(options);
                driver.Url = "https://www.facebook.com/";
                log.Debug("navigating to url");
                //Used to maximize the window
                driver.Manage().Window.Maximize();
                log.Info("Window is maximized");
            }
            catch 
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchSessionException, "chrome session not created");
            }

        }
        [TearDown]
        public void TearDown()
        {
            //Used to close the opened session
            driver.Quit();
        }

        public static void TakeScreenShot()
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\TestScreenShots\FaceBookTest.png");
        }
    }
}
