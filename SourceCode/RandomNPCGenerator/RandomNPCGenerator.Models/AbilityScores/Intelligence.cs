using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.AbilityScores
{
    public class Intelligence : AbilityScore
    {
        public Intelligence(int value)
        {
            Value = value;
            Modifier = GetModifier();
        }
    }
}
