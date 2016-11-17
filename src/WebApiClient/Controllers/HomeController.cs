using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ContactWebApITest.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using ContactWebApITest.Logging;

namespace ContactWebApITest.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation(LoggingEvents.GET_ITEM, "index.cshtml page is loaded");

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
                    _logger.LogInformation(LoggingEvents.GET_ITEM, "response is sucessful");

                    tcontent = await response.Content.ReadAsStringAsync();
                }

                return Json(tcontent);
            }
            catch (Exception ex)
            {

                _logger.LogInformation(LoggingEvents.GET_ITEM_NOTFOUND, "response is not sucessful");


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
                    _logger.LogInformation(LoggingEvents.GET_ITEM, "response is sucessful");

                    tcontent = await response.Content.ReadAsStringAsync();
                }

                return Json(tcontent);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM_NOTFOUND, "response is not sucessful");

                return Json("no name");

                throw ex;
            }
        }



     
    }
}
