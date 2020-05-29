using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgCentrTestTask.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name="Имя")]
        public string Name { get; set; }

        [Display(Name = "Время создания")]
        public DateTime CreatedAt { get; set; }
    }
}