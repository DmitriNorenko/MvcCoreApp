namespace MvcCoreApp.Models.Db
{
    public interface IRequestRepository
    {
        Task AddLog(string url);
        Task<Request[]> ShowLog();
    }
}
