using MediatRAndCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRAndCQRS.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
}
