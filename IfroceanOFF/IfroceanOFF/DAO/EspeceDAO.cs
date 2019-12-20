using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class EspeceDAO
    {
        public int idEspeceDAO;
        public string nomEspeceDAO;
        public int quantiteEspeceDAO;


        public EspeceDAO(int idEspeceDAO, string nomEspeceDAO, int quantiteEspeceDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomEspeceDAO = nomEspeceDAO;
            this.quantiteEspeceDAO = quantiteEspeceDAO;

        }

        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> liste = EspeceDAL.selectEspeces();
            return liste;
        }
        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO es = EspeceDAL.getEspece(idEspece);
            return es;
        }
        public static void updateEspece(EspeceDAO es)
        {
            EspeceDAL.updateEspece(es);

        }
        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);

        }
        public static void insertEspece(EspeceDAO es)
        {
            EspeceDAL.insertEspece(es);

        }
    }
}
