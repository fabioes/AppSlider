using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Get
{
    public class UserGetService : IUserGetService
    {
        private readonly IUserRepository userRepository;
        
        public UserGetService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> Get(UserGetCommand command)
        {
            var user = await userRepository.Get(command.Id);

            var returnUser = (UserResult)user;

            return returnUser;
        }

        public async Task<UserResult> GetByUsername(String username)
        {
            var user = await userRepository.GetByUsername(username);

            var returnUser = (UserResult)user;

            return returnUser;
        }

        public async Task<List<UserResult>> GetAll()
        {
            var users = await userRepository.GetAll();

            var returnUsers = users.Select(s => (UserResult)s).ToList();
            
            return returnUsers;
        }
    }
}
