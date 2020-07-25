using System.Collections.Generic;
using AutoMapper;
using ErrorCenter.Entities;
using ErrorCenter.Models.Environment;
using ErrorCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCenter.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class EnvironmentsController : Controller
    {
        private readonly IEnvironmentService _environmentService;
        private readonly IMapper _mapper;

        public EnvironmentsController(IEnvironmentService environmentService, IMapper mapper)
        {
            _environmentService = environmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentModel>> GetAll()
        {
            var envs = _environmentService.GetAll();
            if (envs == null)
                return NotFound(new {message = "No environments found"});

            var envsModel = _mapper.Map<IEnumerable<EnvironmentModel>>(envs);
            return Ok(envsModel);
        }

        [HttpGet]
        [Route("{envId}")]
        public ActionResult<EnvironmentModel> GetEnvironment(int envId)
        {
            var env = _environmentService.GetById(envId);

            if (env == null)
                return NotFound(new {message = "Environment not found"});

            var envModel = _mapper.Map<EnvironmentModel>(env);
            return Ok(envModel);
        }

        [HttpPost]
        public ActionResult PostEnvironment(EnvironmentRegisterModel value)
        {
            var env = _mapper.Map<Environment>(value);
            _environmentService.CreateEnvironment(env);
            var envModel = _mapper.Map<EnvironmentModel>(env);
            return Ok(envModel);
        }

        [HttpDelete]
        [Route("{envId}")]
        public ActionResult DeleteEnvironment(int envId)
        {
            var deleteEnv = _environmentService.GetById(envId);
            if (deleteEnv == null)
                return NotFound(new {message = "Can't delete. Environment not found"});
            _environmentService.DeleteEnvironment(envId);
            return NoContent();
        }
    }
}