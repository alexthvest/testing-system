using System;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetResponse()
    {
        return Ok("Hello, World");
    }
}
