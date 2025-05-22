using DataMgmtModule.Application.Dtos.ComponentDto;
//using DataMgmtModule.Application.Features.Components.Dtos;
using DataMgmtModule.Application.Interfaces.Repositories;
using MediatR;

namespace DataMgmtModule.Application.Features.Components.Queries.GetAll;

public class GetAllComponentsQueryHandler : IRequestHandler<GetAllComponentsQuery, List<ComponentDto>>
{
    private readonly IComponentRepository _repository;

    public GetAllComponentsQueryHandler(IComponentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ComponentDto>> Handle(GetAllComponentsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}
