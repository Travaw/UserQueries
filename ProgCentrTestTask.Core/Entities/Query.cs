using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgCentrTestTask.Core.Entities
{
    public class Query
    {
        public Query()
        {
            Users = new HashSet<User>();
        }

        [Required]
        public int Id { get; set; }

        public string Search { get; set; }

        public string SortBy { get; set; }

        public string Order { get; set; }

        public string Page { get; set; }

        public string Limit { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public bool IsExecuted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
