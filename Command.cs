using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUITest
{
    internal class Command : INotifyPropertyChanged
    {
        //private values are required here as we cannot use auto-properties to pass values to the viewer
        private int _commandID;
        private List<int> _values;
        private string _textValue;
        public CommandType CommandType { get; set; }

        //getters simply return whatever value is in the associated private variable
        //setters set the private value to whatever value is passed in, and also activate the OnPropertyChanged method, using the associated value name
        //adjusting the onpropertychanged values to be more efficent by removing strings
        public int CommandID
        {
            get { return _commandID; }
            set
            {
                _commandID = value;
                OnPropertyChanged(nameof(CommandID));
            }
        }

        public List<int> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public string TextValue
        {
            get { return _textValue; }
            set
            {
                _textValue = value;
                OnPropertyChanged(nameof(TextValue));
            }
        }

        public Command(int commandID, CommandType commandType, List<int> values, string textValues)
        {
            CommandID = commandID;
            CommandType = commandType;
            Values = values;
            TextValue = textValues;
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
