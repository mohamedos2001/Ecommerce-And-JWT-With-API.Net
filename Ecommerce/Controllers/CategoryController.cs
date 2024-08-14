using Ecommerce.Dto;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        ITIAPIContext context = new ITIAPIContext();


        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<Category> cate = context.Categories.ToList();

            return Ok(cate);

        }
        [HttpGet]
        [Route("{id:int}")]   //string [Route("{name:alpha}")] 
        public IActionResult Getbyid(int id)
        {
            Category cate = context.Categories
                         .FirstOrDefault(e => e.Id == id);

            

           

            return Ok(cate);

        }
        [HttpPost]
        public IActionResult PostEmployee(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return Created("http://localhost:5047/api/Category" + category.Id, category);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult PutEmployee(int id, Category category)
        {

            if (ModelState.IsValid)
            {
                Category old = context.Categories.FirstOrDefault(e => e.Id == id);
                old.Name = category.Name;
                old.Description = category.Description;
               

                context.SaveChanges();

                return StatusCode(StatusCodes.Status204NoContent);

            }
            return BadRequest(ModelState);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {

            Category de = context.Categories.FirstOrDefault(e => e.Id == id);
            context.Categories.Remove(de);
            context.SaveChanges();

            return Ok();
        }
    }
}
