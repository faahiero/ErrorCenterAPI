using System.Collections.Generic;
using ErrorCenter.Entities;

namespace ErrorCenter.Services
{
    public interface ILevelService
    {
        IList<Level> GetAll();
        Level GetById(int id);
        Level GetByName(string name);
        void CreateLevel(Level level);
        bool DeleteLevel(int levelId);
    }
}