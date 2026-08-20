using CheersMandu.Models;  

namespace CheersMandu.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}