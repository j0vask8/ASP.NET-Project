using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]

    
    public class UsersController : Controller
    {
        private IGetUserCommand _getOneCommand;
        private IGetUsersCommand _getCommand;
        private IAddUserCommand _addCommand;
        private IDeleteUserCommand _deleteCommand;
        private IUpdateUserCommand _updateCommand;

        public UsersController(IGetUserCommand getOneCommand, IGetUsersCommand getCommand, IAddUserCommand addCommand, IDeleteUserCommand deleteCommand, IUpdateUserCommand updateCommand)
        {
            _getOneCommand = getOneCommand;
            _getCommand = getCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
        }

        /// <summary>
        /// ( Gets all Users. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Users
        ///     {
        ///        "Keyword": Movies,
        ///        "OnlyActive": "true",
        ///     }
        ///
        /// </remarks>
        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search)
        {
            return Ok(_getCommand.Execute(search));
        }

        /// <summary>
        /// ( Gets a single User. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Users/3
        ///     {
        ///        "id": 3,
        ///     }
        ///
        /// </remarks>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDto = _getOneCommand.Execute(id);
                return Ok(userDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// ( Creates a User. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Users
        ///     {
        ///        "Username": "Davy123",
        ///        "Email": "david@gmail.com",
        ///        "Password": "davy321"
        ///     }
        ///
        /// </remarks>
        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromQuery]CreateUserDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An Error occured");
            }
        }

        /// <summary>
        /// ( Updates a specific User. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Users/5
        ///     {
        ///        "Username": "Davy123",
        ///        "Email": "david@gmail.com",
        ///        "Password": "davy321"
        ///     }
        ///
        /// </remarks>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery]CreateUserDto dto)
        {
            try
            {
                _updateCommand.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured");
            }
        }

        /// <summary>
        /// ( Deletes a specific User. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Users/8
        ///     {
        ///        "id": "8",
        ///     }
        ///
        /// </remarks>
        // DELETE: api/Users/5
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
