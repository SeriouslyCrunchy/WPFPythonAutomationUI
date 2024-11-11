using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUITest
{
    internal class Command : INotifyPropertyChanged
    {
        //private values are required here as we must use public values to send to the UI, however the best way to update those values is to use 
        //private values to update the public values, and we can then call OnPropertyChanged on the public value
        private int _commandID;
        private string _values;
        public CommandType CommandType { get; set; }

        //getters simply return whatever value is in the associated private variable
        //setters set the private value to whatever value is passed in, and also activate the OnPropertyChanged method, using the associated value name
        //can also adjusting the onpropertychanged values to be more efficent by removing strings
        public int CommandID
        {
            get { return _commandID; }
            set
            {
                _commandID = value;
                OnPropertyChanged(nameof(CommandID));
            }
        }

        public string Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        //constructor for each new command class

        public Command(int commandID, CommandType commandType, string values)
        {
            CommandID = commandID;
            CommandType = commandType;
            Values = values;
        }

        //this must be activated each time you need to change something in the UI otherwise it wont update
        //a better way to do it is to make this method inherited
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum CommandType { Click, Drag, EnterText, Wait }
}
