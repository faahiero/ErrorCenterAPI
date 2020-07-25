using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Error
{
    public class ErrorRegisterModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int EnvironmentId { get; set; }
        [Required]
        public int LevelId { get; set; }
    }
}