namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        public Photo()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string PhotoLink { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int LikesNumber { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual User User { get; set; }
    }
}
