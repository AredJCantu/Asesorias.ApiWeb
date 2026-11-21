using System;
using System.Collections.Generic;
using System.Text;

namespace AsesoriasCore.DTOs
{
    public class InscripcionDTO
    {
        public int Id { get; set; }
        public string? Materia { get; set; }
        public string? Tutor { get; set; }
        public int NumeroAlumnos { get; set; }//8 alumnos inscritos
        public int Cupo { get; set; }//10 cupos totales
        public DateOnly? Fecha { get; set; }
        public byte? Hora { get; set; }
        public string? EstadoInscripcion { get; set; }//Pendiente, aceptado, rechazado
    }
    public class AlumnosInscritosDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? EstadoInscripcion { get; set; }
    }
}
