using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Mapper
{
    public class ItemMapperProfile: Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<Models.Item, Dal.Entities.Item>();
            CreateMap<Dal.Entities.Item, Models.Item>();

        }
    }
}
