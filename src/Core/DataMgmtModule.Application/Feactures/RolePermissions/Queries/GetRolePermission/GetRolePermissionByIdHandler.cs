using MediatR;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;

namespace DataMgmtModule.Application.Features.RolePermissions.Queries.GetById
{
    public class GetRolePermissionByIdQuery : IRequest<RolePermissionDto>
    {
        public int Id { get; set; }

        public GetRolePermissionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
