using KipsuAssessment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KipsuAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctrler = new AppController();

            ctrler.Run();
        }
    }
}
