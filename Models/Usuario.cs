using SQLite;

namespace ProyectoP3.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Ciudad { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Institucion { get; set; }
    }
}


