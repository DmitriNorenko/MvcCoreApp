﻿namespace MvcCoreApp.Models.Db
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User []> GetUsers();
    }
}
