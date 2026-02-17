using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace BlogApp.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;


        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
