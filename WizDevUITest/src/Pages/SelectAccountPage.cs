using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WizDevUITest.Pages
{
    public class SelectAccountPage
    {
        IWebDriver _driver;
        const string BASE_URL = "https://translate.google.com";

        public SelectAccountPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = BASE_URL;
        }

        public void ChangeAccount()
        {
            _driver.FindElement(By.XPath("//*[text()='Сменить аккаунт']")).Click();
        }
    }
}
