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
    }
}
