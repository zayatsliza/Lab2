using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Dormitory
    {
        public Dormitory()
        {
            Floor = new List<Floor>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name ="Номер гуртожитку")]
        [Range(1, 18)]
        public int Number { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Номер адреси")]
        public int AdressNumber { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Вулиця")]
        public string AdressStreet { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Кампус")]
        public int CampusId { get; set; }
        public virtual Campus Campus { get; set; }
        public virtual ICollection<Floor> Floor { get; set; }
    }
}
