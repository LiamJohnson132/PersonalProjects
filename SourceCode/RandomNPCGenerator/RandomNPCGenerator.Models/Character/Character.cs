using RandomNPCGenerator.Models.Classes;
using RandomNPCGenerator.Models.Equipment;
using RandomNPCGenerator.Models.Equipment.Armor;
using RandomNPCGenerator.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Models.Character
{
    public class Character
    {
        public int CharacterId { get; set; }
        public int ChallengeRating { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }

        //core
        public RaceBase Race { get; set; }
        public ClassBase Class { get; set; }
        public AbilityScoreSet AbilityScores { get; set; }

        //equipment
        public WeaponBase Weapon { get; set; }
        public ArmorBase Armor { get; set; }
        public ShieldBase Shield { get; set; }

        //view members
        public int BaseAttack { get; set; }
        public int FortSave { get; set; }
        public int RefSave { get; set; }
        public int WillSave { get; set; }
        public int ArmorClass { get; set; }
        public int FlatFootedAC { get; set; }
        public int TouchAC { get; set; }
        public int Speed { get; set; }
        public int WeaponAttack { get; set; }
        public int WeaponDamage { get; set; }
    }
    
}
