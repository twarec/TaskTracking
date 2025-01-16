using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracking.Application.Services;
using TaskTracking.Application.Validation;
using TaskTracking.Domain.Entity;
using TaskTracking.Domain.Interfaces;
using TaskTracking.Domain.Repositorys;

namespace TaskTracking.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(_ =>
        {
            _.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);

            _.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ServiceExtensions).Assembly);

        services.AddDbContext<DbContext, DatabaseContext>(_ =>
        {
            _.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });

        services.AddAutoMapper(typeof(AppMappingProfile));

        services.AddTransient<IRepository<UserEntity>, BaseRepository<UserEntity>>();
        services.AddTransient<IRepository<TaskEntity>, BaseRepository<TaskEntity>>();
        services.AddTransient<IRepository<TaskCommentEntity>, BaseRepository<TaskCommentEntity>>();
        services.AddTransient<IRepository<TaskUserEntity>, BaseRepository<TaskUserEntity>>();

        return services;
    }
}
