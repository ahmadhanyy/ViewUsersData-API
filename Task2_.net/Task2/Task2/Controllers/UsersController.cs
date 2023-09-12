using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using Task2.Dtos;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        private readonly IMapper _mapper;
        private readonly AppDbContext _db;

        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var usersFromDb = _db.UsersTable.Where(x => x.IsActive == true).ToList();
            var usersList = _mapper.Map<IEnumerable<UserDto>>(usersFromDb);
            return Ok(usersList);
        }
        [HttpPost]
        public async Task<IActionResult> addUser(UserDetailesDto newUser)
        {
            User user = new();
            user = _mapper.Map<User>(newUser);
            await _db.UsersTable.AddAsync(user);
            _db.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> updateUser(UserDto newUser)
        {
            var user = await _db.UsersTable.SingleOrDefaultAsync(x => x.Id == newUser.Id);
            if (user == null)
            {
                return NotFound($"User ID {newUser.Id} not exist ");
            }
            //user = _mapper.Map<User>(newUser);
            user.Name = newUser.Name;
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
