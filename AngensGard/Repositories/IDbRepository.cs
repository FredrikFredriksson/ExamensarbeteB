using AngensGard.Models.Pocos;

namespace AngensGard.Repositories
{
    public interface IDbRepository
    {
        Order GetOrderById(int id);
    }
}