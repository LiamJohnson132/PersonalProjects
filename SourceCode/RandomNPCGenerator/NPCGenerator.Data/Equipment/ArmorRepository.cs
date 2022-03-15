using NPCGenerator.Data.SaveFiles;
using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.Models.Equipment.Armor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NPCGenerator.Data.Equipment
{
    public class ArmorRepository
    {
        private static string _path = SavePath.GetPath() + "repos\\Armor.txt";
        public List<ArmorBase> GetAll()
        {
            List<ArmorBase> armors = new List<ArmorBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ArmorBase armor;

                        string[] cols = line.Split('|');

                        ArmorType armorType; 
                        switch (cols[1])
                        {
                            case "None":
                                armorType = ArmorType.None;
                                break;
                            case "Light":
                                armorType = ArmorType.Light;
                                break;
                            case "Medium":
                                armorType = ArmorType.Medium;
                                break;
                            case "Heavy":
                                armorType = ArmorType.Heavy;
                                break;
                            default:
                                throw new Exception("Error: Armor type is not supported.");
                        }

                        armor = new ArmorBase()
                        {
                            ArmorId = int.Parse(cols[0]),
                            ArmorType = armorType,
                            Name = cols[2],
                            ArmorBonus = int.Parse(cols[3]),
                            MaxDexBonus = int.Parse(cols[4]),
                            ArmorCheckPenalty = int.Parse(cols[5]),
                            ArcaneSpellFailure = int.Parse(cols[6])
                        };

                        armors.Add(armor);
                    }
                }

                return armors;
            }
            else
            {
                throw new Exception("Error: Armor file could not be found.");
            }
        }

        public ArmorBase GetById(int param)
        {
            List<ArmorBase> armors = new List<ArmorBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ArmorBase armor;

                        string[] cols = line.Split('|');

                        ArmorType armorType;
                        switch (cols[1])
                        {
                            case "None":
                                armorType = ArmorType.None;
                                break;
                            case "Light":
                                armorType = ArmorType.Light;
                                break;
                            case "Medium":
                                armorType = ArmorType.Medium;
                                break;
                            case "Heavy":
                                armorType = ArmorType.Heavy;
                                break;
                            default:
                                throw new Exception("Error: Armor type is not supported.");
                        }

                        armor = new ArmorBase()
                        {
                            ArmorId = int.Parse(cols[0]),
                            ArmorType = armorType,
                            Name = cols[2],
                            ArmorBonus = int.Parse(cols[3]),
                            MaxDexBonus = int.Parse(cols[4]),
                            ArmorCheckPenalty = int.Parse(cols[5]),
                            ArcaneSpellFailure = int.Parse(cols[6])
                        };

                        armors.Add(armor);
                    }
                }

                return armors.FirstOrDefault(a => a.ArmorId == param);
            }
            else
            {
                throw new Exception("Error: Armor file could not be found.");
            }
        }
    }
}
