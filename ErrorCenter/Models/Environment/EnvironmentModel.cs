using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Environment
{
    public class EnvironmentModel
    {
        public int EnvironmentId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}