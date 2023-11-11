using AnchorzUp.Core.Entities;
using AnchorzUp.Core.Interfaces;
using AttendanceTracker.Core.Specifications;

namespace AnchorzUp.Core.Services
{
    public class ShortenerUrlService : IShortenerUrlService
    {
        private readonly IAsyncRepository<ShortenerUrl> _shortenerUrlRepository;
        public ShortenerUrlService(IAsyncRepository<ShortenerUrl> shortenerUrlRepository)
        {
            _shortenerUrlRepository = shortenerUrlRepository;
        }

        public async Task<IReadOnlyList<ShortenerUrl>> GetShortenerUrlAsync(CancellationToken cancellationToken = default)
        {
            var shortenerUrlList = await _shortenerUrlRepository.ListAllAsync();
            return shortenerUrlList;
        }

        public async Task<bool> AddShortenerUrlAsync(string originalUrl, string idExpiration, CancellationToken cancellationToken = default)
        {
            var queryToFindOriginalUrl = new ReadOnlyIfOriginalUrlExistedSpecification(originalUrl);
            var checkIfExist = await _shortenerUrlRepository.FirstOrDefaultAsync(queryToFindOriginalUrl, cancellationToken);
            DateTime dateTimeExpiration;
            if (idExpiration == "1") dateTimeExpiration = DateTime.Now.AddMinutes(1);
            else if (idExpiration == "2") dateTimeExpiration = DateTime.Now.AddMinutes(5);
            else if (idExpiration == "3") dateTimeExpiration = DateTime.Now.AddMinutes(30);
            else if (idExpiration == "4") dateTimeExpiration = DateTime.Now.AddHours(1);
            else if (idExpiration == "5") dateTimeExpiration = DateTime.Now.AddHours(5);
            else dateTimeExpiration = DateTime.Now;
            if (checkIfExist != null) return false;
                var createShortenerUrl = await _shortenerUrlRepository.AddAsync(new ShortenerUrl
                {
                    Id = Guid.NewGuid().ToString(),
                    OriginalUrl = originalUrl,
                    ShortAlias = GenerateShortAlias(),
                    CreatedDateTime = DateTime.Now,
                    ExpirationDateTime = dateTimeExpiration,
                }, cancellationToken);
                return createShortenerUrl;
        }
        public async Task<string> FindOriginalUrl(string shortUrl, CancellationToken cancellationToken)
        {
            string domainUrl = "http://localhost/" + shortUrl;
            var queryToFindShortenerUrl = new ReadOnlyShortUrlSpecification(domainUrl);
            var checkIfExist = await _shortenerUrlRepository.FirstOrDefaultAsync(queryToFindShortenerUrl, cancellationToken);

            if (checkIfExist == null || checkIfExist.ExpirationDateTime <= DateTime.Now)
            {
                return "Short URL not found";
            }

            try
            {
                return checkIfExist.OriginalUrl.Replace("%2F", "/");
            }
            catch (Exception ex)
            {
                return "An error occurred while processing the request.";
            }
        }
        public async Task<bool> DeleteUrlAsync(string id, CancellationToken cancellationToken = default)
        {
            try {
                var findById = await _shortenerUrlRepository.GetByIdAsync(id);
                await _shortenerUrlRepository.DeleteAsync(findById);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        private string GenerateShortAlias()
        {
            string domainUrl = "http://localhost/";
            string shortAlias = Guid.NewGuid().ToString("N").Substring(0, 4).ToLower();
            string finalShortAlias = domainUrl + shortAlias;
            return finalShortAlias;
        }
    }
}
