using System.Linq;
using DataAccess.DataContext;
using NUnit.Framework;

namespace Tester.DataAccess.Repositories.IntegrationTests
{
    [TestFixture]
    public class RepositoryFixture
    {
        /// <summary>
        ///     This code will be executed automatically after each test. We need to clean the database because the tests should be
        ///     independent.
        /// </summary>
        [TearDown]
        public void CleanDatabase()
        {
            using (var context = new CodingExerciseContext())
            {
                var tableNames = context.Database
                    .SqlQuery<string>(
                        "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%'")
                    .ToList();

                foreach (var tableName in tableNames)
                {
                    context.Database.ExecuteSqlCommand($"DELETE FROM {tableName}");
                }

                context.SaveChanges();
            }
        }
    }
}