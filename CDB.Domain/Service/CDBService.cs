using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using CDB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Domain.Service
{
    public class CDBService: ICDBService
    {
        public double GetTaxRate(int MonthQuantity)
        {
            double taxRate = 0;
            switch (MonthQuantity)
            {
                case int n when (n > 0 && n <= 6):
                    taxRate = 0.225;
                    break;
                case int n when (n > 6 && n <= 12):
                    taxRate = 0.20;
                    break;
                case int n when (n > 12 && n <= 24):
                    taxRate = 0.175;
                    break;
                case int n when (n > 24):
                    taxRate = 0.15;
                    break;
            }

            return taxRate;
        }

        public CalculateCDBCommandResult calculateCDB(CalculateCDBCommand cdb)
        {
            double finalValue = cdb.InitialValue;
            double TB = 1.08;
            double CDI = 0.009;

            double monthlyIncomeCDB = 0;

            for (int i = 1; i <= cdb.NumberOfMonths; i++)
            {
                monthlyIncomeCDB = finalValue * (1 + (CDI * TB));

                finalValue = monthlyIncomeCDB;
            }

            double tax = GetTaxRate(cdb.NumberOfMonths) * finalValue;

            var data = new CalculateCDBCommandResult { finalValue = Math.Round(finalValue, 2), tax = Math.Round(tax, 2) };

            return data;
        }
    }
}
