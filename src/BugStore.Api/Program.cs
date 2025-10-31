using BugStore.Api.Extesions;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(x=>
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMapProducts();
app.UseMapCustomers();
app.UseMapOrder();

app.Run();
