using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Blok
    {
        public Blok()
        {
            Room = new List<Room>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Блок")]
        [Range(1,9)]
        public int Number { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Поверх")]
        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Room> Room
        {
            get; set;
        }
    }
}
