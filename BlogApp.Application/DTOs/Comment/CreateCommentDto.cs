using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.Comment
{
    public class CreateCommentDto
    {
        public int PostId { get; set; }
        public string Text { get; set; } = null!;
        public string Content { get; set; }
    }

}
