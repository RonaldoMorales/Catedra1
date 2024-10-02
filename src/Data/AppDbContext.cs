using System;
using Catedra1.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1.src.Data;



    public class AppDbContext(DbContextOptions dbContextOptions) :  DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
    }

