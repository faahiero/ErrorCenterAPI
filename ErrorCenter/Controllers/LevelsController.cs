using System.Collections.Generic;
using AutoMapper;
using ErrorCenter.Entities;
using ErrorCenter.Models.Level;
using ErrorCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LevelsController : Controller
    {
        private readonly ILevelService _levelService;
        private readonly IMapper _mapper;

        public LevelsController(ILevelService levelService, IMapper mapper)
        {
            _levelService = levelService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<LevelModel>> GetAll()
        {
            var levels = _levelService.GetAll();
            if (levels == null)
                return NotFound(new {message = "No levels found"});

            var levelsModel = _mapper.Map<IEnumerable<LevelModel>>(levels);
            return Ok(levelsModel);
        }
        
        [HttpGet]
        [Route("{levelId}")]
        public ActionResult<IEnumerable<LevelModel>> GetLevel(int levelId)
        {
            var level = _levelService.GetById(levelId);
            if (level == null)
                return NotFound(new {message = "Level not found"});

            var levelModel = _mapper.Map<LevelModel>(level);
            return Ok(levelModel);
        }
        
        [HttpPost]
        public ActionResult PostLevel(LevelRegisterModel value)
        {
            var level = _mapper.Map<Level>(value);
            _levelService.CreateLevel(level);
            var levelModel = _mapper.Map<LevelModel>(level);
            return Ok(levelModel);
        }
        
        [HttpDelete]
        [Route("{levelId}")]
        public ActionResult DeleteLevel(int levelId)
        {
            var deleteLvl = _levelService.GetById(levelId);
            if (deleteLvl == null)
                return NotFound(new {message = "Can't delete. Level not found"});
            _levelService.DeleteLevel(levelId);
            return NoContent();
        }
    }
}