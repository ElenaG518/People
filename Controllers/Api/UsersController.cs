using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using People.Data;
using People.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UsersContext _context;

        //public UsersController(UsersContext context)
        //{
        //    _context = context;
        //}

        private readonly IUserRepo _user;

        public UsersController(IUserRepo user)
        {
            _user = user;
        }

        // GET: api/Users
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _user.GetAllUsers();

            return result;
        }


        // GET: api/Users/Neo
        [Route("name/{name}")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            var result = await _user.GetUsersByName(name);
            return result;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _user.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.ID }, user);
        //}
        public async Task<ActionResult<User>> PostUser(User newUser)
        {
            var user = await _user.CreateUser(newUser);
  
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            await _user.UpdateUser(user);

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.ID == id);
        //}

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _user.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _user.DeleteUser(id);

            return user;
        }
    }
}

