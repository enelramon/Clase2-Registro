using System.Windows;
using Clase2_Registro.Entidades;
using Clase2_Registro.BLL;
using System;

namespace Clase2_Registro.UI.Registros
{
    public partial class rActores : Window
    {
        private Actores actor;
        public rActores()
        {
            InitializeComponent();
            actor = new Actores();

            this.DataContext = actor;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            var encontrado = ActoresBLL.Buscar(this.ToInt(ActorIdTextBox.Text));

            if (encontrado != null)
            {
                this.actor = encontrado;
                this.DataContext = this.actor;
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ActoresBLL.Guardar(this.actor);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActoresBLL.Eliminar(this.ToInt(ActorIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Limpiar()
        {
            this.actor = new Actores();
            this.DataContext = this.actor;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        public int ToInt(string valor)
        {
            int retorno = 0;

            int.TryParse(valor,out retorno);

            return retorno;
        }
    }


}
