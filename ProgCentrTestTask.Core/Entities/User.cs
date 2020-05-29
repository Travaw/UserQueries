using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgCentrTestTask.Core.Entities
{
    public class User
    {
        public User()
        {
            Queries = new HashSet<Query>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Query> Queries{ get; set; }
    }
}
