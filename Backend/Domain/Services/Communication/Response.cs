using System;

namespace Backend.Domain.Services.Communication;

public class ControllerResponse<T>
{
    public bool Success { get; init; }

    public string? Message { get; init; }

    public T? Resource { get; init; }

    //repon controller jika success
    public ControllerResponse(T source)
    {
        Success = true;
        Message = null;
        Resource = source;
    }

    //respon controller jika fail
    public ControllerResponse(string Message)
    {
        Success = false;
        this.Message = Message;
        Resource = default;
    }
}
