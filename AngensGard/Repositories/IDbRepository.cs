using AngensGard.Models.Pocos;
using AngensGard.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Repositories
{
    public interface IDbRepository
    {
        Order GetOrderById(int id);
        OrderDetail GetOrderDetailsById(int id);
        Product GetProductById(int id);
        void RemoveOrder(int id);
        void SaveOrder(OrderViewModel RegisteredOrder);
    }
}