using NPCGenerator.Data.Core;
using NPCGenerator.Data.SaveFiles;
using RandomNPCGenerator.Models;
using RandomNPCGenerator.Models.AbilityScores;
using RandomNPCGenerator.Models.Character;
using RandomNPCGenerator.Models.Classes;
using RandomNPCGenerator.Models.Equipment;
using RandomNPCGenerator.Models.Equipment.Armor;
using RandomNPCGenerator.Models.Races;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data
{
    public class CharacterRepository
    {
        private static string _path = SavePath.GetPath() + "characters\\chars.txt";
        private static string FormatLine(Character character)
        {
            string line;
            string delimiter = "|";

            line = character.CharacterId.ToString() + delimiter;
            line += character.ChallengeRating.ToString() + delimiter;
            line += character.Level.ToString() + delimiter;
            line += character.HitPoints.ToString() + delimiter;
            line += character.Race.RaceId.ToString() + delimiter;
            line += character.Class.ClassId.ToString() + delimiter;
            line += character.AbilityScores.Strength.Value.ToString() + ',';
            line += character.AbilityScores.Dexterity.Value.ToString() + ',';
            line += character.AbilityScores.Constitution.Value.ToString() + ',';
            line += character.AbilityScores.Intelligence.Value.ToString() + ',';
            line += character.AbilityScores.Wisdom.Value.ToString() + ',';
            line += character.AbilityScores.Charisma.Value.ToString() + delimiter;
            line += character.Weapon.WeaponId.ToString() + delimiter;
            line += character.Armor.ArmorId.ToString() + delimiter;
            line += character.Shield.ShieldId.ToString();

            return line;
        }
        public List<Character> GetAll()
        {
            List<Character> characters = new List<Character>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Character character;

                        string[] cols = line.Split('|');

                        string[] abilities = cols[6].Split(',');

                        character = new Character()
                        {
                            CharacterId = int.Parse(cols[0]),
                            ChallengeRating = int.Parse(cols[1]),
                            Level = int.Parse(cols[2]),
                            HitPoints = int.Parse(cols[3]),
                            AbilityScores = new AbilityScoreSet()
                            {
                                Strength = new Strength(int.Parse(abilities[0])),
                                Dexterity = new Dexterity(int.Parse(abilities[1])),
                                Constitution = new Constitution(int.Parse(abilities[2])),
                                Intelligence = new Intelligence(int.Parse(abilities[3])),
                                Wisdom = new Wisdom(int.Parse(abilities[4])),
                                Charisma = new Charisma(int.Parse(abilities[5]))
                            },
                            Race = new RaceBase(),
                            Class = new ClassBase(),
                            Weapon = new WeaponBase(),
                            Armor = new ArmorBase(),
                            Shield = new ShieldBase()
                        };

                        character.Race.RaceId = int.Parse(cols[4]);
                        character.Class.ClassId = int.Parse(cols[5]);
                        character.Weapon.WeaponId = int.Parse(cols[7]);
                        character.Armor.ArmorId = int.Parse(cols[8]);
                        character.Shield.ShieldId = int.Parse(cols[9]);

                        characters.Add(character);
                    }
                }

                return characters;
            }
            else
            {
                throw new Exception("Error: chars.txt file could not be found.");
            }
        }

        public Character GetById(int param)
        {
            List<Character> characters = new List<Character>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Character character;

                        string[] cols = line.Split('|');

                        string[] abilities = cols[6].Split(',');

                        character = new Character()
                        {
                            CharacterId = int.Parse(cols[0]),
                            ChallengeRating = int.Parse(cols[1]),
                            Level = int.Parse(cols[2]),
                            HitPoints = int.Parse(cols[3]),
                            AbilityScores = new AbilityScoreSet()
                            {
                                Strength = new Strength(int.Parse(abilities[0])),
                                Dexterity = new Dexterity(int.Parse(abilities[1])),
                                Constitution = new Constitution(int.Parse(abilities[2])),
                                Intelligence = new Intelligence(int.Parse(abilities[3])),
                                Wisdom = new Wisdom(int.Parse(abilities[4])),
                                Charisma = new Charisma(int.Parse(abilities[5]))
                            },
                            Race = new RaceBase(),
                            Class = new ClassBase(),
                            Weapon = new WeaponBase(),
                            Armor = new ArmorBase(),
                            Shield = new ShieldBase()
                        };

                        character.Race.RaceId = int.Parse(cols[4]);
                        character.Class.ClassId = int.Parse(cols[5]);
                        character.Weapon.WeaponId = int.Parse(cols[7]);
                        character.Armor.ArmorId = int.Parse(cols[8]);
                        character.Shield.ShieldId = int.Parse(cols[9]);

                        characters.Add(character);
                    }
                }

                return characters.FirstOrDefault(c => c.CharacterId == param);
            }
            else
            {
                throw new Exception("Error: chars.txt file could not be found.");
            }
        }

        public void Insert(Character character)
        {
            List<Character> characters = GetAll();

            if (characters.Any())
            {
                character.CharacterId = characters.Max(c => c.CharacterId) + 1;
            } else
            {
                character.CharacterId = 0;
            }

            characters.Add(character);

            if (File.Exists(_path))
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    sw.WriteLine("Id|CR|Lvl|HP|RaceId|ClassId|AbilityScores,etc|WeaponId|ArmorId|ShieldId");

                    foreach (var c in characters)
                    {
                        sw.WriteLine(FormatLine(c));
                    }
                }
            }
            else
            {
                throw new Exception("Error: chars.txt file could not be found.");
            }
        }

        public void Delete(int id)
        {
            List<Character> characters = GetAll();
            characters.RemoveAll(c=>c.CharacterId == id);

            if (File.Exists(_path))
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    sw.WriteLine("Id|CR|Lvl|HP|RaceId|ClassId|AbilityScores,etc|WeaponId|ArmorId|ShieldId");

                    foreach (var c in characters)
                    {
                        sw.WriteLine(FormatLine(c));
                    }
                }
            }
            else
            {
                throw new Exception("Error: chars.txt file could not be found.");
            }
        }

        public void Update(Character character)
        {
            List<Character> characters = GetAll();
            characters.RemoveAll(c=>c.CharacterId == character.CharacterId);
            characters.Add(character);

            if (File.Exists(_path))
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    sw.WriteLine("Id|CR|Lvl|HP|RaceId|ClassId|AbilityScores,etc|WeaponId|ArmorId|ShieldId");

                    foreach (var c in characters)
                    {
                        sw.WriteLine(FormatLine(c));
                    }
                }
            }
            else
            {
                throw new Exception("Error: chars.txt file could not be found.");
            }
        }
    }
}
