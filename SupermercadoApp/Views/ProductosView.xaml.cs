using SupermercadoApp.ViewModels;

namespace SupermercadoApp.Views;

public partial class ProductosView : ContentPage
{
	public ProductosView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as ProductosViewModel;
        //if (viewmodel.NotaSeleccionada != null)
        //{
        viewmodel.ObtenerProductos();
        viewmodel.SelectedProduct = null;

        //}
    }
}