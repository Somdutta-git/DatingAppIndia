using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UserController(DataContext context) : ControllerBase
    {


        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = context.Users.ToList();
            return users;
        }

        [HttpGet("{Id:int}")] // api/users/3
        public ActionResult<AppUser> GetUser(int Id) 
        {
            var user = context.Users.Find(Id);

            if (user == null) return NotFound();
            
            return user;
        }
    }
}
