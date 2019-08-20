using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDProductos.Model
{
    public class ProductosModel
    {
        [PrimaryKey, AutoIncrement, Unique]

        public int IDProducto { get; set; }
        public string CategoriaProduc { get; set; }
        public string Categoria { get; set; }
        public string NombreProduto { get; set; }

    }
}
