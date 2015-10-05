namespace BlogAppDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? BlogId { get; set; }
        public int? PosterId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual User User { get; set; }
    }
}
