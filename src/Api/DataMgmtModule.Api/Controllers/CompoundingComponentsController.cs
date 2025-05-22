using DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Query.GetCompoundingComponents;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetDataByIdcompoundingQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundingComponentsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CompoundingComponentsController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpGet]
        public async Task<IActionResult>GetCompoundingComponents(int id)
        {
            return Ok(await _mediator.Send(new GetCompoundingComponentsQuery(id)));
        }




        
    }
}
