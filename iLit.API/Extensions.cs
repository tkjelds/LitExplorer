using static iLit.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using iLit.Core;
//Credit to Rasmus Lystrøm for the implementation of this Extension class for API's
//rnie@itu.dk

namespace iLit.API
{

    public static class Extensions
    {
        public static IActionResult ToActionResult(this Response response) => response switch
        {
            Created => new NoContentResult(),
            Deleted => new NoContentResult(),
            NotFound => new NotFoundResult(),
            Conflict => new ConflictResult(),
            BadRequest => new BadRequestResult(),
            _ => throw new NotSupportedException($"{response} not supported")
        };

        public static ActionResult<T> ToActionResult<T>(this Option<T> option) where T : class
            => option.IsSome ? option.Value : new NotFoundResult();
    }
}
