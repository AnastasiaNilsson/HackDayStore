using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HackDayStoreDbKey") ?? throw new InvalidOperationException("Connection string 'StoreContext' not found.")));

builder.Services.AddCors(options => 
    options.AddPolicy(name: "AllowEverything", builder => 
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
    )
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowEverything");
app.UseAuthorization();

app.MapControllers();

app.Run();
