using Microsoft.EntityFrameworkCore;
using EAPPractice2.Models;
using EAPPractice2.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseInMemoryDatabase("List"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/employee", async (EmployeeDbContext db) =>
    await db.employees.ToListAsync());

app.MapGet("/employee/{id}", async (int id, EmployeeDbContext db) =>
    await db.employees.FindAsync(id)
        is Employee employees
            ? Results.Ok(employees)
            : Results.NotFound());

app.MapPost("/employee", async (Employee todo, EmployeeDbContext db) =>
{
    db.employees.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/employee/{todo.Id}", todo);
});

app.MapPut("/employee/{id}", async (int id, Employee inputTodo, EmployeeDbContext db) =>
{
    var todo = await db.employees.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/employee/{id}", async (int id, EmployeeDbContext db) =>
{
    if (await db.employees.FindAsync(id) is Employee todo)
    {
        db.employees.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

app.Run();