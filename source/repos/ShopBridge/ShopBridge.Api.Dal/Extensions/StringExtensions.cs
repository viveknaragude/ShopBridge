using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Dal.Extensions
{
    public static class StringExtensions
    {
        public static DbContextOptions<T> StrToContextOptions<T>(this string connectionString) where T : DbContext
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer<T>(new DbContextOptionsBuilder<T>(), connectionString).Options;
        }
    }
}
