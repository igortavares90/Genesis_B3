﻿using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Interfaces
{
    public interface ICDBService
    {
        double GetTaxRate(int MonthQuantity);
        public CalculateCDBCommandResult calculateCDB(CalculateCDBCommand cdb);
    }
}
