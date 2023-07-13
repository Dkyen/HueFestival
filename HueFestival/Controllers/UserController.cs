namespace HueFestival.Controllers
{
    
    using HueFestival.Repositories;
    using HueFestival.Models;
    using HueFestival.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
  
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger logger;
        private readonly AuthRepository authRepository;

        public UserController(ILogger _logger, AuthRepository _authRepository)
        {
           logger= _logger;
           authRepository= _authRepository;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<User[]> GetAll()
        {
            try
            {
                var users = authRepository.GetAll();
                return Ok(users);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPost("Role")]
        public ActionResult<User> ChangeRole(UserChangeRoleInputModel model)
        {
            try
            {
                var user = authRepository.ChangeRole(model.Email!, model.Role!);
                return Ok(user);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
        }

        


    }
}
