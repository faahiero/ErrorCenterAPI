using System;
using System.Collections.Generic;

namespace ErrorCenter.Entities
{
    public class Level
    {
        public int LevelId { get; set; }
        public String Name { get; set; }
        
        public virtual ICollection<Error> Errors { get; set; }
    }
}