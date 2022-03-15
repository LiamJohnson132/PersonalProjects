using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.Models.Equipment;
using RandomNPCGenerator.Models.Equipment.Armor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Classes
{
    public class ClassBase
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int HitDie { get; set; }
        public BAB BaseAttackBonus { get; set; }
        public Save FortSave { get; set; }
        public Save RefSave { get; set; }
        public Save WillSave { get; set; }
        public List<ArmorBase> ArmorProficiencies { get; set; }
        public List<ShieldBase> ShieldProficiencies { get; set; }
        public List<WeaponBase> WeaponProficiencies { get; set; }
    }
}
