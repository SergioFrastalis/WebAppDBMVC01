using Microsoft.EntityFrameworkCore;
using WebAppDBMVC01.Core.enums;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.Models;

namespace WebAppDBMVC01.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {   
        public TeacherRepository(Mvc01DbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUsersTeachersAsync()
        {
            var usersWithTeacherRole = await context.Users
                .Where( u => u.UserRole == UserRole.Teacher)
                .Include(u => u.Teacher)
                .ToListAsync();

            return usersWithTeacherRole;
        }

        public async Task<List<User>> GetAllUsersTeachersPaginatedAsync(int pageNumber, int pageSize)
        {   
            int skip = (pageNumber - 1) * pageSize;
            var usersWithTeacherRole = await context.Users
                .Where(u => u.UserRole == UserRole.Teacher)
                .Include(u => u.Teacher)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return usersWithTeacherRole;
        }

        public async Task<Teacher?> GetByPhoneNumberAsync(string? phoneNumber)
        {
            return await context.Teachers.Where(t => t.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public async Task<PaginatedResult<User>> GetPaginatedUsersTeachersAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await context.Users
                .Where(u => u.UserRole == UserRole.Teacher)
                .CountAsync();

            int skip = (pageNumber - 1) * pageSize;
            var usersWithTeacherRole = await context.Users
                .Where(u => u.UserRole == UserRole.Teacher)
                .Include(u => u.Teacher)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<User>
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = usersWithTeacherRole
            };
        }

        public async Task<PaginatedResult<User>> GetPaginatedUsersTeachersFilteredAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates)
        {

            var totalRecords = await context.Users
                .Where(u => u.UserRole == UserRole.Teacher)
                .CountAsync();
            int skip = (pageNumber - 1) * pageSize;

            IQueryable <User> query  = context.Users
                .Where(u => u.UserRole == UserRole.Teacher)
                .Include(u => u.Teacher)
                .Skip(skip)
                .Take(pageSize);

            if (predicates != null && predicates.Any())
            {                
                query = query.Where(u => predicates.All(predicate => predicate(u)));                
            }

            var usersTeachers = await query.ToListAsync();

            return new PaginatedResult<User>
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Data = usersTeachers
            };
        }

        public async Task<List<Course>> GetTeacherCoursesAsync(int id)
        {
            List<Course> courses;

            courses =  await context.Teachers
                .Where(t => t.Id == id)
                .SelectMany(t => t.Courses)
                .ToListAsync();
            return courses;
        }

        public async Task<User?> GetUserTeacherByUsernameAsync(string username)
        {
            var userTeacher = await context.Users
                .Where(u => u.UserRole == UserRole.Teacher && u.Username == username)              
                .SingleOrDefaultAsync();

            return userTeacher;
        }

        
    }
}
