using AsesoriasCore.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AsesoriasCore.Validators
{
    public abstract class AsesoriasValidatorBase<T>:AbstractValidator<T> where T : CreateEditAsesoriaDTO
    {
        protected AsesoriasValidatorBase()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x=>x.Materia).NotEmpty().WithMessage("Especifique una materia.");
            RuleFor(x => x.Fecha).NotNull().WithMessage("La Fecha no debe estar vacia.")
                .Must(x => x >= DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha debe ser hoy o en el futuro.");
            RuleFor(x => x.Cupo).Must(x => x >= 4).WithMessage("El cupo minimo es de 4 alumnos en adelante");
            RuleFor(x => x.Lugar).NotEmpty().WithMessage("Especifique una lugar para la asesoria.");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("Especifique una Descripcion válida.");
            RuleFor(x=>x.Hora).NotEmpty().WithMessage("especifique la hora").Must(x=>MustHora(x)).WithMessage("La hora debe ir en formato militar");

        }
        bool MustHora(int? hora)
        {
            if (hora is null)
                return false;
            return Regex.IsMatch(hora.ToString(),$"0[0-9]||1[0-9]||2[0-3]");
        }
    }
}
