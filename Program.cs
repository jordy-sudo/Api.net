using webapi.Services;
using proyectoef;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//conexion a base de datos
builder.Services.AddSqlServer<TareasContext>("Data Source = DESKTOP-4B8M8CA\\SQLEXPRESS;Initial Catalog=TareasDb;user id =sa;password=Literaturarusa1");

//inyeccion de mi servicio creado de helloworl
builder.Services.AddScoped<InterfaceHelloWorldService, HelloWorldServices>();// cada que se inyecte la interfaz se crea una isntancia de helloworldService
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.UseAuthorization();
app.MapControllers();

app.Run();
