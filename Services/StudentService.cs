using AutoMapper;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.Repositories;

namespace WebAppDBMVC01.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<StudentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<bool> DeleteStudentAsync(int id)
        {
            bool studentDeleted = false;

            try
            {
                studentDeleted = await _unitOfWork.StudentRepository.DeleteAsync(id);
                _logger.LogInformation("{Message}", "Student with id: " + id + "deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
            }
            return studentDeleted;
        }

   

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            List<User> usersStudents = new List<User>();
            try
            {
                usersStudents = await _unitOfWork.StudentRepository.GetAllUsersStudentsAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return usersStudents;   
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            Student? student = null;

            try
            {
                student = await _unitOfWork.StudentRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message} {Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return student;
        }



        public async Task<int> GetStudentCountAsync()
        {
            int count;

            try
            {
                count = await _unitOfWork.StudentRepository.GetCountAsync();    
            }
            catch (Exception ex)
            {

                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return count;
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int id)
        {
            List<Course> courses = new List<Course>();

            try
            {
                courses = await _unitOfWork.StudentRepository.GetStudentCoursesAsync(id);   
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);   
                throw;
            }
            return courses;
        }
    }
}
