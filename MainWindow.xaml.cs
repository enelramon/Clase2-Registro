using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clase2_Registro.Entidades;
using Clase2_Registro.UI.Registros;
using Clase2_Registro.UI.Consultas;
using Microsoft.EntityFrameworkCore;

namespace Clase2_Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rActoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rActores rActores = new rActores();
            rActores.Show();
        }

        private void cActoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cActores cActores = new cActores();
            cActores.Show();
        }

    }
}
