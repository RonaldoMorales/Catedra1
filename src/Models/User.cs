using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Catedra1.src.Models;

public class User
{
    //Estructura del unico modelo de la catedra

    public int Id { get; set; }

    [Required]
    public string Rut { get; set; } = string.Empty;

    [Required]
    [StringLength(100,MinimumLength =3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(masculino|femenino|otro|prefiero no decirlo)$", ErrorMessage = "generos permitidos: 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'.")]

    public string Genero { get; set; } = string.Empty;

    [Required]

    public DateOnly FechaNacimiento { get; set; } = new DateOnly();
    
}
