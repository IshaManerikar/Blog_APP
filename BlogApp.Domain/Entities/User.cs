using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BlogApp.Domain.Entities
{
    public class User
    {
        public int userId { get; set; }           // Primary Key
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Role: Admin / Author / Reader
        public string Role { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();

    }
}
