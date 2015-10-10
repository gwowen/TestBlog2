using BlogAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDataAccess.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private BlogAppContext m_Context = null;
        private Repository<Category> categoryRepository = null;
        private Repository<Blog> blogRepository = null;
        private Repository<Comment> commentRepository = null;
        private Repository<User> userRepository = null;
        private Repository<Role> roleRepository = null;

        public UnitOfWork()
        {
            m_Context = new BlogAppContext();
        }

        public void SaveChanges()
        {
            m_Context.SaveChanges();
        }

        public Repository<Category> CategoryRepository
        {
            get
            {
                if(categoryRepository == null)
                {
                    categoryRepository = new Repository<Category>(m_Context);
                }

                return categoryRepository;
            }
        }

        public Repository<Blog> BlogRepository
        {
            get
            {
                if(blogRepository == null)
                {
                    blogRepository = new Repository<Blog>(m_Context);
                }

                return blogRepository;
            }
        }

        public Repository<Comment> CommentRepository
        {
            get
            {
                if(commentRepository == null)
                {
                    commentRepository = new Repository<Comment>(m_Context);
                }

                return commentRepository;
            }
        }

        public Repository<User> UserRepository
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new Repository<User>(m_Context);
                }

                return userRepository;
            }
        }

        public Repository<Role> RoleRepository
        {
            get
            {
                if(roleRepository == null)
                {
                    roleRepository = new Repository<Role>(m_Context);
                }

                return roleRepository;
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    m_Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
