using Entities;

namespace DataAccess.Abstract
{
    public interface ILastTranactionRepository
    {
        Task<LastTransaction> Add(LastTransaction lastTransaction);
        Task<List<LastTransaction>> GetList();
    }
}
