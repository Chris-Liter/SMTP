var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://34.45.208.167") // Reemplaza con la IP o dominio de tu aplicación Angular
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Middleware de CORS
app.UseCors("AllowSpecificOrigin");

// Otro middleware y configuraciones
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
