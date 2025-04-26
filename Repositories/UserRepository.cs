using Microsoft.EntityFrameworkCore;
using WebAppDBMVC01.Data;
using WebAppDBMVC01.Security;

namespace WebAppDBMVC01.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(Mvc01DbContext context) : base(context) 
        { 
        }

        public Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize) 
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsersFilteredPaginatedAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates)
        {
            int skip = (pageNumber - 1) * pageSize;
            IQueryable<User> query = context.Users.Skip(skip).Take(pageSize);

            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }
            return await query.ToListAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserAsync(string username, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u =>
            (u.Username == username || u.Email == username) && 
            EncryptionUtil.isValidPassword(password, u.Password));
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            if (existingUser.Id != id)
            {
                return null;
            }

            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            return existingUser;
        }
    }
}
