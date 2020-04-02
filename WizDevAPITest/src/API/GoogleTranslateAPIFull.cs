using RestSharp;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace WizDevAPITest.API
{
    public class GoogleTranslateAPIFull : GoogleTranslateAPI
    {
        public List<string> AllTranslations =>
            ResponseContent(ContentKind.AllTranslations);

        public override IRestResponse GET(string text)
        {
            _request = "https://translate.google.com/translate_a/single?client=webapp&sl=ru&tl=en&hl=ru&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&otf=1&ssel=0&tsel=0&xid=1791807&kc=7&tk=664348.826282"
                + "&q=" +  text.ToLower();
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
                        dynamic[] translations = _rawJson[5][0][2];
                        return from t in translations
                               select t[0];
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
