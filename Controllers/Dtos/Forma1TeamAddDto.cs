using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1App.Controllers.Dtos
{
    public class Forma1TeamAddDto
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime FoundedDate { get; set; }

        public int WinnedChampionshipsCount { get; set; }

        public bool PaiedEntryFee { get; set; }
    }
}
