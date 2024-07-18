using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoP3.Models;
using SQLite;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProyectoP3.Repositorios
{
    public class ProductoRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Producto>();
        }

        public ProductoRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Producto> GetProductos()
        {
            Init();
            return conn.Table<Producto>().ToList();
        }

        public void SaveProducto(Producto producto)
        {
            Init();
            conn.Insert(producto);
        }

        public async Task<List<Producto>> GetProductosFromApi()
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://api.example.com/productos");
            var productos = JsonConvert.DeserializeObject<List<Producto>>(response);
            return productos;
        }
    }
}