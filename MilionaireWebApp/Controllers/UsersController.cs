using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilionaireWebApp.Models;
using MilionaireWebApp.Repository;
using MilionaireWebApp.ViewModels;

namespace MilionaireWebApp.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;

        public UsersController(RestApiDbContext dbContext)
        {
            _userRepository = new UserRepository(dbContext);
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserViewModel viewModel)
        {
            var user = RegisterUserViewModel.FromViewModel(viewModel);

            if (_userRepository.UsernameExists(user.Username))
            {
                ModelState.AddModelError("userExists", "Ka ydoric");
                return BadRequest(ModelState);
            }
            else
            {
                _userRepository.Add(user);
                return Ok();
            }

        }
    }
}