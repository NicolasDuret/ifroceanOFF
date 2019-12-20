using IfroceanOFF.Ctrl;
using IfroceanOFF.DAO;
using System.Collections.ObjectModel;

namespace IfroceanOFF.ORM
{
    class ComptageORM
    {
        public static ComptageViewModel getComptage(int idComptage)
        {
            ComptageDAO cpDAO = ComptageDAO.getComptage(idComptage);
            ComptageViewModel cp = new ComptageViewModel(cpDAO.idComptageDAO, ZoneORM.getZone(cpDAO.idZoneComptageDAO), EspeceORM.getEspece(cpDAO.idEspeceComptageDAO), cpDAO.populationComptageDAO);
            return cp;
        }

        public static ObservableCollection<ComptageViewModel> listeComptages()
        {
            ObservableCollection<ComptageDAO> lDAO = ComptageDAO.listeComptages();
            ObservableCollection<ComptageViewModel> l = new ObservableCollection<ComptageViewModel>();
            foreach (ComptageDAO element in lDAO)
            {
                ComptageViewModel cp = new ComptageViewModel(element.idComptageDAO, ZoneORM.getZone(element.idZoneComptageDAO), EspeceORM.getEspece(element.idEspeceComptageDAO), element.populationComptageDAO);
                l.Add(cp);
            }
            return l;
        }



        public static void updateComptage(ComptageViewModel cp)
        {
            ComptageDAO.updateComptage(new ComptageDAO(cp.idComptageProperty, cp.idZoneProperty.idZoneProperty, cp.idEspeceProperty.idEspeceProperty, cp.populationComptageProperty));
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAO.supprimerComptage(id);
        }

        public static void insertComptage(ComptageViewModel cp)
        {
            ComptageDAO.insertComptage(new ComptageDAO(cp.idComptageProperty, cp.idZoneProperty.idZoneProperty, cp.idEspeceProperty.idEspeceProperty, cp.populationComptageProperty));
        }
    }
}

