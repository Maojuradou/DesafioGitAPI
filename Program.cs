var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var estudiantes = new[]
{
    new Estudiante(1, "Carlos Pérez", "3001234567"),
    new Estudiante(2, "María López", "3109876543"),
    new Estudiante(3, "Juan García", "3205551234")
};

app.MapGet("/estudiantes", () =>
{
    return estudiantes;
})
.WithName("GetEstudiantes");

app.Run();

record Estudiante(int Id, string Nombre, string Telefono);