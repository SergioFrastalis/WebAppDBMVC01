namespace WebAppDBMVC01.Repositories
{
    public interface IUnitOfWork
    {
        // ToDo UserRepository

        UserRepository UserRepository { get; }
        TeacherRepository TeacherRepository { get; }
        StudentRepository StudentRepository { get;}
        CourseRepository CourseRepository { get; } 

        Task<bool> SaveAsync();
    }
}
