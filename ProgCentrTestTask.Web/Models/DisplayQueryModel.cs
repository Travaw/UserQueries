using System;
using System.ComponentModel.DataAnnotations;

namespace ProgCentrTestTask.Web.Models
{
    public class DisplayQueryModel: CreateQueryModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Статус")]
        public bool IsExecuted { get; set; }
    }
}