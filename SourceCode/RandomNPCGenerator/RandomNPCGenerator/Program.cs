using RandomNPCGenerator.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var appCtrl = new AppController();
            appCtrl.Run();
        }
    }
}
