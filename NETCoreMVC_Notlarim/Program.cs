using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NETCoreMVC_Notlarim.AutoMappers;
using NETCoreMVC_Notlarim.Constraints;
using NETCoreMVC_Notlarim.Extensions;
using NETCoreMVC_Notlarim.Handlers;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Services;
using NETCoreMVC_Notlarim.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("custom", typeof(CustomConstraint)));
builder.Services.Configure<MailInfo>(builder.Configuration.GetSection("MailInfo"));

//DEP.INJ VE IOC

//builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); //defult olarak singleton

//builder.Services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog(), ServiceLifetime.Transient));

//builder.Services.AddSingleton<ConsoleLog>();
// CTOR PARAMETRELI ISE
//builder.Services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5));

// INTERFACEDEN SONRA SU SEKILDE ISLEM YAPARIZ
builder.Services.AddScoped<ILog>(p => new ConsoleLog(5));
builder.Services.AddSingleton<ILog, TextLog>(); // ctor default olmasi lazim
builder.Services.AddSingleton<ILog, ConsoleLog>(p => new ConsoleLog(5));

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

    //CUSTOM ROUTE HANDLER;

    //endpoints.Map("example-route", async c =>
    //{
    //    // https://localhost:5001/example-route endpointine gelen herhangi bir istek controllerden ziyade
    //    // direkt olarak buradaki fonksiyon tarafindan karsilanacaktir
    //});

    endpoints.Map("example-route", new ExampleHandler().Handler()); // bu fonksiyon tarafindan karsilandi
    //endpoints.Map("image/{fileName}", new ImageHandler().Handler());


    //AREA ROUTE;

    endpoints.MapControllerRoute(
        name: "areaDefault",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        ); //AREALARIN ESLESTIRILMESI ICIN :exist constrainti uygulanir

    //AREAYA AIT OZEL ROTA BELIRLEMEMIZE YARAR
    endpoints.MapAreaControllerRoute(
        name: "yonetim",
        areaName: "yonetim_paneli",
        pattern: "admin/{controller=Home}/{action=Index}"
        );

    endpoints.MapAreaControllerRoute(
        name: "fatura",
        areaName: "fatura_yonetimi",
        pattern: "fatura/{controller=Home}/{action=Index}"
        );
});
app.Run();


//  MIDDLEWARES ; REQUESTTEN RESPONSE KADAR OLAN ARADA OLUSAN ISLEMLERE DENILEBILIR
//               MIDDLEWARELER SARMAL BIR SEKILDE TETIKLENIR, Use ile baslar, siralama onemlidir

//  HAZIR MIDDLEWARES;

//  RUN METHODU ; KENDISINDEN SONRA GELEN MWYI TETIKLEMEZ DOLAYISIYLA KENDISINDEN SONRAKI MWYI TETIKLEMEYECEGI ICIN AKIS KESILIR

app.Run(async context => 
{
    Console.WriteLine("run mw");
});

//  Use METHODU ; SADE MWDIR. KENDISINDEN SONRAKI MWYI CAGIRIR

app.Use(async (context, next) =>
{
    Console.WriteLine("START USE MW");
    await next.Invoke(); //bir sonraki mw cagirilir
    Console.WriteLine("STOP USE MW");
});
app.Run(async context =>
{
    Console.WriteLine("START RUN MW");
});

//  Map METHODU ; PATHE GORE ISLEM YAPAR

app.Map("/home", builder =>
{
    builder.Run(async c => await c.Response.WriteAsync("RUN MIDDLEWAREI TETIKLENDI"));
});

//  MapWhen METHODU ; GELEN REQUESTIN HERHANGI BIR OZELIGINE GORE ISLEM YAPAR

app.MapWhen(c => c.Request.Method == "GET", builder =>
{
    builder.Use(async (context, task) =>
    {
        Console.WriteLine("START USE MW");
        await task.Invoke();
        Console.WriteLine("STOP USE MW");
    });
});

//CUSTOM MIDDLEWARE

app.UseHello();


