using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class PlageDAO
    {
        public int idPlageDAO;
        public string nomPlageDAO;
        public string departementPlageDAO;
        public int communePlageDAO;

        public PlageDAO(int idPlageDAO, string nomPlageDAO, string departementPlageDAO, int communePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.departementPlageDAO = departementPlageDAO;
            this.communePlageDAO = communePlageDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }
        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageDAO pl)
        {
            PlageDAL.updatePlage(pl);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO pl)
        {
            PlageDAL.insertPlage(pl);
        }
    }
}
