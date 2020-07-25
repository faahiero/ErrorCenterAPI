using System.Collections.Generic;
using System.Linq;
using ErrorCenter.Entities;
using ErrorCenter.Helpers;

namespace ErrorCenter.Services
{
    public class LevelService : ILevelService
    {
        private readonly DataContext _context;

        public LevelService(DataContext context)
        {
            _context = context;
        }

        public IList<Level> GetAll()
        {
            var levels = _context.Levels.ToList();
            return levels;
        }
        
        public Level GetById(int id)
        {
            var level = _context.Levels.Find(id);
            return level;
        }
        
        public Level GetByName(string name)
        {
            return _context.Levels.FirstOrDefault(l => l.Name == name);
        }
        
        
        public void CreateLevel(Level level)
        {
            _context.Levels.Add(level); 
            _context.SaveChanges();
        }
        
        public bool DeleteLevel(int levelId)
        {
            var level = GetById(levelId);
            _context.Levels.Remove(level);
            _context.SaveChanges();
            return true;
        }
    }
}