using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Data;
using api.DTOs.User;
using api.Mappers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var AllUsers = await _context.Users.ToListAsync();
            
            var AllUsersDTO = AllUsers.Select(s => s.ToUserDTO());

            return Ok(AllUsersDTO);
        }

        [HttpGet]
        [Route("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByID( int id)
        {
            var User = await _context.Users.FindAsync(id);
            if(User == null)
            {
                return NotFound();
            }

            return Ok(User.ToUserDTO());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO UserDTO)
        {
            var UserModel = UserDTO.ToUserFromCreateDTO();
            await _context.Users.AddAsync(UserModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserByID), new {id = UserModel.ID}, UserModel.ToUserDTO());
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> UpdateUser( [FromBody] UpdateUserRequestDTO UpdateDTO)
        {
            var UserModel = await _context.Users.FirstOrDefaultAsync(t => t.ID == UpdateDTO.Id);
            if(UserModel == null)
            {
                return NotFound();
            }

            UserModel.Name = UpdateDTO.Name;
            UserModel.Email = UpdateDTO.Email;
            UserModel.Password = UpdateDTO.Password;

            await _context.SaveChangesAsync();

            return Ok(UserModel.ToUserDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var UserModel = await _context.Users.FirstOrDefaultAsync(t => t.ID == id);
            if(UserModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(UserModel);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}