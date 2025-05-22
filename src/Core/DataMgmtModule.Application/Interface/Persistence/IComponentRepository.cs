using DataMgmtModule.Application.Dtos.ComponentDto;
//using DataMgmtModule.Application.Features.Components.Dtos;

namespace DataMgmtModule.Application.Interfaces.Repositories;

public interface IComponentRepository
{
    Task<List<ComponentDto>> GetAllAsync(CancellationToken cancellationToken);
}
