using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    class PersonneViewModel
    {

        private int idPersonne;
        private string nomPersonne;
        private string prenomPersonne;
        private EtudeViewModel etudePersonne;
        private int isAdminPersonne;
        //private string concat;


        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom, int isAdmin, EtudeViewModel etudePersonneProperty)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.isAdminPersonneProperty = isAdmin;
            this.etudePersonneProperty = etudePersonneProperty;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomPersonne;
                OnPropertyChanged("nomPersonneProperty");
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                this.concatProperty = this.nomPersonne + " " + value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }
        public EtudeViewModel etudePersonneProperty
        {
            get { return etudePersonne; }
            set
            {
                this.etudePersonne = value;
                OnPropertyChanged("etudePersonneProperty");
            }
        }
        public int isAdminPersonneProperty
        {
            get { return isAdminPersonne; }
            set
            {
                this.isAdminPersonne = value;
                OnPropertyChanged("isAdminPersonneProperty");
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
                PersonneORM.updatePersonne(this);
            }
        }
    }
}

