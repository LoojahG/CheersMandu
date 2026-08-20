using CheersMandu.Models;

namespace CheersMandu.Data.interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
