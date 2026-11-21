using System;
using System.Collections.Generic;

namespace AsesoriasAPI.Models.Entities;

public partial class Inscripcion
{
    public int Id { get; set; }

    public int IdAlumno { get; set; }

    public int IdAsesoria { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Asesoria IdAsesoriaNavigation { get; set; } = null!;
}
