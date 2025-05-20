using MediatR;

namespace DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling
{
    public class DeleteInjectionModlingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int DeletedBy { get; set; }


        public DeleteInjectionModlingCommand(int id,int deletedBy)
        {
            Id = id;
            DeletedBy = deletedBy;
        }
    }
}
