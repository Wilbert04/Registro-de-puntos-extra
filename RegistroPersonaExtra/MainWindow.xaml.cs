using RegistroPersonaExtra.BLL;
using RegistroPersonaExtra.Entidades;
using RegistroPersonaExtra.UI.Consultas;
using System;
using System.Collections.Generic;
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

namespace RegistroPersonaExtra
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

        
        private void ButtonNuevo(object sender, RoutedEventArgs e)
        {
            Nombretextbox.Text = string.Empty;

        }

        private Personas LlenaClase()
        {
            Personas personas = new Personas();

            personas.PersonaId = Convert.ToInt32(Idtextbox.Text);
            personas.Nombre = Nombretextbox.Text;

            return personas;
        }

        private void LlenaCampo(Personas personas)
        {
            Idtextbox.Text = Convert.ToString(personas.PersonaId);
            Nombretextbox.Text = personas.Nombre;

        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(Nombretextbox.Text))
            {
                MessageBox.Show("Debe llenar el Campo Nombre!!");
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDatos()
        {
            Personas personas = PersonasBLL.Buscar((int)Convert.ToInt32(Idtextbox.Text));
            return (personas != null);
        }

        private void ButtonGuardar(object sender, RoutedEventArgs e)
        {
            Personas personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();


            if (Idtextbox.Text == "0")
                paso = PersonasBLL.Guardar(personas);

            else
            {
                if (!ExisteEnLaBaseDatos())
                {
                    MessageBox.Show("No puede modificar alguien que no existe");
                }

                paso = PersonasBLL.Modificar(personas);
            }

            if (paso)
            {
                MessageBox.Show("¡¡Guardado!!");
            }
            else
            {
                MessageBox.Show("No se Guardo!!");
            }
        }

        private void ButtonEliminar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(Idtextbox.Text, out id);

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!");
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar!!");
            }
        }

        private void ButtonBuscar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(Idtextbox.Text, out id);
            Personas personas = new Personas();

            personas = PersonasBLL.Buscar(id);

            if (personas != null)
            {
                MessageBox.Show("Persona Encontrada!!");
                LlenaCampo(personas);
            }
            else
            {
                MessageBox.Show("Persona No Encontrada!!");
            }
        }

        private void ButtonConsultar(object sender, RoutedEventArgs e)
        {
            ConsultaPersonas cpersonas = new ConsultaPersonas();
            cpersonas.Show();
        }
    }
  }

