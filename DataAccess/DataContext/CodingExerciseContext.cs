using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entities;

namespace DataAccess.DataContext
{
    public class CodingExerciseContext : DbContext
    {
        public CodingExerciseContext()
            : base("CodingExerciseContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodingExerciseContext>());
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}