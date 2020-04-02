using System;
using System.IO;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizDevUITest.Pages;

namespace WizDevUITest.Scenarios
{
    [Binding]
    public class SimpleRuEnTranslationSteps
    {
        GoogleTranslatePage gt;

        [Given(@"I have opened google translate in browser")]
        public void GivenIHaveOpenedGoogleTranslateInBrowser()
        {            
            string projDir = Directory.GetParent(Environment.CurrentDirectory).FullName;
            gt = new GoogleTranslatePage(new ChromeDriver(projDir + "/drivers"));
        }

        [When(@"I have entered (.*) into left side")]
        public void WhenIHaveEnteredПриветIntoLeftSide(string text)
        {
            gt.SendText(text);
        }

        [When(@"(.*) is selected to translate")]
        public void WhenАнглийскийIsSelectedToTranslate(string language)
        {
            gt.SelectOutputLang(language.ToLower());
        }

        [Then(@"I see (.*) in the right side")]
        public void ThenISeeHelloInTheRightSide(string translation)
        {
            string actual = gt.GetTranslation();
            Assert.AreEqual(translation, actual);
        }

        [After]
        public void Close()
        {
            gt.ClosePage();
        }
    }
}
