using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1App.Models
{
    public class Forma1TeamEntity : EntityBase
    {       
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public int WinnedChampionshipsCount { get; set; }

        public bool PaiedEntryFee { get; set; }
    }
}