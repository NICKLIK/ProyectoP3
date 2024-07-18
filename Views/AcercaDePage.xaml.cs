using ProyectoP3.ViewModels;

namespace ProyectoP3.Views
{
    public partial class AcercaDePage : ContentPage
    {
        public AcercaDePage()
        {
            InitializeComponent();
            BindingContext = new AcercaDeViewModel();
        }
    }
}
