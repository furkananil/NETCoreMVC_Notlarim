using FluentValidation.AspNetCore;
using NETCoreMVC_Notlarim.Constraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("custom", typeof(CustomConstraint)));

builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapGet("/", () => "Merhaba dünya...");
app.UseEndpoints(endpoints =>
{
    //ROUTELER OZELDEN GENELE SIRALANMALIDIR

    //CUSTOM ROUTE OLUSTURMA
    endpoints.MapControllerRoute("Default5", "{controller=Home}/{action=Index}/{id?}/{x?}/{y?}");

    //ROUTE CONSTRAINTS (defaultu stringtir)
    endpoints.MapControllerRoute("Default6", "{controller=Home}/{action=Index}/{id:int?}/{x?}/{y:int?}");
    endpoints.MapControllerRoute("Default5", "{controller=Home}/{action=Index}/{id:custom}/{x:alpha:length(12)?}/{y?}"); // x : 12 karakter olmalidir

    endpoints.MapControllerRoute("anasayfa", "anasayfa", new { controller = "Home", action = "Index" });// /anasayfa
    endpoints.MapControllerRoute("Default2", "{action}/{controller}");
    endpoints.MapControllerRoute("Default3", "{action}/furkan/{controller}");
    endpoints.MapControllerRoute("Default4", "{controller=Personel}/{action=Index}");

 
    endpoints.MapControllerRoute("CustomRoute", "{controller=Home}/{action=Index}/{a}/{b}/{id}");
    endpoints.MapDefaultControllerRoute();

    //ATTRIBUTE ROUTING ICIN GEREKLI
    endpoints.MapControllers();
});
app.Run();