using EveryDaily.Core.ControllerBases;
using EveryDaily.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EveryDaily.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : CustomControllerBase
{
    
    [HttpGet("helloworld")]
    public IActionResult Get()
    {
        var response = Response<string>.Success("Hello World", 200);
        return CreateActionResultInstance(response);
    }
}