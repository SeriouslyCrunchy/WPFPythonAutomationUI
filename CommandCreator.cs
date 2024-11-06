using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUITest
{
    //this static class only exists to create commands with inputs fed into it
    internal static class CommandCreator
    {

        public static Command CreateCommand()
        {
            Command command = new Command(0,CommandType.EnterText,null,"Testtext");
            return command;

        }

    }
}
