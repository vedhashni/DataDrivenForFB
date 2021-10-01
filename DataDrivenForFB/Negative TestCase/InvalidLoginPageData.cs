using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataDrivenForFB.Negative_TestCase
{
    public class InvalidLoginPageData
    {
        //Used to intialize elements of a page class
        public InvalidLoginPageData(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Used to find the element email by specifying its locator
        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        public IWebElement email;

        //Used to find the element password by specifying its id
        [FindsBy(How = How.Id, Using = "pass")]
        [CacheLookup]
        public IWebElement password;

        //Used to find the login button by specifying its name
        [FindsBy(How = How.Name, Using = "login")]
        [CacheLookup]
        public IWebElement loginbutton;

        [FindsBy(How = How.XPath, Using = "//*[@class='_9ay7']")]
        [CacheLookup]
        public IWebElement alertmessage;
    }
}
