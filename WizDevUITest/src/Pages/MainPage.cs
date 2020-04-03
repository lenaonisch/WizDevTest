using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WizDevUITest.Pages
{
    public class MainPage : IWebPage
    {
        protected IWebDriver _driver;
        protected WebPage _webPage;
        const string LOGOUT_BTN_XPATH = "//a[@text='Выйти']";
        const string LOGIN_BTN_XPATH = "//*[text()='Войти']";
        const string ACCOUNT_XPATH = "//a[contains(@href, 'SignOut')]";

        public MainPage(Browsers browser) 
        {
            _webPage = WebPage.GetInstance(browser);
            _driver = _webPage._driver;
        }

        public static IWebElement WaitUntilElementClickable(IWebDriver _driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public virtual bool Exists()
        {
            return _driver != null;
        }

        public IWebElement BtnLogin
        {
            get 
            {
                return _driver.FindElement(By.XPath(LOGIN_BTN_XPATH));
            }
        }

        public IWebElement BtnAccount
        {
            get 
            {
                return _driver.FindElement(By.XPath(ACCOUNT_XPATH));
            }
        }

        public bool IsLogined
        {
            get { return BtnLogin == null; }
        }

        public void Logout()
        {
            if (IsLogined)
            {
                BtnAccount.Click();
                var logoutbtn = WaitUntilElementClickable(_driver, By.XPath(LOGOUT_BTN_XPATH));
                logoutbtn.Click();
                WaitUntilElementClickable(_driver, By.XPath(LOGIN_BTN_XPATH));
            }
        }

        public void ClosePage()
        {
            _webPage.ClosePage();
        }
    }
}
