using MilionaireWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionaireWebApp.ViewModels
{
    public class RegisterUserViewModel
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public static User FromViewModel(RegisterUserViewModel viewModel)
        {
            User user = new User()
            {
                Id = viewModel.Id,
                Username = viewModel.Username
            };

            return user;
        }
    }
}
