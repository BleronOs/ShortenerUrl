using System;
using AnchorzUp.Core.Entities;
using Ardalis.Specification;
namespace AttendanceTracker.Core.Specifications
{
    public class ReadOnlyIfOriginalUrlExistedSpecification : Specification<ShortenerUrl>
    {
        public ReadOnlyIfOriginalUrlExistedSpecification(string originalUrl)
        {
            Query.Where(e => e.OriginalUrl == originalUrl && e.ExpirationDateTime >= DateTime.Now).AsNoTracking();
        }
    }
}


