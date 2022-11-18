using CDB.Domain.Commands.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Validators
{
    public class CdbValidator : AbstractValidator<CalculateCdbCommand>
    {
        public CdbValidator()
        {
            RuleFor(x => x.InitialValue)
                .NotEmpty().WithMessage("Informe o valor inicial.")
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero.");


            RuleFor(x => x.NumberOfMonths)
                .NotEmpty().WithMessage("Informe a quantidade de meses que a aplicação deve render")
                .GreaterThan(0).WithMessage("Quantidade de meses deve ser maior que zero.");

        }
    }
}
