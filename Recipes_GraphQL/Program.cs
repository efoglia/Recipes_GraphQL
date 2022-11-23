using Microsoft.EntityFrameworkCore;
using Recipes_GraphQL.Data;
using Recipes_GraphQL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddDbContextFactory<RecipesContext>(p => p.UseSqlServer("Server=localhost;Database=RecipesDB;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<RecipesContext>(
    sp => sp.GetRequiredService<IDbContextFactory<RecipesContext>>()
    .CreateDbContext());

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<Mutation>();

var app = builder.Build();

await RecipesContext.CheckAndSeedDatabaseAsync(
    app.Services.GetRequiredService<IDbContextFactory<RecipesContext>>()
    .CreateDbContext());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
