using RandomNPCGenerator.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNPCGenerator.Controller
{
    public class AppController
    {
        private View _view = new View();
        private CharacterController _charCtrl = new CharacterController();
        public void Run()
        {
            bool run = true;
            while (run)
            {
                run = Menu();
            }
        }
        public bool Menu()
        {
            var command = _view.ReadCommand();

            switch (command.CommandName.ToLower())
            {
                case "exit":
                    return false;
                case "help":
                    Help();
                    return true;
                case "npc":
                    if (!(command.StringParam == null))
                    {
                        switch (command.StringParam.ToLower())
                        {
                            case "list":
                                _charCtrl.ListAll();
                                return true;
                            case "roll":
                                _charCtrl.CreateRandom();
                                return true;
                            case "create":
                                _charCtrl.CreateManual();
                                return true;
                            default:
                                _view.BadCommand();
                                return true;
                        }
                    } else
                    {
                        // list npc details by id
                        _charCtrl.ShowDetails(command.IntParam);
                        return true;
                    }
                default:
                    _view.BadCommand();
                    return true;
            }
        }
        public void Help()
        {
            _view.DisplayCommands();
        }
    }
}
