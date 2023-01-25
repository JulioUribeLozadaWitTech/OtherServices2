using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OtherServices2.Models;
using OtherServices2.Models2;
using OtherServices2.Models3;
using OtherServices2.Utiles;
using System.Text.Json.Serialization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddMicrosoftIdentityUI();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<BillOtherServicesContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OtherServices2conexion")));

builder.Services.AddDbContext<PatientPortalContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PatientPortalconexion")));

builder.Services.AddDbContext<PlantaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Gradoconexion")));

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureB2C"));
builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options => {
    //options.RequireHttpsMetadata = false; 
});
builder.Services.AddRazorPages(options => {
    options.Conventions.AllowAnonymousToPage("/Index");
}).AddMvcOptions(options => { })
       .AddMicrosoftIdentityUI();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to 
    // the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=Tercero}/{action=Index}/{id?}");

app.Run();
