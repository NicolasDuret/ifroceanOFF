using IfroceanOFF.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.Ctrl
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        private int idCommune;
        private string nomCommune;


        public CommuneViewModel()
        {

        }
        public CommuneViewModel(int idCommune, string nom)
        {
            this.idCommune = idCommune;
            this.nomCommuneProperty = nom;
        }

        public int idCommuneProperty
        {
            get { return idCommune; }
        }
        public string nomCommuneProperty
        {
            get { return nomCommune; }
            set
            {
                nomCommune = value;
                OnPropertyChanged("nomCommuneProperty");
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
                CommuneORM.updateCommune(this);
            }
        }
    }


}
