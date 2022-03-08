using AbilityScoreDiceRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreDiceRoller.UI
{
    public class UserInterface
    {
        public RollRule Menu(List<RollRule> rules)
        {
            Console.Clear();
            var line = "[{0}] {1}";
            foreach (var rule in rules)
            {
                Console.WriteLine(line, rule.Id, rule.MenuDesc);
            }
            Console.WriteLine("Enter the number of the menu choice.");
            
            while (true)
            {
                Console.Write("Choice: ");
                var input = Console.ReadLine();

                if (input == null || !int.TryParse(input, out int output))
                {
                    Console.WriteLine("Invalid menu option. Please enter a valid menu choice.");
                } else
                {
                    var rule = rules.Where(r => r.Id == output).FirstOrDefault();
                    if (rule != null)
                    {
                        return rule;
                    } else
                    {
                        Console.WriteLine("Invalid menu option. Please enter a valid menu choice.");
                    }
                }
            }
        }

        public void DisplayScores(List<int> scores)
        {
            if (scores.Count != 6)
            {
                throw new Exception("Error: An incorrect amount of Ability Scores has been created.");
            }

            Console.Clear();
            Console.WriteLine($"The rolled ability scores are: {scores[0]}, {scores[1]}, {scores[2]}, {scores[3]}, {scores[4]}, and {scores[5]}");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
