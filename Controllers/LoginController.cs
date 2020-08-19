using ERPSysterm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IActionResult Login(string UserName, string Pwd)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Pwd))
            {
                return Ok(new
                {
                    token = Const.GetToken(UserName)
                }) ;
            }
            else
            {
                return BadRequest(new { message = "username or password is incorrect." });
            }
        }
    }
}
