using AutoMapper;
using HueFestival.Repositories;
using HueFestival.Models;
using HueFestival.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueFestival.Data;

namespace HueFestival.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IMapper mapper;

        private readonly AuthRepository authRepo;

        public AuthController( AuthRepository authRepo, IMapper mapper)
        {
            this.authRepo = authRepo;
            this.mapper = mapper;
           
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<string> Login(LoginInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (this.authRepo.IsAuthenticated(userModel.Email!, userModel.Password!))
                    {
                        var user = this.authRepo.GetByEmail(userModel.Email!);
                        var token = this.authRepo.GenerateJwtToken(userModel.Email!, user!.Role!);

                        return Ok(Json(token));
                    }
                    return BadRequest("Email or password are not correct!");
                }

                return BadRequest(ModelState);
            }
            catch (Exception)
            {
               
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public Task < ActionResult<string>> Register(RegisterInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userModel.Password != userModel.ConfirmedPassword)
                    {
                        return Task.FromResult<ActionResult<string>>(BadRequest("Passwords does not match!"));
                    }

                    if (this.authRepo.DoesUserExists(userModel.Email!))
                    {
                        return Task.FromResult<ActionResult<string>>(BadRequest("User already exists!"));
                    }
                    var mappedModel = this.mapper.Map<RegisterInputModel, User>(userModel);
                    mappedModel.Role = "User";
                    var user = this.authRepo.RegisterUser(mappedModel);


                    if (user != null)
                    {
                        var token = this.authRepo.GenerateJwtToken(user.Email!, mappedModel.Role);
                        return Task.FromResult<ActionResult<string>>(Ok(Json(token)));

                    }

                    return Task.FromResult<ActionResult<string>>(BadRequest("Email or password are not correct!"));
                }

                return Task.FromResult<ActionResult<string>>(BadRequest(ModelState));
            }
            catch (Exception)
            {
               
                return Task.FromResult<ActionResult<string>>(StatusCode(500));
            }
        }
    }
}