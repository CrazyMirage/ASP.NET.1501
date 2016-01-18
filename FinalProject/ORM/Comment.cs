namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PhotoId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? ParentComment { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual User User { get; set; }
    }
}
