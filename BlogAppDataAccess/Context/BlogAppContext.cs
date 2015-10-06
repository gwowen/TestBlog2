namespace BlogAppDataAccess.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogAppContext : DbContext
    {
        public BlogAppContext() : base("name=BlogAppConnectionString")
        { 
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one to many relationship between Category and Blog
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            //one to many relationship between Blog and Comment
            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Blog)
                .HasForeignKey(e => e.BlogId)
                .WillCascadeOnDelete(false);

            //one to many relationship between User and Blog
            modelBuilder.Entity<User>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            //one to many relationship between User and Comment
            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.PosterId);

            //many to many relationship between User and Role
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserRoles")
                            .MapLeftKey("UserId")
                            .MapRightKey("RoleId"));
        }
    }
}
