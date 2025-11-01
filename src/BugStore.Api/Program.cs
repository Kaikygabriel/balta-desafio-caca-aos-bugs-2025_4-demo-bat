using BugStore.Api.Extesions;
using BugStore.Application.Handlers.Products;
using BugStore.Domain.Interfaces;
using BugStore.Infrastructure.Data;
using BugStore.Infrastructure.Repositories;
using MediatorX.Core.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddMediator(typeof(Handler).Assembly);
builder.Services.AddDbContext<AppDbContext>(x=>
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMapProducts();
app.UseMapCustomers();
app.UseMapOrder();

app.Run();
