using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJPnPMVC.Models;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJPnPMVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            List<Customer> cusInfo = new List<Customer>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                   
                    cusInfo = JsonConvert.DeserializeObject<List<Customer>>(readTask);
                }
            }
           

            return View(cusInfo);
        }
    }
}
