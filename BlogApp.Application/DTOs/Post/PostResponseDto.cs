using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PostResponseDto
{
    public int PostId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int? CategoryId { get; set; } 
    public string CategoryName { get; set; } = null!;
    public int LikesCount { get; set; }
}

