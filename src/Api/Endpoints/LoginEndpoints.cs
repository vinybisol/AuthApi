using Api.InputModel;
using Api.ViewModel;
using Domain.Models;
using FluentValidation;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints;

public static class LoginEndpoints
{
    public static RouteGroupBuilder Map(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/auth");

        api.MapPost("login", Login);
        api.MapPost("register", RegisterAsync);
        return api;
    }

    private static async Task<IResult> Login(LoginInputModel loginInput, MongoDbContext db)
    {
        var existingLogin = await db.Logins.FirstOrDefaultAsync(x => x.Email == loginInput.Email && x.Password == loginInput.Password);
        if (existingLogin is null)
            return TypedResults.NotFound();
        return TypedResults.Ok(new TokenViewModel("sou um token quero trabalhar"));
    }

    private static async Task<Results<BadRequest<object>, Created>> RegisterAsync(
        IValidator<RegisterLoginInputModel> _validator, RegisterLoginInputModel loginInput, MongoDbContext db)
    {
        var result = _validator.Validate(loginInput);

        if (!result.IsValid)
            return TypedResults.BadRequest<object>(new { error = result.ToString(" ") });

        var loginModel = new LoginModel(loginInput.Email, loginInput.Password);

        db.Logins.Add(loginModel);
        await db.SaveChangesAsync();
        return TypedResults.Created();
    }
}
