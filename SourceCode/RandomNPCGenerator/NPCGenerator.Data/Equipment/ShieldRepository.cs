using NPCGenerator.Data.SaveFiles;
using RandomNPCGenerator.Models.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data.Equipment
{
    public class ShieldRepository
    {
        private static string _path = SavePath.GetPath() + "repos\\Shield.txt";
        public List<ShieldBase> GetAll()
        {
            List<ShieldBase> shields = new List<ShieldBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ShieldBase shield;

                        string[] cols = line.Split('|');

                        shield = new ShieldBase()
                        {
                            ShieldId = int.Parse(cols[0]),
                            Name = cols[1],
                            ShieldBonus = int.Parse(cols[2]),
                            MaxDexBonus = int.Parse(cols[3]),
                            ArmorCheckPenalty = int.Parse(cols[4]),
                            ArcaneSpellFailure = int.Parse(cols[5])
                        };

                        shields.Add(shield);
                    }
                }

                return shields;
            }
            else
            {
                throw new Exception("Error: Shield.txt file could not be found.");
            }
        }

        public ShieldBase GetById(int param)
        {
            List<ShieldBase> shields = new List<ShieldBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ShieldBase shield;

                        string[] cols = line.Split('|');

                        shield = new ShieldBase()
                        {
                            ShieldId = int.Parse(cols[0]),
                            Name = cols[1],
                            ShieldBonus = int.Parse(cols[2]),
                            MaxDexBonus = int.Parse(cols[3]),
                            ArmorCheckPenalty = int.Parse(cols[4]),
                            ArcaneSpellFailure = int.Parse(cols[5])
                        };

                        shields.Add(shield);
                    }
                }

                return shields.FirstOrDefault(s => s.ShieldId == param);
            }
            else
            {
                throw new Exception("Error: Shield.txt file could not be found.");
            }
        }

        public List<ShieldBase> GetByName(string param)
        {
            List<ShieldBase> shields = new List<ShieldBase>();

            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    sr.ReadLine(); // skip header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ShieldBase shield;

                        string[] cols = line.Split('|');

                        shield = new ShieldBase()
                        {
                            ShieldId = int.Parse(cols[0]),
                            Name = cols[1],
                            ShieldBonus = int.Parse(cols[2]),
                            MaxDexBonus = int.Parse(cols[3]),
                            ArmorCheckPenalty = int.Parse(cols[4]),
                            ArcaneSpellFailure = int.Parse(cols[5])
                        };

                        shields.Add(shield);
                    }
                }

                return shields.Where(s => s.Name.Contains(param)).ToList();
            }
            else
            {
                throw new Exception("Error: Shield.txt file could not be found.");
            }
        }
    }
}
