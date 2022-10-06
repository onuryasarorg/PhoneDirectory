using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(Enumerable.Empty<Models.Contact>());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Models.Contact contractModel)
    {
        return Ok();
    }

    [HttpPut("{contactId}")]
    public async Task<IActionResult> Put(Guid contactId, Models.Contact contractModel)
    {
        return NoContent();
    }

    [HttpDelete("{contactId}")]
    public async Task<IActionResult> Delete(Guid contactId)
    {
        return NoContent();
    }
}
