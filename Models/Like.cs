namespace Pinterest.Models;

public class Like
{
    public Guid ID { get; set; }
    public Pin LikedPin { get; set; }
    public Guid PinId { get; set; }
    public Profile LikedByProfile { get; set; }
    public Guid ProfileId { get; set; }
}