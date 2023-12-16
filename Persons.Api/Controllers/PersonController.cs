using Microsoft.AspNetCore.Mvc;
using Persons.Api.Dtos;
using Persons.Api.Services.Abstract;
using Persons.Api.Services.Concrete;

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

        [HttpGet("GetPersonWithContactInfo")]
        public async Task<ActionResult> GetPersonWithContactInfo()
        {
            var result = await _personService.GetPersonWithContactInfo();
            return Ok(result);
        }

        [HttpDelete("DeletePerson")]
        public async Task<ActionResult> DeletePerson(Guid personId)
        {
            await _personService.DeletePerson(personId);
            return Ok();
        }
    }
}
