﻿using AutoMapper;
using ItemManager.Models.LostItems;
using ItemManager.Models.FoundItems;
using ItemManager.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
