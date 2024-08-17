var builder = WebApplication.CreateBuilder(args);
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

app.MapGet("/", () => "Merhaba d�nya...");
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();