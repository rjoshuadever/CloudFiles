global using CloudFiles.Data;
global using Microsoft.EntityFrameworkCore;
using CloudFiles.Services;
using Microsoft.Data.Sqlite;



var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration.GetConnectionString("CloudFilesDb") == String.Empty) {
    SqliteConnection conn;
    conn = new SqliteConnection("Data Source=CloudFilesData.db");

    conn.Open();
}
   

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UserFileService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CloudFilesDb"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context  = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
