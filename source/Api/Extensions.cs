using Microsoft.AspNetCore.Mvc;

namespace AlphaCentauri.Api;

public static class Extensions
{
    public static IActionResult DeleteActionResult(this CrossCutting.IResult result) => result.BaseResult();

    public static IActionResult GetActionResult<T>(this T result) => result is null || (result is IEnumerable<dynamic> enumerable && !enumerable.Any()) ? new NoContentResult() : new OkObjectResult(result);

    public static IActionResult PatchActionResult(this CrossCutting.IResult result) => result.BaseResult();

    public static IActionResult PostActionResult<T>(this CrossCutting.IResult<T> result) => result.Failed ? new BadRequestObjectResult(result.Message) : new OkObjectResult(result.Data);

    public static IActionResult PutActionResult(this CrossCutting.IResult result) => result.BaseResult();

    private static IActionResult BaseResult(this CrossCutting.IResult result) => result.Failed ? new BadRequestObjectResult(result.Message) : new OkResult();
}
