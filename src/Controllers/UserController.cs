using System;
using Catedra1.src.Interfaces;
using Catedra1.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catedra1.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository; 

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet] //OBTENER TODOS LOS USUARIOS

    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return Ok(users);
    }

    [HttpPost] //CREAR USUARIO

    public async Task<IActionResult> CreateUserAsync([FromBody] User user)
    {
        var newUser = await _userRepository.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUsersAsync), new {rut = newUser.Rut}, newUser);
    }

    [HttpDelete("{id}")] //ELIMINAR USUARIO

    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")] //ACTUALIZAR USUARIO

    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        await _userRepository.UpdateUserAsync(user);
        return NoContent();
    }

    

    

    

    
    
   



}
