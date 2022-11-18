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
    public class CdbController : ControllerBase
    {
        private readonly CDBValidator _validator;
        private readonly ICdbService _cdbService;
        public CdbController(CDBValidator validator, ICdbService cdbService)
        {
            _validator = validator;
            _cdbService = cdbService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CalculateCDBCommandResult), StatusCodes.Status200OK)]
        public async Task<ActionResult> CalculateCDB([FromQuery] CalculateCDBCommand cdb)
        {
            ValidationResult result = await _validator.ValidateAsync(cdb);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            var data = _cdbService.CalculateCDB(cdb);

            return new OkObjectResult(data);
        }
    }
}
