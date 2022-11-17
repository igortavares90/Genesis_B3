using FluentValidation;

namespace CDB.Domain.Commands.Input
{
    public class CalculateCDBCommand
    {
        public double InitialValue { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
