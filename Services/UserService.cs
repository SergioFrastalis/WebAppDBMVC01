using AutoMapper;
using WebAppDBMVC01.Core.Filters;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.DTO;
using WebAppDBMVC01.Repositories;

namespace WebAppDBMVC01.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            List<User> users = new List<User>();
            List<Func<User, bool>> predicates = new List<Func<User, bool>>();

            try
            {
                if (!string.IsNullOrEmpty(userFiltersDTO.Username))
                {
                    predicates.Add(u => u.Username == userFiltersDTO.Username);
                }
                if (!string.IsNullOrEmpty(userFiltersDTO.Email))
                {
                    predicates.Add(u => u.Username == userFiltersDTO.Email);

                }
                if (!string.IsNullOrEmpty(userFiltersDTO.UserRole))
                {
                    predicates.Add(u => u.UserRole.ToString() == userFiltersDTO.UserRole);
                }

                users = await _unitOfWork.UserRepository.GetAllUsersFilteredPaginatedAsync( pageNumber, pageSize, predicates);
            }

            catch (Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
            }
            return users;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            User? user = null;

            try
            {
                user = await _unitOfWork.UserRepository.GetByUsernameAsync(username);

            }
            catch (Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
            }
            return user;
        }
        public async Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials)
        {
            User? user;

            try
            {
                user = await _unitOfWork.UserRepository.GetUserAsync(credentials.Username!, credentials.Password!);
                _logger.LogInformation("{Message}", "User: " + user + " found and returned."); //ToDo to String()
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return user;
        }
    }
}
