using Microsoft.AspNetCore.Mvc;
using Persons.Api.Dtos;
using Persons.Api.Entity;
using Persons.Api.Services.Abstract;

namespace Persons.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _service;

        public ContactInformationController(IContactInformationService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> GetContactInfo(ContactInformationCreateDto data)
        {
            await _service.AddContact(data);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetContactInfo()
        {
            var result = await _service.GetContact();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteContactInfo(Guid id)
        {
            await _service.DeleteContact(id);
            return Ok();
        }
    }
}
