using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.DAL.Models;
using MyApp.MVC.Models;
using Newtonsoft.Json;

namespace MyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44334");
                MediaTypeWithQualityHeaderValue contentType =new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/blogs").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<Blog> data = JsonConvert.DeserializeObject<List<Blog>>(stringData);
                return View(data);
            }
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
