using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Commands.Output
{
    public class CalculateCdbCommandResult
    {
        public double FinalValue { get; set; }
        public double Tax { get; set; }
    }
}
