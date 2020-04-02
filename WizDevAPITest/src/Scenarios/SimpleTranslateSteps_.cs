using RestSharp;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;

namespace WizDevTest.src
{
    [Binding]
    public class SimpleTranslateSteps_
    {
        RestClient _client; //= new RestClient("https://translate.google.com/");
        RestRequest _request; //= new RestRequest("/#view=home&op=translate&sl=ru&tl=en&text=привет", DataFormat.Json);


        [Given(@"I have entered (.*) into the google translator")]
        public void GivenIHaveEnteredПриветIntoTheGoogleTranslator(string toTranslate)
        {
            _client = new RestClient("https://translate.google.com/");
        }
        
        [When(@"I finished typing")]
        public void WhenIFinishedTyping()
        {
            /*
             * https://translate.google.com/translate_a/single?client=webapp&sl=ru&tl=en&hl=ru&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&otf=1&ssel=0&tsel=0&xid=1791807&kc=7&tk=664348.826282&q=%D0%BF%D1%80%D0%B8%D0%B2%D0%B5%D1%82
             */
            _request = new RestRequest("translate_a/single?client=webapp&sl=ru&tl=en&hl=ru&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&otf=1&ssel=0&tsel=0&xid=1791807&kc=7&tk=664348.826282&q=%D0%BF%D1%80%D0%B8%D0%B2%D0%B5%D1%82", DataFormat.Json);
            
        }
        
        [Then(@"I get Hello")]
        public void ThenIGetHello()
        {
            var response = _client.Get(_request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            dynamic json = JsonConvert.DeserializeObject(response.Content);
            Assert.AreEqual(response.Content, "Hello");
        }
    }
}
