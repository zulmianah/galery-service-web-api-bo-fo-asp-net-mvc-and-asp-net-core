using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using rest;
using rest.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace bo.Controllers
{
    public class PictureController : Controller
    {

        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44388/api/";

        // GET: https://localhost:44323/Picture/Index?IdCategoryPicture=65
        public ActionResult Index(int IdCategoryPicture)
        {
            ViewBag.Message = "Galery by Anah.";
            ViewBag.IdCategoryPicture = IdCategoryPicture;
            return View();
        }

        // GET: https://localhost:44323/Picture/RestIndex?idPicture=65
        public async Task<string> RestIndex(int idPicture)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("CategoryPicture/" + idPicture);

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

        // https://localhost:44323/Picture/RestPaginate?IdCategoryPicture=65&pageNumber=1&pageSize=2

        [HttpGet]
        public async Task<string> RestPaginate(int IdCategoryPicture, int pageNumber, int pageSize)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var query = new Dictionary<String, string>
                {
                    ["IdCategoryPicture"] = IdCategoryPicture.ToString(),
                    ["pageNumber"] = pageNumber.ToString(),
                    ["pageSize"] = pageSize.ToString()
                };
                HttpResponseMessage response = await client.GetAsync(QueryHelpers.AddQueryString("Picture/CategoryPicture/paginate", query));

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


        // POST: Picture/RestCreate
        [HttpPost]
        //public string RestCreate(PICTURE picture)
        //public async Task<string> RestCreate(PICTURE picture)
        public async Task<string> RestCreate(FormCollection formCollection)
        {
            PICTURE picture = new PICTURE();
            picture.ID_CATEGORY_PICTURE = int.Parse(formCollection["ID_CATEGORY_PICTURE"]);
            picture.NAME_PICTURE = formCollection["NAME_PICTURE"];
            picture.DATE_PUBLISH_PICTURE = Convert.ToDateTime(formCollection["DATE_PUBLISH_PICTURE"]);
            picture.DATE_UPLOAD_PICTURE = Convert.ToDateTime(formCollection["DATE_UPLOAD_PICTURE"]);
            picture.PRICE_PICTURE = decimal.Parse(formCollection["PRICE_PICTURE"]);
            string myJsonPicture = "";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            myJsonPicture = System.Text.Json.JsonSerializer.Serialize(picture, options);
            string filePath = "";
            var httpRequest = System.Web.HttpContext.Current.Request;

            // Check if files are available
            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();

                // interate the files and save on the server
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    var tes = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/" + postedFile.FileName);
                    postedFile.SaveAs(tes);

                    files.Add(tes);
                    filePath = files[0];
                }
            }

            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = System.IO.File.OpenRead(filePath))
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                            {
                                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                                // "file" parameter name should be the same as the server side input parameter name
                                form.Add(fileContent, "myFile", Path.GetFileName(filePath));
                                form.Add(new StringContent(myJsonPicture), "pICTURE");

                                httpClient.BaseAddress = new Uri(Baseurl);
                                HttpResponseMessage response = await httpClient.PostAsync("Picture", form);
                                if (response.IsSuccessStatusCode)
                                {
                                    return response.RequestMessage.ToString();
                                }
                                else
                                {
                                    return response.RequestMessage.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}