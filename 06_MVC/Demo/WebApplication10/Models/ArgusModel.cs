using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class ArgusModel
    {

        public int ID { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public List<Mitarbeiter> Angestellte { get; set; }
    }
}
