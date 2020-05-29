using System;
using System.Collections.Generic;
using System.Text;

namespace ProgCentrTestTask.Application.DTOs
{
    public class QueryDisplayDTO : QueryCreateDTO
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsExecuted { get; set; }
    }
}
