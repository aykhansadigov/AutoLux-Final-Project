using AutoLux.Application.DTOs;
using AutoLux.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Car obyektini CarDto-ya çevirmək üçün
            CreateMap<Car, CarDto>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsForSale && src.IsForRent ? "Satış & Kirayə" : src.IsForSale ? "Satılır" : "Kirayə"));
        }
    }
}
