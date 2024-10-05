using System;
using Bogus;
using Catedra1.src.Models;
namespace Catedra1.src.Data;


public class DataSeeder
{


    public static void Initialize(AppDbContext context)
        {
            if(!context.Users.Any())
            {

                context.Users.AddRange(new User
            {
                Rut = "12345678-9",
                Nombre = "Lionel Messi",
                Email = "lionel.messi@psg.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1987, 6, 24)
            },

            new User
            {
                Rut = "23456789-0",
                Nombre = "Cristiano Ronaldo",
                Email = "cristiano.ronaldo@alnassr.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1985, 2, 5)
            },

            new User
            {
                Rut = "34567890-1",
                Nombre = "Neymar Junior",
                Email = "neymar.junior@alhilal.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1992, 2, 5)
            },

            new User
            {
                Rut = "45678901-2",
                Nombre = "Kylian Mbappé",
                Email = "kylian.mbappe@psg.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1998, 12, 20)
            },

            new User
            {
                Rut = "56789012-3",
                Nombre = "Robert Lewandowski",
                Email = "robert.lewandowski@barcelona.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1988, 8, 21)
            },

            new User
            {
                Rut = "67890123-4",
                Nombre = "Kevin De Bruyne",
                Email = "kevin.debruyne@mancity.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1991, 6, 28)
            },

            new User
            {
                Rut = "78901234-5",
                Nombre = "Mohamed Salah",
                Email = "mohamed.salah@liverpool.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1992, 6, 15)
            },

            new User
            {
                Rut = "89012345-6",
                Nombre = "Sergio Ramos",
                Email = "sergio.ramos@sevilla.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1986, 3, 30)
            },

            new User
            {
                Rut = "90123456-7",
                Nombre = "Virgil van Dijk",
                Email = "virgil.vandijk@liverpool.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1991, 7, 8)
            },

            new User
            {
                Rut = "01234567-8",
                Nombre = "Luka Modric",
                Email = "luka.modric@realmadrid.com",
                Genero = "masculino",
                FechaNacimiento = new DateOnly(1985, 9, 9)
            }

                );
                context.SaveChanges();
                   
            }

        }

}
        