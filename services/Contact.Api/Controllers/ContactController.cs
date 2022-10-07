using EFContext.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly DBContext dBContext;

    public ContactController(ILogger<ContactController> logger,
        DBContext dBContext)
    {
        _logger = logger;
        this.dBContext = dBContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await dBContext.GetContacts());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Models.Contact contractModel)
    {
        if (!contractModel.Validate())
        {
            return BadRequest("Invalid item of object");
        }
        await ProducerHelper.CreateContact(contractModel);
        return NoContent();
    }

    [HttpPut("{contactId}")]
    public async Task<IActionResult> Put(Guid contactId, Models.Contact contractModel)
    {
        if (!contractModel.Validate())
        {
            return BadRequest("Invalid item of object");
        }

        if (await dBContext.GetContactById(contactId).IsNotFound())
            return BadRequest();

        await ProducerHelper.UpdateContact(contractModel);
        return NoContent();
    }

    [HttpDelete("{contactId}")]
    public async Task<IActionResult> Delete(Guid contactId)
    {
        if (await dBContext.GetContactById(contactId).IsNotFound())
            return BadRequest();

        await ProducerHelper.DeleteContact(contactId);
        return NoContent();
    }
}
