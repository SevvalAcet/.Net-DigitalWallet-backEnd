using Business.Abstarct;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class LastTransactionManager : ILastTransactionService
    {
        private readonly ILastTranactionRepository lastTranactionRepository;

        public LastTransactionManager(ILastTranactionRepository lastTranactionRepository)
        {
            this.lastTranactionRepository = lastTranactionRepository;
        }

        public Task<LastTransaction> Add(LastTransaction lastTransaction)
        {
            var result = this.lastTranactionRepository.Add(lastTransaction);
            return result;
        }

        public Task<List<LastTransaction>> GetList()
        {
            return this.lastTranactionRepository.GetList();
        }
    }
}
