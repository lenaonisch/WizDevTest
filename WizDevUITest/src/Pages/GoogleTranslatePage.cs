using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WizDevUITest.Pages
{
    public class GoogleTranslatePage
    {
        const string BASE_URL = "https://translate.google.com";
        IWebDriver _driver;

        public GoogleTranslatePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = BASE_URL;
        }

        public void SendText(string text)
        {
            _driver.FindElement(By.Id("source")).SendKeys(text);
        }

        public void SelectOutputLang(string shortName)
        {
            var locator = By.XPath("//div[@class='tl-wrap']//div[contains(@id, 'sugg-item') and text()='" + shortName + "']");
            _driver.FindElement(locator).Click();
        }

        public string GetTranslation()
        {
            return _driver.FindElement(By.XPath("//span[contains(@class, 'translation')]/span")).Text;
        }

        public void ClosePage()
        {
            _driver.Close();
        }
    }
}
