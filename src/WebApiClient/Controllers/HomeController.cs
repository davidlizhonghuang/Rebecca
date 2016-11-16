using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ContactWebApITest.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace WebApiClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }



        [HttpGet]
        public async Task<JsonResult> GetData(HttpRequestMessage request) //called by angulat js
        {
            try
            {
                HttpResponseMessage response;

                List<Contact> Content = null;

                var url = "http://localhost:59551/api/Contacts";

                var uri = new Uri(url);

                var client = new HttpClient();

                var tcontent = "";

                client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");

                response = await client.GetAsync(uri);

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (response.IsSuccessStatusCode)
                {
                   tcontent = await response.Content.ReadAsStringAsync();
                }

                return Json(tcontent);
            }
            catch (Exception ex)
            {

                return Json("err"); 

                 throw ex; //handle by elmah

            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDetail(HttpRequestMessage request, int id) //called by angulat js
        {
            try
            {
                HttpResponseMessage response;

                Contact Content = null;

                var url = "http://localhost:59551/api/Contacts/" + id;

                var uri = new Uri(url);

                var client = new HttpClient();

                var jsondata = new JArray();

                var tcontent = "";

               client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");

                response = await client.GetAsync(uri);

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (response.IsSuccessStatusCode)
                {
                    tcontent = await response.Content.ReadAsStringAsync();
                }

                return Json(tcontent);
            }
            catch (Exception ex)
            {
                return Json("no name");

                throw ex;
            }
        }




    }
}
