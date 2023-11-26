using System.Linq.Expressions;
using UOW.BusinessLayer.Dependency;
using UOW.DtoLayer.CategoryDto;
using UOW.EntityLayer.Entities;

namespace UOW.BusinessLayer.Categories
{
    public interface ICategoryService : IScopedDependency
    {
        IQueryable GetAll();
        IQueryable GetAll(Expression<Func<Category, bool>> predicate);
        CreateCategoryDto GetById(int id);
        CreateCategoryDto Get(Expression<Func<Category, bool>> predicate);
        CreateCategoryDto Add(CreateCategoryDto dto);
        CreateCategoryDto Update(CreateCategoryDto dto);
        bool Delete(CreateCategoryDto dto);
        bool Delete(int id);
    }
}
