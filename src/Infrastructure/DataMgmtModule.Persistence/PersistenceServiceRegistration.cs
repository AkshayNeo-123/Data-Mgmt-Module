﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Persistence.Repository;

namespace DataMgmtModule.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
          services.AddDbContext<PersistenceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));
            services.AddScoped<IProjects,ProjectsRepository>();
            services.AddScoped<IRecipe,RecipeRepository>();
            services.AddScoped<IRecipeComponent,RecipeComponentRepository>();
            services.AddScoped<IMaterialsRepository, MaterialsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<ICompoundingData, CompoundingDataRepository>();
            services.AddScoped<ICompoundingComponentsRepository, CompoundingComponentsRepository>();
            services.AddScoped<IDosageRepository, DosageRepository>();
            services.AddScoped<IInjectionMoldingRepository, InjectionMoldingRepository>();
            services.AddScoped<IAuth, AuthRepository>();

            return services;
        }
    }
}
