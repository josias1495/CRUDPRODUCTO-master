using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CRUDProductos.Model;
using System.IO;

namespace CRUDProductos.Service
{
   
    public class Repository
    {
        SQLiteConnection BaseDeDatos;

        public Repository()
        {
            var UbicacionBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"NombreDB.db3");
            BaseDeDatos = new SQLiteConnection(UbicacionBD);
            BaseDeDatos.CreateTable<ProductosModel>();
        }

        public int CrearProducto(ProductosModel NuevoProducto)
        {
            return BaseDeDatos.Insert(NuevoProducto);
        }

        public int ActualizarProducto(ProductosModel ProductoIdentificado)
        {
            return BaseDeDatos.Update(ProductoIdentificado);
        }

        public int EliminarProducto(ProductosModel ProductoEliminado)
        {
            return BaseDeDatos.Delete(ProductoEliminado);
        }

        public List<ProductosModel> Buscar(string text)
        {
            return BaseDeDatos.Table<ProductosModel>().ToList();
        }
       
    }
}
