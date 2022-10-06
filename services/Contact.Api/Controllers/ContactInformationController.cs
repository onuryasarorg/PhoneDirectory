using Contact.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactInformationController : ControllerBase
{
    private readonly ILogger<ContactInformationController> _logger;

    public ContactInformationController(ILogger<ContactInformationController> logger)
    {
        _logger = logger;
    }

    [HttpPost("{contactId}/information")]
    public async Task Post(Guid contactId, object informationModel)
    {
        
    }

    [HttpDelete("{contactId}/information/{infoId}")]
    public async Task Delete(Guid contactId, Guid infoId)
    {
    }
}
