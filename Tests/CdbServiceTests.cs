using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using CDB.Domain.Service;
using System;
using Xunit;

namespace Tests
{
    public class CdbServiceTests
    {
        private readonly CdbService cdbService;

        public CdbServiceTests()
        {
            cdbService = new CdbService();
        }

        [Fact]
        public void InvalidInitialValueTest()
        {
            var cdbCommand = new CalculateCdbCommand();

            cdbCommand.InitialValue = 0;

            var exception = Assert.Throws<Exception>(() => cdbService.CalculateCDB(cdbCommand));

            Assert.Equal("Valor deve ser maior que zero.",exception.Message);
        }

        [Fact]
        public void InvalidNumberOfMonthsTest()
        {
            var cdbCommand = new CalculateCdbCommand();

            cdbCommand.InitialValue = 10;
            cdbCommand.NumberOfMonths = 0;

            var exception = Assert.Throws<Exception>(() => cdbService.CalculateCDB(cdbCommand));

            Assert.Equal("Quantidade de meses deve ser maior que zero.", exception.Message);
        }
    }
}