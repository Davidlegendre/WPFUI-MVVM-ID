using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UiDesktopApp2.Services
{
    internal class ServicePrueba : IServicePrueba
    {
        public void Saludar()
        {
            MessageBox.Show("Hola");
        }

        public string Num()
        {
            return new Random().Next().ToString();
        }
    }
}
