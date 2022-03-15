using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.UI
{
    public class UserIO
    {
        public int PromptInt(string prompt, string errorMessage, int min, int max)
        {
            Console.Write(prompt);

            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result >= min && result <= max)
                {
                    return result;
                } else
                {
                    throw new Exception(errorMessage);
                }
            } else
            {
                throw new Exception(errorMessage);
            }
        }

        public bool PromptBool(string prompt)
        {
            Console.Write("Press Enter to " + prompt + " or press any other button to cancel.");

            return Console.ReadKey().Key == ConsoleKey.Enter ? true : false;
        }

        public string ReadCommand()
        {
            return Console.ReadLine();
        }

        public string ReadIntOrString(string intParam, string stringParam)
        {
            Console.Write($"{intParam} or {stringParam}: ");
            var input = Console.ReadLine();
            return input;
        }
    }
}
