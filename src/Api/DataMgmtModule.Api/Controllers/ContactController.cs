using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Application.Feactures.ContactFeatures.Command.AddContacts;
using DataMgmtModule.Application.Feactures.ContactFeatures.Command.DeleteContactData;
using DataMgmtModule.Application.Feactures.ContactFeatures.Command.UpdateContacts;
using DataMgmtModule.Application.Feactures.ContactFeatures.Query.GetAllContactcsData;
using DataMgmtModule.Application.Feactures.ContactFeatures.Query.GetById;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IContactRepository _contactRepository;
        public ContactController(IMediator mediator, IContactRepository contactRepository)
        {
            _mediator = mediator;
            _contactRepository = contactRepository;
        }
        [HttpPost]
        public async Task<IActionResult>AddContactsAsync(AddContactDTO contact)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var addContacts= await _mediator.Send(new AddContactsCommand(contact,userId));
            return Ok(addContacts);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<IActionResult>>> GetAllContactsAsync()
        {
            var getAllData =await _mediator.Send(new GetAllContactsQuery());
            return Ok(getAllData);
        }

        [HttpGet("GetAllManufacturer")]
        public async Task<ActionResult<IEnumerable<IActionResult>>> GetAllContactsOfManufacturer()
        {
            var getAllData = await _contactRepository.GetAllContactsofmanufacturer();
            return Ok(getAllData);
        }
        [HttpGet("GetAllSupplier")]
        public async Task<ActionResult<IEnumerable<IActionResult>>> GetAllContactsOfSupplier()
        {
            var getAllData = await _contactRepository.GetAllContactsofSupplier();
            return Ok(getAllData);
        }
        [HttpGet("GetAllBoth")]
        //public async Task<ActionResult<IEnumerable<IActionResult>>> GetAllContactsOfManufacturerSupplier()
        //{
        //    var getAllData = await _contactRepository.GetAllContactsofBoth();
        //    return Ok(getAllData);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult>GetContactAsync(int id)
        {
            var getDataById =await _mediator.Send(new GetContactsByIdQuery(id));
            return Ok(getDataById);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateContactAsync(int id,AddContactDTO addContactDTO)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var updateData=await _mediator.Send(new UpdateContactQuery(id, addContactDTO,userId));
            return Ok(updateData);
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteContactAsync(int id)
        {
            var deleteData=await _mediator.Send(new DeleteContactQuery(id));
            return Ok(deleteData);
        }

    }
}
