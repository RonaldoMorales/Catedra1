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

    public async Task<User> CreateUser(UserDto user)
    {

        i
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

    public async Task<User> DeleteUserAsync(string rut)
    {
        var user = await _context.Users.FindAsync(rut);
        if (user == null)
        {
            return null;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public Task DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserAsync(string rut)
    {
        return await _context.Users.FindAsync(rut);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

}
