using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Error
{
    public class ErrorModel
    {
        public int ErrorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
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