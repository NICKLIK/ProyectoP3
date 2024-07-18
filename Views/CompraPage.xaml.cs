using ProyectoP3.ViewModels;
using Microsoft.Maui.Controls;

namespace ProyectoP3.Views
{
    public partial class CompraPage : ContentPage
    {
        public CompraPage()
        {
            InitializeComponent();
            BindingContext = new CompraViewModel();
        }
    }
}
