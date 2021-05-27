using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Campus
    {
        public Campus()
        {
            Dormitory = new List<Dormitory>();
        }
        public int Id { get; set; }
        //[Required(ErrorMessage = "Поле не може бути порожнім")]
        //[Display(Name ="Університет")]
        //public string University { get; set; }
        //[Required(ErrorMessage = "Поле не може бути порожнім")]
        //[Display(Name = "Кампус")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Унiверситет")]
        public int UniversityId { get; set; }
        public virtual University University { get; set; }

        public virtual ICollection<Dormitory> Dormitory { get; set; }
    }
}
