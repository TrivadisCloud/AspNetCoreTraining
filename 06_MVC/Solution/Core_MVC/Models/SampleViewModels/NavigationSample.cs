using System.ComponentModel.DataAnnotations;

namespace Core_MVC.Models.SampleViewModels
{
    public class NavigationSample
    {
        public int NavigationSampleID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NavigationText { get; set; }
    }
}
