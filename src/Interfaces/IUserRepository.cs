using System;
using Catedra1.src.Models;

namespace Catedra1.src.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(); // GET
    Task<User> GetUserAsync(string rut); // GET
    Task<User> CreateUserAsync(User user); // POST
    Task<User> UpdateUserAsync(User user); // PUT 
    Task<User> DeleteUserAsync(string rut); // DELETE
}
