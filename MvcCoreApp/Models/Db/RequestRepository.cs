using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCoreApp.Models.Db
{
    public class RequestRepository : IRequestRepository
    {
        public readonly BlogContext _context;
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddLog(string url)
        {
            Request request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url
            };
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
        public async Task<Request[]> ShowLog()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
