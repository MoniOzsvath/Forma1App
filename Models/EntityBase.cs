using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forma1App.Models
{
    public abstract class EntityBase
    {
        public EntityBase()
        {            
            var now = DateTime.Today;
            CreatedDate = now;
            UpdatedDate = now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
