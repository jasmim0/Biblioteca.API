using Biblioteca.API.Repositories;
using BibliotecaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Habilitando o Cors
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowVueClient",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:8080")
//                  .AllowAnyHeader()
//                  .AllowAnyMethod()
//                  .AllowCredentials();
//        });
//});

// Add services to the container.

builder.Services.AddControllers();

//Realiza a leitura da conexão com o banco
builder.Services.AddSingleton<BibliotecaRepository>(
    provider =>
    new BibliotecaRepository(builder.Configuration
    .GetConnectionString("DefaultConnection")));

//Swagger Parte 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

//Cors
app.UseCors("AllowVueClient");

//Swagger Parte 2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud Pessoa V1");
        c.RoutePrefix = string.Empty;
    });
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
