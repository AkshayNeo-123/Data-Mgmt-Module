using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Application.Dtos.Dosage;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using DataMgmtModule.Application.Dtos.RecipeComponentDtos;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.InjectionMoldingInjectionMolding.InjectionMolding;

namespace DataMgmtModule.Application.MapperProfiles
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Projects, GetAllProjectsDto>();
            CreateMap<Projects, AddProjectDto>().ReverseMap();
            CreateMap<Projects, UpdateProjectDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Additive, DisplayAdditive>().ReverseMap();
            CreateMap<MainPolymer, DisplayMainPolymer>().ReverseMap();



            CreateMap<Recipe, AddRecipe>().ReverseMap();
            CreateMap<RecipeComponent, AddRecipeComponentDto>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeDto>().ReverseMap();
            CreateMap<Recipe, GetAllRecipeDtos>().ReverseMap();

            CreateMap<Materials, GetAllMaterialsDto>().ReverseMap();
            CreateMap<Materials, AddMaterialsDto>().ReverseMap();
            CreateMap<Materials, UpdateMaterialsDto>().ReverseMap();

            CreateMap<Roles, AddRole>().ReverseMap();

            CreateMap<CompoundingDatum, CompoundingDataDTO>().ReverseMap();
            CreateMap<CompoundingComponent, CompoundingComponentsDTO>().ReverseMap();
            CreateMap<Dosage, DosageDTO>().ReverseMap();

            CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
            CreateMap<RolePermissionDto, RolePermission>().ReverseMap();

            CreateMap<InjectionMolding, InjectionMoldingDto>().ReverseMap();
            CreateMap<InjectionMolding, UpdateInjectionMoldingDto>().ReverseMap();
            CreateMap<InjectionMolding, AddInjectionMoldingDto>().ReverseMap();

            CreateMap<Contact, AddContactDTO>().ReverseMap();

        }
    }
}
