using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.AbilityScores
{
    public class Strength : AbilityScore
    {
        public Strength(int value)
        {
            Value = value;
            Modifier = GetModifier();
        }
    }
}
