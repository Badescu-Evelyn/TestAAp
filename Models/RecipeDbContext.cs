using Azure;
using foodrecipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using foodrecipe.DataModels;

public class RecipeDbContext : IdentityDbContext<User>
{
    public RecipeDbContext()
    {

    }

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Name=ConnectionStrings:RecipeDb");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId);

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId);

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Instructions)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId);

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Reviews)
            .WithOne(rv => rv.Recipe)
            .HasForeignKey(rv => rv.RecipeId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Reviews)
            .WithOne(rv => rv.User)
            .HasForeignKey(rv => rv.UserId);
    }

public DbSet<foodrecipe.Models.CategoryViewModel> CategoryViewModel { get; set; } = default!;
}
