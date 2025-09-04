using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: MyAllowSpecificOrigins,
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//app.Run();
