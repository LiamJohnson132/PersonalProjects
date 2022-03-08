using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreDiceRoller.BLL
{
    public class DiceRoller
    {
        public int RollDice(int sides, int count, int ignore = 0)
        {
            Random r = new Random();

            List<int> rolls = new List<int>();

            int total = 0;

            for (int i = 0; i < count; i++)
            {
                rolls.Add(r.Next(1, sides + 1));
            }

            /*rolls = rolls.OrderByDescending(x => x).ToList();

            if (ignore != 0)
            {
                rolls.RemoveRange(rolls.Count - ignore, ignore);
            }*/

            if (ignore > 0)
            {
                for (int i = 0; i < ignore; i++)
                {
                    rolls.Remove(rolls.Min());
                }
            }

            total = rolls.Sum();

            return total;
        }
    }
}
