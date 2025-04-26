using WebAppDBMVC01.Data;

namespace WebAppDBMVC01.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Student>> GetCourseStudentsAsync(int id);
        Task<Teacher?> GetCourseTeacherAsync(int id);
    }
}
