using DataMgmtModule.Application.Feactures.MaterialsMaster.Query;
using DataMgmtModule.Application.Feactures.MaterialsMaster.Query.MvrMfrQuery;
using DataMgmtModule.Application.Feactures.MaterialsMaster.Query.StorageLocationQuery;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialMasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("mvrmfr")]
        public async Task<ActionResult<IEnumerable<MvrMfr>>> GetAllMvrMfr()
        {
            var result = await _mediator.Send(new GetAllMvrMfrQuery());
            return Ok(result);
        }

        [HttpGet("storage")]
        public async Task<ActionResult<IEnumerable<StorageLocation>>> GetAllStorage()
        {
            var result = await _mediator.Send(new GetAllStorageQuery());
            return Ok(result);
        }
    }
    }
