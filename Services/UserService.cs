using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;

namespace foodrecipe.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}
