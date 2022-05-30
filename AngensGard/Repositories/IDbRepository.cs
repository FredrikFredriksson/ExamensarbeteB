using AngensGard.Models.Pocos;
using AngensGard.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Repositories
{
    public interface IDbRepository
    {
        List<Order> GetListOfOrders();
        List<Product> GetListOfProducts();
        Order GetOrderById(int id);
        OrderDetail GetOrderDetailsById(int id);
        List<Order> GetOrdersByDelivery(string delivery);
        List<Order> GetOrdersByStatus(string status);
        Product GetProductById(int id);
        void RemoveOrder(int id);
        void SaveOrder(OrderViewModel RegisteredOrder);
        void UpdateOrder(Order order);
        void UpdateStockBalance(Product product);
    }
}