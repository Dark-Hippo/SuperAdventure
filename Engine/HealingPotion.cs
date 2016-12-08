using Engine.Interfaces;

namespace Engine
{
    public class HealingPotion : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, int amountToHeal)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            AmountToHeal = amountToHeal;
        }
    }
}
