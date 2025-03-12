//using Java.Time;
using SupermercadoApp.ViewModels;
using SupermercadoServices.Models;

namespace SupermercadoApp.Views;

[QueryProperty(nameof(Product), "ProductToEdit")]
public partial class AddEditProductoView : ContentPage
{
    public Producto Product
    {
        set
        {
            var producto = value;
            var viewmodel = this.BindingContext as AddEditProductoViewModel;
            viewmodel.EditProduct = producto;
        }
    }
    //nuevo
    public AddEditProductoView()
	{
		InitializeComponent();
	}
    //editar
    //public AddEditProductoView(Producto producto)
    //{
    //    InitializeComponent();
    //    //asigno al viewmodel el producto que me pasan
    //    var viewmodel = this.BindingContext as AddEditProductoViewModel;
    //    viewmodel.EditProduct = producto;
    //}
}