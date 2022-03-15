using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Equipment
{
    public class ShieldBase
    {
        public int ShieldId { get; set; }
        public string Name { get; set; }
        public int ShieldBonus { get; set; }
        public int MaxDexBonus { get; set; }
        public int ArmorCheckPenalty { get; set; }
        public int ArcaneSpellFailure { get; set; }
    }
}
