﻿using Engine.Interfaces;

namespace Engine
{
    public class QuestCompletionItem
    {
        public IItem Details { get; set; }
        public int Quantity { get; set; }

        public QuestCompletionItem(IItem details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
