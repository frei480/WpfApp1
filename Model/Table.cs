using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Table : INotifyPropertyChanged
    {
        private string title;
        private string file_model;

        public string Title 
        { 
            get => title; 
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string File_model { get => file_model; set
            {
                file_model = value;
                OnPropertyChanged("file_model");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
