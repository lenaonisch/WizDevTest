using System.Net;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using WizDevAPITest.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace WizDevAPITest.Scenarios
{
    [Binding]
    public class SimpleTranslateSteps
    {
        GoogleTranslateAPIFull gt = new GoogleTranslateAPIFull();

        [Given(@"I have sent (.*) text into google translator")]
        public void GivenIHaveSentПриветRequestIntoGoogleTranslator(string phrase)
        {   
            gt.GET(phrase);
        }
        
        [Then(@"I get (.*) among possible translations")]
        public void ThenIGetHelloAmongPossibleTranslations(string possibleTransation)
        {
            Assert.AreEqual(HttpStatusCode.OK, gt.Response.StatusCode);
            Assert.AreEqual(possibleTransation, (string)gt.ResponseContent(ContentKind.MajourTranslation));
        }

        [Then(@"I get Forbidden status")]
        public void ThenIGetForbiddenStatus()
        {
            Assert.AreEqual(HttpStatusCode.Forbidden, gt.Response.StatusCode);
        }

        [Then(@"I get at least (.*) synonyms")]
        public void ThenIGetAtLeastSynonyms(int p0)
        {
            List<string> synonyms = gt.ResponseContent(ContentKind.AllTranslations);
            Assert.IsTrue(synonyms.Count > 3);
        }

        [Then(@"(.*) is among them")]
        public void ThenHiIsAmongThem(string word)
        {
            List<string> synonyms = gt.ResponseContent(ContentKind.AllTranslations);
            Assert.IsTrue(synonyms.Contains(word));
        }
    }
}
