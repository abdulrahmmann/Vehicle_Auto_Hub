global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using VehicleAutoHub.Domain.DDD.Entity;
global using VehicleAutoHub.Domain.Entities;

global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using VehicleAutoHub.Domain.IdentityEntities;
global using DriveType = VehicleAutoHub.Domain.Entities.DriveType;

global using System.Reflection;
global using Microsoft.EntityFrameworkCore.Design;

global using Microsoft.EntityFrameworkCore.Diagnostics;
global using MediatR;
global using VehicleAutoHub.Domain.DDD.Aggregate;

global using VehicleAutoHub.Infrastructure.Context;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using VehicleAutoHub.Infrastructure.Interceptors;
global using VehicleAutoHub.Infrastructure.UOF;

global using VehicleAutoHub.Domain.IRepository;
global using VehicleAutoHub.Infrastructure.Repository;