using DataMgmtModule.Application.Dtos.Dosage;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Command.AddDosages;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Command.DeleteDosage;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Query.GetDosage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosageController : ControllerBase
    {
        private IMediator _mediator;

        public DosageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDosageAsync(int id)
        {
            return Ok(await _mediator.Send(new GetDosageQuery(id)));

        }

        //[HttpPost]
        //public async Task<IActionResult>AddDosagesAsync(int id,DosageDTO dosageDTO)
        //{
        //    var addData =await _mediator.Send(new AddDosagesCommand(id, dosageDTO));
        //    return Ok(addData);
        //}




    }
}
