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
    public class AcercaDeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AcercaDe> Informacion { get; set; }
        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }

        public AcercaDeViewModel()
        {
            Informacion = new ObservableCollection<AcercaDe>();
            LoadInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadInfo()
        {
            var info = App.AcercaDeRepo.GetAcercaDeInfo();
            Informacion.Clear();
            foreach (var item in info)
            {
                Informacion.Add(item);
            }
        }
    }
}

