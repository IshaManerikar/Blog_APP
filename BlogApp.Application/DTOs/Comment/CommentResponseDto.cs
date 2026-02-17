using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.Comment
{
    public class CommentResponseDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int PostId { get; set; }
    }

}
