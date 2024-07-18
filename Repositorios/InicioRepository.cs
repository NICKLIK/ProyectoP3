using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProyectoP3.Models;

namespace ProyectoP3.Repositorios
{
    public class InicioRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Inicio>();
        }

        public InicioRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Inicio> GetInicioMessages()
        {
            Init();
            return conn.Table<Inicio>().ToList();
        }

        public void SaveInicioMessage(Inicio inicio)
        {
            Init();
            conn.Insert(inicio);
        }
    }
}
