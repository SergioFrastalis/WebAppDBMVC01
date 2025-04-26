using WebAppDBMVC01.Data;

namespace WebAppDBMVC01.Repositories
{
    internal interface IStudentRepository
    {
        Task<List<Course>> GetStudentCoursesAsync(int id);
        Task<Student?> GetByAm(string? am);
        Task<List<User>> GetAllUsersStudentsAsync();

    }
}