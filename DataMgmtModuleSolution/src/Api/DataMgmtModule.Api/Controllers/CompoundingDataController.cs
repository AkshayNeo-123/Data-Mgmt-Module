using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Dtos.CommonDtos;
using DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.DeleteCompoundingComponents;
using DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.UpdateCompoundingComponentsData;
using DataMgmtModule.Application.Feactures.CompoundingComponentsDates.Command.AddCompoundingComponents;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Command.AddCompoundingData;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Command.DeleteCompoundingData;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Command.UpdateCompoundingData;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundDataByIdQuery;
using DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundingDataByRecipe;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Command.AddDosages;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Command.DeleteDosage;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Command.UpdateDosageData;
using DataMgmtModule.Application.Feactures.DosagesFeatures.Query.GetDosage;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundingDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompoundingDataController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCompoundingData(CompoundingDataAndComponents compoundingDataDTO)



        {
            if (compoundingDataDTO == null)
            {
                return BadRequest("Invalid Components data.");
            }
            var data = await _mediator.Send(new AddCompoundingCommand(compoundingDataDTO));
            var finalData = await _mediator.Send(new AddCompoundingComponentsCommand(data, compoundingDataDTO));
            var result = await _mediator.Send(new AddDosagesCommand(data, compoundingDataDTO));
            return Ok(new { Message = "Compoundings added successfully!" });
        }



        //[HttpDelete("{id}")]

        //public async Task<IActionResult> DeleteDosageAsync(int id)
        //{

        //    return Ok(await _mediator.Send(new DeleteDosageCommand(id)));
        //}


        [HttpDelete]
        public async Task<IActionResult> deleteCompoundingData(int CompoundingId)
        {
            return Ok(await _mediator.Send(new DeleteCompoundingDataCommand(CompoundingId)));

        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompoundingData(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteCompoundingDataCommand(id)));

        //}

        [HttpGet("get-by-compounding-id/{id}")]
        public async Task<IActionResult>GetCompoundByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetCompoundDataByQuery(id)));
        }

        [HttpPut]

        public async Task<IActionResult>UpdateDataAsync(int CompoundingId, CompoundingDataAndComponents compoundingDataDTO)
        {
            var uData =await _mediator.Send(new UpdateCompoundingCommand(CompoundingId, compoundingDataDTO.CompoundingDataDTO));
            var updateCompoundingComponent = await _mediator.Send(new UpdateCompoundingComponentsCommad(uData,compoundingDataDTO));
            var uDosage = await _mediator.Send(new UpdateDosageCommand(uData, compoundingDataDTO));
            return Ok(uData);
        }



        [HttpGet("get-by-recipe-id/{recipeId}")]
        public async Task<IActionResult>GetCompoundingDataByRecipe(int recipeId)
        {
            var getCompoundingData =await _mediator.Send(new GetCompoundingDataByRecipe(recipeId));
            return Ok(getCompoundingData);
        }


    }
}
