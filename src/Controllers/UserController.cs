using System;
using System.Text;
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


            if(gender != "masculino" || gender!= "femenino" || gender != "otro" || gender != "prefiero no decirlo")
                return BadRequest("Los generos disponibles son 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'");
                
            users = users.Where(u => u.Genero == gender);
        }


        return Ok(users);
    }

    
    




}
