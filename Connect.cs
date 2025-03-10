using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using TFlex.DOCs.Model;
using TFlex.DOCs.Model.Classes;
using TFlex.DOCs.Model.References.Units;
using TFlex.PdmFramework.Resolve;

namespace WpfApp1
{
    class Connect
    {
        private static ServerConnection _connection;
        public static ServerConnection connect()
        {
            AssemblyResolver.Instance.AddDirectory(@"C:\Program Files (x86)\T-FLEX DOCs 17\Program");
            MessageBox.Show("connect command");// Ваша логика здесь
            try
            {
                // Подключаемся к серверу. Должен появиться диалог логина
                _connection = ServerConnection.Open();
                if (_connection is null)
                {                
                    return null;
                }
                return _connection;
            }
            catch
            {                
                return null;
            }
        }
    }
}
