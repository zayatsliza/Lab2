using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Floor
    {
        public Floor()
        {
            Blok = new List<Blok>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Поверх")]
        [Range(1, 9)]
        public int Number { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Гуртожиток")]
        public int DormId { get; set; }
        public virtual Dormitory Dormitory { get; set; }
        public virtual ICollection<Blok> Blok { get; set; }
    }
}
