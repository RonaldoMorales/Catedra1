using System;
using Catedra1.src.Models;
using Catedra1.src.Dtos;

namespace Catedra1.src.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetUsuarios(); // GET A TODOS LOS USERS
    Task<User> CrearUsuario(UserDto user); // POST CREA UN NUEVO USUARIO
    Task<User> UpdateUser(int Id, UserDto user); // PUT, ACTUALIZA A LOS USUARIOS MEDIANTE ID
    Task DeleteUser(int Id); // DELETE, ELIMINA A UN USUARIO POR ID

    Task<bool> UserExists(string rut); // VERIFICA SI EXISTE UN USUARIO por RUT

    Task<bool> UserExistsId(int Id); // VERIFICA SI EXISTE UN USUARIO por ID

}
