using System.Data;

namespace CheersMandu.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
