using System;

namespace ErrorCenter.Entities
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Origin { get; set; }
        public string Details { get; set; }
        public int EventId { get; set; }
        
        
        public int EnvironmentId { get; set; }
        public virtual Environment Environment { get; set; }
        
        public int LevelId { get; set; }
        public virtual Level Level { get; set; }
    }
}


