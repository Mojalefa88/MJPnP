using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJPnP.DAL;
using MJPnP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJPnP.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        readonly IProductRepository<int,Product> _productRepository;
        readonly IProductCategoryRepository<int, ProductCategoryViewModel> _productCategoryRepository;
        private PnPDbContext db;
        public ProductsController(IProductRepository<int, Product> productRepository, IProductCategoryRepository<int, ProductCategoryViewModel> productCategoryRepository)
        {
            this._productRepository = productRepository;
            this._productCategoryRepository = productCategoryRepository;
        }
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    return _productRepository.GetAll();
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
           return _productRepository.Get(id);
        }
        // GET api/values/value
        [HttpGet]
        public IQueryable<ProductCategoryViewModel> Get(string value)
        {
            return _productCategoryRepository.GetProd(value);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _productRepository.Create(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
