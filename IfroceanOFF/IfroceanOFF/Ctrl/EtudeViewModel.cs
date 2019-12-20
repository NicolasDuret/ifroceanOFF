using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private string titreEtude;
        private DateTime dateCreationEtude;
        private DateTime dateFinEtude;
        private string nomPlage;
        private string departementPlage;


        public EtudeViewModel() { }
        public EtudeViewModel(int idEtude, string titre, DateTime dateCrea, DateTime dateFin, string nomPlage, string departementPlage)
        {
            this.idEtude = idEtude;
            this.titreEtudeProperty = titre;
            this.dateCreationEtudeProperty = dateCrea;
            this.dateFinEtudeProperty = dateFin;
            this.nomPlageProperty = nomPlage;
            this.departementPlage = departementPlage;
        }
        public EtudeViewModel(int idEtude, string titre, DateTime dateCrea, DateTime dateFin)
        {
            this.idEtude = idEtude;
            this.titreEtudeProperty = titre;
            this.dateCreationEtudeProperty = dateCrea;
            this.dateFinEtudeProperty = dateFin;
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
        }
        public string titreEtudeProperty
        {
            get { return titreEtude; }
            set
            {
                titreEtude = value;
                OnPropertyChanged("titreEtudeProperty");
            }
        }

        public DateTime dateCreationEtudeProperty
        {
            get { return dateCreationEtude; }
            set
            {
                dateCreationEtude = value;
                OnPropertyChanged("dateCreationEtudeProperty");
            }
        }
        public DateTime dateFinEtudeProperty
        {
            get { return dateFinEtude; }
            set
            {
                dateFinEtude = value;
                OnPropertyChanged("dateFinEtudeProperty");
            }
        }
        public string nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value;
                OnPropertyChanged("nomPlageProperty");
            }
        }
        public string departementPlageProperty
        {
            get { return departementPlage; }
            set
            {
                departementPlage = value;
                OnPropertyChanged("departementPlageProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }


        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeORM.updateEtude(this);
            }
        }
    }


}
