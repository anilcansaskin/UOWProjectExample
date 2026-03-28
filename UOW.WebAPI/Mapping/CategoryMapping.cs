using Mapster;
using UOW.DtoLayer.CategoryDto;
using UOW.EntityLayer.Entities;

namespace UOW.WebAPI.Mapping
{
    public class CategoryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, GetCategoryDto>()
                .Map(dest => dest, src => src);
            
            config.NewConfig<GetCategoryDto, Category>()
                .Map(dest => dest, src => src);

            config.NewConfig<Category, CreateCategoryDto>()
                .Map(dest => dest, src => src);
            
            config.NewConfig<CreateCategoryDto, Category>()
                .Map(dest => dest, src => src);
        }
    }
}
