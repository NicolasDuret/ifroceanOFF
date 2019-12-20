using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class ComptageViewModel
    {
        private int idComptage;
        private ZoneViewModel idZoneComptage;
        private EspeceViewModel idEspeceComptage;
        private string populationComptage;

        public ComptageViewModel() { }

        public ComptageViewModel(int id, ZoneViewModel idZoneProperty, EspeceViewModel idEspeceProperty, string population)
        {
            this.idComptage = id;
            this.idZoneComptage = idZoneProperty;
            this.idEspeceComptage = idEspeceProperty;
            this.populationComptageProperty = population;

        }
        public int idComptageProperty
        {
            get { return idComptage; }
        }

        public ZoneViewModel idZoneProperty
        {
            get { return idZoneComptage; }
        }

        public EspeceViewModel idEspeceProperty
        {
            get { return idEspeceComptage; }


        }
        public String populationComptageProperty
        {
            get { return populationComptage; }
            set
            {
                this.populationComptage = value;
                OnPropertyChanged("populationComptageProperty");
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
                ComptageORM.updateComptage(this);
            }
        }
    }
}

