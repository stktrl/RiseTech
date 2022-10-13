using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseTech.Busines.Abstract;
using RiseTech.Entities.Models;
using System;

namespace RiseTech.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult AddNewContact([FromBody] ContactDto addContactDto)
        {
            var result = _contactService.AddContact(addContactDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteContact([FromRoute] Guid Id)
        {
            var result = _contactService.DeleteContact(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateContact([FromBody] ContactDto contactDto, [FromRoute] Guid Id)
        {
            var result = _contactService.UpdateContact(contactDto, Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }
        [HttpGet]
        public IActionResult GetContacts(int offset = 0, int limit = 10)
        {
            var result = _contactService.GetContacts(offset, limit);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }
        [HttpPost("{Id}/ContactInfos")]
        public IActionResult AddContactInfo(Guid Id,[FromBody] ContactInfoDto contactInfoDto)
        {
            var result = _contactService.AddContactInfo(contactInfoDto, Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }
        }
        [HttpDelete("ContactInfos/{Id}")]
        public IActionResult DeleteContactInfo(Guid Id)
        {
            var result = _contactService.DeleteContactInfo(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(result.Code, result);
            }

        }
    }
}
