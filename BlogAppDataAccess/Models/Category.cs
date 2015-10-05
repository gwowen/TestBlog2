namespace BlogAppDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
