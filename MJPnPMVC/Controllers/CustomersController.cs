using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJPnPMVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJPnPMVC.Controllers
{
    public class CustomersController : Controller
    {
       
        const string SessionKeyName = "_Name";
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/customers");


                var postTask = client.PostAsJsonAsync<Customer>("customers", customer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(customer);
        }

        public IActionResult Login()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Login(Customer customer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");
                var responseTask = client.GetAsync(string.Format("customers/{0}/{1}",customer.email, customer.password));
                //GetAsync(string.Format("api/User?username={0}&password={1}", username, password));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;

                    //  string hasValue = JsonConvert.DeserializeObject<string>(readTask);

                    if (readTask != "Failed to login")
                    {
                        HttpContext.Session.SetString("Name", customer.lastName);

                        var session = HttpContext.Session.GetString("Name");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.loginError = "Either your username/passord is incorrect";
                    }
                        
                } 
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var customer = new Customer();

           // List<Customer> customer = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");

                var responseTask = client.GetAsync("customers/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(readTask);
                }
            }
            //Customer cus = customer.Where(c => c.customerID == id).FirstOrDefault();

            return View(customer);
            
        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/customers");

                var putTask = client.PutAsJsonAsync<Customer>("customers", customer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = new Customer();

            // List<Customer> customer = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");

                var responseTask = client.GetAsync("customers/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(readTask);
                }
            }
            //Customer cus = customer.Where(c => c.customerID == id).FirstOrDefault();

            return View(customer);
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/customers");

                var putTask = client.PutAsJsonAsync<Customer>("customers", customer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }
    }
}
