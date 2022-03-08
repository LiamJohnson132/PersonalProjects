using AbilityScoreDiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreDiceRoller.Data
{
    public class RuleRepository
    {
        private List<RollRule> _rules;

        public RuleRepository()
        {
            _rules = new List<RollRule>()
            {
                new RollRule()
                {
                    Id = 1,
                    MenuDesc = "3d6 x 6",
                    DiceCount = 3,
                    DiceSides = 6,
                    DiceIgnore = 0,
                    RollCount = 6,
                    RollIgnore = 0
                },
                new RollRule()
                {
                    Id = 2,
                    MenuDesc = "3d6 x 7 (drop the lowest)",
                    DiceCount = 3,
                    DiceSides = 6,
                    DiceIgnore = 0,
                    RollCount = 7,
                    RollIgnore = 1
                },
                new RollRule()
                {
                    Id = 3,
                    MenuDesc = "4d6 (drop the lowest) x 6",
                    DiceCount = 4,
                    DiceSides = 6,
                    DiceIgnore = 1,
                    RollCount = 6,
                    RollIgnore = 0
                },
                new RollRule()
                {
                    Id = 4,
                    MenuDesc = "4d6 (drop the lowest) x 7 (drop the lowest)",
                    DiceCount = 4,
                    DiceSides = 6,
                    DiceIgnore = 1,
                    RollCount = 7,
                    RollIgnore = 1
                },
                new RollRule()
                {
                    Id = 5,
                    MenuDesc = "5d6 (drop the 2 lowest) x 6",
                    DiceCount = 5,
                    DiceSides = 6,
                    DiceIgnore = 2,
                    RollCount = 6,
                    RollIgnore = 0
                },
                new RollRule()
                {
                    Id = 6,
                    MenuDesc = "5d6 (drop the 2 lowest) x 7 (drop the lowest)",
                    DiceCount = 5,
                    DiceSides = 6,
                    DiceIgnore = 2,
                    RollCount = 7,
                    RollIgnore = 1
                },
                new RollRule()
                {
                    Id = 7,
                    MenuDesc = "1d20 x 6",
                    DiceCount = 1,
                    DiceSides = 20,
                    DiceIgnore = 0,
                    RollCount = 6,
                    RollIgnore = 0
                }
            };
        }
        public List<RollRule> GetAll()
        {
            return _rules;
        }

        public RollRule GetById(int id)
        {
            return _rules.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}
