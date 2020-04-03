using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WizDevUITest.Pages
{
    public class GoogleTranslatePage : MainPage
    {
        const string TRANSLATOR_LABEL_XPATH = "//span[text()='Переводчик']";
        const string TRANSLATED_TEXT_XPATH = "//span[contains(@class, 'translation')]/span";

        public GoogleTranslatePage(Browsers browser) : base(browser) { }

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
            return _driver.FindElement(By.XPath(TRANSLATED_TEXT_XPATH)).Text;
        }

        public override bool Exists()
        {
            return _driver.FindElements(By.XPath(TRANSLATOR_LABEL_XPATH)).Count > 1;
        }
    }
}
