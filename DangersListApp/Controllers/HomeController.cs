using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using DangersListApp.Models;
using System.Net;

namespace DangersListApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> DangersMVC()
        {
            List<Zgloszenie> zgloszenia = new List<Zgloszenie>();

            //Ustawiamy proxy
            // First create a proxy object

            var proxy = new WebProxy()
            {
                Address = new Uri($"http://126.179.0.206:9090"),
                UseDefaultCredentials = false,

                // *** These creds are given to the proxy server, not the web server ***
                Credentials = new NetworkCredential(
                    userName: "MichaMat",
                    password: "Michalek58")
            };

        // Now create a client handler which uses that proxy

        var httpClientHandler = new HttpClientHandler()
        {
            Proxy = proxy,
        };

            using (var client = new HttpClient(httpClientHandler))
            {
                try
                {
                    client.Timeout = new TimeSpan(0,0,600000);
                    client.BaseAddress = new Uri("https://api.um.warszawa.pl");
                    var response = await client.GetAsync($"/api/action/19115store_getNotifications/?id=28dc65ad-fff5-447b-99a3-95b71b4a7d1e&apikey=7c0e8f2a-34d8-4a98-93b7-abf1941558c3");
                    //client.BaseAddress = new Uri("http://wp.pl");
                    //var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    JObject jStringResult = JObject.Parse(stringResult);
                    zgloszenia = jStringResult["result"]["result"]["notifications"].Select(z => z.ToObject<Zgloszenie>()).ToList();

                    ViewBag.Message = "";
                    
                }
                catch (HttpRequestException httpRequestException)
                {
                    ViewBag.Message = httpRequestException.Message;
                }
                finally
                {
                    
                }
                return View(zgloszenia);
            }
        }

            public ActionResult Index()
        {
            return View();
        }
    }
}