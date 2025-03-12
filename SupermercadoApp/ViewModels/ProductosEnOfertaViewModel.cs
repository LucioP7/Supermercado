using SupermercadoApp.Class;
using SupermercadoServices.Models;
using SupermercadoServices.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoApp.ViewModels
{
    public class ProductosEnOfertaViewModel : ObjectNotification
    {
        private ProductoService productoService = new ProductoService();
        private ClienteService clienteService = new ClienteService();

        private string filterProducts;
        public string FilterProducts
        {
            get { return filterProducts; }
            set
            {
                filterProducts = value;
                OnPropertyChanged();
                _ = FiltrarProducto();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set
            {
                productos = value;
                OnPropertyChanged();
            }
        }

        private List<Producto>? productosListToFilter;
        private bool activityStart;
        public bool ActivityStart
        {
            get { return activityStart; }
            set
            {
                activityStart = value;
                OnPropertyChanged();
            }
        }

        private int saldoPuntos;
        public int SaldoPuntos
        {
            get { return saldoPuntos; }
            set
            {
                saldoPuntos = value;
                OnPropertyChanged();
            }
        }

        public Command ObtenerProductosCommand { get; }
        public Command FiltrarProductosCommand { get; }

        public ProductosEnOfertaViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProductos());
            FiltrarProductosCommand = new Command(async () => await FiltrarProducto());
            ObtenerProductos();
        }

        private async Task FiltrarProducto()
        {
            if (productosListToFilter != null)
            {
                var productosFiltrados = productosListToFilter
                    .Where(p => p.Oferta &&
                                p.Nombre.ToUpper().Contains(FilterProducts.ToUpper()))
                    .Select(p => AplicarDescuentoConPuntos(p));

                Productos = new ObservableCollection<Producto>(productosFiltrados);
            }
        }

        private async Task ObtenerProductos()
        {
            FilterProducts = string.Empty;
            ActivityStart = true;
            productosListToFilter = await productoService.GetAllAsync();
            SaldoPuntos = await clienteService.ObtenerSaldoPuntosAsync();

            var productosEnOferta = productosListToFilter
                .Where(p => p.Oferta)
                .Select(p => AplicarDescuentoConPuntos(p))
                .ToList();

            Productos = new ObservableCollection<Producto>(productosEnOferta);
            ActivityStart = false;
        }

        private Producto AplicarDescuentoConPuntos(Producto producto)
        {
            decimal descuento = SaldoPuntos * 0.01m;
            producto.PrecioConPuntos = Math.Max(0, producto.Precio - descuento);
            return producto;
        }
    }
}
