using NPCGenerator.Data;
using NPCGenerator.Data.Core;
using NPCGenerator.Data.Equipment;
using NPCGenerator.Data.Factories;
using RandomNPCGenerator.Models.AbilityScores;
using RandomNPCGenerator.Models.Classes;
using RandomNPCGenerator.Models.Enums;
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
    public class CharacterFactory
    {
        private Random _random = new Random();
        private Character _character = new Character();
        // character create function
        public Character RollCharacter(int challengeRating)
        {
            _character.ChallengeRating = challengeRating;
            _character.Level = GetLevel(challengeRating);
            _character.AbilityScores = GetAbilityScores();
            _character.Race = GetRace();

            // apply ability bonus
            switch (_character.Race.AbilityScoreBonus)
            {
                case AbilityScoreAdjustment.None:
                    break;
                case AbilityScoreAdjustment.Strength:
                    _character.AbilityScores.Strength = new Strength(_character.AbilityScores.Strength.Value + 2);
                    break;
                case AbilityScoreAdjustment.Dexterity:
                    _character.AbilityScores.Dexterity = new Dexterity(_character.AbilityScores.Dexterity.Value + 2);
                    break;
                case AbilityScoreAdjustment.Constitution:
                    _character.AbilityScores.Constitution = new Constitution(_character.AbilityScores.Constitution.Value + 2);
                    break;
                case AbilityScoreAdjustment.Intelligence:
                    _character.AbilityScores.Intelligence = new Intelligence(_character.AbilityScores.Intelligence.Value + 2);
                    break;
                case AbilityScoreAdjustment.Wisdom:
                    _character.AbilityScores.Wisdom = new Wisdom(_character.AbilityScores.Wisdom.Value + 2);
                    break;
                case AbilityScoreAdjustment.Charisma:
                    _character.AbilityScores.Charisma = new Charisma(_character.AbilityScores.Charisma.Value + 2);
                    break;
                default:
                    throw new Exception("Error: Ability Score adjustment is invalid");
            }
            // apply ability penalty
            switch (_character.Race.AbilityScorePenalty)
            {
                case AbilityScoreAdjustment.None:
                    break;
                case AbilityScoreAdjustment.Strength:
                    _character.AbilityScores.Strength = new Strength(_character.AbilityScores.Strength.Value - 2);
                    break;
                case AbilityScoreAdjustment.Dexterity:
                    _character.AbilityScores.Dexterity = new Dexterity(_character.AbilityScores.Dexterity.Value - 2);
                    break;
                case AbilityScoreAdjustment.Constitution:
                    _character.AbilityScores.Constitution = new Constitution(_character.AbilityScores.Constitution.Value - 2);
                    break;
                case AbilityScoreAdjustment.Intelligence:
                    if (!(_character.AbilityScores.Intelligence.Value - 2 < 3))
                    {
                        _character.AbilityScores.Intelligence = new Intelligence(_character.AbilityScores.Intelligence.Value - 2);
                    }
                    break;
                case AbilityScoreAdjustment.Wisdom:
                    _character.AbilityScores.Wisdom = new Wisdom(_character.AbilityScores.Wisdom.Value - 2);
                    break;
                case AbilityScoreAdjustment.Charisma:
                    _character.AbilityScores.Charisma = new Charisma(_character.AbilityScores.Charisma.Value - 2);
                    break;
                default:
                    throw new Exception("Error: Ability Score adjustment is invalid");
            }

            _character.Class = GetClass();
            _character.Weapon = ChooseWeapon(_character.Class.WeaponProficiencies);
            _character.Shield = ChooseShield(_character.Class.ShieldProficiencies);
            _character.Armor = ChooseArmor(_character.Class.ArmorProficiencies);
            _character.HitPoints = RollHitPoints();

            return _character;
        }
        // generate character members
        private int GetLevel(int challengeRating)
        {
            int level = (challengeRating * 4) / 3;
            if ((challengeRating - 1) % 3 == 0)
            {
                
                int levelAdjust = _random.Next(0, 2);
                level += levelAdjust;
            }
            return level;
        }
        private AbilityScoreSet GetAbilityScores()
        {
            var repo = new DiceRepository();

            var strength = new Strength(repo.RollDice(3, 6, _random));
            var dexterity = new Dexterity(repo.RollDice(3, 6, _random));
            var constitution = new Constitution(repo.RollDice(3, 6, _random));
            var intelligence = new Intelligence(repo.RollDice(3, 6, _random));
            var wisdom = new Wisdom(repo.RollDice(3, 6, _random));
            var charisma = new Charisma(repo.RollDice(3, 6, _random));

            AbilityScoreSet scores = new AbilityScoreSet()
            {
                Strength = strength,
                Dexterity = dexterity,
                Constitution = constitution,
                Intelligence = intelligence,
                Wisdom = wisdom,
                Charisma = charisma
            };
            return scores;
        }
        private RaceBase GetRace()
        {
            var repo = new RaceRepository();
            var races = repo.GetAll();
            int choice = _random.Next(0, races.Count());
            return races.FirstOrDefault(x => x.RaceId == choice);
        }
        private ClassBase GetClass()
        {
            var repo = new ClassRepository();
            var classes = repo.GetAll(_character.Race);
            int choice = _random.Next(0, classes.Count());
            return classes.FirstOrDefault(x => x.ClassId == choice);
        }
        private WeaponBase ChooseWeapon(List<WeaponBase> profs)
        {
            var repo = WeaponRepositoryFactory.GetRepository(_character.Race.Size);
            var weapons = repo.GetAll();
            int choice = _random.Next(0, profs.Count());
            return weapons.FirstOrDefault(x => x.WeaponId == choice);
        }
        private ShieldBase ChooseShield(List<ShieldBase> profs)
        {
            var repo = new ShieldRepository();
            if (_character.Weapon.Name.Contains("Shield"))
            {
                if (_character.Weapon.Name.Contains("Light"))
                {
                    profs = repo.GetByName("Light");
                }
                if (_character.Weapon.Name.Contains("Heavy"))
                {
                    profs = repo.GetByName("Heavy");
                }
            }
            else 
            {
                if (_character.Weapon.Type == WeaponType.TwoHanded)
                {
                    profs = repo.GetByName("No Shield");
                } else if (_character.Weapon.Type == WeaponType.Ranged)
                {
                    profs = repo.GetByName("Buckler");
                }
            }
            int choice = _random.Next(0, profs.Count());
            var shields = repo.GetAll();
            return shields.FirstOrDefault(x => x.ShieldId == choice);
        }
        private ArmorBase ChooseArmor(List<ArmorBase> profs)
        {
            var repo = new ArmorRepository();
            var armors = repo.GetAll();
            int choice = _random.Next(0, profs.Count());
            return armors.FirstOrDefault(x => x.ArmorId == choice);
        }

        private int RollHitPoints()
        {
            int hitPoints = _character.Class.HitDie + _character.AbilityScores.Constitution.Modifier;
            var dice = new DiceRepository();

            if (_character.Level > 1)
            {
                hitPoints += dice.RollDice(_character.Level - 1, _character.Class.HitDie, _random);
                hitPoints += _character.AbilityScores.Constitution.Modifier * (_character.Level - 1);
            }

            return hitPoints;
        }
    }
}
