using AutoMapper;
using WebAppDBMVC01.Repositories;

namespace WebAppDBMVC01.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
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


        public UserService UserService => new(_unitOfWork, _mapper, _logger );

        public TeacherService TeacherService => throw new NotImplementedException();

        public StudentService StudentService => throw new NotImplementedException();
    }
}
