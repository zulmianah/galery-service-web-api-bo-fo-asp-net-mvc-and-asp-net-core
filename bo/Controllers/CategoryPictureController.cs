using Newtonsoft.Json;
using rest;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace bo.Controllers
{
    public class CategoryPictureController : Controller
    {

        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44388/api/";

        // GET: CategoryPicture
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryPicture/RestIndex
        public async Task<string> RestIndex()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("CategoryPicture");

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

        // POST: CategoryPicture/RestCreate
        [HttpPost]
        public async Task<Uri> RestCreate(CATEGORY_PICTURE product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "CategoryPicture", product);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response.Headers.Location;
            }
        }

        // DELETE: CategoryPicture/48
        // DELETE: CategoryPicture/RestDelete/48

        [HttpPost]
        public async Task<string> RestDelete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage response = await client.DeleteAsync("CategoryPicture/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var EmpResponse = response.Content.ReadAsStringAsync().Result;
                    return EmpResponse;
                }
                else
                {
                    return response.RequestMessage.ToString();
                }
            }
        }

        // POST: CategoryPicture/RestUpdate

        [HttpPost]
        public async Task<string> RestUpdate(int id, CATEGORY_PICTURE product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage response = await client.PutAsJsonAsync("CategoryPicture/" + id, product);
                if (response.IsSuccessStatusCode)
                {
                    var EmpResponse = response.Content.ReadAsStringAsync().Result;
                    return EmpResponse;
                }
                else
                {
                    return response.RequestMessage.ToString();
                }
            }
        }


    }

}