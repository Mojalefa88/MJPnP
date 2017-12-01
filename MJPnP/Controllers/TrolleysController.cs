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
    public class TrolleysController : Controller
    {
        readonly ITrolleyRepository<int, Cart> _trolleyRepository;
        readonly ICartProductRepository<int, CartProductViewModel> _cartProductRepository;
        //public TrolleyService
        public TrolleysController(ITrolleyRepository<int, Cart> trolleyRepository, ICartProductRepository<int, CartProductViewModel> cartProductRepository)
        {
            this._trolleyRepository = trolleyRepository;
            this._cartProductRepository = cartProductRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<CartProductViewModel> Get(int id)
        {
            return _cartProductRepository.Read(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Cart trolley)
        {
            _trolleyRepository.AddToTrolley(trolley);
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
