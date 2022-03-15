using NPCGenerator.Data.Equipment;
using NPCGenerator.Data.Factories;
using NPCGenerator.Data.SaveFiles;
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

namespace NPCGenerator.Data.Core
{
    public class ClassRepository
    {
        private static string _path = SavePath.GetPath() + "repos\\Class.txt";
        public List<ClassBase> GetAll(RaceBase race)
        {
            List<ClassBase> classes = new List<ClassBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ClassBase classObject;

                        string[] cols = line.Split('|');

                        BAB bAB;
                        switch (cols[3])
                        {
                            case "Poor":
                                bAB = BAB.Poor;
                                break;
                            case "Average":
                                bAB = BAB.Average;
                                break;
                            case "Good":
                                bAB = BAB.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid BAB value");
                        }

                        Save fortSave;
                        switch (cols[4])
                        {
                            case "Average":
                                fortSave = Save.Average;
                                break;
                            case "Good":
                                fortSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        Save refSave;
                        switch (cols[5])
                        {
                            case "Average":
                                refSave = Save.Average;
                                break;
                            case "Good":
                                refSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        Save willSave;
                        switch (cols[6])
                        {
                            case "Average":
                                willSave = Save.Average;
                                break;
                            case "Good":
                                willSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        List<ArmorBase> armorProfs = new List<ArmorBase>();
                        for (int i = 0; i <= int.Parse(cols[7]); i++)
                        {
                            var armor = new ArmorBase()
                            {
                                ArmorId = i
                            };
                            armorProfs.Add(armor);
                        }

                        List<ShieldBase> shieldProfs = new List<ShieldBase>();
                        for (int i = 0; i <= int.Parse(cols[8]); i++)
                        {
                            var shield = new ShieldBase()
                            {
                                ShieldId = i
                            };
                            shieldProfs.Add(shield);
                        }

                        List<WeaponBase> weaponProfs = new List<WeaponBase>();
                        for (int i = 0; i <= int.Parse(cols[9]); i++)
                        {
                            var weapon = new WeaponBase()
                            {
                                WeaponId = i
                            };
                            weaponProfs.Add(weapon);
                        }

                        classObject = new ClassBase()
                        {
                            ClassId = int.Parse(cols[0]),
                            Name = cols[1],
                            HitDie = int.Parse(cols[2]),
                            BaseAttackBonus = bAB,
                            FortSave = fortSave,
                            RefSave = refSave,
                            WillSave = willSave,
                            ArmorProficiencies = armorProfs,
                            ShieldProficiencies = shieldProfs,
                            WeaponProficiencies = weaponProfs
                        };

                        classes.Add(classObject);
                    }
                }

                return classes;
            }
            else
            {
                throw new Exception("Error: Shield.txt file could not be found.");
            }
        }

        public ClassBase GetById(RaceBase race, int param)
        {
            List<ClassBase> classes = new List<ClassBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ClassBase classObject;

                        string[] cols = line.Split('|');

                        BAB bAB;
                        switch (cols[3])
                        {
                            case "Poor":
                                bAB = BAB.Poor;
                                break;
                            case "Average":
                                bAB = BAB.Average;
                                break;
                            case "Good":
                                bAB = BAB.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid BAB value");
                        }

                        Save fortSave;
                        switch (cols[4])
                        {
                            case "Average":
                                fortSave = Save.Average;
                                break;
                            case "Good":
                                fortSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        Save refSave;
                        switch (cols[5])
                        {
                            case "Average":
                                refSave = Save.Average;
                                break;
                            case "Good":
                                refSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        Save willSave;
                        switch (cols[6])
                        {
                            case "Average":
                                willSave = Save.Average;
                                break;
                            case "Good":
                                willSave = Save.Good;
                                break;
                            default:
                                throw new Exception("Error: Invalid Save value");
                        }

                        List<ArmorBase> armorProfs;
                        var armorRepo = new ArmorRepository();
                        var armors = armorRepo.GetAll();
                        armorProfs = armors.Where(a => a.ArmorId <= int.Parse(cols[7])).ToList();

                        List<ShieldBase> shieldProfs;
                        var shieldRepo = new ShieldRepository();
                        var shields = shieldRepo.GetAll();
                        shieldProfs = shields.Where(s => s.ShieldId <= int.Parse(cols[8])).ToList();

                        List<WeaponBase> weaponProfs;
                        var weaponRepo = WeaponRepositoryFactory.GetRepository(race.Size);
                        var weapons = weaponRepo.GetAll();
                        weaponProfs = weapons.Where(w => w.WeaponId <= int.Parse(cols[9])).ToList();

                        classObject = new ClassBase()
                        {
                            ClassId = int.Parse(cols[0]),
                            Name = cols[1],
                            HitDie = int.Parse(cols[2]),
                            BaseAttackBonus = bAB,
                            FortSave = fortSave,
                            RefSave = refSave,
                            WillSave = willSave,
                            ArmorProficiencies = armorProfs,
                            ShieldProficiencies = shieldProfs,
                            WeaponProficiencies = weaponProfs
                        };

                        classes.Add(classObject);
                    }
                }

                return classes.FirstOrDefault(c=>c.ClassId == param);
            }
            else
            {
                throw new Exception("Error: Shield.txt file could not be found.");
            }
        }
    }
}
