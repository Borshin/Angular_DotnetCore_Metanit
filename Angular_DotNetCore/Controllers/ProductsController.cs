using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_DotNetCore.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;

            if (!db.Products.Any())
            {
                db.Products.Add(new Product {Name = "iPhone X", Company = "Apple", Price = 79900});
                db.Products.Add(new Product { Name = "Galaxy S8", Company = "Samsung", Price = 49900 });
                db.Products.Add(new Product { Name = "Pixel 2", Company = "Google", Price = 52900 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await db.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();

                return Ok(product);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                await db.SaveChangesAsync();

                return Ok(product);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }

            return Ok(product);
        }
    }
}
