using Microsoft.EntityFrameworkCore;
using todolist.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando https no meu backendtambem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

//Setando o sqlite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Adicionando https no meu backendtambem
app.UseCors("AllowLocalhost4200");


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
