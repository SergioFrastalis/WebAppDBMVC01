using Microsoft.EntityFrameworkCore;
using WebAppDBMVC01.Core.enums;
using WebAppDBMVC01.Data;

namespace WebAppDBMVC01.Repositories
{
    public class StudentRepository :BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(Mvc01DbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUsersStudentsAsync()
        {
            return await context.Users
                .Where(u => u.UserRole == UserRole.Student)
                .Include(u => u.Student)
                .ToListAsync();
        }

        public async Task<Student?> GetByAm(string? am)
        {
            return await context.Students
                .Where(s => s.Am == am)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int id)
        {
            
            return await context.Students
                .Where(s => s.Id == id)                                
                .SelectMany(s => s.Courses)
                .ToListAsync();
        }
    }
    
    
}
