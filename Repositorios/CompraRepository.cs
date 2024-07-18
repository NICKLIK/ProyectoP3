using System.Collections.Generic;
using SQLite;
using ProyectoP3.Models;

namespace ProyectoP3.Repositorios
{
    public class CompraRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Compra>();
        }

        public CompraRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Compra> GetCompras()
        {
            Init();
            return conn.Table<Compra>().ToList();
        }

        public void SaveCompra(Compra compra)
        {
            Init();
            conn.Insert(compra);
        }

        public void UpdateCompra(Compra compra)
        {
            Init();
            conn.Update(compra);
        }

        public void DeleteCompra(int id)
        {
            Init();
            conn.Delete<Compra>(id);
        }
    }
}
