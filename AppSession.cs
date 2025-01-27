﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationUITest
{
    //must inherit INotifyPropertyChanged for UI updating
    class AppSession : INotifyPropertyChanged
    {
        //required here so we can adjust the command type based on user selection
        public CommandType CommandChosen;

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

        private string listSelectText;
        public string ListSelectText
        {
            get { return listSelectText; }
            set
            {
                listSelectText = value;
                OnPropertyChanged("ListSelectText");
            }
        }
        private string commandValues;
        public string CommandValues
        {
            get { return commandValues; }
            set
            {
                commandValues = value;
                OnPropertyChanged("CommandValues");
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
            CommandList.Add(CommandCreator.CreateCommand(currentCommand, CommandType.EnterText, "TextValues"));/*CommandID, CommandType,CommandValues*/
            currentCommand++;

        }

        //functions for button click commands

        public void AddCommand(string[] InputValues)
        {
            //this checks the text input given and adjusts the command type based off it
            if (ListSelectText == "System.Windows.Controls.ListBoxItem: Enter Text")
            {
                CommandChosen = CommandType.EnterText;
            }
            else if (ListSelectText == "System.Windows.Controls.ListBoxItem: Click")
            {
                CommandChosen = CommandType.Click;
            }

            else if (ListSelectText == "System.Windows.Controls.ListBoxItem: Drag")
            {
                CommandChosen = CommandType.Drag;
            }
            else if (ListSelectText == "System.Windows.Controls.ListBoxItem: Wait")
            {
                CommandChosen = CommandType.Wait;
            }
            //adds the input values list to the command list
            CommandValues = InputValues[0].ToString(); //(ToString(InputValues[0]) + InputValues[1] + InputValues[2] + InputValues[3]);
            //OnPropertyChanged("CommandValues");

            //creates a new command with the given values (found elsewhere here)
            CommandList.Add(CommandCreator.CreateCommand(currentCommand, CommandChosen, CommandValues));
            
            //adds further info to the output box, showing the number, what command, and the values in it
            OutputText += (currentCommand + " " + CommandChosen + " " + CommandValues);
            OutputText += (Environment.NewLine);
            OnPropertyChanged("OutputText");
            currentCommand++;
        }

        //deletes the top most value from the CommandList List
        public void DeleteCommand()
        {
            CommandList.RemoveAt(CommandList.Count-1);
            currentCommand--;

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
            CommandList.Clear();
            currentCommand = 1;

        }
        public void UpdateSelected()
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
