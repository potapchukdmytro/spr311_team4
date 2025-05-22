using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using team4.BLL.Dtos.Category;
using team4.DAL.Entities;
using AutoMapper;

namespace team4.BLL.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();

            CreateMap<CreateCategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateCategoryDto, CategoryEntity>();
        }
    }
}