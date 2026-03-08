using RestaurantProject.WebUILayer.Areas.Admin.Models;
using RestaurantProject.WebUILayer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("openai", client => client.BaseAddress = new Uri("https://api.openai.com/v1/"));
builder.Services.Configure<OpenAI>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddSingleton(sp =>
{
    var openAI = new OpenAI();
    sp.GetRequiredService<IConfiguration>().GetSection("OpenAI").Bind(openAI);
    return openAI;
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.MapHub<ChatHub>("/chathub");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();