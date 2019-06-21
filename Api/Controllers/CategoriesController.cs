using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Threading.Tasks;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Searches;
using Application.Commands;
using Application.Exceptions;
using Application.DTO;

namespace Api.Controllers
{

    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {

        private readonly IGetCategoryCommand _getOneCommand;
        private readonly IGetCategoriesCommand _getCommand;
        private readonly IAddCategoryCommand _addCommand;
        private readonly IDeleteCategoryCommand _deleteCommand;
        private readonly IUpdateCategoryCommand _updateCommand;

        public CategoriesController(IGetCategoryCommand getOneCommand, IGetCategoriesCommand getCommand, IAddCategoryCommand addCommand, IDeleteCategoryCommand deleteCommand, IUpdateCategoryCommand updateCommand)
        {
            _getOneCommand = getOneCommand;
            _getCommand = getCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
        }

        /// <summary>
        /// ( Gets all Categories / Searches Categories with a keyword. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Categories
        ///     {
        ///        "Keyword": Movies,
        ///        "OnlyActive": "true",
        ///     }
        ///
        /// </remarks>
        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery]CategorySearch query)
        => Ok(_getCommand.Execute(query));

        /// <summary>
        /// ( Returns a single Category. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Categories/5
        ///     {
        ///        "id": 4,
        ///     }
        ///
        /// </remarks>
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoryDto = _getOneCommand.Execute(id);
                return Ok(categoryDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch(Exception) {
                return StatusCode(500, "An error occured.");
            }
        }

        /// <summary>
        /// ( Creates a Category. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Categories
        ///     {
        ///        "name": "Games",
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromQuery]CreateCategoryDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return Created("Api/Categories", new CategoryDto {
                    Name = dto.Name
                });
            }
            catch (EntityAlreadyExistsException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        /// <summary>
        /// ( Updates a specific Category. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Categories/3
        ///     {
        ///        "name": "Games",
        ///     }
        ///
        /// </remarks>
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery]CategoryDto dto)
        {
            try
            {
                _updateCommand.Execute(dto);
                return NoContent();
            }
            catch(EntityNotFoundException)
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
        // DELETE: api/Categories/5
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // 505
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured.");
            }
        }
    }
}
