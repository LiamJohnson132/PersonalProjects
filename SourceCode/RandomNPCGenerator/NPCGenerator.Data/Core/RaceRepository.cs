using NPCGenerator.Data.SaveFiles;
using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.Models.Races;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data.Core
{
    public class RaceRepository
    {
        private static string _path = SavePath.GetPath() + "repos\\Race.txt";
        public List<RaceBase> GetAll()
        {
            List<RaceBase> races = new List<RaceBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        RaceBase race;

                        string[] cols = line.Split('|');

                        AbilityScoreAdjustment asBonus;
                        switch (cols[2])
                        {
                            case "None":
                                asBonus = AbilityScoreAdjustment.None;
                                break;
                            case "Str":
                                asBonus = AbilityScoreAdjustment.Strength;
                                break;
                            case "Con":
                                asBonus = AbilityScoreAdjustment.Constitution;
                                break;
                            case "Dex":
                                asBonus = AbilityScoreAdjustment.Dexterity;
                                break;
                            case "Int":
                                asBonus = AbilityScoreAdjustment.Intelligence;
                                break;
                            case "Wis":
                                asBonus = AbilityScoreAdjustment.Wisdom;
                                break;
                            case "Cha":
                                asBonus = AbilityScoreAdjustment.Charisma;
                                break;
                            default:
                                throw new Exception("Error: Invalid Ability Score adjustment value");
                        }

                        AbilityScoreAdjustment asPenalty;
                        switch (cols[3])
                        {
                            case "None":
                                asPenalty = AbilityScoreAdjustment.None;
                                break;
                            case "Str":
                                asPenalty = AbilityScoreAdjustment.Strength;
                                break;
                            case "Con":
                                asPenalty = AbilityScoreAdjustment.Constitution;
                                break;
                            case "Dex":
                                asPenalty = AbilityScoreAdjustment.Dexterity;
                                break;
                            case "Int":
                                asPenalty = AbilityScoreAdjustment.Intelligence;
                                break;
                            case "Wis":
                                asPenalty = AbilityScoreAdjustment.Wisdom;
                                break;
                            case "Cha":
                                asPenalty = AbilityScoreAdjustment.Charisma;
                                break;
                            default:
                                throw new Exception("Error: Invalid Ability Score adjustment value");
                        }

                        RaceSize size;
                        switch (cols[5])
                        {
                            case "Small":
                                size = RaceSize.Small;
                                break;
                            case "Medium":
                                size = RaceSize.Medium;
                                break;
                            /*case "Large":
                                size = RaceSize.Large;
                                break;*/
                            default:
                                throw new Exception("Error: Invalid Race Size Value");
                        }

                        race = new RaceBase()
                        {
                            RaceId = int.Parse(cols[0]),
                            Name = cols[1],
                            AbilityScoreBonus = asBonus,
                            AbilityScorePenalty = asPenalty,
                            BaseSpeed = int.Parse(cols[4]),
                            Size = size
                        };

                        races.Add(race);
                    }
                }

                return races;
            }
            else
            {
                throw new Exception("Error: Race.txt file could not be found.");
            }
        }

        public RaceBase GetById(int param)
        {
            List<RaceBase> races = new List<RaceBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        RaceBase race;

                        string[] cols = line.Split('|');

                        AbilityScoreAdjustment asBonus;
                        switch (cols[2])
                        {
                            case "None":
                                asBonus = AbilityScoreAdjustment.None;
                                break;
                            case "Str":
                                asBonus = AbilityScoreAdjustment.Strength;
                                break;
                            case "Con":
                                asBonus = AbilityScoreAdjustment.Constitution;
                                break;
                            case "Dex":
                                asBonus = AbilityScoreAdjustment.Dexterity;
                                break;
                            case "Int":
                                asBonus = AbilityScoreAdjustment.Intelligence;
                                break;
                            case "Wis":
                                asBonus = AbilityScoreAdjustment.Wisdom;
                                break;
                            case "Cha":
                                asBonus = AbilityScoreAdjustment.Charisma;
                                break;
                            default:
                                throw new Exception("Error: Invalid Ability Score adjustment value");
                        }

                        AbilityScoreAdjustment asPenalty;
                        switch (cols[3])
                        {
                            case "None":
                                asPenalty = AbilityScoreAdjustment.None;
                                break;
                            case "Str":
                                asPenalty = AbilityScoreAdjustment.Strength;
                                break;
                            case "Con":
                                asPenalty = AbilityScoreAdjustment.Constitution;
                                break;
                            case "Dex":
                                asPenalty = AbilityScoreAdjustment.Dexterity;
                                break;
                            case "Int":
                                asPenalty = AbilityScoreAdjustment.Intelligence;
                                break;
                            case "Wis":
                                asPenalty = AbilityScoreAdjustment.Wisdom;
                                break;
                            case "Cha":
                                asPenalty = AbilityScoreAdjustment.Charisma;
                                break;
                            default:
                                throw new Exception("Error: Invalid Ability Score adjustment value");
                        }

                        RaceSize size;
                        switch (cols[5])
                        {
                            case "Small":
                                size = RaceSize.Small;
                                break;
                            case "Medium":
                                size = RaceSize.Medium;
                                break;
                            /*case "Large":
                                size = RaceSize.Large;
                                break;*/
                            default:
                                throw new Exception("Error: Invalid Race Size Value");
                        }

                        race = new RaceBase()
                        {
                            RaceId = int.Parse(cols[0]),
                            Name = cols[1],
                            AbilityScoreBonus = asBonus,
                            AbilityScorePenalty = asPenalty,
                            BaseSpeed = int.Parse(cols[4]),
                            Size = size
                        };

                        races.Add(race);
                    }
                }

                return races.FirstOrDefault(r => r.RaceId == param);
            }
            else
            {
                throw new Exception("Error: Race.txt file could not be found.");
            }
        }
    }
}
