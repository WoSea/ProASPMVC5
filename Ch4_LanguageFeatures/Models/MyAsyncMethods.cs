using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Ch4_LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            //  var httpTask = await client.GetAsync("https://google.com");
            /* return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
             {
                 return antecedent.Result.Content.Headers.ContentLength;
             });*/
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}