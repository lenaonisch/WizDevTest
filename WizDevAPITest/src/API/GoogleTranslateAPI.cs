using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizDevAPITest.API
{
    public abstract class GoogleTranslateAPI
    {
        protected RestClient _client = new RestClient();
        protected IRestResponse _response;
        protected string _request;

        public string Request { get => _request; }
        public IRestResponse Response { get => _response; }
        public abstract IRestResponse GET(string text);
        public abstract dynamic ResponseContent(ContentKind resultKind = ContentKind.Full);
    }
}
