using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace bo.Controllers
{
    public class HouseController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44388/api/";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public async Task<string> CategoryPicture()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("CategoryPicture/test");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    return EmpResponse;
                }
                else
                {
                    return Res.RequestMessage.ToString();
                }
            }
        }
        public async Task<string> CategoryPicturePeriode()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("CategoryPicture/test2");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    return EmpResponse;
                }
                else
                {
                    return Res.RequestMessage.ToString();
                }
            }
        }
        [HttpPost]
        public ActionResult FormLogin(string EMAIL, string PASSWORD)
        {
            Session["login"] = 1;
            return RedirectToAction("Index", "House");
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Index", "House");
        }
        public ActionResult LoginFirst()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Galery by Anah.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Anah's contact page.";

            return View();
        }
    }
}