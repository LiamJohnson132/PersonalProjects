using RandomNPCGenerator.Models;
using RandomNPCGenerator.Models.AbilityScores;
using RandomNPCGenerator.Models.Character;
using RandomNPCGenerator.Models.Classes;
using RandomNPCGenerator.Models.Equipment;
using RandomNPCGenerator.Models.Equipment.Armor;
using RandomNPCGenerator.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.UI
{
    public class View
    {
        private UserIO _userIO = new UserIO();
        public int PromptChallengeRating()
        {
            Console.WriteLine("What do you want the Challenge Rating of the NPC to be?");

            while (true)
            {
                try
                {
                    int input = _userIO.PromptInt("Challenge Rating: ", "Please enter an integer between 1 and 20.", 1, 20);
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DisplayCharacterFull(Character character)
        {
            Console.Clear();
            Console.WriteLine($"**** CR {character.ChallengeRating} {character.Class.Name} ********");
            Console.WriteLine($"* Size/Type: {character.Race.Size} Humanoid ({character.Race.Name})");
            Console.WriteLine($"* Hit Dice: {character.Level}d{character.Class.HitDie} ({character.HitPoints} hp)");
            Console.WriteLine(FormatInitiative(character.AbilityScores.Dexterity.Modifier));
            Console.WriteLine($"* Speed: {character.Speed} ft. ({character.Speed / 5} squares)");
            Console.WriteLine($"* Armor Class: {character.ArmorClass}, touch {character.TouchAC}, flat-footed {character.FlatFootedAC}");
            Console.WriteLine(FormatGrapple(character.BaseAttack, character.BaseAttack + character.AbilityScores.Strength.Modifier));
            Console.WriteLine(FormatAttackBonus(character));
            Console.WriteLine(FormatSaves(character));
            Console.WriteLine(FormatAbilities(character.AbilityScores));
            Console.WriteLine("*****************************************");
        }
        public string FormatInitiative(int dexMod)
        {
            string line = $"* Initiative: ";
            line += dexMod >= 0 ? "+" : "";
            line += $"{dexMod}";
            return line;
        }
        public string FormatGrapple(int baseAttack, int grapple)
        {
            string line = $"* Base Attack/Grapple: +{baseAttack}/";
            line += grapple >= 0 ? "+" : "";
            line += $"{grapple}";
            return line;
        }
        public string FormatAttackBonus(Character character)
        {
            string line = $"* Attack: {character.Weapon.Name} ";
            line += character.WeaponAttack >= 0 ? "+" : "";
            line += $"{character.WeaponAttack} " +
                $"({character.Weapon.DamageDice.Count()}d{character.Weapon.DamageDice[0]}";
            if (character.WeaponDamage != 0)
            {
                line += character.WeaponDamage > 0 ? "+" : "";
                line += $"{character.WeaponDamage}";
            }
            if (character.Weapon.CriticalThreatRange > 1) {
                line += $"/{21 - character.Weapon.CriticalThreatRange}-20)";
            } else if (character.Weapon.CriticalDamageMultiplier > 2) {
                line += $"/x{character.Weapon.CriticalDamageMultiplier})";
            } else {
                line += $")";
            }
            return line;
        }
        public string FormatSaves(Character character)
        {
            string line = $"* Saves: Fort ";
            line += character.FortSave >= 0 ? "+" : "";
            line += $"{character.FortSave}, Ref ";
            line += character.RefSave >= 0 ? "+" : "";
            line += $"{character.RefSave}, Will ";
            line += character.WillSave >= 0 ? "+" : "";
            line += $"{character.WillSave}";
            return line;
        }
        public string FormatAbilities(AbilityScoreSet abilities)
        {
            return $"* Str {abilities.Strength.Value}, " +
                $"Dex {abilities.Dexterity.Value}, " +
                $"Con {abilities.Constitution.Value}, " +
                $"Int {abilities.Intelligence.Value}, " +
                $"Wis {abilities.Wisdom.Value}, " +
                $"Cha {abilities.Charisma.Value}";
        }
        public bool ConfirmCharacter()
        {
            Console.WriteLine("Do you want to save this character?");

            while (true)
            {
                try
                {
                    var input = _userIO.PromptBool("save");
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public void DisplayList(List<Character> characters)
        {
            Console.Clear();
            Console.WriteLine("* ID | CR Class/Race | Ability Scores **********");
            foreach (var character in characters)
            {
                Console.WriteLine($"* {character.CharacterId} | CR {character.ChallengeRating} {character.Class.Name}/{character.Race.Name} | " +
                    $"Str {character.AbilityScores.Strength.Value} " +
                    $"Dex {character.AbilityScores.Dexterity.Value} " +
                    $"Con {character.AbilityScores.Constitution.Value} " +
                    $"Int {character.AbilityScores.Intelligence.Value} " +
                    $"Wis {character.AbilityScores.Wisdom.Value} " +
                    $"Cha {character.AbilityScores.Charisma.Value}");
            }
            Console.WriteLine("***************************");
        }

        public Command ReadCommand()
        {
            Console.Write("Type command and press enter (Type \"Help\" to list commands): ");

            string input = _userIO.ReadCommand();

            string[] split = input.Split(' ');

            var command = new Command()
            {
                CommandName = split[0]
            };

            if (split.Length > 1)
            {
                if (int.TryParse(split[1], out var result))
                {
                    command.IntParam = result;
                }
                else
                {
                    command.StringParam = split[1];
                }
            }

            return command;
        }
        public void BadCommand()
        {
            Console.Clear();
            Console.WriteLine("Command not recognized or command parameters are not in the correct format.");
        }
        public void DisplayCommands()
        {
            Console.Clear();
            Console.WriteLine("* {CommandName} {Param} * {Description} *");
            Console.WriteLine("* exit * Close the program");
            Console.WriteLine("* help * Lists all commands");
            Console.WriteLine("* npc list * Lists all npcs in short form");
            Console.WriteLine("* npc {id} * Display full information for npc by ID");
            Console.WriteLine("* npc roll * Randomly generates a new npc, then displays the full info");
            Console.WriteLine("* npc create * Generate a new npc with given information");
        }
        public void NoCharacters()
        {
            Console.Clear();
            Console.WriteLine("There are no saved NPCs");
        }
        public void CharacterNotFound()
        {
            Console.Clear();
            Console.WriteLine("Cannot find NPC by that ID");
        }
        public int GetLevel()
        {
            Console.WriteLine("What do you want the Level of the character to be?");
            while (true)
            {
                try
                {
                    int input = _userIO.PromptInt("Level", "Please enter an integer between 1 and 30", 1, 30);
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public int GetAbility(string ability)
        {
            Console.WriteLine($"What do you want the {ability} to be?");
            while (true)
            {
                try
                {
                    int input = _userIO.PromptInt(ability, "Please enter an integer between 3 and 18", 3, 18);
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public RaceBase GetRace(List<RaceBase> races)
        {
            ListRaces(races);
            Console.WriteLine("Which race is your character? (Enter the name or ID)");
            while (true)
            {
                var input = _userIO.ReadIntOrString("Race ID", "Race Name");
                var choice = new RaceBase();
                if (int.TryParse(input, out var id))
                {
                    choice = races.FirstOrDefault(r => r.RaceId == id);
                } else
                {
                    choice = races.FirstOrDefault(r => r.Name == input);
                }
                if (choice == null)
                {
                    Console.WriteLine("Race not found: Please enter a valid ID or Name.");
                } else
                {
                    return choice;
                }
            }
        }
        public void ListRaces(List<RaceBase> races)
        {
            Console.WriteLine("* ID | Name | Ability Bonus | Ability Penalty | Speed | Size");
            foreach (var race in races)
            {
                var line = $"* {race.RaceId} | {race.Name} | " +
                    $"{race.AbilityScoreBonus} +2 | {race.AbilityScorePenalty} -2 | " +
                    $"{race.BaseSpeed} | {race.Size}";
                Console.WriteLine(line);
            }
        }
        public ClassBase GetClass(List<ClassBase> classes)
        {
            ListClasses(classes);
            Console.WriteLine("Which class will your character be? (Enter the name or ID)");
            while (true)
            {
                var input = _userIO.ReadIntOrString("Class ID", "Class Name");
                var choice = new ClassBase();
                if (int.TryParse(input, out var id))
                {
                    choice = classes.FirstOrDefault(r => r.ClassId == id);
                }
                else
                {
                    choice = classes.FirstOrDefault(r => r.Name == input);
                }
                if (choice == null)
                {
                    Console.WriteLine("Class not found: Please enter a valid ID or Name.");
                }
                else
                {
                    return choice;
                }
            }
        }

        public void ListClasses(List<ClassBase> classes)
        {
            Console.WriteLine("* ID | Name | HitDie | BAB | Fort | Ref | Will | Armor Profs. | Shield Profs. | Weapon Profs.");
            foreach (var c in classes)
            {
                var line = $"* {c.ClassId} | {c.Name} | d{c.HitDie} | " +
                    $"{c.BaseAttackBonus} | {c.FortSave} | {c.RefSave} | {c.WillSave} | ";
                switch (c.ArmorProficiencies.Count())
                {
                    case 1:
                        line += "No armor";
                        break;
                    case 5:
                        line += "All Light armors";
                        break;
                    case 9:
                        line += "All Light or Medium armors";
                        break;
                    case 13:
                        line += "All armors";
                        break;
                }
                line += " | ";
                switch (c.ShieldProficiencies.Count())
                {
                    case 1:
                        line += "No shields";
                        break;
                    case 7:
                        line += "All shields";
                        break;
                }
                line += " | ";
                switch (c.WeaponProficiencies.Count())
                {
                    case 19:
                        line += "Simple weapons";
                        break;
                    case 54:
                        line += "All weapons";
                        break;
                }
                Console.WriteLine(line);
            }
        }

        public ArmorBase GetArmor(List<ArmorBase> armors, List<ArmorBase> armorProficiencies)
        {
            throw new NotImplementedException();
        }

        public void ListArmors(List<ArmorBase> armors)
        {

        }

        public WeaponBase GetWeapon(List<WeaponBase> weapons, List<WeaponBase> weaponProficiencies)
        {
            throw new NotImplementedException();
        }

        public void ListWeapons(List<WeaponBase> weapons)
        {

        }

        public ShieldBase GetShield(List<ShieldBase> shields, List<ShieldBase> shieldProficiencies, WeaponBase weapon)
        {
            throw new NotImplementedException();
        }

        public void ListShields(List<ShieldBase> shields)
        {

        }
    }
}
