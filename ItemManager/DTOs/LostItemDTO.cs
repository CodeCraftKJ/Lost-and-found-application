﻿namespace ItemManager.DTOs
{
    public class LostItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string ContactInfo { get; set; }
    }
}
