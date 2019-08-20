using System;
using System.Collections.Generic;
using System.Text;
using CRUDProductos.Model;
using CRUDProductos.View;
using CRUDProductos.Service;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CRUDProductos.VIewModel
{
    public class InicioProductoViewModel : ClaseBase
    {
        Repository Repositorio { get; set; }
        
        private ObservableCollection<ProductosModel> _Producto;

        public ObservableCollection<ProductosModel> Producto
        {
            get { return _Producto; }
            set { _Producto = value; OnPropertyChanged(); }
        }

        public Command GuardarCommand { get; set; }
        public ProductosModel ProductoSeleccionado { get; set; }

        public int IDProductoF { get; set; }
        public string CategoriaProductF { get; set; }
        public string CategoriaF { get; set; }
        public string NombreProductoF { get; set; }


        

        public void ObtenerProducto()
        {
            var Repo = new Repository();
            var Resultado = Repo.Buscar(NombreProductoF);
            Producto = new ObservableCollection<ProductosModel>(Resultado);
        }

        public InicioProductoViewModel()
        {
            ObtenerProducto();
            ProductoSeleccionado = null;
            Repositorio = new Repository();
            GuardarCommand = new Command(GuardarCambios);
        }

        public InicioProductoViewModel(ProductosModel ProductoParametro): this()
        {
            ProductoSeleccionado = ProductoParametro;
            if (ProductoParametro != null)
            {
                NombreProductoF = ProductoParametro.NombreProduto;
                CategoriaProductF = ProductoParametro.CategoriaProduc;
                CategoriaF = ProductoParametro.Categoria;
            }
        }

        void GuardarCambios()
        {
            if (ProductoSeleccionado !=null)
            {
                ProductoSeleccionado.NombreProduto = NombreProductoF;
                ProductoSeleccionado.CategoriaProduc = CategoriaProductF;
                ProductoSeleccionado.Categoria = CategoriaF;

                var respuestaDB = Repositorio.ActualizarProducto(ProductoSeleccionado);
               
            } else
            {
                var productoNuevo = new ProductosModel();
                productoNuevo.NombreProduto = NombreProductoF;
                productoNuevo.CategoriaProduc = CategoriaProductF;
                productoNuevo.Categoria = CategoriaF;

                var resultadoDb = Repositorio.CrearProducto(productoNuevo);
            }
        }


    }
}
