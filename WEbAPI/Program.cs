using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
string connection = @"Server=localhost\SQLEXPRESS;Database=HranitelPROWSR;Trusted_Connection=True;TrustServerCertificate=True";
builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer(connection));
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

//  авторизация
app.MapPost("/login", async (UserLogin loginData, DbContext db) =>
{
   
});
app.UseStaticFiles();
app.Run();
class UserLogin{
    string login { get; set; }
    string password { get; set; }
}