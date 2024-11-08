﻿using answer.Models.Domain;

namespace answer.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllAsync();
        Task<Group?> GetByIdAsync(int id);
    }
}
