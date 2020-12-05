using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> GetAction(
            [FromServices] DataContext context
        )
        {
            var employee = new User { ID = 1, UserName = "robin", Password = "robin", Role = "employee" };
            var manager = new User { ID = 2, UserName = "batman", Password = "batman", Role = "manager" };
            var category = new Category { ID = 1, Title = "Informática" };
            var product = new Product { ID = 1, Category = category, Title = "Mouse", Price = 299, Description = "Mouse Gamer" };
            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });
        }
    }
}