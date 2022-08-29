using Microsoft.EntityFrameworkCore;
using StormerMobileAPI.Models;
using System;

namespace StormerMobileAPI.Context;
public class AccountContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    #region Configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseCosmos(
            accountEndpoint: "https://telecom-project-db.documents.azure.com:443/",
            accountKey: "wRvBT0T05loywHfw4rBJJbhfsSRexp4bNaAc02RDpuQTGMMFOX08DCSRtTilRM93Q7m5WEjJiWHwifxWPl0ATg==",
            databaseName: "telecom-database");
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region DefaultContainer
        modelBuilder.Entity<Account>()
            .ToContainer("accounts");
        #endregion

        #region StringConverterForPartitionKey
        modelBuilder.Entity<Account>()
            .Property(a => a.Id)
            .HasConversion(
                v => v.ToString(),
                v => Int32.Parse(v)
            );
        #endregion

        #region PartitionKey
        modelBuilder.Entity<Account>()
            .HasPartitionKey(a => a.Id);
        #endregion




    }


}
