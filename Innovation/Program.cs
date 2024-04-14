using Services;
using Services.IServices;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseStaticFiles();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    app.MapControllerRoute(
    name: "default",
    pattern: "{area=Client}/{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=UserAdmin}/{action=Login}/{id?}");

});


app.Run();
