using System;
using AnchorzUp.Core.Entities;
using Ardalis.Specification;
namespace AttendanceTracker.Core.Specifications
{
    public class ReadOnlyShortUrlSpecification : Specification<ShortenerUrl>
    {
        public ReadOnlyShortUrlSpecification(string shortUrl)
        {
            Query.Where(e => e.ShortAlias == shortUrl).AsNoTracking();
        }
    }
}


