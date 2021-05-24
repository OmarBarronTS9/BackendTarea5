using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BACKEND_TAREA5.Models;
using BACKEND_TAREA5.Backend;
using Microsoft.AspNetCore.Http;
using BACKEND_TAREA5.DataAccess;
using BACKEND_TAREA5;

namespace API_USER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginRequest loginRequest) 
        {
            if (loginRequest == null)
            {
                return BadRequest();
            }
            try
            {
                Usuario user = new UserSC().GetUserByUsername(loginRequest.Username);
                if(user.Contraseña == loginRequest.Password)
                {
                    var token = TokenGenerator.GenerateTokenJWT(loginRequest.Username);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorException(ex);
            }
        }

        private IActionResult ThrowInternalErrorException(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}