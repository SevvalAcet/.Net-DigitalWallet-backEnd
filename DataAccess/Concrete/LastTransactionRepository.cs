using DataAccess.Abstract;
using Digiwallet.DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class LastTransactionRepository : ILastTranactionRepository
    {
        public async Task<LastTransaction> Add(LastTransaction lastTransaction)
        {
            var dbContext = new DigiwalletDbContext();
            await dbContext.Set<LastTransaction>().AddAsync(lastTransaction);
            dbContext.SaveChanges();
            return lastTransaction;
        }

        public async Task<List<LastTransaction>> GetList()
        {
            var dbContext = new DigiwalletDbContext();
            var result = await dbContext.LastTransactions.ToListAsync();
            return result;
        }
    }
}
