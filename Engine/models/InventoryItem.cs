﻿using Engine.Interfaces;

namespace Engine.Models
{
    public class InventoryItem
    {
        public IItem Details { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(IItem details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
