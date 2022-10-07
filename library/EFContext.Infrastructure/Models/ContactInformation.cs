namespace EFContext.Infrastructure.Models;

public class Contact
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Firm { get; set; }
}
