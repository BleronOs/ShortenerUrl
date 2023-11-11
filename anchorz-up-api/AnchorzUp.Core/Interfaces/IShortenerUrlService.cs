using AnchorzUp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorzUp.Core.Interfaces
{
    public interface IShortenerUrlService
    {
        Task<IReadOnlyList<ShortenerUrl>> GetShortenerUrlAsync(CancellationToken cancellationToken = default);
        Task<bool> AddShortenerUrlAsync(string originalUrl, string idExpiration, CancellationToken cancellationToken = default);
        Task<string> FindOriginalUrl(string shortUrl, CancellationToken cancellationToken);
        Task<bool> DeleteUrlAsync(string id, CancellationToken cancellationToken = default);

    }
}
