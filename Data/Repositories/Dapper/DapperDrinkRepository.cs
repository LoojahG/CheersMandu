using CheersMandu.Data.interfaces;
using CheersMandu.Models;
using Dapper;

namespace CheersMandu.Data.Repositories.Dapper
{
    public class DapperDrinkRepository : IDrinkRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DapperDrinkRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Drink> Drinks
        {
            get
            {
                using var connection = _connectionFactory.CreateConnection();

                const string sql = @"
                    SELECT d.*, c.CategoryId, c.CategoryName, c.Description
                    FROM Drinks d
                    INNER JOIN Categories c ON d.CategoryId = c.CategoryId";

                return connection.Query<Drink, Category, Drink>(
                    sql,(drink, category) => 
                    {
                        drink.Category = category;
                        return drink;
                    },
                    splitOn: "CategoryId");
            }
        }

        public IEnumerable<Drink> PreferredDrinks
        {
            get
            {
                using var connection = _connectionFactory.CreateConnection();

                const string sql = @"
                    SELECT d.*, c.CategoryId, c.CategoryName, c.Description
                    FROM Drinks d
                    INNER JOIN Categories c ON d.CategoryId = c.CategoryId
                    WHERE d.IsPreferredDrink = 1";

                return connection.Query<Drink, Category, Drink>(
                    sql,(drink, category) =>
                    {
                        drink.Category = category;
                        return drink;
                    },
                    splitOn: "CategoryId");
            }
        }

        public Drink GetDrinkById(int drinkId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                SELECT d.*, c.CategoryId, c.CategoryName, c.Description
                FROM Drinks d
                INNER JOIN Categories c ON d.CategoryId = c.CategoryId
                WHERE d.DrinkId = @DrinkId";

            return connection.Query<Drink, Category, Drink>(
                sql,(drink, category) =>{drink.Category = category;
                    return drink;
                },
                new { DrinkId = drinkId },
                splitOn: "CategoryId")
                .FirstOrDefault();
        }
    }
}
