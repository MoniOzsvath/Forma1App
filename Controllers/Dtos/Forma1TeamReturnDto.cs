using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1App.Controllers.Dtos
{
    public class Forma1TeamReturnDto : EntityBaseReturnDto
    {
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public int WinnedChampionshipsCount { get; set; }

        public bool PaiedEntryFee { get; set; }
    }
}
