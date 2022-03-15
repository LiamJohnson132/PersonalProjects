using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.AbilityScores
{
    public abstract class AbilityScore
    {
        public int Value { get; set; }
        public int Modifier { get; set; }
        protected int GetModifier()
        {
            decimal mod = (Value - 10) / 2;
            return (int)Math.Floor(mod);
        }
    }
}
