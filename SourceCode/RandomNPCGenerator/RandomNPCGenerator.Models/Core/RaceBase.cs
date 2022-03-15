using RandomNPCGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Races
{
    public class RaceBase
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public AbilityScoreAdjustment AbilityScoreBonus { get; set; }
        public AbilityScoreAdjustment AbilityScorePenalty { get; set; }
        public int BaseSpeed { get; set; }
        public RaceSize Size { get; set; }
    }
}
