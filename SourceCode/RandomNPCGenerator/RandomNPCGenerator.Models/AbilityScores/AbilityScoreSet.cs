using RandomNPCGenerator.Models.AbilityScores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models
{
    public class AbilityScoreSet
    {
        public Strength Strength { get; set; }
        public Dexterity Dexterity { get; set; }
        public Constitution Constitution { get; set; }
        public Intelligence Intelligence { get; set; }
        public Wisdom Wisdom { get; set; }
        public Charisma Charisma { get; set; }
    }
}
