using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPCGenerator.Data;
using NPCGenerator.Data.Core;
using NPCGenerator.Data.Equipment;
using NPCGenerator.Data.Factories;
using RandomNPCGenerator.Models;
using RandomNPCGenerator.Models.AbilityScores;
using RandomNPCGenerator.Models.Character;
using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.UI;

namespace RandomNPCGenerator.Controller
{
    public class CharacterController
    {
        private View _view = new View();
        private CharacterRepository _charRepo = new CharacterRepository();
        public Character CalcCharacterView(Character character)
        {
            switch (character.Class.BaseAttackBonus)
            {
                case BAB.Good:
                    character.BaseAttack = character.Level;
                    break;
                case BAB.Average:
                    character.BaseAttack = (character.Level * 3) / 4;
                    break;
                case BAB.Poor:
                    character.BaseAttack = character.Level / 2;
                    break;
            }

            switch (character.Class.FortSave)
            {
                case Save.Good:
                    character.FortSave = (character.Level / 2) + 2 + character.AbilityScores.Constitution.Modifier;
                    break;
                case Save.Average:
                    character.FortSave = character.Level / 3 + character.AbilityScores.Constitution.Modifier;
                    break;
            }

            switch (character.Class.WillSave)
            {
                case Save.Good:
                    character.WillSave = (character.Level / 2) + 2 + character.AbilityScores.Wisdom.Modifier;
                    break;
                case Save.Average:
                    character.WillSave = character.Level / 3 + character.AbilityScores.Wisdom.Modifier;
                    break;
            }

            switch (character.Class.RefSave)
            {
                case Save.Good:
                    character.RefSave = (character.Level / 2) + 2 + character.AbilityScores.Dexterity.Modifier;
                    break;
                case Save.Average:
                    character.RefSave = character.Level / 3 + character.AbilityScores.Dexterity.Modifier;
                    break;
            }

            if (character.Armor.ArmorType == ArmorType.Heavy ||
                character.Armor.ArmorType == ArmorType.Medium &&
                character.Race.RaceId != 1)
            {
                character.Speed = character.Race.BaseSpeed == 30 ? 20 : 15;
            } else
            {
                character.Speed = character.Race.BaseSpeed == 30 ? 30 : 20;
            }

            if (character.AbilityScores.Dexterity.Value > character.Armor.MaxDexBonus)
            {
                character.ArmorClass = 10 +
                    character.Armor.ArmorBonus +
                    character.Armor.MaxDexBonus +
                    character.Shield.ShieldBonus;
                character.TouchAC = 10 + character.Armor.MaxDexBonus;
            } else
            {
                character.ArmorClass = 10 +
                    character.Armor.ArmorBonus +
                    character.AbilityScores.Dexterity.Modifier +
                    character.Shield.ShieldBonus;
                character.TouchAC = 10 + character.AbilityScores.Dexterity.Modifier;
            }
            character.FlatFootedAC = 10 +
                character.Armor.ArmorBonus +
                character.Shield.ShieldBonus;
            if (character.Race.Size == RaceSize.Small)
            {
                character.ArmorClass++;
                character.FlatFootedAC++;
                character.TouchAC++;
            }

            if (character.Weapon.IsFinesse)
            {
                character.WeaponAttack = character.BaseAttack + character.AbilityScores.Dexterity.Modifier;

                if (character.Weapon.IsThrown)
                {
                    character.WeaponDamage = character.AbilityScores.Strength.Modifier;
                } else
                {
                    character.WeaponDamage = 0;
                }
            } else
            {
                character.WeaponAttack = character.BaseAttack + character.AbilityScores.Strength.Modifier;
                if (character.Weapon.Type == WeaponType.TwoHanded)
                {
                    character.WeaponDamage = (character.AbilityScores.Strength.Modifier * 3) / 2;
                } else
                {
                    character.WeaponDamage = character.AbilityScores.Strength.Modifier;
                }
            }
            if (character.Race.Size == RaceSize.Small)
            {
                character.WeaponAttack++;
            }

            return character;
        }

        public Character CharacterFillObjects(Character character)
        {
            var raceRepo = new RaceRepository();
            var classRepo = new ClassRepository();
            var weaponRepo = WeaponRepositoryFactory.GetRepository(character.Race.Size);
            var armorRepo = new ArmorRepository();
            var shieldRepo = new ShieldRepository();

            character.Race = raceRepo.GetById(character.Race.RaceId);
            character.Class = classRepo.GetById(character.Race, character.Class.ClassId);
            character.Weapon = weaponRepo.GetById(character.Weapon.WeaponId);
            character.Armor = armorRepo.GetById(character.Armor.ArmorId);
            character.Shield = shieldRepo.GetById(character.Shield.ShieldId);

            return character;
        }

        public void CreateRandom()
        {
            var factory = new CharacterFactory();

            var challengeRating = _view.PromptChallengeRating();

            var character = CalcCharacterView(CharacterFillObjects(factory.RollCharacter(challengeRating)));

            _view.DisplayCharacterFull(character);

            if (_view.ConfirmCharacter())
            {
                _charRepo.Insert(character);
            }

            Console.Clear();
        }

