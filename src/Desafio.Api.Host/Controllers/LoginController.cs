using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LoginController : ControllerBase
  {
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok("Ok");
    }
  }
}
