
using WebAppDBMVC01.Data;

namespace WebAppDBMVC01.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Mvc01DbContext _context;

        public UnitOfWork(Mvc01DbContext context)
        {
            _context = context;
        }

        public TeacherRepository TeacherRepository => new(_context);        

        public StudentRepository StudentRepository => new(_context);

        public CourseRepository CourseRepository => new(_context);

        public UserRepository UserRepository => new(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;   
        }
    }
}
