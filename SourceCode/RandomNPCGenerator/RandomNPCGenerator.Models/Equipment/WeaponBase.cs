using RandomNPCGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Equipment
{
    public class WeaponBase
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public WeaponRarity Rarity { get; set; }
        public WeaponType Type { get; set; }
        public bool IsDouble { get; set; }
        public List<int> DamageDice { get; set; }
        public int CriticalThreatRange { get; set; }
        public int CriticalDamageMultiplier { get; set; }
        public int RangeIncrement { get; set; }
        public List<DamageType> DamageTypes { get; set; }
        public bool IsFinesse { get; set; }
        public bool IsThrown { get; set; }
    }
}
