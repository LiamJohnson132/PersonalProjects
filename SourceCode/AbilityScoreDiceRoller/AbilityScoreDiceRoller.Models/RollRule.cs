using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreDiceRoller.Models
{
    public class RollRule
    {
        public int Id { get; set; }
        public string MenuDesc { get; set; }
        public int DiceSides { get; set; }
        public int DiceCount { get; set; }
        public int DiceIgnore { get; set; }
        public int RollCount { get; set; }
        public int RollIgnore { get; set; }
    }
}
