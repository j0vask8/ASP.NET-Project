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
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private IGetRolesCommand _getCommand;
        private IGetRoleCommand _getOneCommand;

        public RolesController(IGetRolesCommand getCommand, IGetRoleCommand getOneCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
        }

        /// <summary>
        /// ( Gets all Roles. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Roles
        ///     {
        ///     }
        ///
        /// </remarks>
        // GET: api/Roles
        [HttpGet]
        public IActionResult Get([FromQuery]RoleSearch dto)
        {
            try
            {
                var roles = _getCommand.Execute(dto);
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured");
            }
        }

        /// <summary>
        /// ( Gets a single Roles. )
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Roles/3
        ///     {
        ///        "id": 3,
        ///     }
        ///
        /// </remarks>
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var roles = _getOneCommand.Execute(id);
                return Ok(roles);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
                //return StatusCode(500, "An error occured");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured");
            }
        }
        
    }
}
