using CDB.Domain.Commands.Input;
using CDB.Domain.Commands.Output;
using CDB.Domain.Interfaces;
using CDB.Domain.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CDB.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CDBController : ControllerBase
  {
    private readonly ILogger<CDBController> _logger;
    private CDBValidator _validator;
    private ICDBService _cdbService;
    public CDBController(ILogger<CDBController> logger, CDBValidator validator, ICDBService cdbService)
    {
      _validator = validator;
      _logger = logger;
      _cdbService = cdbService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CalculateCDBCommandResult), (int)StatusCodes.Status200OK)]
    public async Task<ActionResult> CalculateCDB([FromQuery] CalculateCDBCommand cdb)
    {
      ValidationResult result = await _validator.ValidateAsync(cdb);

      if (!result.IsValid)
      {
        return BadRequest(result);
      }

      double finalValue = cdb.InitialValue;
      double TB = 1.08;
      double CDI = 0.009;

      double monthlyIncomeCDB = 0;

      for (int i = 1; i <= cdb.NumberOfMonths; i++)
      {
        monthlyIncomeCDB = finalValue * (1 + (CDI * TB));

        finalValue = monthlyIncomeCDB;
      }

      double tax = _cdbService.GetTaxRate(cdb.NumberOfMonths) * finalValue;

      var data = new CalculateCDBCommandResult { finalValue = Math.Round(finalValue, 2), tax = Math.Round(tax, 2) };

      return new OkObjectResult(data);
    }
  }
}
