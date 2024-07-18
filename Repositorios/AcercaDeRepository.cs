using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoP3.Models;
using SQLite;

namespace ProyectoP3.Repositorios
{
    public class AcercaDeRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<AcercaDe>();
        }

        public AcercaDeRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<AcercaDe> GetAcercaDeInfo()
        {
            Init();
            return conn.Table<AcercaDe>().ToList();
        }

        public void SaveAcercaDeInfo(AcercaDe acercaDe)
        {
            Init();
            conn.Insert(acercaDe);
        }
    }
}
