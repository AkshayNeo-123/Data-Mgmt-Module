using DataMgmtModule.Application.Dtos.ComponentDto;
//using DataMgmtModule.Application.Features.Components.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DataMgmtModule.Application.Features.Components.Queries.GetAll;

public class GetAllComponentsQuery : IRequest<List<ComponentDto>> { }
