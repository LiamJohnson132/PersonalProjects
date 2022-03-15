using RandomNPCGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Equipment.Armor
{
    public class ArmorBase
    {
        public int ArmorId { get; set; }
        public string Name { get; set; }
        public ArmorType ArmorType { get; set; }
        public int ArmorBonus { get; set; }
        public int MaxDexBonus { get; set; }
        public int ArmorCheckPenalty { get; set; }
        public int ArcaneSpellFailure { get; set; }
    }
}
