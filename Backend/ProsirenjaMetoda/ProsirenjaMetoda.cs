using System;

namespace Backend.ProsirenjaMetoda
{
    public static class ProsirenjaMetoda
    {
        public static DateTime SkratiMilisekunde(this DateTime vreme)
        {
            return vreme.AddTicks(-(vreme.Ticks % TimeSpan.TicksPerSecond));
        }
    }
}