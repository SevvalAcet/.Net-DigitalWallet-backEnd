using Entities;

namespace Business.Abstarct
{
    public interface ILastTransactionService
    {
        Task<LastTransaction> Add(LastTransaction lastTransaction);
        Task<List<LastTransaction>> GetList();
    }
}
