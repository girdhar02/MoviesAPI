using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository,ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet] //"api/genre"
        [HttpGet("list")] //"api/genre/list"
        //[ResponseCache(Duration =60)]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the Genres");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}",Name ="getGenre")] //"api/genres/Id"  
        public ActionResult<Genre> Get(int Id, [FromHeader] string pram2)
        {
            logger.LogDebug("GetById method executing...");
            var genre = repository.GetGenreById(Id);
            if(genre == null)
            {
                logger.LogWarning($"Genre with {Id} not found");
                throw new ApplicationException();
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id }, genre);
        }
        
        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            return NoContent();
        }
        
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
