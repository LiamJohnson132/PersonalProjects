using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data
{
    public class DiceRepository
    {
        public int RollDice(int quantity, int sides, Random r)
        {
            int result = 0;

            for (int i = 0; i < quantity; i++)
            {
                result += r.Next(1, sides + 1);
            }
            return result;
        }
    }
}
