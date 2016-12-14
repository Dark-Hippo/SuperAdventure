using Engine.Interfaces;

namespace Engine.Models
{
    public class Weapon : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int id, string name, string namePlural, int minimumDamage, int maximumDamage)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
