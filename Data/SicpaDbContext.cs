using Microsoft.EntityFrameworkCore;
using SICPA.Api.Models;

namespace SICPA.Api.Data
{
    public class SicpaDbContext : DbContext
    {
        public SicpaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Enterprise> Enterprises => Set<Enterprise>();
        public DbSet<DepartmentEmployee> DepartmentEmployees => Set<DepartmentEmployee>();

        // dotnet tool install --global dotnet-ef Se asegura de tener disponibles todos los comandos de EF
        // dotnet ef migrations add firstmigration --project SICPA.Api.csproj Crear migraciones Code first
        // dotnet ef database update firstmigration --project SICPA.Api.csproj Crear base de datos
    }
}
