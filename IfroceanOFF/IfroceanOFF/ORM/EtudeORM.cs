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
    public class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO eDAO = EtudeDAO.getEtude(idEtude);
            EtudeViewModel e = new EtudeViewModel(eDAO.idEtudeDAO, eDAO.titreEtudeDAO, eDAO.dateCreationEtudeDAO, eDAO.dateFinEtudeDAO);
            return e;
        }

        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> listeDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> liste = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in listeDAO)
            {
                EtudeViewModel e = new EtudeViewModel(element.idEtudeDAO, element.titreEtudeDAO, element.dateCreationEtudeDAO, element.dateFinEtudeDAO);
                liste.Add(e);
            }
            return liste;
        }
        public static ObservableCollection<EtudeViewModel> requeteEtudePlage()
        {
            ObservableCollection<EtudeDAO> listeDAO = EtudeDAO.requeteEtudePlage();
            ObservableCollection<EtudeViewModel> liste = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in listeDAO)
            {
                EtudeViewModel e = new EtudeViewModel(element.idEtudeDAO, element.titreEtudeDAO, element.dateCreationEtudeDAO, element.dateFinEtudeDAO, element.nomPlageDAO, element.departementPlageDAO);
                liste.Add(e);
            }
            return liste;
        }

        public static void updateEtude(EtudeViewModel e)
        {
            EtudeDAO.updateEtude(new EtudeDAO(e.idEtudeProperty, e.titreEtudeProperty, e.dateCreationEtudeProperty, e.dateFinEtudeProperty));
        }
        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }
        public static void insertEtude(EtudeViewModel e)
        {
            EtudeDAO.insertEtude(new EtudeDAO(e.idEtudeProperty, e.titreEtudeProperty, e.dateCreationEtudeProperty, e.dateFinEtudeProperty));
        }
    }
}
