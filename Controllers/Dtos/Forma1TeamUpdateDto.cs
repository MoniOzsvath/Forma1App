using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1App.Controllers.Dtos
{
    public class Forma1TeamUpdateDto: Forma1TeamAddDto
    {
        [Required]
        public long Id { get; set; }
    }
}
