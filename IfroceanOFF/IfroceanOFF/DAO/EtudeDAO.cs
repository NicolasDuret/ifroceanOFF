using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class EtudeDAO
    {
        public int idEtudeDAO;
        public string titreEtudeDAO;
        public DateTime dateCreationEtudeDAO;
        public DateTime dateFinEtudeDAO;
        public string nomPlageDAO;
        public string departementPlageDAO;

        public EtudeDAO(int idEtudeDAO, string titreEtudeDAO, DateTime dateCreationEtudeDAO, DateTime dateFinEtudeDAO, string nomPlageDAO, string departementPlageDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.titreEtudeDAO = titreEtudeDAO;
            this.dateCreationEtudeDAO = dateCreationEtudeDAO;
            this.dateFinEtudeDAO = dateFinEtudeDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.departementPlageDAO = departementPlageDAO;
        }
        public EtudeDAO(int idEtudeDAO, string titreEtudeDAO, DateTime dateCreationEtudeDAO, DateTime dateFinEtudeDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.titreEtudeDAO = titreEtudeDAO;
            this.dateCreationEtudeDAO = dateCreationEtudeDAO;
            this.dateFinEtudeDAO = dateFinEtudeDAO;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes()
        {
            ObservableCollection<EtudeDAO> liste = EtudeDAL.selectEtudes();
            return liste;
        }
        public static ObservableCollection<EtudeDAO> requeteEtudePlage()
        {
            ObservableCollection<EtudeDAO> requeteEtudePlage = EtudeDAL.requeteEtudePlage();
            return requeteEtudePlage;
        }
        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO e = EtudeDAL.getEtude(idEtude);
            return e;
        }
        public static void updateEtude(EtudeDAO e)
        {
            EtudeDAL.updateEtude(e);

        }
        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);

        }
        public static void insertEtude(EtudeDAO e)
        {
            EtudeDAL.insertEtude(e);

        }
    }
}
