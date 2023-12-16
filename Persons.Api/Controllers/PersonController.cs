using Microsoft.AspNetCore.Mvc;
using Persons.Api.Dtos;
using Persons.Api.Services.Abstract;

namespace Persons.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("AddPerson")]
        public async Task<ActionResult> AddPerson(PersonCreateDto data)
        {
            await _personService.AddPerson(data);
            return Ok();
        }

        [HttpGet("GetPerson")]
        public async Task<ActionResult> GetPerson()
        {
            var result = await _personService.GetPerson();
            return Ok(result);
        }
    }
}
