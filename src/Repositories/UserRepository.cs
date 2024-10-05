using System;
using Catedra1.src.Data;
using Catedra1.src.Dtos;
using Catedra1.src.Interfaces;
using Catedra1.src.Models;
using Microsoft.EntityFrameworkCore;


namespace Catedra1.src.Repositories;

public class UserRepository : IUserRepository
{
    public readonly AppDbContext _context;  
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CrearUsuario(UserDto user)
    {

        if(UserExists(user.Rut).Result)
        {
            throw new Exception("El usuario ya existe");
        }
        
        var NuevoUser = new User
            {
                Rut = user.Rut,
                Nombre = user.Nombre,
                Email = user.Email,
                Genero = user.Genero,
                FechaNacimiento = user.FechaNacimiento
            };

        await _context.Users.AddAsync(NuevoUser);
        await _context.SaveChangesAsync();
        return NuevoUser;
    }

     public async Task<bool> UserExists(string rut)
        {
            return await _context.Users.AnyAsync(u => u.Rut == rut);
        }



       public async Task<IEnumerable<UserDto>> GetUsuarios()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => new UserDto
            {
                Rut = u.Rut,
                Nombre = u.Nombre,
                Email = u.Email,
                Genero = u.Genero,
                FechaNacimiento = u.FechaNacimiento
            });
        }

        public async Task<User> UpdateUser(int Id, UserDto user)
        {
            var userToUpdate = await _context.Users.FindAsync(Id);
            if (userToUpdate == null)
            {
                throw new Exception("El usuario no existe");
            }

            userToUpdate.Rut = user.Rut;
            userToUpdate.Nombre = user.Nombre;
            userToUpdate.Email = user.Email;
            userToUpdate.Genero = user.Genero;
            userToUpdate.FechaNacimiento = user.FechaNacimiento;

            await _context.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task DeleteUser(int Id)
        {
            var userToDelete = await _context.Users.FindAsync(Id);
            if (userToDelete == null)
            {
                throw new Exception("El usuario no existe");
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }



}
