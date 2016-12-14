using Engine.Interfaces;
using Engine.Models;
using System.Collections.Generic;

namespace Engine
{
    public class Monster
    {
        public IHitPoints HitPoints { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Monster(int id, string name, int maximumDamage, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints)
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            HitPoints.Current = currentHitPoints;
            HitPoints.Maximum = maximumDamage;
            LootTable = new List<LootItem>();
        }
    }
}
