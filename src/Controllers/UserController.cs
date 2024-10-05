using System;
using System.Text;
using Catedra1.src.Dtos;
using Catedra1.src.Interfaces;
using Catedra1.src.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

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

    [HttpGet] //OBTENER TODOS LOS USUARIOS, CON LA OPCION DE APLICAR FILTROS

    public async Task<IActionResult> GetUsuarios([FromQuery] string? sort = null, [FromQuery] string? gender = null){
        var users = await _userRepository.GetUsuarios();

        if(sort != null)
        {       
            if(sort == "asc")
                users = users.OrderBy(u => u.Nombre);
                

            else if(sort == "desc")
                users = users.OrderByDescending(u => u.Nombre);
            else 
                return BadRequest("El parametro sort debe ser 'asc' o 'desc'");
        }

        if(gender!= null){


            var generos =   new List<string> { "masculino", "femenino", "otro", "prefiero no decirlo" };

            if(!generos.Contains(gender))
                return BadRequest("El genero debe ser 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'");
                
            users = users.Where(u => u.Genero == gender);
        }


        return Ok(users);
    }

    [HttpPost] //CREAR UN NUEVO USUARIO

    public async Task<IActionResult> CrearUsuario([FromBody] UserDto user)
    {
        try
        {
            var NuevoUser = await _userRepository.CrearUsuario(user);
            
            return CreatedAtAction(nameof(CrearUsuario), new { id = NuevoUser.Id }, NuevoUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{Id}")] //ELIMINAR UN USUARIO POR ID
    public async Task<IActionResult> DeleteUser(int Id)
    {
        if(await _userRepository.UserExistsId(Id))
        {
            await _userRepository.DeleteUser(Id);
            return Ok("Usuario eliminado");
        }
        else
        {
            return NotFound("Usuario no encontrado");
        }
    }

    [HttpPut("{Id}")] //ACTUALIZAR UN USUARIO POR ID

    public async Task<IActionResult> UpdateUser(int Id, UserDto user)
    {
        if(await _userRepository.UserExistsId(Id))
        {
            try
            {
                var userUpdated = await _userRepository.UpdateUser(Id, user);
                return Ok(userUpdated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        else
        {
            return NotFound("Usuario no encontrado");
        }
    }






    
    




}
