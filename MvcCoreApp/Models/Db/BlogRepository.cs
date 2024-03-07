using Microsoft.EntityFrameworkCore;

namespace MvcCoreApp.Models.Db
{
    public class BlogRepository :IBlogRepository
    {
        public readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.JoinDate = DateTime.Now;

            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
         public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
