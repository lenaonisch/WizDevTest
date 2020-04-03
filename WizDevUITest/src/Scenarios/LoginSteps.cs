using System;
using System.IO;
using TechTalk.SpecFlow;
using WizDevUITest.Pages;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WizDevUITest.Scenarios
{
    [Binding]
    public class LoginSteps
    {
        GoogleTranslatePage gt;
        LoginPage lp;

        [Given(@"Nobody is logged in")]
        public void GivenNobodyIsLoggedIn()
        {
            gt = new GoogleTranslatePage(Browsers.Chrome);
            gt.Logout();
        }
        
        [When(@"I press Войти")]
        public void WhenIPressВойти()
        {
            gt.BtnLogin.Click();
        }
        
        [Then(@"Login page is opened")]
        public void ThenLoginPageIsOpened()
        {
            lp = new LoginPage(Browsers.Chrome);
            lp.WaitFirstStageLoginPageExist();
            Assert.IsTrue(lp.IsFirstStageLoginPageExists);
        }

        [Then(@"Translation page is opened")]
        public void ThenTranslationPageIsOpened()
        {
            Assert.IsTrue(gt.Exists());
        }

        [Then(@"Password page is opened")]
        public void ThenPasswordPageIsOpened()
        {
            lp.WaitSecondStageLoginPageExist();
            Assert.IsTrue(lp.IsSecondStageLoginPageExists);
        }


        [Then(@"I enter (.*) email")]
        public void ThenIEnterItanetGmail_ComEmail(string email)
        {
            lp.EnterEmail(email);
        }

        [Then(@"I press Далее")]
        public void ThenIPressДалее()
        {
            lp.PressNext();
        }

        [Then(@"I enter (.*) password")]
        public void ThenIEnterAaPassword(string pass)
        {
            lp.EnterPassword(pass);
        }

    }
}
