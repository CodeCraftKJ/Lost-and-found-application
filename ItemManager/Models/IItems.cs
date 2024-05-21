namespace ItemManager.Models
{
    public interface IItem
    {
        int ItemId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        DateTime Date { get; set; }
        string ContactInfo { get; set; }
    }
}
