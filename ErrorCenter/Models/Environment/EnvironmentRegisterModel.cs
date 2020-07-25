using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Environment
{
    public class EnvironmentRegisterModel
    {
        [Required]
        public string Name { get; set; }
    }
}