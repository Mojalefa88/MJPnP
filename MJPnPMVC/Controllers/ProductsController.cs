using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJPnPMVC.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJPnPMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string searchValue)
        {
            List<ProductCategoryViewModel> productCategoryVM = new List<ProductCategoryViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");
                var responseTask = client.GetAsync("products/?value=" + searchValue);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    productCategoryVM = JsonConvert.DeserializeObject<List<ProductCategoryViewModel>>(readTask);
                }
               
            }
            return View(productCategoryVM);
        }
        [HttpPost]
        public IActionResult Index(ProductCategoryViewModel pcvm)
        {
            var trolley = new Cart
            {
                ProductId = pcvm.ProductId,
                Quantity = pcvm.Quantity,
                CustomerId = 1
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/trolleys");
                var postTask = client.PostAsJsonAsync<Cart>("trolleys", trolley);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Trolley",new { id=trolley.CartId});
                }
            }

                return View(pcvm);
        }
        [HttpGet]
        public IActionResult Trolley(int id)
        {
            List<CartProductViewModel> cartProductVM = new List<CartProductViewModel>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api");
                var getTask = client.GetAsync("trolleys/"+ id);
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    cartProductVM = JsonConvert.DeserializeObject<List<CartProductViewModel>>(readTask);
                }
            }
            return View(cartProductVM);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile productImage)
        {
            using (var reader = new StreamReader(productImage.OpenReadStream()))
            {
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(productImage.ContentDisposition);
                var fileName = parsedContentDisposition.FileName;

                if(fileName != null)
                {
                    using(var mem = new MemoryStream())
                    {
                        productImage.CopyTo(mem);
                        product.Image = mem.ToArray();
                        
                    }
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/Products");

                var postTask = client.PostAsJsonAsync<Product>("products", product);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(product);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var product = new Product();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53856/api/");
                var getTask = client.GetAsync("products/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(readTask);
                }
            }
            return View(product);
        }
    }
}
