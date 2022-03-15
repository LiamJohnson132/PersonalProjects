using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.AbilityScores
{
    public class Dexterity : AbilityScore
    {
        public Dexterity(int value)
        {
            Value = value;
            Modifier = GetModifier();
        }
    }
}
