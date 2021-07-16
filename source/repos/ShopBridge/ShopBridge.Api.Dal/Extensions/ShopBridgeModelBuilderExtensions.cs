using Microsoft.EntityFrameworkCore;
using ShopBridge.Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace ShopBridge.Dal.Extensions
{
    public static class ShopBridgeModelBuilderExtensions
    {
        public static void ConfigureShopBridgeContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(item =>
            {
                item.ToTable("Items");
                item.HasKey(i => i.Id);
                item.HasIndex(i =>  i.Name).IsUnique();
                item.Property(i => i.Name).IsRequired();
                item.Property(i => i.Price).IsRequired();
                item.Property(i => i.Quantity).IsRequired();

            });
        }
    }
}
