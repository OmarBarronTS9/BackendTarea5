using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND_TAREA5.Backend;
using BACKEND_TAREA5.DataAccess;
using Microsoft.AspNetCore.Http;
using BACKEND_TAREA5.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new UserSC().GetUser().ToList());
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorException(ex);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(new UserSC().GetUserByID(id));
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorException(ex);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel newUser)
        {
            try
            {
                new UserSC().AddUser(newUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorException(ex);
            }
        }

            // PUT api/<UserController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    new UserSC().DeleteUser(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return ThrowInternalErrorException(ex);
                }
            }

            #region helpers
            private IActionResult ThrowInternalErrorException(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            #endregion
        }
    }

