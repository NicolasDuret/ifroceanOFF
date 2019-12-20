using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class EspeceViewModel : INotifyPropertyChanged
    {
        private int idEspece;
        private string nomEspece;
        private int quantiteEspece;

        public EspeceViewModel()
        {

        }
        public EspeceViewModel(int idEspece, string nom, int quantite)
        {
            this.idEspece = idEspece;
            this.nomEspece = nom;
            this.quantiteEspece = quantite;
        }

        public int idEspeceProperty
        {
            get { return idEspece; }
        }
        public string nomEspeceProperty
        {
            get { return nomEspece; }
            set
            {
                nomEspece = value;
                OnPropertyChanged("nomEspeceProperty");
            }
        }

        public int quantiteEspeceProperty
        {
            get { return quantiteEspece; }
            set
            {
                quantiteEspece = value;
                OnPropertyChanged("quantiteEspeceProperty");
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
                EspeceORM.updateEspece(this);
            }
        }
    }


}
