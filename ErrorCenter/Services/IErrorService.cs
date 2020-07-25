using System.Collections.Generic;
using ErrorCenter.Entities;

namespace ErrorCenter.Services
{
    public interface IErrorService
    {
        IList<Error> GetAll();
        Error GetById(int id);
        IList<Error> GetByLevel(int levelId);
        IList<Error> GetByEnv(int envId);
        IList<Error> FilteredErrors(int env, int? searchField, string searchString);
        void CreateError (Error error);
        bool UpdateError(Error error);
        bool DeleteError(int errorId);
    }
}