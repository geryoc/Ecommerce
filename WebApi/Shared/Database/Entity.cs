using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.WebApi.Shared.Database
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "datetimeoffset(2)")]
        public DateTimeOffset Created { get; set; }

        [Column(TypeName = "datetimeoffset(2)")]
        public DateTimeOffset? Updated { get; set; }

        [Column(TypeName = "datetimeoffset(2)")]
        public DateTimeOffset? Deleted { get; set; }
    }
}
