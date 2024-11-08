﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationUITest
{
    //must inherit INotifyPropertyChanged for UI updating
    class AppSession : INotifyPropertyChanged
    {



        //private values are required here as we must use public values to send to the UI, however the best way to update those values is to use 
        //private values to update the public values, and we can then call OnPropertyChanged on the public value
        private string outputText;
        public string OutputText
        {
            get { return outputText; }
            set
            {
                outputText = value;
                OnPropertyChanged("OutputText");
            }
        }

        private int currentCommand = 0;

        //we want a way to process items in a list and present them in a way the player can see
        //the best way to do this is with an ObservableCollection, as this also automatically updates the UI
        //and so does not require an OnPropertyChanged statement
        public ObservableCollection<Command> CommandList { get; set; }

        //these must be initialised and is best done in a constructor
        public AppSession()
        {
            CommandList = new ObservableCollection<Command>();

            //We can add items directly into the command list here if we desire and they will show up on app start
            CommandList.Add(CommandCreator.CreateCommand(currentCommand, CommandType.EnterText, null, "TextValues"));/*CommandID, CommandType,CommandValues*/
            currentCommand++;

            
        }

        //functions for button click commands

        public void AddCommand()
        {
            CommandList.Add(CommandCreator.CreateCommand(currentCommand, CommandType.EnterText, null, "TextValues2"));
            string OutputTextLine = string.Concat(CommandList[0]);
            OutputText += (OutputTextLine);
            OutputText += (Environment.NewLine);
            OnPropertyChanged("OutputText");
            currentCommand++;
        }
        public void DeleteCommand()
        {
            CommandList.RemoveAt(CommandList.Count-1);

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
