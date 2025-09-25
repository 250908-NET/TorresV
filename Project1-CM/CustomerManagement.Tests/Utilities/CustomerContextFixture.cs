using CustomerManagement.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Tests.Fixtures
{
    // Fixture so DbContext is set up once per test class
    public class CustomerContextFixture : IDisposable
    {
        private readonly SqliteConnection _connection;
        public CustomerContext Context { get; }

        public CustomerContextFixture()
        {
            // Create a real in-memory SQLite connection
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseSqlite(_connection)
                .Options;

            Context = new CustomerContext(options);

            // Ensure schema is created (important for unique index on Email)
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
            _connection.Dispose();
        }
    }
}
