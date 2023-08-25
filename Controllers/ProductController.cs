using Microsoft.AspNetCore.Mvc;
using POCAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Data.Entity;

namespace POCAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _DbContext;

        public ProductController(ProductDBContext dBContext)
        {
            this._DbContext = dBContext;
        }
        [HttpGet]

        // public async Task<ActionResult<IEnumerable<Product>>>
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _DbContext.Product.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post (Product product)
        {
            _DbContext.Add(product);
            await _DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int ProductID)
        {
            if(ProductID < 1)
            return BadRequest();
            var product = await _DbContext .Product.FindAsync(ProductID);
            if (product == null)
                return NotFound();
            _DbContext.Product.Remove(product);
            await _DbContext.SaveChangesAsync();
            return Ok();         
        }

        [HttpPut]

      /* public async Task<IActionResult> Put (Product productdata)
        {
            if (productdata == null || productdata.ProductID == 0)
            return BadRequest();

            var product = await _DbContext.Product.FindAsync(productdata.ProductID);
            if (product == null)
                return NotFound();

            product.ProductID = productdata.ProductID;
            product.ProductName = productdata.ProductName;
           
            await _DbContext.SaveChangesAsync();
            return Ok(product);
        } */

       public async Task<IActionResult> UpdateContact (int ProductID, [FromBody] Product product)
        {
            var prd = await _DbContext.Product.FindAsync(ProductID);
            if (prd != null)
            {
                //prd.ProductID = product.ProductID;
                prd.ProductName = product.ProductName;

                await _DbContext.SaveChangesAsync();
                return Ok(prd);
            }
            return NotFound();
        }
    }
}


