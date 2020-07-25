using System.Collections.Generic;
using System.Linq;
using ErrorCenter.Entities;
using ErrorCenter.Helpers;

namespace ErrorCenter.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly DataContext _context;

        public EnvironmentService(DataContext context)
        {
            _context = context;
        }
        
        public IList<Environment> GetAll()
        {
            var envs = _context.Environments.ToList();
            return envs;
        }
        
        public Environment GetById(int id)
        {
            var env = _context.Environments.Find(id);
            return env;
        }
        
        public void CreateEnvironment(Environment environment)
        {
            _context.Environments.Add(environment); 
            _context.SaveChanges();
        }
        
        public bool DeleteEnvironment(int envId)
        {
            var env = GetById(envId);
            _context.Environments.Remove(env);
            _context.SaveChanges();
            return true;
        }

        public bool EnvironmentExist(int id)
        {
            return _context.Environments.Any(e => e.EnvironmentId == id);
        }
    }
}