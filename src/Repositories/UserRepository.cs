using System;
using Catedra1.src.Data;
using Catedra1.src.Interfaces;

namespace Catedra1.src.Repositories;

public class UserRepository : IUserRepository
{
    public readonly AppDbContext _context;  
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

}
