using System.Collections.Generic;

namespace ErrorCenter.Entities
{
    public class Environment
    {
        public int EnvironmentId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Error> Errors { get; set; }
    }
}



