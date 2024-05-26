using AutoMapper;
using ItemManager.Models.LostItems;
using ItemManager.Models.FoundItems;
using ItemManager.DTOs;

namespace ItemManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LostItem, LostItemDTO>().ReverseMap();
            CreateMap<FoundItem, FoundItemDTO>().ReverseMap();
        }
    }
}
