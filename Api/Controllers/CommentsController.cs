using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CommentCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private IGetCommentsCommand _getCommand;
        private IGetCommentCommand _getOneCommand;
        private IDeleteCommentCommand _deleteCommand;
        private IUpdateCommentCommand _updateCommand;
        private IAddCommentCommand _addCommand;

        public CommentsController(IGetCommentsCommand getCommand, IGetCommentCommand getOneCommand, IDeleteCommentCommand deleteCommand, IUpdateCommentCommand updateCommand, IAddCommentCommand addCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _addCommand = addCommand;
        }
        /// <summary>
        /// ( Gets all Comments. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Comments
        ///     {
        ///        "Keyword": Movies,
        ///        "OnlyActive": "true",
        ///     }
        ///
        /// </remarks>
        // GET: api/Comments
        [HttpGet]
        public ActionResult Get([FromQuery] CommentSearch search)
        {
            return Ok(_getCommand.Execute(search));
        }

        //public IActionResult Get([FromQuery]CategorySearch query)
        //=> Ok(_getCommand.Execute(query));

        /// <summary>
        /// ( Gets a single comment. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Comments/3
        ///     {
        ///        "id": 3,
        ///     }
        ///
        /// </remarks>
        // GET: api/Comments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var comment = _getOneCommand.Execute(id);
                return Ok(comment);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An Error Occured");
            }
        }

        /// <summary>
        /// ( Creates a Comment. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Comments
        ///     {
        ///        "Content": "Hello Wordl!",
        ///     }
        ///
        /// </remarks>
        // POST: api/Comments
        [HttpPost]
        public IActionResult Post([FromQuery]CommentCreateDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error ocurred");
            }
        }

        /// <summary>
        /// ( Updates a specific Comment. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Comments/5
        ///     {
        ///        "Content": "Hello World!" 
        ///     }
        ///
        /// </remarks>
        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery]CommentDto dto)
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
        /// ( Deletes a specific Comment. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Comments/8
        ///     {
        ///        "id": "8",
        ///     }
        ///
        /// </remarks>
        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured");
            }
        }
    }
}
