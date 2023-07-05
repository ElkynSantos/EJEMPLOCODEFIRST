using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Databases.Models.Db;

public partial class AbcdataBaseContext : DbContext
{

    public AbcdataBaseContext(DbContextOptions<AbcdataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Automobile> Automobiles { get; set; }

    public virtual DbSet<BranchOffice> BranchOffices { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Automobile>().ToTable("Automobile");
        modelBuilder.Entity<BranchOffice>().ToTable("BranchOffice");
        modelBuilder.Entity<Employee>().ToTable("Employee");
        
    }

}
