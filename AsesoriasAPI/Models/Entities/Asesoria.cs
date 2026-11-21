using System;
using System.Collections.Generic;

namespace AsesoriasAPI.Models.Entities;

public partial class Asesoria
{
    public int Id { get; set; }

    public int IdTutor { get; set; }

    public string Materia { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int Hora { get; set; }

    public string Lugar { get; set; } = null!;

    public int Cupo { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Alumno IdTutorNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcion { get; set; } = new List<Inscripcion>();
}
