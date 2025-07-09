using System;
using Backend.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Config;

public static class InvalidModelStateResponseFactory
{
    public static IActionResult ProduceErrorResponse(ActionContext context)
    {
        var errors = context
            .ModelState.SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
        var response = new ControllerErrorResponse(errors);
        return new BadRequestObjectResult(response);
    }
}
