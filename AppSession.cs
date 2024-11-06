using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationUITest
{
    class AppSession : INotifyPropertyChanged
    {

        //we want a way to process items in a list and present them in a way the player can see
        //the best way to do this is with an ObservableCollection, as this also automatically updates the UI
        //and so does not require an OnPropertyChanged statement
        public ObservableCollection<Command> CommandList { get; set; }
        public string TestText;

        ////these must be initialised and is best done in a constructor
        public AppSession()
        {
            CommandList = new ObservableCollection<Command>();

            //We can add items directly into the command list here if we desire and they will show up on app start
            CommandList.Add(CommandCreator.CreateCommand());/*CommandID, CommandType,CommandValues*/
            CommandList.Add(CommandCreator.CreateCommand());
            CommandList.Add(CommandCreator.CreateCommand());
            TestText = string.Concat(CommandList[0]);
        }

        public void AddCommand()
        {


        }
        public void DeleteCommand()
        {


        }
        public void SaveCommands()
        {


        }
        public void LoadCommands()
        {


        }
        public void RunCommands()
        {


        }
        public void ClearCommands()
        {


        }



        //this must be activated each time you need to change something in the UI otherwise it wont update
        //a better way to do it is to make this method inherited
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
