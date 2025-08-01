namespace Pinterest.Models;

public class Folder
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string ?Picture { get; set;}
    public Guid ProfileID { get; set; }
    public Profile Author { get; set; }
    public ICollection<Pin> Pins { get; set; } = [];
}