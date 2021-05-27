using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Lab2.Models
{
    public class University
    {
        public University()
        {
            Campus = new List<Campus>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Університет")]
        public string Name { get; set; }

        public virtual ICollection<Campus> Campus { get; set; }

    }
}
