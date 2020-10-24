using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static IEnumerable<string> Errors(this ModelStateDictionary modelState) =>
            modelState
                .Values
                .SelectMany(e => e.Errors)
                .Select(e => e.ErrorMessage);
    }
}
