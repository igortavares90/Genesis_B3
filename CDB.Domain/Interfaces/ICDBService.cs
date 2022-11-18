using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Interfaces
{
    public interface ICdbService
    {
        public CalculateCdbCommandResult CalculateCDB(CalculateCdbCommand cdb);
        public double GetTaxRate(int MonthQuantity);
    }
}
