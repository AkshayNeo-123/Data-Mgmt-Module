using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetrecipeAndProject
{
    public record GetRecipeAndProject(string search, decimal? tensileModulusMAX,decimal? tensileModulusMin,
            decimal? charpyImpactMax,decimal? charpyImpactMin,
            decimal? stressAtYieldMax , decimal? stressAtYieldMin) : IRequest<IEnumerable<RecipeProjectDTO>>
    { }
        //public string ProjectNumber { get; set; }

        //public GetRecipeAndProject(string projectNumber)
        //{
        //    ProjectNumber = projectNumber;
        //}
    
}
