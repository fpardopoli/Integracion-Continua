using Api.User.Core.ContextSqlServerDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Core.Dto;
using User.Core.Parameter;

namespace User.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ContextSqlServerDB _context;

        public UserController(ContextSqlServerDB context)
        {
            _context = context;
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<List<UserDto>>> GetUser()
        {
            try
            {
                List<UserDto> ToLisUser = await (from Us in _context.User
                                                 where Us.Id != 0
                                                 select new UserDto
                                                 {
                                                     Id = Us.Id,
                                                     Identification = Us.Identification,
                                                     Mail = Us.Mail,
                                                     Name = Us.Name,
                                                 }
                                                 ).ToListAsync();

                return Ok(ToLisUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex?.Message}");
            }


        }


        [HttpPost("SaveUser")]
        public async Task<ActionResult<string[]>> SaveUser(ParameterUser ParameterUser)
        {
            try
            {
                string[] svRta = new string[1];
                Api.User.Core.Entities.User? user = new()
                {
                    Identification = ParameterUser.Identification,
                    Mail = ParameterUser.Mail,
                    Name = ParameterUser.Name,
                };
                _context.User.AddRange(user!);
                int Ire = await _context.SaveChangesAsync();
                if (Ire > 0)
                {
                    svRta = new string[] { "Guardo felix3 correctamente." };
                }
                else
                {
                    svRta = new string[] { "El registro no se guardo." };
                }
                return Ok(svRta);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex?.Message}");
            }
        }


        [HttpPut("UpdateUser")]
        public async Task<ActionResult<string[]>> UpdateUser(ParameterUser ParameterUser)
        {
            try
            {
                string[] svRta = new string[1];
                Api.User.Core.Entities.User? user = await _context.User.Where(x => x.Identification.Equals(ParameterUser.Identification)).FirstOrDefaultAsync();
                if (user == null)
                {
                    return svRta = new string[] { $"Usuario no existe." };
                }
                user.Mail = ParameterUser.Mail;
                user.Name = ParameterUser.Name;
                _context.User.UpdateRange(user!);
                int Ire = await _context.SaveChangesAsync();
                if (Ire > 0)
                {svRta = new string[] { "Actualizó correctamente." };}
                else
                {svRta = new string[] { "El registro no se actualizó." };}
                return Ok(svRta);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex?.Message}");
            }
        }
    }
}
