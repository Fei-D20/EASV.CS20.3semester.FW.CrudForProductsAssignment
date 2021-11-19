using EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase

    {
    private readonly IUserAuthenticator _userAuthenticator;

    public LoginController(IUserAuthenticator userAuthenticator)
    {
        _userAuthenticator = userAuthenticator;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post([FromBody] LoginInput model)
    {
        string userToken;
        if (_userAuthenticator.Login(model.Username, model.Password, out userToken))
        {
            //Authentication successful
            return Ok(new
            {
                username = model.Username,
                token = userToken
            });
        }

        return Unauthorized("Unknown username and password combination");
    }
    }
}