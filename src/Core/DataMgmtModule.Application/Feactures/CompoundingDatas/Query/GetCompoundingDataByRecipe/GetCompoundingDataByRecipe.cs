
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundingDataByRecipe
{
    public record GetCompoundingDataByRecipe(int Id, DateOnly? searchdate) :IRequest<IEnumerable<CompoundingDatum>>
    {
    }
}
