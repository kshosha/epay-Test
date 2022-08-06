using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPayServer.Data;
using EPayServer.Models;

namespace EPayServer.Controllers
{
    [Route("Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepo _repository;

        public CustomersController(ICustomersRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Customer[]> GetCustomers()
        {
            var items = _repository.GetCustomers();
            return Ok(items);
        }
        [HttpPost]
        public ActionResult PostCustomers([FromBody] Customer[] customers)
        {
            foreach (var c in customers)
            {
                if (c.FirstName == null || c.LastName == null)
                    break;
                if (_repository.GetCustomerByID(c.Id) != null)
                    break;
                if (c.Age <= 18)
                    break;
                _repository.CreateCustmer(c);
            }
            
            return Ok();
        }


    }
}
