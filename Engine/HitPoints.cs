using System;
using Engine.Interfaces;

namespace Engine
{
    public class HitPoints : IHitPoints
    {
        public int Current { get; set; }
        public int Maximum { get; set; }

        public HitPoints(int currentHitPoints, int maximumHitPoints)
        {
            Current = currentHitPoints;
            Maximum = maximumHitPoints;
        }
    }
}
