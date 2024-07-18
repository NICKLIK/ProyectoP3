// UsuarioRepository.cs
using ProyectoP3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoP3.Repositorios
{
    public class UsuarioRepository
    {
        SQLiteConnection database;

        public UsuarioRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Usuario>();
        }

        public List<Usuario> GetUsuarios()
        {
            return database.Table<Usuario>().ToList();
        }

        public void SaveUsuario(Usuario usuario)
        {
            database.Insert(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            database.Update(usuario);
        }

        public void DeleteUsuario(int id)
        {
            database.Delete<Usuario>(id);
        }
    }
}
