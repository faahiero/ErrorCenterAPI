using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Models.Level
{
    public class LevelRegisterModel
    {
        [Required]
        public String Name { get; set; }
    }
}