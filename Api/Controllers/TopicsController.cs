using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Topics")]
    public class TopicsController : Controller
    {
        private IGetTopicsCommand _getCommand;
        private IGetTopicCommand _getOneCommand;
        private IAddTopicCommand _addCommand;
        private IDeleteTopicCommand _deleteCommand;
        private IUpdateTopicCommand _updateCommand;

        public TopicsController(IGetTopicsCommand getCommand, IGetTopicCommand getOneCommand, IAddTopicCommand addCommand, IDeleteTopicCommand deleteCommand, IUpdateTopicCommand updateCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
        }

        /// <summary>
        /// ( Gets all Topics / Searches Topics with a keyword. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Topics
        ///     {
        ///        "Keyword": Movies,
        ///        "OnlyActive": "true",
        ///     }
        ///
        /// </remarks>
        // GET: api/Topics
        [HttpGet]
        public IActionResult Get([FromQuery]TopicSearch query)
        => Ok(_getCommand.Execute(query));

        /// <summary>
        /// ( Returns a single Topic. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Topics/5
        ///     {
        ///        "id": 4,
        ///     }
        ///
        /// </remarks>
        // GET: api/Topics/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var topic = _getOneCommand.Execute(id);
                return Ok(topic);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An Error has occured.");
            }
            
        }

        /// <summary>
        /// ( Creates a Topic. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     
        /// 
        /// /Topics
        ///     {
        ///        "Subject": "Favourite game?",
        ///        "Content": "What is your favourite game? ",
        ///     }
        ///
        /// </remarks>
        // POST: api/Topics
        [HttpPost]
        public IActionResult Post([FromQuery] CreateTopicDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityAlreadyExistsException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error ocurred");
            }
        }
        
        // PUT: api/Topics/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery]TopicDto dto)
        {
            try
            {
                _updateCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
        }

        /// <summary>
        /// ( Deletes a specific Category. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Categories/3
        ///     {
        ///        "id": "5",
        ///     }
        ///
        /// </remarks>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (EntityDeleted)
            {
                return StatusCode(410, "The Topic is already Deleted");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured");
            }
        }
    }
}
