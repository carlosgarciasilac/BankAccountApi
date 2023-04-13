using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly ILogger<BankAccountController> _logger;

    public BankAccountController(ILogger<BankAccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("TestGet")]
    public IActionResult TestGet()
    {
        // TODO: Implement endpoint
        return Ok();
    }
}