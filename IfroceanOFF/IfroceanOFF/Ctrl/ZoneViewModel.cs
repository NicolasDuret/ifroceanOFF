using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class ZoneViewModel : INotifyPropertyChanged
    {
        private int idZone;
        private string pointA;
        private string pointB;
        private string pointC;
        private string pointD;
        private int superficieZone;
        private PlageViewModel idPlageZone;
        private EtudeViewModel idEtudeZone;
        private int idPlage;
        private string nomPlage;
        private string titreEtude;

        public ZoneViewModel() { }
        public ZoneViewModel(int idPlage, string nomPlage, int idZone)
        {
            this.idPlage = idPlage;
            this.nomPlage = nomPlage;
            this.idZone = idZone;

        }
        public ZoneViewModel(int idZone, string pointA, string pointB, string pointC, string pointD, int superficie, string nomPlage, string titreEtude)
        {
            this.idZone = idZone;
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            this.pointD = pointD;
            this.superficieZone = superficie;
            this.nomPlage = nomPlage;
            this.titreEtude = titreEtude;
        }
        public ZoneViewModel(int idZone, string pointA, string pointB, string pointC, string pointD, int superficie, PlageViewModel idPlageProperty, EtudeViewModel idEtudeProperty)
        {
            this.idZone = idZone;
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            this.pointD = pointD;
            this.superficieZone = superficie;
            this.idPlageZone = idPlageProperty;
            this.idEtudeZone = idEtudeProperty;

        }

        public int idZoneProperty
        {
            get { return idZone; }
        }
        public string pointAProperty
        {
            get { return pointA; }
            set
            {
                pointA = value;
                OnPropertyChanged("pointAProperty");
            }
        }
        public string pointBProperty
        {
            get { return pointB; }
            set
            {
                pointB = value;
                OnPropertyChanged("pointBProperty");
            }
        }
        public string pointCProperty
        {
            get { return pointC; }
            set
            {
                pointC = value;
                OnPropertyChanged("pointCProperty");
            }
        }
        public string pointDProperty
        {
            get { return pointD; }
            set
            {
                pointD = value;
                OnPropertyChanged("pointDProperty");
            }
        }

        public int superficieZoneProperty
        {
            get { return superficieZone; }
            set
            {
                superficieZone = value;
                OnPropertyChanged("superficieZoneProperty");
            }
        }
        public PlageViewModel PlageProperty
        {
            get { return idPlageZone; }
            set
            {
                idPlageZone = value;
                OnPropertyChanged("idPlageZoneProperty");
            }
        }

        public EtudeViewModel idEtudeProperty
        {
            get { return idEtudeZone; }
            set
            {
                idEtudeZone = value;
                OnPropertyChanged("idEtudeZoneProperty");
            }
        }
        public string nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                pointA = value;
                OnPropertyChanged("nomPlageProperty");
            }
        }
        public string titreEtudeProperty
        {
            get { return titreEtude; }
            set
            {
                pointA = value;
                OnPropertyChanged("titreEtudeProperty");
            }
        }
        public int idPlageProperty
        {
            get { return idPlage; }
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
                ZoneORM.updateZone(this);
            }
        }
    }


}
