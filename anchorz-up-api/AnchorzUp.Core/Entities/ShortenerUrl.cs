using AnchorzUp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorzUp.Core.Entities
{
    [Table("shortener_url")]
    public class ShortenerUrl : IEntity
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Required]
        [Column("original_url")]
        public string OriginalUrl { get; set; }
        [Required]
        [Column("short_alias")]
        public string ShortAlias { get; set; }
        [Required]
        [Column("created_date_time")]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        [Column("expiration_date_time")]
        public DateTime? ExpirationDateTime { get; set; }
    }
}
