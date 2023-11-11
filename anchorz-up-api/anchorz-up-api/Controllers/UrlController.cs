using AnchorzUp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace AnchorzUp.Api.Controllers
{
    public class UrlController : Controller
    {
        private readonly IShortenerUrlService _shortenerUrlService;
        public UrlController(IShortenerUrlService shortenerUrlService)
        {
            _shortenerUrlService = shortenerUrlService;
        }
        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> YourAction(string shortUrl)
        {
            var result = await _shortenerUrlService.FindOriginalUrl(shortUrl, CancellationToken.None);

            if (result == "Short URL not found")
            {
                return NotFound();
            }
            else if (result.StartsWith("An error occurred"))
            {
                return BadRequest();
            }
            else
            {
                return Redirect(result);
            }
        }
    }
}
