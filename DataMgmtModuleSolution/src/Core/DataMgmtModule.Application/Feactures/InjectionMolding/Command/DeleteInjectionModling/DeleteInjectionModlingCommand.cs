using MediatR;

namespace DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling
{
    public class DeleteInjectionModlingCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteInjectionModlingCommand(int id)
        {
            Id = id;
        }
    }
}
