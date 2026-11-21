using System;
using System.Collections.Generic;
using System.Text;

namespace AsesoriasCore.DTOs
{
    public class AsesoriaDTO
    {
        public int Id { get; set; }
        public string? Materia { get; set; }
        public string? Tutor { get; set; }
        public int NumeroAlumnos { get; set; }//8 alumnos inscritos
        public int Cupo { get; set; }//10 cupos totales
        public DateOnly? Fecha { get; set; }
        public byte? Hora { get; set; }
        public string? Estado { get; set; } //Cancelada, pendiente, Completada
    }

    public class DetallesAsesoriaDTO:AsesoriaDTO
    {
        public string? Descripcion { get; set; }
        public string? Lugar { get; set; }
    }
    public class CreateEditAsesoriaDTO
    {
        public string? Materia { get; set; }
        public int IdTutor { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? Hora { get; set; }
        public string? Lugar { get; set; }
        public int Cupo { get; set; }
        public string? Descripcion { get; set; }
    }
    public class DetallesAsesoriaTutorDTO:DetallesAsesoriaDTO
    {
        public IEnumerable<AlumnosInscritosDTO>? ListaAlumnos { get; set; }//Todos los alumnos con inscripciones con estado = pendiente o estado = aceptado
    }

}
