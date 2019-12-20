using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class PlageViewModel
    {

        private int idPlage;
        private string nomPlage;
        private string departementPlage;
        private int communePlage;

        //private string concat;


        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, string departement, int Commune_idCommune)
        {
            this.idPlage = id;
            this.nomPlageProperty = nom;
            this.departementPlageProperty = departement;
            this.communePlageProperty = Commune_idCommune;

        }
        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value;
                OnPropertyChanged("nomPlageProperty");
            }

        }
        public String departementPlageProperty
        {
            get { return departementPlage; }
            set
            {
                this.departementPlage = value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }
        public int communePlageProperty
        {
            get { return communePlage; }
            set
            {
                this.communePlage = 1;
                this.concatProperty = this.communePlage + " " + 1;
                OnPropertyChanged("communePlageProperty");
            }
        }

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageORM.updatePlage(this);
            }
        }
    }
}

