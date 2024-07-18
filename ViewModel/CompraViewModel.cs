using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ProyectoP3.Models;
using ProyectoP3.Repositorios;

namespace ProyectoP3.ViewModels
{
    public class CompraViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Compra> Compras { get; set; }

        private Compra _selectedCompra;
        public Compra SelectedCompra
        {
            get => _selectedCompra;
            set
            {
                _selectedCompra = value;
                OnPropertyChanged();
                if (_selectedCompra != null)
                {
                    UsuarioId = _selectedCompra.UsuarioId;
                    ProductoId = _selectedCompra.ProductoId;
                    Cantidad = _selectedCompra.Cantidad;
                    PrecioTotal = _selectedCompra.PrecioTotal;
                }
                OnPropertyChanged(nameof(IsCompraSelected));
            }
        }

        public bool IsCompraSelected => SelectedCompra != null;

        private int _usuarioId;
        public int UsuarioId
        {
            get => _usuarioId;
            set
            {
                _usuarioId = value;
                OnPropertyChanged();
            }
        }

        private int _productoId;
        public int ProductoId
        {
            get => _productoId;
            set
            {
                _productoId = value;
                OnPropertyChanged();
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get => _cantidad;
            set
            {
                _cantidad = value;
                OnPropertyChanged();
            }
        }

        private decimal _precioTotal;
        public decimal PrecioTotal
        {
            get => _precioTotal;
            set
            {
                _precioTotal = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCompraCommand { get; }
        public ICommand EditCompraCommand { get; }
        public ICommand DeleteCompraCommand { get; }

        public CompraViewModel()
        {
            Compras = new ObservableCollection<Compra>();
            SaveCompraCommand = new Command(SaveCompra);
            EditCompraCommand = new Command(EditCompra);
            DeleteCompraCommand = new Command(DeleteCompra);
            LoadCompras();
        }

        private void LoadCompras()
        {
            var compras = App.CompraRepo.GetCompras();
            Compras.Clear();
            foreach (var compra in compras)
            {
                Compras.Add(compra);
            }
        }

        private void SaveCompra()
        {
            if (SelectedCompra == null)
            {
                var compra = new Compra
                {
                    UsuarioId = UsuarioId,
                    ProductoId = ProductoId,
                    Cantidad = Cantidad,
                    PrecioTotal = PrecioTotal
                };

                App.CompraRepo.SaveCompra(compra);
            }
            else
            {
                SelectedCompra.UsuarioId = UsuarioId;
                SelectedCompra.ProductoId = ProductoId;
                SelectedCompra.Cantidad = Cantidad;
                SelectedCompra.PrecioTotal = PrecioTotal;

                App.CompraRepo.UpdateCompra(SelectedCompra);
            }

            LoadCompras();
            ClearFields();
        }

        private void EditCompra()
        {
            if (SelectedCompra != null)
            {
                SaveCompra();
            }
        }

        private void DeleteCompra()
        {
            if (SelectedCompra != null)
            {
                App.CompraRepo.DeleteCompra(SelectedCompra.Id);
                LoadCompras();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            UsuarioId = 0;
            ProductoId = 0;
            Cantidad = 0;
            PrecioTotal = 0;
            SelectedCompra = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
