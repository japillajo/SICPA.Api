using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SICPA.Api.Data;
using SICPA.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgresSQLConnection");
builder.Services.AddDbContext<SicpaDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API
//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//       new WeatherForecast
//       (
//           DateTime.Now.AddDays(index),
//           Random.Shared.Next(-20, 55),
//           summaries[Random.Shared.Next(summaries.Length)]
//       ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

#region Employee
app.MapPost("/employees/", async (Employee e, SicpaDbContext db) =>
{
    db.Employees.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/employees/{e.Id}", e);
});

app.MapGet("/employees/{id:int}", async (int id, SicpaDbContext db) =>
{
    return await db.Employees.FindAsync(id)
    is Employee e
    ? Results.Ok(e)
    : Results.NotFound();
});

app.MapGet("/employees", async (SicpaDbContext db) => await db.Employees.ToListAsync());

app.MapPut("/employees/{id:int}", async (int id, Employee e, SicpaDbContext db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var employee = await db.Employees.FindAsync(id);

    if (employee == null) return Results.NotFound();

    employee.Name = e.Name;
    employee.Surname = e.Surname;
    employee.Position = e.Position;
    employee.Email = e.Email;
    employee.Age = e.Age;
    employee.Status = e.Status;
    employee.ModifiedDate = new DateTime();
    employee.ModifiedBy = e.ModifiedBy;

    await db.SaveChangesAsync();

    return Results.Ok(employee);
});

app.MapDelete("/employees/{id:int}", async (int id, SicpaDbContext db) =>
{
    var employee = await db.Employees.FindAsync(id);

    if (employee is null) return Results.NotFound();

    db.Employees.Remove(employee);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

#endregion

#region Enterprise
app.MapPost("/enterprises/", async (Enterprise e, SicpaDbContext db) =>
{
    db.Enterprises.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/enterprises/{e.Id}", e);
});

app.MapGet("/enterprises/{id:int}", async (int id, SicpaDbContext db) =>
{
    return await db.Enterprises.FindAsync(id)
    is Enterprise e
    ? Results.Ok(e)
    : Results.NotFound();
});

app.MapGet("/enterprises", async (SicpaDbContext db) => await db.Enterprises.ToListAsync());

app.MapPut("/enterprises/{id:int}", async (int id, Enterprise e, SicpaDbContext db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var enterprise = await db.Enterprises.FindAsync(id);

    if (enterprise == null) return Results.NotFound();

    enterprise.Name = e.Name;
    enterprise.Address = e.Address;
    enterprise.Position = e.Position;
    enterprise.Status = e.Status;
    enterprise.ModifiedDate = new DateTime();
    enterprise.ModifiedBy = e.ModifiedBy;

    await db.SaveChangesAsync();

    return Results.Ok(enterprise);
});

app.MapDelete("/enterprises/{id:int}", async (int id, SicpaDbContext db) =>
{
    var enterprise = await db.Enterprises.FindAsync(id);

    if (enterprise is null) return Results.NotFound();

    db.Enterprises.Remove(enterprise);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

#endregion

#region Department
app.MapPost("/departments/", async (Department e, SicpaDbContext db) =>
{
    db.Departments.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/departments/{e.Id}", e);
});

app.MapGet("/departments/{id:int}", async (int id, SicpaDbContext db) =>
{
    return await db.Departments.FindAsync(id)
    is Department e
    ? Results.Ok(e)
    : Results.NotFound();
});

app.MapGet("/departments", async (SicpaDbContext db) => await db.Departments.ToListAsync());

app.MapPut("/departments/{id:int}", async (int id, Department e, SicpaDbContext db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var department = await db.Departments.FindAsync(id);

    if (department == null) return Results.NotFound();

    department.Name = e.Name;
    department.Description = e.Description;
    department.Phone = e.Phone;
    department.Status = e.Status;
    department.ModifiedDate = new DateTime();
    department.ModifiedBy = e.ModifiedBy;
    department.EnterpriseId = e.EnterpriseId;

    await db.SaveChangesAsync();

    return Results.Ok(department);
});

app.MapDelete("/departments/{id:int}", async (int id, SicpaDbContext db) =>
{
    var department = await db.Departments.FindAsync(id);

    if (department is null) return Results.NotFound();

    db.Departments.Remove(department);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

#endregion

#region DepartmentEmployee
app.MapPost("/departmentemployees/", async (DepartmentEmployee e, SicpaDbContext db) =>
{
    db.DepartmentEmployees.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/departmentemployees/{e.Id}", e);
});

app.MapGet("/departmentemployees/{employeeId:int}", async (int employeeId, SicpaDbContext db) =>
{
    return await db.DepartmentEmployees.FindAsync(employeeId)
    is DepartmentEmployee e
    ? Results.Ok(e)
    : Results.NotFound();
});

//app.MapPut("/departmentemployees/{employeeId:int}", async (int employeeId, DepartmentEmployee e, SicpaDbContext db) =>
//{
//    if (e.EmployeeId != employeeId)
//        return Results.BadRequest();

//    var department = await db.Departments.FindAsync(id);

//    if (department == null) return Results.NotFound();

//    department.Name = e.Name;
//    department.Description = e.Description;
//    department.Phone = e.Phone;
//    department.Status = e.Status;
//    department.ModifiedDate = new DateTime();
//    department.ModifiedBy = e.ModifiedBy;
//    department.EnterpriseId = e.EnterpriseId;

//    await db.SaveChangesAsync();

//    return Results.Ok(department);
//});

#endregion

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}