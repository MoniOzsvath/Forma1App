using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1App.Controllers.Dtos
{
    public class EntityBaseReturnDto
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
