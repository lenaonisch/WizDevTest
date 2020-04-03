using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WizDevUITest.Pages
{
    public class WebPage
    {
        public IWebDriver _driver { get; protected set; }
        protected static WebPage _instance;
        protected const string BASE_URL = "https://translate.google.com";

        public void ClosePage()
        {
            _driver.Close();
        }

        public static IWebDriver NewBrowserInstance(Browsers browser)
        {
            string projDir = Directory.GetParent(Environment.CurrentDirectory).FullName;

            switch (browser)
            {
                case Browsers.Chrome:
                    return new ChromeDriver(projDir + "/drivers");
                default:
                    return new ChromeDriver(projDir + "/drivers");
            }
        }

        public static WebPage GetInstance(Browsers browser)
        {
            if (_instance == null)
            {
                _instance = new WebPage();
                _instance._driver = NewBrowserInstance(browser);
                _instance._driver.Url = BASE_URL;
            }
            return _instance;
        }

        public static void GoHome()
        {
            if (_instance != null)
            {
                _instance._driver.Navigate().GoToUrl(BASE_URL);
            }
        }
    }
}
