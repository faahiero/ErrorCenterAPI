using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Level
{
    public class LevelModel
    {
        public int LevelId { get; set; }
        [Required]
        public String Name { get; set; }
    }
}