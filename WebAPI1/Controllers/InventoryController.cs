using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/Inventory")]
    //[Produces("application/json")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductID=1,ProductName="Product1", ProductPrice="200"},
            new Product(){ProductID=2,ProductName="Product2", ProductPrice="300"},
            new Product(){ProductID=3,ProductName="Product3", ProductPrice="400"}
        };

        public IEnumerable<Product> Get()
        {
            return _products;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {

            var p = _products.SingleOrDefault(x => x.ProductID == product.ProductID);
            _products.Remove(p);
            _products.Add(product);
                
        }



    }

}