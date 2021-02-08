using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fo.Models;
using rest;
using System.Net.Http;
using Newtonsoft.Json;

namespace fo.Controllers
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
            return View();
        }
        public async Task<List<PICTURE_SEARCH>> IndexRest()
        {
            List<PICTURE_SEARCH> l = new List<PICTURE_SEARCH>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44388/api/Picture/Search?NAME_PICTURE&NAME_CATEGORY_PICTURE&MIN&MAX&MINDATEPUB&MAXDATEPUB&MINDATEUP&MAXDATEUP"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    l = JsonConvert.DeserializeObject<List<PICTURE_SEARCH>>(apiResponse);
                }
            }
            return l;
        }
        public async Task<List<PICTURE_SEARCH>> SearchRest(
        string NAME_PICTURE,
                string NAME_CATEGORY_PICTURE,
                decimal MIN,
                decimal MAX,
                DateTime MINDATEPUB,
                DateTime MAXDATEPUB,
                DateTime MINDATEUP,
                DateTime MAXDATEUP
            )
        {
            List<PICTURE_SEARCH> l = new List<PICTURE_SEARCH>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44388/api/Picture/Search?NAME_PICTURE="
                    + NAME_PICTURE
                    + "&NAME_CATEGORY_PICTURE="
                    + NAME_CATEGORY_PICTURE
                    + "&MIN="
                    + MIN
                    + "&MAX="
                    + MAX
                    + "&MINDATEPUB="
                    + MINDATEPUB
                    + "&MAXDATEPUB="
                    + MAXDATEPUB
                    + "&MINDATEUP="
                    + MINDATEUP
                    + "&MAXDATEUP="
                    + MAXDATEUP
                    ))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    l = JsonConvert.DeserializeObject<List<PICTURE_SEARCH>>(apiResponse);
                }
            }
            return l;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
