using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using Appeon.DataStoreDemo.Services;

namespace Appeon.DataStoreDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _iloginservice;

        public UserController(ILoginService iloginservice)
        {
            _iloginservice = iloginservice;
        }

        //GET api/User/{userName}/{password}
        [HttpGet("{userName}/{password}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> Login(string userName, string password)
        {
            try
            {
                var result = _iloginservice.UserIsExist(userName);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "The user name ['" + userName + "'] is not exist.");
                }
                result = _iloginservice.Login(userName, password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
