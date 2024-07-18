using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoP3.Repositorios;
using ProyectoP3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProyectoP3.ViewModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Inicio> Mensajes { get; set; }
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public InicioViewModel()
        {
            Mensajes = new ObservableCollection<Inicio>();
            LoadMessages();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadMessages()
        {
            var mensajes = App.InicioRepo.GetInicioMessages();
            Mensajes.Clear();
            foreach (var mensaje in mensajes)
            {
                Mensajes.Add(mensaje);
            }
        }
    }
}
