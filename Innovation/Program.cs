using Innovation;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using Services;
using Services.IServices;
using Services.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

builder.Services.AddMvc()
    .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(JsonStringLocalizerFactory));
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ar")    
    };

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});



ServicesConfigs.LoadServicesConfigration(builder.Services, builder.Configuration);
builder.Services.AddScoped<IHeaderServ, HeaderServ>();
builder.Services.AddScoped<IAboutServ, AboutServ>();
builder.Services.AddScoped<IContactServ, ContactServ>();
builder.Services.AddScoped<IMyServiceServ, MyServiceServ>();
builder.Services.AddScoped<IWorkServ, WorkServ>();
builder.Services.AddScoped<ITeamServ, TeamServ>();
builder.Services.AddScoped<IUserServ, UserServ>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var supportedCultures = new[] { "en", "ar" };
var localizationOptions = new RequestLocalizationOptions()
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);



app.UseStaticFiles();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
name: "default",
pattern: "{area=Client}/{controller=Home}/{action=Index}");

    app.MapControllerRoute(
name: "default",
pattern: "{area=Admin}/{controller=UserAdmin}/{action=Login}/{id?}");

});


app.Run();
