using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ErrorCenter.Entities;
using ErrorCenter.Models.Error;
using ErrorCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ErrorsController : Controller
    {
        private readonly IErrorService _errorService;
        private readonly IMapper _mapper;

        public ErrorsController(IErrorService errorService, IMapper mapper)
        {
            _errorService = errorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorModel>> GetAll()
        {
            var errors = _errorService.GetAll();

            if (errors == null)
                return NotFound();

            var errorsModel = _mapper.Map<IEnumerable<ErrorModel>>(errors);
            return Ok(errorsModel);

        }

        [HttpGet]
        [Route("{errorId}")]
        public ActionResult<ErrorModel> GetError(int errorId)
        {
            var error = _errorService.GetById(errorId);

            if (error == null)
                return NotFound();
            
            var errorModel = _mapper.Map<ErrorModel>(error);
            return Ok(errorModel);
        }

        
        [HttpGet]
        [Route("level/{levelId}")]
        public ActionResult<IEnumerable<ErrorModel>> GetErrorByLevel(int levelId)
        {
            var errorsByLevel = _errorService.GetByLevel(levelId);

            if (!errorsByLevel.Any())
                return NotFound();

            var errorsByLevelModel = _mapper.Map<IEnumerable<ErrorModel>>(errorsByLevel);
            return Ok(errorsByLevelModel);
        }
        
        [HttpGet]
        [Route("env/{envId}")]
        public ActionResult<IEnumerable<ErrorModel>> GetErrorByEnv(int envId)
        {
            var errorsByEnv = _errorService.GetByEnv(envId);

            if (!errorsByEnv.Any())
                return NotFound();

            var errorsByEnvModel = _mapper.Map<IEnumerable<ErrorModel>>(errorsByEnv);
            return Ok(errorsByEnvModel);
        }
        
        [HttpGet]
        [Route("env/searchField/searchString")]
        public ActionResult<IEnumerable<ErrorModel>> GetErrorFiltered(int env, int searchField, string searchString)
        {
            var errorsFiltered = _errorService.FilteredErrors(env, searchField, searchString);

            if (!errorsFiltered.Any())
                return NotFound();

            return Ok(errorsFiltered.
                Select(x => _mapper.Map<ErrorModel>(x)).
                ToList()); 
        }
        
        [HttpPost]
        public ActionResult PostError(ErrorRegisterModel value)
        {
            var error = _mapper.Map<Error>(value);
            _errorService.CreateError(error);
            var errorModel = _mapper.Map<ErrorModel>(error);
            return Ok(errorModel);
        }
        
        [HttpPut]
        [Route("{errorId}")]
        public ActionResult PutError(int errorId, ErrorModel value)
        {
            var error = _mapper.Map<Error>(value);
            error.ErrorId = errorId;

            _errorService.UpdateError(error);
            var errorModel = _mapper.Map<ErrorModel>(error);
            return Ok(errorModel);
        }
        
        [HttpDelete]
        [Route("{errorId}")]
        public ActionResult DeleteError(int errorId)
        {
            var deleteError = _errorService.GetById(errorId);
            if (deleteError == null)
                return NotFound();
            _errorService.DeleteError(errorId);
            return NoContent();
        }
        
    }
}