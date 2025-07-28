namespace Pinterest.Models;

public class Pasta
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public Guid ProfileID { get; set; }
    public Profile Author { get; set; }
    public ICollection<Pin> Pins { get; set; } = [];
}