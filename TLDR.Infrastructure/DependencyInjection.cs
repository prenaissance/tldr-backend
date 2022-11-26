using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TLDR.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using TLDR.Application.Authentication.Services;
using TLDR.Domain.Entities.Common.Abstractions;
using TLDR.Infrastructure.Persistance.Repositories;
using TLDR.Domain.Entities.Authentication;
using TLDR.Domain.Entities.QnA.Repositories;
using TLDR.Domain.Entities.Activity.Repositories;

namespace TLDR.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TldrDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(TldrDbContext).Assembly.FullName)));

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddTransient<IRepository<User>, CommonRepository<User>>();
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        services.AddTransient<IAnswerRepository, AnswerRepository>();
        services.AddTransient<IActivityRepository, ActivityRepository>();

        return services;
    }
}