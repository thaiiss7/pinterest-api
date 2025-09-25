namespace Pinterest.Models;

public class Pin
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Picture { get; set; }
    public Guid ProfileID { get; set; }
    public Profile Author { get; set; }
    public ICollection<Folder> Folders { get; set; } = [];
    public ICollection<Like> Likes { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}