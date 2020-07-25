using System.Collections.Generic;
using System.Linq;
using ErrorCenter.Entities;
using ErrorCenter.Helpers;

namespace ErrorCenter.Services
{
    public class ErrorService : IErrorService
    {
        private readonly DataContext _context;
        private readonly ILevelService _levelService;

        public ErrorService(DataContext context, ILevelService levelService)
        {
            _context = context;
            _levelService = levelService;
        }

        public IList<Error> GetAll()
        {
            var errors = _context.Errors.ToList();
            return errors;
        }

        public Error GetById(int id)
        {
            var error = _context.Errors.Find(id);
            return error;
        }

        public IList<Error> GetByLevel(int levelId)
        {
            var errorByLevel = _context.Levels
                .Where(x => x.LevelId == levelId)
                .SelectMany(x => x.Errors)
                .ToList();
            return errorByLevel;
        }

        public IList<Error> GetByEnv(int envId)
        {
            var errorByEnv = _context.Environments
                .Where(x => x.EnvironmentId == envId)
                .SelectMany(x => x.Errors)
                .ToList();
            return errorByEnv;
        }

        public IList<Error> FilteredErrors(int env, int? searchField, string searchString)
        {
            var errorsList = new List<Error>();

            if (searchString == string.Empty || searchField == 0)
            {
                errorsList = _context.Errors
                    .Where(x => x.EnvironmentId == env || env <= 0)
                    .OrderBy(x => x.LevelId)
                    .ToList();
            }
            else
            {
                errorsList = searchField switch
                {
                    1 => _context.Errors
                        .Where(x => x.Level == _levelService.GetByName(searchString))
                        .ToList(),
                    2 => _context.Errors
                        .Where(x => x.Details.Contains(searchString))
                        .OrderBy(x => x.LevelId)
                        .ToList(),
                    3 => _context.Errors
                        .Where(x => x.Origin.Contains(searchString))
                        .OrderBy(x => x.LevelId)
                        .ToList(),
                    _ => errorsList
                };

                errorsList = errorsList
                    .Where(x => x.EnvironmentId == env || env <= 0)
                    .ToList();
            }
            
            return errorsList;
        }

        public void CreateError(Error error)
        {
            _context.Errors.Add(error);
            _context.SaveChanges();
        }

        public bool UpdateError(Error error)
        {
            var existentError = GetById(error.ErrorId);
            existentError.Title = error.Title;
            existentError.Origin = error.Origin;
            existentError.Details = error.Details;
            existentError.EventId = error.EventId;
            existentError.EnvironmentId = error.EnvironmentId;
            existentError.LevelId = error.LevelId;

            _context.Errors.Update(existentError);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteError(int errorId)
        {
            var error = GetById(errorId);
            _context.Errors.Remove(error);
            _context.SaveChanges();
            return true;
        }
    }
}