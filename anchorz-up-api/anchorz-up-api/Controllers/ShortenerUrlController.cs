using AnchorzUp.Api.Models;
using AnchorzUp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnchorzUp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortenerUrlController : Controller
    {
        private readonly IShortenerUrlService _shortenerUrlService;
        public ShortenerUrlController(IShortenerUrlService shortenerUrlService)
        {
            _shortenerUrlService = shortenerUrlService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetShortenerUrl(CancellationToken cancellationToken = default)
        {
            var shortenerUrlList = await _shortenerUrlService.GetShortenerUrlAsync(cancellationToken);
            return Ok(shortenerUrlList);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddShortenerUrl([FromBody] AddShortUrl url, CancellationToken cancellationToken = default)
        {
            var create = await _shortenerUrlService.AddShortenerUrlAsync(url.OriginalUrl, url.IdExpiration, cancellationToken);
            if (!create) return StatusCode(409);
            if (create) return Ok();
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteShortUrl(string id, CancellationToken cancellationToken = default)
        {
            await _shortenerUrlService.DeleteUrlAsync(id, cancellationToken);
            return Ok();
        }
    }
}
