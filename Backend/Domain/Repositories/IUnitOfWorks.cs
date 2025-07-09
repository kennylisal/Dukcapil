using System;

namespace Backend.Domain.Repositories;

public interface IUnitOfWorks
{
    Task<bool> CompleteAsync();
}
