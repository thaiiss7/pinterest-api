namespace Pinterest.Models;

public class Comment
{
    public Guid ID { get; set; }
    public string Text { get; set; }
    public Profile Author { get; set; }
    public Guid AuthorId { get; set; }
    public Pin Pin { get; set; }
    public Guid PinId { get; set; }
}