using BlogAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDataAccess.Repositories
{
    class CategoryRepository : IRepository<Category>
    {
        BlogAppContext m_Context = null;

        public CategoryRepository(BlogAppContext context)
        {
            m_Context = context;
        }

        public IEnumerable<Category> GetAll(System.Linq.Expressions.Expression<Func<Category, bool>> predicate = null)
        {
            return m_Context.Categories.Where(predicate);
        }

        public Category Get(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return m_Context.Categories.SingleOrDefault(predicate);
        }

        public void Add(Category entity)
        {
            m_Context.Categories.Add(entity);
        }

        public void Update(Category entity)
        {
            m_Context.Categories.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(Category entity)
        {
            m_Context.Categories.Remove(entity);
        }

        public int Count()
        {
            return m_Context.Categories.Count();
        }
    }
}
