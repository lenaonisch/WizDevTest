using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace WizDevUITest.Pages
{
    public class LoginPage : MainPage
    {
        private const string PASSWORD_XPATH = "//input[@type='password']";
        private const string EMAIL_XPATH = "//input[@type='email']";
        private const string NEXT_XPATH = "//*[text()='Далее']";
        private IWebElement _emailInput
        {
            get 
            {
                return _driver.FindElement(By.XPath(EMAIL_XPATH));
            }
        }
        private IWebElement _passwordInput
        {
            get
            {
                return _driver.FindElement(By.XPath(PASSWORD_XPATH));
            }
        }

        public LoginPage(Browsers browser) : base (browser) { }

        public void EnterEmail(string email)
        {
            //itanet181@gmail.com
            _emailInput.SendKeys(email);
        }

        public void WaitFirstStageLoginPageExist()
        {
            MainPage.WaitUntilElementClickable(_driver, By.XPath(EMAIL_XPATH));
        }

        public void WaitSecondStageLoginPageExist()
        {
            MainPage.WaitUntilElementClickable(_driver, By.XPath(PASSWORD_XPATH));
        }

        public bool IsSecondStageLoginPageExists
        {
            get { return _passwordInput != null; }
        }

        public bool IsFirstStageLoginPageExists
        {
            get { return _emailInput != null; }
        }

        public void PressNext()
        {
            _driver.FindElement(By.XPath(NEXT_XPATH)).Click();
        }

        public void EnterPassword(string password)
        {
            //Aa111111!
            MainPage.WaitUntilElementClickable(_driver, By.XPath(PASSWORD_XPATH)).SendKeys(password);
        }
    }
}
