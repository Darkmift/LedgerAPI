using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LedgerAPI.Data;
using LedgerAPI.Models;
using LedgerAPI.DTOs;
using LedgerAPI.Extensions;
using Newtonsoft.Json;

namespace LedgerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LedgerAPIContext _context;

        public UsersController(LedgerAPIContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<User>> PostUser(AddUserDTO userDTO)
        //{
        //    var user = await _context.User.AddAsync(userDTO.dtoToModel());
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Entity.Id }, user);
        //}
        [HttpPost]
        public IActionResult PostUser([FromBody] AddUserDTO userDto)
        {
            try
            {
                var user = userDto.dtoToModel();
                _context.User.Add(user);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (JsonSerializationException ex)
            {
                return BadRequest("Data could not be processed");
            }
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
