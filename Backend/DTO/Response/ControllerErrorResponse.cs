using System;

namespace Backend.DTO.Response;

public class ControllerErrorResponse
{
    public bool Success = false;
    public List<string> Messages { get; set; }

    public ControllerErrorResponse(string message)
    {
        Messages = [];
        if (!string.IsNullOrWhiteSpace(message))
        {
            Messages.Add(message);
        }
    }

    public ControllerErrorResponse(List<string> messages)
    {
        Messages = messages ?? [];
    }
}
