using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class ComptageDAO
    {
        public int idComptageDAO;
        public int idZoneComptageDAO;
        public int idEspeceComptageDAO;
        public string populationComptageDAO;

        public ComptageDAO(int idComptageDAO, int idZoneComptageDAO, int idEspeceComptageDAO, string populationComptageDAO)
        {
            this.idZoneComptageDAO = idComptageDAO;
            this.idZoneComptageDAO = idZoneComptageDAO;
            this.idEspeceComptageDAO = idEspeceComptageDAO;
            this.populationComptageDAO = populationComptageDAO;

        }

        public static ObservableCollection<ComptageDAO> listeComptages()
        {
            ObservableCollection<ComptageDAO> l = ComptageDAL.selectComptages();
            return l;
        }
        public static ComptageDAO getComptage(int idComptage)
        {
            ComptageDAO cp = ComptageDAL.getComptage(idComptage);
            return cp;
        }

        public static void updateComptage(ComptageDAO cp)
        {
            ComptageDAL.updateComptage(cp);
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAL.supprimerComptage(id);
        }

        public static void insertComptage(ComptageDAO cp)
        {
            ComptageDAL.insertComptage(cp);
        }
    }
}
