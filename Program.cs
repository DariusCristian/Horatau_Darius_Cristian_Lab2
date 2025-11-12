using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Horatau_Darius_Cristian_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Horatau_Darius_Cristian_Lab2.Pages.Books;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => {
    
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AddPageRoute("/Books/Index", "/");
    options.Conventions.AddPageRoute("/Details", "/Books/Details/{id:int}");
});
builder.Services.AddDbContext<Horatau_Darius_Cristian_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Horatau_Darius_Cristian_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Horatau_Darius_Cristian_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Horatau_Darius_Cristian_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Horatau_Darius_Cristian_Lab2Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
