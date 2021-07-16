using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Dal.Interfaces
{
    public interface IRepository
    {
        void Save();
        Task SaveAsync();
    }
}
