namespace Contact.Api.Models;

public class ContactLocation
{
    public Guid ContactId { get; set; }
    public string Lat { get; set; }
    public string Long { get; set; }
}
