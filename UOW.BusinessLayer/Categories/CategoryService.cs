using Mapster;
using System.Linq.Expressions;
using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract;
using UOW.DtoLayer.CategoryDto;
using UOW.EntityLayer.Entities;

namespace UOW.BusinessLayer.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public CreateCategoryDto Add(CreateCategoryDto dto)
        {
            Category mapped = dto.Adapt<Category>();
            Category result = _uow.GetRepository<Category>().Add(mapped);
            _uow.SaveChanges();
            return result.Adapt<CreateCategoryDto>();
        }

        public bool Delete(CreateCategoryDto dto)
        {
            Category mapped = dto.Adapt<Category>();
            bool result = _uow.GetRepository<Category>().Delete(mapped);
            _uow.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            _uow.GetRepository<Category>().Delete(id);
            _uow.SaveChanges();
            return true;
        }

        public CreateCategoryDto Get(Expression<Func<Category, bool>> predicate)
        {
            var result = _uow.GetRepository<Category>().Get(predicate);
            return result.Adapt<CreateCategoryDto>();
        }

        public IQueryable GetAll()
        {
            IQueryable<Category> list = _uow.GetRepository<Category>().GetAll();
            return list.ProjectToType<GetCategoryDto>().AsQueryable();
        }

        public IQueryable GetAll(Expression<Func<Category, bool>> predicate)
        {
            IQueryable<Category> list = _uow.GetRepository<Category>().GetAll(predicate);
            return list.ProjectToType<GetCategoryDto>().AsQueryable();
        }

        public CreateCategoryDto GetById(int id)
        {
            var result = _uow.GetRepository<Category>().GetById(id);
            return result.Adapt<CreateCategoryDto>();
        }

        public CreateCategoryDto Update(CreateCategoryDto dto)
        {
            Category mapped = dto.Adapt<Category>();
            var result = _uow.GetRepository<Category>().Update(mapped);
            _uow.SaveChanges();
            return result.Adapt<CreateCategoryDto>();
        }
    }
}
