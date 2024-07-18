using ProyectoP3.Repositorios;
using System.IO;

namespace ProyectoP3
{
    public partial class App : Application
    {
        public static InicioRepository InicioRepo { get; private set; }
        public static AcercaDeRepository AcercaDeRepo { get; private set; }
        public static ProductoRepository ProductoRepo { get; private set; }
        public static CompraRepository CompraRepo { get; private set; }
        public static UsuarioRepository UsuarioRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ProyectoP3.db3");
            InicioRepo = new InicioRepository(dbPath);
            AcercaDeRepo = new AcercaDeRepository(dbPath);
            ProductoRepo = new ProductoRepository(dbPath);
            CompraRepo = new CompraRepository(dbPath);
            UsuarioRepo = new UsuarioRepository(dbPath);

            MainPage = new AppShell();
        }
    }
}

