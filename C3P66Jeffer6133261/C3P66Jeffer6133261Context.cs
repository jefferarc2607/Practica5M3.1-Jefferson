using C3P66Jeffer6133261.Models;
using Microsoft.EntityFrameworkCore;

public class C3P66Jeffer6133261Context(DbContextOptions<C3P66Jeffer6133261Context> options) : DbContext(options)
{

    // DbSets para cada tabla
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Oficina> Oficinas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<EmpleadoContable> EmpleadosContables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empleado>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<EmpleadoContable>()
            .HasIndex(e => e.Email)
            .IsUnique();
    }
}
