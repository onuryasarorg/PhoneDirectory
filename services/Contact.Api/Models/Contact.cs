namespace Contact.Api.Models;

public class Contact : IValidate
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Firm { get; set; }

    public bool Validate()
    {
        return this.Id != Guid.Empty
            || string.IsNullOrEmpty(this.Name) 
            || string.IsNullOrEmpty(this.Lastname)
            || string.IsNullOrEmpty(this.Firm);
    }
}
