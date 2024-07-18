using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace ProyectoP3.Views
{
    public partial class ProductoPage : ContentPage
    {
        public ObservableCollection<ProductoItem> Entretenimiento { get; set; }
        public ObservableCollection<ProductoItem> Electrodomesticos { get; set; }
        public ObservableCollection<ProductoItem> Servicios { get; set; }
        public ObservableCollection<ProductoItem> Vestimenta { get; set; }
        public ObservableCollection<ProductoItem> Descuentos { get; set; }

        public ProductoPage()
        {
            InitializeComponent();

            // Inicialización de las colecciones
            Entretenimiento = new ObservableCollection<ProductoItem>
            {
                new ProductoItem { ImageUrl = "ajedrez.jpg" },
                new ProductoItem { ImageUrl = "cartas.jpg" },
                new ProductoItem { ImageUrl = "spinner.jpg" },
                new ProductoItem { ImageUrl = "yoyo.jpg" },
                new ProductoItem { ImageUrl = "legos.jpg" },
                new ProductoItem { ImageUrl = "trompo.jpg" }
            };

            Electrodomesticos = new ObservableCollection<ProductoItem>
            {
                new ProductoItem { ImageUrl = "telefono.jpg" },
                new ProductoItem { ImageUrl = "ps5.jpg" },
                new ProductoItem { ImageUrl = "reloj.jpg" },
                new ProductoItem { ImageUrl = "xbox.jpg" },
                new ProductoItem { ImageUrl = "switch.jpg" },
                new ProductoItem { ImageUrl = "refri.jpg" }
            };

            Servicios = new ObservableCollection<ProductoItem>
            {
                new ProductoItem { ImageUrl = "curso.jpg" },
                new ProductoItem { ImageUrl = "frances.jpg" },
                new ProductoItem { ImageUrl = "redes.jpg" },
                new ProductoItem { ImageUrl = "ingles.jpg" },
                new ProductoItem { ImageUrl = "social.jpg" },
                new ProductoItem { ImageUrl = "diseno.jpg" }
            };

            Vestimenta = new ObservableCollection<ProductoItem>
            {
                new ProductoItem { ImageUrl = "nike.jpg" },
                new ProductoItem { ImageUrl = "gorra.jpg" },
                new ProductoItem { ImageUrl = "saco.jpg" },
                new ProductoItem { ImageUrl = "adidas.jpg" },
                new ProductoItem { ImageUrl = "piercings.jpg" },
                new ProductoItem { ImageUrl = "camiseta.jpg" }
            };

            Descuentos = new ObservableCollection<ProductoItem>
            {
                new ProductoItem { ImageUrl = "ingles.jpg" },
                new ProductoItem { ImageUrl = "nike.jpg" },
                new ProductoItem { ImageUrl = "reloj.jpg" },
                new ProductoItem { ImageUrl = "legos.jpg" },
                new ProductoItem { ImageUrl = "diseno.jpg" },
                new ProductoItem { ImageUrl = "saco.jpg" }
            };

            BindingContext = this;
        }

        public class ProductoItem
        {
            public string ImageUrl { get; set; }
        }
    }
}
