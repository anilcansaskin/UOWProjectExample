using AutoMapper;
using System.Linq.Expressions;
using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract;
using UOW.DtoLayer.CategoryDto;
using UOW.EntityLayer.Entities;

namespace UOW.BusinessLayer.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public CreateCategoryDto Add(CreateCategoryDto dto)
        {
            Category mapped = _mapper.Map<Category>(dto);
            Category result = _uow.GetRepository<Category>().Add(mapped);
            _uow.SaveChanges();
            return _mapper.Map<CreateCategoryDto>(result);
        }

        public bool Delete(CreateCategoryDto dto)
        {
            Category mapped = _mapper.Map<Category>(dto);
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
            return _mapper.Map<CreateCategoryDto>(result);
        }

        public IQueryable GetAll()
        {
            IQueryable<Category> list = _uow.GetRepository<Category>().GetAll();
            return _mapper.Map<List<GetCategoryDto>>(list).AsQueryable();
        }

        public IQueryable GetAll(Expression<Func<Category, bool>> predicate)
        {
            IQueryable<Category> list = _uow.GetRepository<Category>().GetAll(predicate);
            return _mapper.Map<List<GetCategoryDto>>(list).AsQueryable();
        }

        public CreateCategoryDto GetById(int id)
        {
            var result = _uow.GetRepository<Category>().GetById(id);
            return _mapper.Map<CreateCategoryDto>(result);
        }

        public CreateCategoryDto Update(CreateCategoryDto dto)
        {
            Category mapped = _mapper.Map<Category>(dto);
            var result = _uow.GetRepository<Category>().Update(mapped);
            _uow.SaveChanges();
            return _mapper.Map<CreateCategoryDto>(result);
        }
    }
}
