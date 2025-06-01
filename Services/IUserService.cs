using WebAppDBMVC01.Core.Filters;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.DTO;

namespace WebAppDBMVC01.Services
{
    public interface IUserService
    {   


        Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize, UserFiltersDTO userFiltersDTO);
    }
}
