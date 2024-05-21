using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemManager.Models.LostItems
{
    [Table("LostItems")]
    public class LostItem(int itemId, string name, string description, string location, DateTime date, string contactInfo) : IItem
    {
        [Key]
        public int ItemId { get; set; } = itemId;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = name;

        [MaxLength(100)]
        public string Description { get; set; } = description;

        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = location;

        [Required]
        public DateTime Date { get; set; } = date;

        [Required]
        [MaxLength(50)]
        public string ContactInfo { get; set; } = contactInfo;
    }
}
