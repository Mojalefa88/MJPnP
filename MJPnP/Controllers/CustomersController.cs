using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJPnP.Models;
using MJPnP.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJPnP.Controllers
{

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        readonly IRepository<int, Customer> _repository;
        public CustomersController(IRepository<int, Customer> repository)
        {
            this._repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet("{username}/{password}")]
        public string Get(string username, string password)
        {
            var login = _repository.Login(username, password);


            return login;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            _repository.Create(customer);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Customer customer)
        {
            _repository.Update(customer);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete([FromBody]Customer customer)
        {
            _repository.Delete(customer);
        }
    }
}
