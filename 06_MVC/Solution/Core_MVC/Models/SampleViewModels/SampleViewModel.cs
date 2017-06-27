using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models.SampleViewModels
{
    public class SampleViewModel
    {
        [Key]
        public int SampleID { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(20)]
        public string Text { get; set; }

        public List<NavigationSample> Navigations { get; set; }
    }
}
