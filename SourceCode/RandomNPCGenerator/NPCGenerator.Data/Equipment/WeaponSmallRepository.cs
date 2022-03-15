using NPCGenerator.Data.Interfaces;
using NPCGenerator.Data.SaveFiles;
using RandomNPCGenerator.Models.Enums;
using RandomNPCGenerator.Models.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data.Equipment
{
    public class WeaponSmallRepository : IWeaponRepository
    {
        private static string _path = SavePath.GetPath() + "repos\\WeaponSmall.txt";
        public List<WeaponBase> GetAll()
        {
            List<WeaponBase> weapons = new List<WeaponBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        WeaponBase weapon;

                        string[] cols = line.Split('|');

                        WeaponRarity weaponRarity;
                        switch (cols[2])
                        {
                            case "Simple":
                                weaponRarity = WeaponRarity.Simple;
                                break;
                            case "Martial":
                                weaponRarity = WeaponRarity.Martial;
                                break;
                            default:
                                throw new Exception("Error: Invalid weapon rarity.");
                        }

                        WeaponType weaponType;
                        switch (cols[3])
                        {
                            case "Unarmed":
                                weaponType = WeaponType.Unarmed;
                                break;
                            case "Light":
                                weaponType = WeaponType.Light;
                                break;
                            case "OneHanded":
                                weaponType = WeaponType.OneHanded;
                                break;
                            case "TwoHanded":
                                weaponType = WeaponType.TwoHanded;
                                break;
                            case "Ranged":
                                weaponType = WeaponType.Ranged;
                                break;
                            default:
                                throw new Exception("Error: Invalid weapon type");
                        }

                        bool isDouble = cols[4] == "0" ? false : true;

                        List<int> damageDice = new List<int>();
                        string[] damageDiceSplit = cols[5].Split(',');
                        foreach (var die in damageDiceSplit)
                        {
                            damageDice.Add(int.Parse(die));
                        }

                        List<DamageType> damageTypes = new List<DamageType>();
                        string[] damageTypesSplit = cols[9].Split(',');
                        foreach (var type in damageTypesSplit)
                        {
                            switch (type)
                            {
                                case "P":
                                    damageTypes.Add(DamageType.Piercing);
                                    break;
                                case "S":
                                    damageTypes.Add(DamageType.Slashing);
                                    break;
                                case "B":
                                    damageTypes.Add(DamageType.Bludgeoning);
                                    break;
                                default:
                                    throw new Exception("Error: Invalid damage type");
                            }
                        }

                        bool isFinesse = cols[10] == "0" ? false : true;

                        bool isThrown = cols[11] == "0" ? false : true;

                        weapon = new WeaponBase()
                        {
                            WeaponId = int.Parse(cols[0]),
                            Name = cols[1].ToString(),
                            Rarity = weaponRarity, // 2
                            Type = weaponType, // 3
                            IsDouble = isDouble, // 4
                            DamageDice = damageDice, // 5
                            CriticalThreatRange = int.Parse(cols[6]),
                            CriticalDamageMultiplier = int.Parse(cols[7]),
                            RangeIncrement = int.Parse(cols[8]),
                            DamageTypes = damageTypes, // 9
                            IsFinesse = isFinesse, // 10
                            IsThrown = isThrown // 11
                        };

                        weapons.Add(weapon);
                    }
                }

                return weapons;
            }
            else
            {
                throw new Exception("Error: WeaponMedium.txt file could not be found.");
            }
        }

        public WeaponBase GetById(int param)
        {
            List<WeaponBase> weapons = new List<WeaponBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        WeaponBase weapon;

                        string[] cols = line.Split('|');

                        WeaponRarity weaponRarity;
                        switch (cols[2])
                        {
                            case "Simple":
                                weaponRarity = WeaponRarity.Simple;
                                break;
                            case "Martial":
                                weaponRarity = WeaponRarity.Martial;
                                break;
                            default:
                                throw new Exception("Error: Invalid weapon rarity.");
                        }

                        WeaponType weaponType;
                        switch (cols[3])
                        {
                            case "Unarmed":
                                weaponType = WeaponType.Unarmed;
                                break;
                            case "Light":
                                weaponType = WeaponType.Light;
                                break;
                            case "OneHanded":
                                weaponType = WeaponType.OneHanded;
                                break;
                            case "TwoHanded":
                                weaponType = WeaponType.TwoHanded;
                                break;
                            case "Ranged":
                                weaponType = WeaponType.Ranged;
                                break;
                            default:
                                throw new Exception("Error: Invalid weapon type");
                        }

                        bool isDouble = cols[4] == "0" ? false : true;

                        List<int> damageDice = new List<int>();
                        string[] damageDiceSplit = cols[5].Split(',');
                        foreach (var die in damageDiceSplit)
                        {
                            damageDice.Add(int.Parse(die));
                        }

                        List<DamageType> damageTypes = new List<DamageType>();
                        string[] damageTypesSplit = cols[9].Split(',');
                        foreach (var type in damageTypesSplit)
                        {
                            switch (type)
                            {
                                case "P":
                                    damageTypes.Add(DamageType.Piercing);
                                    break;
                                case "S":
                                    damageTypes.Add(DamageType.Slashing);
                                    break;
                                case "B":
                                    damageTypes.Add(DamageType.Bludgeoning);
                                    break;
                                default:
                                    throw new Exception("Error: Invalid damage type");
                            }
                        }

                        bool isFinesse = cols[10] == "0" ? false : true;

                        bool isThrown = cols[11] == "0" ? false : true;

                        weapon = new WeaponBase()
                        {
                            WeaponId = int.Parse(cols[0]),
                            Name = cols[1].ToString(),
                            Rarity = weaponRarity, // 2
                            Type = weaponType, // 3
                            IsDouble = isDouble, // 4
                            DamageDice = damageDice, // 5
                            CriticalThreatRange = int.Parse(cols[6]),
                            CriticalDamageMultiplier = int.Parse(cols[7]),
                            RangeIncrement = int.Parse(cols[8]),
                            DamageTypes = damageTypes, // 9
                            IsFinesse = isFinesse, // 10
                            IsThrown = isThrown // 11
                        };

                        weapons.Add(weapon);
                    }
                }

                return weapons.FirstOrDefault(w => w.WeaponId == param);
            }
            else
            {
                throw new Exception("Error: WeaponMedium.txt file could not be found.");
            }
        }
    }
}
