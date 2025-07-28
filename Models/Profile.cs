namespace Pinterest.Models;

public class Profile
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ?Bio { get; set; }
    public ICollection<Folder>? Folders { get; set; } = [];
    public ICollection<Pin>? CreatedPins { get; set; } = [];
}