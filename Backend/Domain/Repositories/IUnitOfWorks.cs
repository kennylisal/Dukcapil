using System;
using Backend.Domain.Services.Communication;

namespace Backend.Domain.Repositories;

public interface IUnitOfWorks
{
    Task<bool> CompleteAsync();

    // Task<T> CompleteAsync<T>(string operasi, string namaTabel, T obj);
    Task<ControllerResponse<T>> CompleteAsync<T>(string operasi, string namaTabel, T obj);
    // void tesFungsi<T>(string message);
}
