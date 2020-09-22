using System.Windows;
using Clase2_Registro.Entidades;
using Clase2_Registro.BLL;
using System;
using System.Collections.Generic;

namespace Clase2_Registro.UI.Consultas
{
    public partial class cActores : Window
    { 
        public cActores()
        {
            InitializeComponent(); 
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
             var listado = new List<Actores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EstudianteId
                        listado = ActoresBLL.GetList(e => e.ActorId == this.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = ActoresBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = ActoresBLL.GetList(c => true);
            }          

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        } 
        public int ToInt(string valor)
        {
            int retorno = 0;

            int.TryParse(valor,out retorno);

            return retorno;
        }
    }

        


}
