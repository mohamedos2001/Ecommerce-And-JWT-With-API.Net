using Ecommerce.Dto;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Ecommerce.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        ITIAPIContext context = new ITIAPIContext();
       

        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<Product> pro = context.Products.ToList();

            return Ok(pro);

        }
        [HttpGet]
        [Route("{id:int}")]   //string [Route("{name:alpha}")] 
        public IActionResult Getbyid(int id)
        {
            Product product = context.Products.Include(p => p.Category) 
                         .FirstOrDefault(e => e.Id == id);

            CateNameWith_Pro cateNameWith_Pro = new CateNameWith_Pro();

            cateNameWith_Pro.CateName = product.Category.Name;

            cateNameWith_Pro.ProName = product.Name;
            cateNameWith_Pro.Id=product.Id;

            return Ok(cateNameWith_Pro);

        }
        [HttpPost]
        public IActionResult PostEmployee(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Created("http://localhost:5047/api/Product" + product.Id, product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult PutEmployee(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                Product old = context.Products.FirstOrDefault(e => e.Id == id);
                old.Name = product.Name;
                old.Description = product.Description;
                old.Price = product.Price;
                

                context.SaveChanges();

                return StatusCode(StatusCodes.Status204NoContent);

            }
            return BadRequest(ModelState);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {

            Product de =context.Products.FirstOrDefault(e => e.Id==id);
            context.Products.Remove(de);
            context.SaveChanges();

            return Ok();
        }

        



        

    }
}
