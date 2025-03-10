using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Commands;

using System.Windows;
using System.Security.Policy;
using WpfApp1.Model;
using TFlex.DOCs.Model;
using WpfApp1.ViewModels.Base;


namespace WpfApp1.ViewModels
{
    class ApplicationViewModel : ViewModel
    {
        private string _Title="Main window";
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        
        private ServerConnection _connection;        
        public ServerConnection Connection
        {
            get => _connection;
            set => Set(ref _connection, value);            
        }


        private string _Status;

        private Table _selected_table;
        public Table Selected_table {
            get => _selected_table;
            set => Set(ref _selected_table, value);                          
        }

        public ObservableCollection<Table> Tables { get; set; }

        private RelayCommand _loadCommand;
        public RelayCommand LoadCommand
        {
            get => _loadCommand ?? (_loadCommand = new RelayCommand(Load_method));
            
        }

        private void Load_method(object obj)
        {            
            MessageBox.Show("load command");            
        }
        
        private RelayCommand connect2docs;

        public ICommand Connect2docs
        {
            get
            {
                if (connect2docs == null)
                {
                    connect2docs = new RelayCommand(PerformConnect2docs);
                }

                return connect2docs;
            }
        }


        private void PerformConnect2docs(object commandParameter)
        {         
            Thread staThread = new Thread(() =>
            {               
                Connection = Connect.connect();
            });
            //STA поток
            staThread.SetApartmentState(ApartmentState.STA); 
            staThread.Start();
        }

    

    }
}
