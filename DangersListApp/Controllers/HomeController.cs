using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using DangersListApp.Models;
using System.Net;
using System.Web.Helpers;

namespace DangersListApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> DangersMVC()
        {
            List<Zgloszenie> zgloszenia = new List<Zgloszenie>();


            using (var client = new HttpClient())
            {
                try
                {
                    client.Timeout = new TimeSpan(0,0,600000);
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["warsawApibUrl"]);
                    var response = await client.GetAsync("");
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

        public async Task<JsonResult> DangersAjaxData()
        {
            List<Zgloszenie> zgloszenia = new List<Zgloszenie>();


            using (var client = new HttpClient())
            {
                try
                {
                    client.Timeout = new TimeSpan(0, 0, 600000);
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["warsawApibUrl"]);
                    var response = await client.GetAsync("");
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
                return Json(zgloszenia,JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DangersAjax()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}