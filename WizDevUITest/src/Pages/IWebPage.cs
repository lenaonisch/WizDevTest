using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace WizDevUITest.Pages
{
    public interface IWebPage
    {
        bool Exists();
        void ClosePage();
    }
}
