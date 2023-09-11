using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public string[] GetDishes()
        {
            string[] dishes = { "Biryani", "Karahi", "Palao" };
            return dishes;
        }
    }
}