        public void CreateManual()
        {
            Character character = new Character();

            character.Level = _view.GetLevel();
            character.ChallengeRating = (character.Level * 3) / 4;

            AbilityScoreSet abilities = new AbilityScoreSet();
            abilities.Strength = new Strength(_view.GetAbility("Strength"));
            abilities.Dexterity = new Dexterity(_view.GetAbility("Dexterity"));
            abilities.Constitution = new Constitution(_view.GetAbility("Constitution"));
            abilities.Intelligence = new Intelligence(_view.GetAbility("Intelligence"));
            abilities.Wisdom = new Wisdom(_view.GetAbility("Wisdom"));
            abilities.Charisma = new Charisma(_view.GetAbility("Charisma"));

            var raceRepo = new RaceRepository();
            var races = raceRepo.GetAll();
            character.Race = _view.GetRace(races);

            // apply ability bonus
            switch (character.Race.AbilityScoreBonus)
            {
                case AbilityScoreAdjustment.None:
                    break;
                case AbilityScoreAdjustment.Strength:
                    character.AbilityScores.Strength = new Strength(character.AbilityScores.Strength.Value + 2);
                    break;
                case AbilityScoreAdjustment.Dexterity:
                    character.AbilityScores.Dexterity = new Dexterity(character.AbilityScores.Dexterity.Value + 2);
                    break;
                case AbilityScoreAdjustment.Constitution:
                    character.AbilityScores.Constitution = new Constitution(character.AbilityScores.Constitution.Value + 2);
                    break;
                case AbilityScoreAdjustment.Intelligence:
                    character.AbilityScores.Intelligence = new Intelligence(character.AbilityScores.Intelligence.Value + 2);
                    break;
                case AbilityScoreAdjustment.Wisdom:
                    character.AbilityScores.Wisdom = new Wisdom(character.AbilityScores.Wisdom.Value + 2);
                    break;
                case AbilityScoreAdjustment.Charisma:
                    character.AbilityScores.Charisma = new Charisma(character.AbilityScores.Charisma.Value + 2);
                    break;
                default:
                    throw new Exception("Error: Ability Score adjustment is invalid");
            }
            // apply ability penalty
            switch (character.Race.AbilityScorePenalty)
            {
                case AbilityScoreAdjustment.None:
                    break;
                case AbilityScoreAdjustment.Strength:
                    character.AbilityScores.Strength = new Strength(character.AbilityScores.Strength.Value - 2);
                    break;
                case AbilityScoreAdjustment.Dexterity:
                    character.AbilityScores.Dexterity = new Dexterity(character.AbilityScores.Dexterity.Value - 2);
                    break;
                case AbilityScoreAdjustment.Constitution:
                    character.AbilityScores.Constitution = new Constitution(character.AbilityScores.Constitution.Value - 2);
                    break;
                case AbilityScoreAdjustment.Intelligence:
                    if (!(character.AbilityScores.Intelligence.Value - 2 < 3))
                    {
                        character.AbilityScores.Intelligence = new Intelligence(character.AbilityScores.Intelligence.Value - 2);
                    }
                    break;
                case AbilityScoreAdjustment.Wisdom:
                    character.AbilityScores.Wisdom = new Wisdom(character.AbilityScores.Wisdom.Value - 2);
                    break;
                case AbilityScoreAdjustment.Charisma:
                    character.AbilityScores.Charisma = new Charisma(character.AbilityScores.Charisma.Value - 2);
                    break;
                default:
                    throw new Exception("Error: Ability Score adjustment is invalid");
            }

            var classRepo = new ClassRepository();
            var classes = classRepo.GetAll(character.Race);
            character.Class = _view.GetClass(classes);

            var armorRepo = new ArmorRepository();
            var armors = armorRepo.GetAll();
            character.Armor = _view.GetArmor(armors, character.Class.ArmorProficiencies);

            var weaponRepo = WeaponRepositoryFactory.GetRepository(character.Race.Size);
            var weapons = weaponRepo.GetAll();
            character.Weapon = _view.GetWeapon(weapons, character.Class.WeaponProficiencies);

            var shieldRepo = new ShieldRepository();
            var shields = shieldRepo.GetAll();
            character.Shield = _view.GetShield(shields, character.Class.ShieldProficiencies, character.Weapon);

            // prompt hit points (based on statistical min and stat. max)
            // calc and display
            // prompt save
        }

        public void Update(int id)
        {
            Console.WriteLine("Method not implemented yet");
        }

        public void ListAll()
        {
            var characters = _charRepo.GetAll();
            if (characters.Count() == 0)
            {
                _view.NoCharacters();
            }
            else
            {
                foreach (var character in characters)
                {
                    CharacterFillObjects(character);
                }
                _view.DisplayList(characters);
            }
        }

        public void ShowDetails(int id)
        {
            var character = _charRepo.GetById(id);
            if (character == null)
            {
                _view.CharacterNotFound();
            } else
            {
                character = CharacterFillObjects(character);
                character = CalcCharacterView(character);
                _view.DisplayCharacterFull(character);
            }
        }
    }
}
