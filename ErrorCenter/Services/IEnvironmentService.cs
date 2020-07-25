using System.Collections.Generic;
using ErrorCenter.Entities;

namespace ErrorCenter.Services
{
    public interface IEnvironmentService
    {
        IList<Environment> GetAll();
        Environment GetById(int id);
        void CreateEnvironment(Environment environment);
        bool DeleteEnvironment(int envId);
        bool EnvironmentExist(int id);
    }
}