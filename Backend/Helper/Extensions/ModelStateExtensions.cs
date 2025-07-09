using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backend.Helper.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessage(this ModelStateDictionary dictionary) =>
        dictionary.SelectMany(m => m.Value!.Errors).Select(m => m.ErrorMessage).ToList();
}
