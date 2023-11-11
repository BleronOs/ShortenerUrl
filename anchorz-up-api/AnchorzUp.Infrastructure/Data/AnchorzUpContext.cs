using AnchorzUp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorzUp.Infrastructure.Data
{
    public class AnchorzUpContext : DbContext
    {
        public AnchorzUpContext(DbContextOptions<AnchorzUpContext> options) : base(options)
        {
            
        }
        public DbSet<ShortenerUrl> shortenerUrls { get; set; }
    }
}
