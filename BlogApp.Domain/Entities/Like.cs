using System;

namespace BlogApp.Domain.Entities
{
    public class Like
    {
        public int LikeId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
