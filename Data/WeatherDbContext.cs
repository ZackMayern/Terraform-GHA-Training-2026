using Docker_Training_2026.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker_Training_2026.Data;

public class WeatherDbContext(DbContextOptions<WeatherDbContext> options) : DbContext(options)
{
    public DbSet<WeatherLocation> WeatherLocations => Set<WeatherLocation>();

    public DbSet<WeatherForecast> Forecasts => Set<WeatherForecast>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherLocation>(entity =>
        {
            entity.HasKey(location => location.Id);
            entity.Property(location => location.LookupKey).HasMaxLength(128);
            entity.Property(location => location.City).HasMaxLength(128);
            entity.Property(location => location.Wind).HasMaxLength(64);
            entity.Property(location => location.Condition).HasMaxLength(128);
            entity.Property(location => location.Icon).HasMaxLength(32);
            entity.HasIndex(location => location.LookupKey).IsUnique();
        });

        modelBuilder.Entity<WeatherForecast>(entity =>
        {
            entity.HasKey(forecast => forecast.Id);
            entity.Property(forecast => forecast.Day).HasMaxLength(16);
            entity.Property(forecast => forecast.Icon).HasMaxLength(32);
            entity.HasOne(forecast => forecast.WeatherLocation)
                .WithMany(location => location.ForecastDays)
                .HasForeignKey(forecast => forecast.WeatherLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}