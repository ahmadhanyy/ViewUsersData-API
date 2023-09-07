using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var usersList = _db.UsersTable.Where(x => x.IsActive == true).ToList();
            return Ok(usersList);
        }
        [HttpPost]
        public async Task<IActionResult> addUser(string username)
        {
            User user = new() { Name = username };
            await _db.UsersTable.AddAsync(user);
            _db.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> updateUser(User newUser)
        {
            var user = await _db.UsersTable.SingleOrDefaultAsync(x => x.Id == newUser.Id);
            if (user == null)
            {
                return NotFound($"User ID {newUser.Id} not exist ");
            }
            user.Name = newUser.Name;
            user.IsActive = newUser.IsActive;
            _db.SaveChanges();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var user = await _db.UsersTable.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User ID {id} not exist ");
            }
            user.IsActive = false;
            _db.SaveChanges();
            return Ok(user);
        }
    }
}
