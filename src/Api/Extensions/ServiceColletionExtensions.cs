using Api.InputModel;
using Api.Validators;
using FluentValidation;

namespace Api.Extensions;

public static class ServiceColletionExtensions
{
    public static IServiceCollection AddEndpointValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterLoginInputModel>, RegisterLoginInputModelValidator>();

        return services;
    }
}
