using ServiceContrcts;
using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IFinhubService, FinhubService>();
builder.Services.AddHttpClient();
builder.Services.Configure<FinhubApiOptions>(builder.Configuration.GetSection("finhubapi"));
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
