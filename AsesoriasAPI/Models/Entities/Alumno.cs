using System;
using System.Collections.Generic;

namespace AsesoriasAPI.Models.Entities;

public partial class Alumno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public virtual ICollection<Asesoria> Asesoria { get; set; } = new List<Asesoria>();

    public virtual ICollection<Inscripcion> Inscripcion { get; set; } = new List<Inscripcion>();
}
