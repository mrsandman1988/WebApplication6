using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> _users;
        public UserController() 
        {
          _users= new List<User>();
           for(int i =1; i<=15;i++)
            {
                User u = new User()
                {
                    Id = i,
                    FirstName = $"Jack {i}",
                    LastName = $"London{i}"
                };
                _users.Add(u);
            }
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll() // endpoint
        {
            var data = _users;
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _users.FirstOrDefault(u =>u.Id == id);
            return Ok(user);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(User user)
        {
            user.Id = 21;
            return Ok(user);
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(User user)
        {
            // update logic
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // logic delete
            return BadRequest();
        }
    }
}
