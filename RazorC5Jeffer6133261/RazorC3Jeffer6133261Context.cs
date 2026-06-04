using Microsoft.EntityFrameworkCore;

public class RazorC3Jeffer6133261Context(DbContextOptions<RazorC3Jeffer6133261Context> options) : DbContext(options)
{
    public DbSet<RazorC3Jeffer6133261.Models.Empleado> Empleado { get; set; } = default!;
    public DbSet<RazorC3Jeffer6133261.Models.Cliente> Cliente { get; set; } = default!;
    public DbSet<RazorC3Jeffer6133261.Models.Oficina> Oficina { get; set; } = default!;
    public DbSet<RazorC3Jeffer6133261.Models.EmpleadoContable> EmpleadoContable { get; set; } = default!;
    public DbSet<RazorC3Jeffer6133261.Models.EmpleadoDeveloper> EmpleadoDeveloper { get; set; } = default!;
}
