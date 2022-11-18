using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using CDB.Domain.Interfaces;

namespace CDB.Domain.Service
{
    public class CdbService : ICdbService
    {
        public CalculateCdbCommandResult CalculateCDB(CalculateCdbCommand cdb)
        {
            if (cdb.InitialValue == 0)
            {
                throw new Exception("Valor deve ser maior que zero.");
            }

            if (cdb.NumberOfMonths == 0)
            {
                throw new Exception("Quantidade de meses deve ser maior que zero.");
            }

            double FinalValue = cdb.InitialValue;
            double Tb = 1.08;
            double Cdi = 0.009;

            double MonthlyIncomeCDB;

            for (int i = 1; i <= cdb.NumberOfMonths; i++)
            {
                MonthlyIncomeCDB = FinalValue * (1 + (Cdi * Tb));

                FinalValue = MonthlyIncomeCDB;
            }

            double Tax = GetTaxRate(cdb.NumberOfMonths) * FinalValue;

            var Data = new CalculateCdbCommandResult { FinalValue = Math.Round(FinalValue, 2), Tax = Math.Round(Tax, 2) };

            return Data;
        }

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
    }
}
