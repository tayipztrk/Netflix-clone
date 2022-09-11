using netflix.Repository;
using netflix.Service;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddRepositories(Configuration);
builder.Services.AddCustomeServices();

builder.Services.AddSwaggerGen(); // yukarıdaki sekilde static dosyadan alma olayı swagger a xml aciklamalar yapmak icin gerekli idi. Ancak docker ile birlikte kanser oldu.





var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
