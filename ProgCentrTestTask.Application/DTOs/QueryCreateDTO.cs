using System;
using System.Collections.Generic;
using System.Text;

namespace ProgCentrTestTask.Application.DTOs
{
    public class QueryCreateDTO
    {
        public string Search { get; set; }
        
        public string SortBy { get; set; }

        public string Order { get; set; }

        public string Page { get; set; }

        public string Limit { get; set; }
    }
}
