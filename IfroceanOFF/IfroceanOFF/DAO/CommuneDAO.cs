using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class CommuneDAO
    {
        public int idCommuneDAO;
        public string nomCommuneDAO;

        public CommuneDAO(int idCommuneDAO, string nomCommuneDAO)
        {
            this.idCommuneDAO = idCommuneDAO;
            this.nomCommuneDAO = nomCommuneDAO;
        }

        public static ObservableCollection<CommuneDAO> listeCommunes()
        {
            ObservableCollection<CommuneDAO> liste = CommuneDAL.selectCommunes();
            return liste;
        }
        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO c = CommuneDAL.getCommune(idCommune);
            return c;
        }
        public static void updateCommune(CommuneDAO c)
        {
            CommuneDAL.updateCommune(c);

        }
        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);

        }
        public static void insertCommune(CommuneDAO c)
        {
            CommuneDAL.insertCommune(c);

        }
    }
}
