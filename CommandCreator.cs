using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUITest
{
    //this static class only exists to create commands with inputs fed into it
    internal static class CommandCreator
    {
        //basic command creator, this takes in values passed in and creates a new command based off them
        public static Command CreateCommand(int CommandID, CommandType commandtype, List<int> IntValues, string TextValues)
        {
            Command command = new Command(CommandID, commandtype, IntValues, TextValues);
            return command;

        }

    }
}
