using CheersMandu.Data.interfaces;
using CheersMandu.Models;
using Dapper;

namespace CheersMandu.Data.Repositories.Dapper
{
    public class DapperCategoryRepository : ICategoryRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DapperCategoryRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                using var connection = _connectionFactory.CreateConnection();
                var sql = "SELECT * FROM Categories";
                return connection.Query<Category>(sql);
            }
        }
    }
}
