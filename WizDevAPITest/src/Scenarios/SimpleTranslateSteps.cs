using System.Net;
using TechTalk.SpecFlow;
using WizDevAPITest.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
