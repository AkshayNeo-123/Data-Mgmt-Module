using DataMgmtModule.Application.Dtos.RecipeComponentTypeDto;
using MediatR;

public record GetAllRecipeComponentTypesQuery : IRequest<List<RecipeComponentTypeDto>>;
