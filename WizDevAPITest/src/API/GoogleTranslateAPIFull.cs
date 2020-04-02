using System;
using System.Linq;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WizDevAPITest.API
{
    public class GoogleTranslateAPIFull : GoogleTranslateAPI
    {
        public List<string> AllTranslations =>
            ResponseContent(ContentKind.AllTranslations);

        public override IRestResponse GET(string text)
        {
            _request = "https://translate.google.com/translate_a/single?client=webapp&sl=ru&tl=en&hl=ru&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&otf=1&pc=1&ssel=6&tsel=3&xid=1791807&kc=2&tk=211474.361133"
                + "&q=" +  text;
            string t = Uri.EscapeUriString(_request);
            _response = _client.Get(new RestRequest(t));
            
            return _response;
        }

        public override dynamic ResponseContent(ContentKind resultKind = ContentKind.Full)
        {
            if (_response != null)
            {
                dynamic _rawJson = JsonConvert.DeserializeObject(_response.Content);

                switch (resultKind)
                {
                    case ContentKind.Full:
                        return _rawJson;
                    case ContentKind.MajourTranslation:
                        return _rawJson[0][0][0];
                    case ContentKind.AllTranslations:
                        JArray array = _rawJson[1][0][1];
                        return array.Select(t => (string)t).ToList();

                        //return temp;
                    default:
                        return null;
                }
            }
            return new List<string>();
        }
    }
}
