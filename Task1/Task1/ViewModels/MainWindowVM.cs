﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.Model;
using Task1.Commands;

namespace Task1.ViewModels
{
    internal class MainWindowVM : VMBase
    {
        #region Input ID
        public string _input_Id;
        public string Input_Id
        {
            get => _input_Id;
            set
            {
                Set(ref _input_Id, value);
            }
        }
        #endregion

        #region Id_List
        public static ObservableCollection<int> _id_list;
        public ObservableCollection<int> Id_list
        {
            get => _id_list;
            set
            {
                Set(ref _id_list, value);
            }
        }
        #endregion

        #region List of strings
        public static ObservableCollection<Message> _messages = new();
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set
            {
                Set(ref _messages, value);
            }
        }
        #endregion

        #region Command
        public ICommand GetStringsCommand { get; }
        private void OnGetStringsCommandExecuted(object p)
        {
            Id_list = _input_Id.ParseId();
            foreach(var e in _id_list)
            {
                Methods.Get(e);
            }
        }
        private bool CanGetStringsCommandExecute(object p)
        {
            if (!string.IsNullOrEmpty(_input_Id)) return true;
            else return false;
        }
        #endregion
        public MainWindowVM()
        {
            GetStringsCommand = new LambdaCommand(OnGetStringsCommandExecuted, CanGetStringsCommandExecute);
            /*
             * метод подсчета количества гласных
             * сделать список
             * вывести список
             */
        }
    }
}
