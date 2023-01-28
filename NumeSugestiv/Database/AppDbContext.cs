using Microsoft.EntityFrameworkCore;
using NumeSugestiv.Features.Assignments.Models;

namespace NumeSugestiv.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}
    
    public DbSet<AssignmentModel> Assignments { get; set; }
    
    
}