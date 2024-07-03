var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://34.45.208.167")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Agregar servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

// Middleware de CORS
app.UseCors("AllowSpecificOrigin");

// Otro middleware y configuraciones
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
