using ProgCentrTestTask.Core.Entities;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ProgCentrTestTask.Core.Context
{
    public class QueriesContext : DbContext
    {
        public QueriesContext():base("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = QueriesDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<QueriesContext>());
            
        }
        public QueriesContext(string connectionString):base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<QueriesContext>());

        }

        public DbSet<Query> Queries { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Query>()
                                        .HasMany(e => e.Users)
                                        .WithMany(e => e.Queries)
                                        .Map(cs =>
                                        {
                                            cs.MapLeftKey("UserRefId");
                                            cs.MapRightKey("QueryRefId");
                                            cs.ToTable("UserQuery");
                                        });
            modelBuilder.Properties<DateTime>()
                                                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
