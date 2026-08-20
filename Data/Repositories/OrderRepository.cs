using CheersMandu.Data.Interfaces;
using CheersMandu.Models;

namespace CheersMandu.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            // Add the order
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();   // This generates the real OrderId

            // Now create the order details
            foreach (var item in _shoppingCart.GetShoppingCartItems())
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,               // real ID now
                    DrinkId = item.Drink.DrinkId,
                    Amount = item.Amount,
                    Price = item.Drink.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}