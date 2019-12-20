using IfroceanOFF.Ctrl;
using IfroceanOFF.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.ORM
{
    public class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO esDAO = EspeceDAO.getEspece(idEspece);
            EspeceViewModel es = new EspeceViewModel(esDAO.idEspeceDAO, esDAO.nomEspeceDAO, esDAO.quantiteEspeceDAO);
            return es;
        }

        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> listeDAO = EspeceDAO.listeEspeces();
            ObservableCollection<EspeceViewModel> liste = new ObservableCollection<EspeceViewModel>();
            foreach (EspeceDAO element in listeDAO)
            {
                EspeceViewModel es = new EspeceViewModel(element.idEspeceDAO, element.nomEspeceDAO, element.quantiteEspeceDAO);
                liste.Add(es);
            }
            return liste;
        }

        public static void updateEspece(EspeceViewModel es)
        {
            EspeceDAO.updateEspece(new EspeceDAO(es.idEspeceProperty, es.nomEspeceProperty, es.quantiteEspeceProperty));
        }
        public static void supprimerEspece(int id)
        {
            EspeceDAO.supprimerEspece(id);
        }
        public static void insertEspece(EspeceViewModel es)
        {
            EspeceDAO.insertEspece(new EspeceDAO(es.idEspeceProperty, es.nomEspeceProperty, es.quantiteEspeceProperty));
        }
    }
}
