using Microsoft.AspNetCore.Mvc;
using StoredProcedurewithEFCore.Repository;

namespace StoredProcedurewithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var user = _repository.GetAll();
            return Ok(user);
        }
    }
}
