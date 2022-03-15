using NPCGenerator.Data;
using NPCGenerator.Data.Core;
using NPCGenerator.Data.Equipment;
using NPCGenerator.Data.SaveFiles;
using NUnit.Framework;
using RandomNPCGenerator.Models;
using RandomNPCGenerator.Models.AbilityScores;
using RandomNPCGenerator.Models.Character;
using RandomNPCGenerator.Models.Classes;
using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.Models.Equipment;
using RandomNPCGenerator.Models.Equipment.Armor;
using RandomNPCGenerator.Models.Races;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Tests
{
    [TestFixture]
    class DataTests
    {
        [SetUp]
        public void SetUp()
        {
            if (File.Exists(SavePath.GetPath() + "characters/chars.txt"))
            {
                using (StreamWriter sw = new StreamWriter(SavePath.GetPath() + "characters/chars.txt"))
                {
                    sw.WriteLine("Id|CR|Lvl|HP|RaceId|ClassId|AbilityScores,etc|WeaponId|ArmorId|ShieldId");
                    sw.WriteLine("0|1|1|4|0|0|10,10,10,10,10,10|0|0|0");
                    sw.WriteLine("1|15|20|240|0|1|18,18,18,18,18,18|44|12|0");
                }
            }
        }
        [TearDown]
        public void CleanUp()
        {
            if (File.Exists(SavePath.GetPath() + "characters/chars.txt"))
            {
                using (StreamWriter sw = new StreamWriter(SavePath.GetPath() + "characters/chars.txt"))
                {
                    sw.WriteLine("Id|CR|Lvl|HP|RaceId|ClassId|AbilityScores,etc|WeaponId|ArmorId|ShieldId");
                    sw.WriteLine("0|1|1|4|0|0|10,10,10,10,10,10|0|0|0");
                    sw.WriteLine("1|15|20|240|0|1|18,18,18,18,18,18|44|12|0");
                }
            }
        }

        [Test]
        public void CanLoadAllArmors()
        {
            var repo = new ArmorRepository();

            var armors = repo.GetAll();

            Assert.AreEqual(13, armors.Count());
            Assert.AreEqual("Unarmored", armors[0].Name);
            Assert.AreEqual("Padded", armors[1].Name);
            Assert.AreEqual("Hide", armors[5].Name);
            Assert.AreEqual("Splint Mail", armors[9].Name);
        }

        [Test]
        public void CanLoadArmorById()
        {
            var repo = new ArmorRepository();

            var armor = repo.GetById(9);

            Assert.AreEqual(9, armor.ArmorId);
            Assert.AreEqual(ArmorType.Heavy, armor.ArmorType);
            Assert.AreEqual("Splint Mail", armor.Name);
            Assert.AreEqual(6, armor.ArmorBonus);
            Assert.AreEqual(0, armor.MaxDexBonus);
            Assert.AreEqual(-7, armor.ArmorCheckPenalty);
            Assert.AreEqual(40, armor.ArcaneSpellFailure);
        }

        [Test]
        public void CanLoadAllMediumWeapons()
        {
            var repo = new WeaponMediumRepository();

            var weapons = repo.GetAll();

            Assert.AreEqual(54, weapons.Count());
            Assert.AreEqual(37, weapons[37].WeaponId);
            Assert.AreEqual("Flail", weapons[30].Name);
            Assert.IsTrue(weapons[12].IsDouble);
            Assert.AreEqual(2, weapons[39].DamageDice.Count());
            Assert.AreEqual(2, weapons[49].DamageTypes.Count());
        }

        [Test]
        public void CanLoadMediumWeaponById()
        {
            var repo = new WeaponMediumRepository();

            var weapon = repo.GetById(12);

            Assert.AreEqual(12, weapon.WeaponId);
            Assert.AreEqual("Quarterstaff", weapon.Name);
            Assert.AreEqual(WeaponType.TwoHanded, weapon.Type);
            Assert.AreEqual(WeaponRarity.Simple, weapon.Rarity);
            Assert.IsTrue(weapon.IsDouble);
            Assert.AreEqual(2, weapon.DamageDice.Count());
            Assert.AreEqual(1, weapon.CriticalThreatRange);
            Assert.AreEqual(2, weapon.CriticalDamageMultiplier);
            Assert.AreEqual(0, weapon.RangeIncrement);
            Assert.AreEqual(DamageType.Bludgeoning, weapon.DamageTypes[0]);
            Assert.IsFalse(weapon.IsFinesse);
            Assert.IsFalse(weapon.IsThrown);
        }

        [Test]
        public void CanLoadAllSmallWeapons()
        {
            var repo = new WeaponSmallRepository();

            var weapons = repo.GetAll();

            Assert.AreEqual(54, weapons.Count());
            Assert.AreEqual(37, weapons[37].WeaponId);
            Assert.AreEqual("Flail", weapons[30].Name);
            Assert.IsTrue(weapons[12].IsDouble);
            Assert.AreEqual(1, weapons[39].DamageDice.Count());
            Assert.AreEqual(2, weapons[49].DamageTypes.Count());
            Assert.IsTrue(weapons[0].IsFinesse);
            Assert.IsFalse(weapons[0].IsThrown);
        }

        [Test]
        public void CanLoadSmallWeaponById()
        {
            var repo = new WeaponSmallRepository();

            var weapon = repo.GetById(12);

            Assert.AreEqual(12, weapon.WeaponId);
            Assert.AreEqual("Quarterstaff", weapon.Name);
            Assert.AreEqual(WeaponType.TwoHanded, weapon.Type);
            Assert.AreEqual(WeaponRarity.Simple, weapon.Rarity);
            Assert.IsTrue(weapon.IsDouble);
            Assert.AreEqual(2, weapon.DamageDice.Count());
            Assert.AreEqual(4, weapon.DamageDice[0]);
            Assert.AreEqual(1, weapon.CriticalThreatRange);
            Assert.AreEqual(2, weapon.CriticalDamageMultiplier);
            Assert.AreEqual(0, weapon.RangeIncrement);
            Assert.AreEqual(DamageType.Bludgeoning, weapon.DamageTypes[0]);
        }

        [Test]
        public void CanLoadAllShields()
        {
            var repo = new ShieldRepository();

            var shields = repo.GetAll();

            Assert.AreEqual(7, shields.Count());
            Assert.AreEqual(4, shields[4].ShieldId);
            Assert.AreEqual("Heavy Wooden Shield", shields[4].Name);
            Assert.AreEqual(2, shields[4].ShieldBonus);
            Assert.AreEqual(50, shields[4].MaxDexBonus);
            Assert.AreEqual(-2, shields[4].ArmorCheckPenalty);
            Assert.AreEqual(15, shields[4].ArcaneSpellFailure);
        }

        [Test]
        public void CanLoadShieldById()
        {
            var repo = new ShieldRepository();

            var shield = repo.GetById(4);

            Assert.AreEqual(4, shield.ShieldId);
            Assert.AreEqual("Heavy Wooden Shield", shield.Name);
            Assert.AreEqual(2, shield.ShieldBonus);
            Assert.AreEqual(50, shield.MaxDexBonus);
            Assert.AreEqual(-2, shield.ArmorCheckPenalty);
            Assert.AreEqual(15, shield.ArcaneSpellFailure);
        }

        [Test]
        public void CanLoadAllRaces()
        {
            var repo = new RaceRepository();

            var races = repo.GetAll();

            Assert.AreEqual(7, races.Count());
            Assert.AreEqual(AbilityScoreAdjustment.Dexterity, races[2].AbilityScoreBonus);
            Assert.AreEqual(AbilityScoreAdjustment.Charisma, races[5].AbilityScorePenalty);
            Assert.AreEqual(RaceSize.Small, races[6].Size);
        }

        [Test]
        public void CanLoadAllClasses()
        {
            var repo = new ClassRepository();
            var raceRepo = new RaceRepository();
            var race = raceRepo.GetById(2);

            var classes = repo.GetAll(race);

            Assert.AreEqual(5, classes.Count());
            Assert.AreEqual("Expert", classes[2].Name);
            Assert.AreEqual(54, classes[1].WeaponProficiencies.Count());
            Assert.AreEqual(13, classes[1].ArmorProficiencies.Count());
            Assert.AreEqual(7, classes[1].ShieldProficiencies.Count());
        }

        [Test]
        public void CanLoadClassById()
        {
            var repo = new ClassRepository();
            var raceRepo = new RaceRepository();
            var race = raceRepo.GetById(2);

            var classFound = repo.GetById(race, 1);

            Assert.AreEqual("Warrior", classFound.Name);
            Assert.AreEqual(54, classFound.WeaponProficiencies.Count());
            Assert.AreEqual(13, classFound.ArmorProficiencies.Count());
            Assert.AreEqual(7, classFound.ShieldProficiencies.Count());
        }

        [Test]
        public void CanLoadShieldByName()
        {
            var repo = new ShieldRepository();

            List<ShieldBase> shields = repo.GetByName("Light");
            Assert.AreEqual(2, shields.Count());

            shields = repo.GetByName("Heavy");
            Assert.AreEqual(2, shields.Count());

            shields = repo.GetByName("No Shield");
            Assert.AreEqual(1, shields.Count());

            shields = repo.GetByName("Buckler");
            Assert.AreEqual(1, shields.Count());
        }

        [Test]
        public void CanLoadCharacters()
        {
            var repo = new CharacterRepository();

            var chars = repo.GetAll();

            Assert.AreEqual(2, chars.Count());
            Assert.AreEqual(4, chars[0].HitPoints);
            Assert.AreEqual(240, chars[1].HitPoints);
        }

        [TestCase(0, 4)]
        [TestCase(1, 240)]
        public void CanLoadCharacterById(int param, int hp)
        {
            var repo = new CharacterRepository();

            var character = repo.GetById(param);

            Assert.AreEqual(hp, character.HitPoints);
        }

        [Test]
        public void CanInsertCharacter()
        {
            var repo = new CharacterRepository();

            var character = new Character()
            {
                CharacterId = 2,
                ChallengeRating = 2,
                Level = 3,
                HitPoints = 9,
                Race = new RaceBase(),
                Class = new ClassBase(),
                AbilityScores = new AbilityScoreSet()
                {
                    Strength = new Strength(8),
                    Dexterity = new Dexterity(8),
                    Constitution = new Constitution(8),
                    Intelligence = new Intelligence(8),
                    Wisdom = new Wisdom(8),
                    Charisma = new Charisma(8),
                },
                Weapon = new WeaponBase(),
                Armor = new ArmorBase(),
                Shield = new ShieldBase()
            };
            character.Race.RaceId = 0;
            character.Class.ClassId = 0;
            character.Weapon.WeaponId = 0;
            character.Armor.ArmorId = 0;
            character.Shield.ShieldId = 0;

            repo.Insert(character);

            var found = repo.GetById(2);

            Assert.AreEqual(character.CharacterId, found.CharacterId);
            Assert.AreEqual(character.HitPoints, found.HitPoints);
            Assert.AreEqual(character.AbilityScores.Strength.Value, found.AbilityScores.Strength.Value);
        }

        [Test]
        public void CanDeleteCharacter()
        {
            var repo = new CharacterRepository();

            repo.Delete(0);

            var found = repo.GetAll();

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanUpdateCharacter()
        {
            var repo = new CharacterRepository();

            var character = new Character()
            {
                CharacterId = 0,
                ChallengeRating = 2,
                Level = 3,
                HitPoints = 9,
                Race = new RaceBase(),
                Class = new ClassBase(),
                AbilityScores = new AbilityScoreSet()
                {
                    Strength = new Strength(8),
                    Dexterity = new Dexterity(8),
                    Constitution = new Constitution(8),
                    Intelligence = new Intelligence(8),
                    Wisdom = new Wisdom(8),
                    Charisma = new Charisma(8),
                },
                Weapon = new WeaponBase(),
                Armor = new ArmorBase(),
                Shield = new ShieldBase()
            };
            character.Race.RaceId = 0;
            character.Class.ClassId = 0;
            character.Weapon.WeaponId = 0;
            character.Armor.ArmorId = 0;
            character.Shield.ShieldId = 0;

            repo.Update(character);

            var found = repo.GetById(0);

            Assert.AreEqual(2, found.ChallengeRating);
            Assert.AreEqual(9, found.HitPoints);
            Assert.AreEqual(8, found.AbilityScores.Strength.Value);
        }
    }
}
