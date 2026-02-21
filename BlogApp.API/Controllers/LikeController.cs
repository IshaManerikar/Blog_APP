using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Services;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/likes")]
    public class LikeController: ControllerBase
    {
        private readonly LikeService _service;

        public LikeController(LikeService service)
        {
            _service = service;
        }


        [HttpPost("{postId}")]
        public async Task<IActionResult> LikePost(int postId)
        {
            await _service.LikePostAsync(postId, 1); // temporary userId = 1
            return Ok();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> UnlikePost(int postId)
        {
            await _service.UnlikePostAsync(postId, 1); // temporary userId = 1
            return Ok();
        }

        [HttpGet("{postId}/count")]
        public async Task<IActionResult> GetLikeCount(int postId)
        {
            var count = await _service.GetLikeCountAsync(postId);
            return Ok(count);
        }


    }
}
