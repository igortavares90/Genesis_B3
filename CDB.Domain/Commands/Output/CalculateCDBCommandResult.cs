using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Commands.Output
{
    public class CalculateCDBCommandResult
    {
        public double finalValue { get; set; }
        public double tax { get; set; }
    }
}
