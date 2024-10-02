using System;
using Bogus;
using Catedra1.src.Models;
namespace Catedra1.src.Data;


public class DataSeeder
{


    public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

    
                if(!context.Users.Any())
                {
                    var userFaker = new Faker<User>()
            .RuleFor(u => u.Rut, f => f.Random.Number(1000000, 25000000).ToString())
            .RuleFor(u => u.Nombre, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.Genero, f => f.PickRandom("masculino", "femenino", "otro", "prefiero no decirlo"))
            .RuleFor(u => u.FechaNacimiento, f => f.Person.DateOfBirth);

        var users = userFaker.Generate(10);

        context.Users.AddRange(users);
        context.SaveChanges();
                }

                context.SaveChanges();


            }
            }

    
}
