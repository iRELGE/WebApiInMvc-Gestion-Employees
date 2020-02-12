using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    static class GlobalsVariables
    {
       public static HttpClient webApiClient = new HttpClient();

        static GlobalsVariables()
        {
            webApiClient.BaseAddress = new Uri("http://localhost:49917/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}