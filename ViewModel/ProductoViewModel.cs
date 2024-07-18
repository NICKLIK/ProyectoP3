using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoP3.Repositorios;
using ProyectoP3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProyectoP3.ViewModels
{
    public class ProductoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand GetProductosCommand { get; private set; }

        public ProductoViewModel()
        {
            Productos = new ObservableCollection<Producto>();
            GetProductosCommand = new Command(async () => await GetProductosFromApi());
            LoadProductos();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadProductos()
        {
            var productos = App.ProductoRepo.GetProductos();
            Productos.Clear();
            foreach (var producto in productos)
            {
                Productos.Add(producto);
            }
        }

        private async Task GetProductosFromApi()
        {
            var productos = await App.ProductoRepo.GetProductosFromApi();
            Productos.Clear();
            foreach (var producto in productos)
            {
                Productos.Add(producto);
            }
        }
    }
}
