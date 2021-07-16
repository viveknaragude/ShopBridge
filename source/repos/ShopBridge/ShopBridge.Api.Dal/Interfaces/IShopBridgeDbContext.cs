using Microsoft.EntityFrameworkCore;
using ShopBridge.Dal.Entities;
using System;
using System.Threading.Tasks;

namespace ShopBridge.Dal.Interfaces
{
    public interface IShopBridgeDbContext:IDisposable
    {
        public DbSet<Item> Items { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
