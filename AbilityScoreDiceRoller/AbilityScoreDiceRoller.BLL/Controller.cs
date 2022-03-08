using AbilityScoreDiceRoller.Data;
using AbilityScoreDiceRoller.Models;
using AbilityScoreDiceRoller.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreDiceRoller.BLL
{
    public class Controller
    {
        public void Run()
        {
            var userInterface = new UserInterface();
            var ruleRepo = new RuleRepository();
            bool run = true;

            while (run)
            {
                try
                {
                    var rule = userInterface.Menu(ruleRepo.GetAll());

                    var abilities = RollAbilities(rule);

                    userInterface.DisplayScores(abilities);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<int> RollAbilities(RollRule rule)
        {
            var diceRoller = new DiceRoller();

            List<int> rolls = new List<int>();

            for (int i = 0; i < rule.RollCount; i++)
            {
                rolls.Add(diceRoller.RollDice(rule.DiceSides, rule.DiceCount, rule.DiceIgnore));
            }

            /*rolls = rolls.OrderByDescending(r => r).ToList();

            if (rule.RollIgnore != 0)
            {
                rolls.RemoveRange(rolls.Count - rule.RollIgnore, rule.RollIgnore);
            }*/

            if (rule.RollIgnore > 0)
            {
                for (int i = 0; i < rule.RollIgnore; i++)
                {
                    rolls.Remove(rolls.Min());
                }
            }

            return rolls;
        }
    }
}
