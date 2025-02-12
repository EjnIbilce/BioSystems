using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using BioSystems.Models;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text.Json;

namespace BioSystems.Data {
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string connectionString = LoadConnectionString();

            optionsBuilder.UseNpgsql(connectionString);
        }

        public static string LoadConnectionString() { 
            var asm = Assembly.GetExecutingAssembly();
            var rn = "BioSystems.Resources.Raw.appsettings.json";

            using var stream = asm.GetManifestResourceStream(rn);

            if (stream == null) throw new FileNotFoundException("Nao achou o appsettings");

            using var reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            using var doc = JsonDocument.Parse(json);

            return doc.RootElement.GetProperty("ConnectionStrings").GetProperty("PostgresDB").GetString()!;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users").HasKey(u => u.id);
        }
    }
}
