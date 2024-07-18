using ProyectoP3.Models;
using ProyectoP3.Repositorios;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ProyectoP3.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }

        private Usuario _selectedUsuario;
        public Usuario SelectedUsuario
        {
            get => _selectedUsuario;
            set
            {
                _selectedUsuario = value;
                OnPropertyChanged();
                if (_selectedUsuario != null)
                {
                    Nombre = _selectedUsuario.Nombre;
                    Apellido = _selectedUsuario.Apellido;
                    Email = _selectedUsuario.Email;
                    Contrasena = _selectedUsuario.Contrasena;
                    Ciudad = _selectedUsuario.Ciudad;
                    Edad = _selectedUsuario.Edad;
                    Genero = _selectedUsuario.Genero;
                    Institucion = _selectedUsuario.Institucion;
                }
                OnPropertyChanged(nameof(IsUsuarioSelected));
            }
        }

        public bool IsUsuarioSelected => SelectedUsuario != null;

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        private string _apellido;
        public string Apellido
        {
            get => _apellido;
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _contrasena;
        public string Contrasena
        {
            get => _contrasena;
            set
            {
                _contrasena = value;
                OnPropertyChanged();
            }
        }

        private string _ciudad;
        public string Ciudad
        {
            get => _ciudad;
            set
            {
                _ciudad = value;
                OnPropertyChanged();
            }
        }

        private int _edad;
        public int Edad
        {
            get => _edad;
            set
            {
                _edad = value;
                OnPropertyChanged();
            }
        }

        private string _genero;
        public string Genero
        {
            get => _genero;
            set
            {
                _genero = value;
                OnPropertyChanged();
            }
        }

        private string _institucion;
        public string Institucion
        {
            get => _institucion;
            set
            {
                _institucion = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveUsuarioCommand { get; }
        public ICommand EditUsuarioCommand { get; }
        public ICommand DeleteUsuarioCommand { get; }

        public UsuarioViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();
            SaveUsuarioCommand = new Command(SaveUsuario);
            EditUsuarioCommand = new Command(EditUsuario);
            DeleteUsuarioCommand = new Command(DeleteUsuario);
            LoadUsuarios();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadUsuarios()
        {
            var usuarios = App.UsuarioRepo.GetUsuarios();
            Usuarios.Clear();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }
        }

        private void SaveUsuario()
        {
            if (SelectedUsuario == null)
            {
                var usuario = new Usuario
                {

                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    Contrasena = Contrasena,
                    Ciudad = Ciudad,
                    Edad = Edad,
                    Genero = Genero,
                    Institucion = Institucion
                };

                App.UsuarioRepo.SaveUsuario(usuario);
            }
            else
            {
                SelectedUsuario.Nombre = Nombre;
                SelectedUsuario.Apellido = Apellido;
                SelectedUsuario.Email = Email;
                SelectedUsuario.Contrasena = Contrasena;
                SelectedUsuario.Ciudad = Ciudad;
                SelectedUsuario.Edad = Edad;
                SelectedUsuario.Genero = Genero;
                SelectedUsuario.Institucion = Institucion;

                App.UsuarioRepo.UpdateUsuario(SelectedUsuario);
            }

            LoadUsuarios();
            ClearFields();
        }

        private void EditUsuario()
        {
            if (SelectedUsuario != null)
            {
                SaveUsuario();
            }
        }

        private void DeleteUsuario()
        {
            if (SelectedUsuario != null)
            {
                App.UsuarioRepo.DeleteUsuario(SelectedUsuario.Id);
                LoadUsuarios();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Contrasena = string.Empty;
            Ciudad = string.Empty;
            Edad = 0;
            Genero = string.Empty;
            Institucion = string.Empty;
            SelectedUsuario = null;
        }
    }
}
