using DataMgmtModule.InjectionMoldingInjectionMolding.InjectionMolding;

//using DataMgmtModule.Application.Features.InjectionMoldings.DTOs;
using MediatR;

public class CreateInjectionMoldingCommand : IRequest<int>
{
    public AddInjectionMoldingDto InjectionMoldingDto { get; set; }

    public CreateInjectionMoldingCommand(AddInjectionMoldingDto dto)
    {
        InjectionMoldingDto = dto;
    }
}
