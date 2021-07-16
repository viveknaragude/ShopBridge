using ShopBridge.Dal.DbContexts;
using System.Threading.Tasks;

namespace ShopBridge.Dal.Repository
{
    public class Repository
    {
        private readonly ShopBridgeDbContext _dbContext;

        public Repository(ShopBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
