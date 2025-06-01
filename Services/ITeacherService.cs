using WebAppDBMVC01.Data;
using WebAppDBMVC01.DTO;

namespace WebAppDBMVC01.Services
{
    public interface ITeacherService
    {
        Task SignUpUserAsync(TeacherSignupDTO request);
        Task<List<User>> GetAllUsersTeachersAsync();
        Task<List<User>> GetAllUsersTeachersAsync(int pageNumber, int pageSize);
        Task<int> GetTeacherCountAsync();
        Task<User?> GetTeacherByUsernameASync(string username);
    }
}
