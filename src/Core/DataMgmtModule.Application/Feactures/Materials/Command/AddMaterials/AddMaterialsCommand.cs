﻿using DataMgmtModule.Application.Dtos.Materials;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.AddMaterials
{
   public class AddMaterialsCommand : IRequest<AddMaterialsDto>
    {
        public AddMaterialsDto AddDto { get; set; }
        public int? UserId { get; set; }

        public AddMaterialsCommand(AddMaterialsDto addDto, int? userId)
        {
            AddDto = addDto;
            UserId = userId;

        }
    }
}
