using ProyectoP3.ViewModels;
using Microsoft.Maui.Controls;

namespace ProyectoP3.Views
{
    public partial class UsuarioPage : ContentPage
    {
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = new UsuarioViewModel();
        }
    }
}

