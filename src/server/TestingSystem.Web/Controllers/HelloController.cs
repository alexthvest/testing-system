using System;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetResponse()
    {
        return Ok("Hello, World");
    }
}
