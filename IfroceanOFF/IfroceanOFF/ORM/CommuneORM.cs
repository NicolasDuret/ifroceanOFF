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
    public class CommuneORM
    {
        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO cDAO = CommuneDAO.getCommune(idCommune);
            CommuneViewModel c = new CommuneViewModel(cDAO.idCommuneDAO, cDAO.nomCommuneDAO);
            return c;
        }

        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> listeDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> liste = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in listeDAO)
            {
                CommuneViewModel c = new CommuneViewModel(element.idCommuneDAO, element.nomCommuneDAO);
                liste.Add(c);
            }
            return liste;
        }

        public static void updateCommune(CommuneViewModel c)
        {
            CommuneDAO.updateCommune(new CommuneDAO(c.idCommuneProperty, c.nomCommuneProperty));
        }
        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }
        public static void insertCommune(CommuneViewModel c)
        {
            CommuneDAO.insertCommune(new CommuneDAO(c.idCommuneProperty, c.nomCommuneProperty));
        }
    }
}
