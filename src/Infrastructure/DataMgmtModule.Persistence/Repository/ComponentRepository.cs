using DataMgmtModule.Application.Dtos.ComponentDto;
//using DataMgmtModule.Application.Features.Components.Dtos;
using DataMgmtModule.Application.Interfaces.Repositories;
//using DataMgmtModule.Infrastructure.Persistence;
using DataMgmtModule.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Infrastructure.Repository;

public class ComponentRepository : IComponentRepository
{
    private readonly PersistenceDbContext _context;

    public ComponentRepository(PersistenceDbContext context)
    {
        _context = context;
    }

    public async Task<List<ComponentDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Components
            .Select(c => new ComponentDto
            {
                Id = c.Id,
                ComponentName = c.ComponentName
            })
            .ToListAsync(cancellationToken);
    }
}
