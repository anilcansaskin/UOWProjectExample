using AutoMapper;
using UOW.DtoLayer.CategoryDto;
using UOW.EntityLayer.Entities;

namespace UOW.WebAPI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
