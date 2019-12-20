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
    class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO plDAO = PlageDAO.getPlage(idPlage);
            PlageViewModel pl = new PlageViewModel(plDAO.idPlageDAO, plDAO.nomPlageDAO, plDAO.departementPlageDAO, plDAO.communePlageDAO);
            return pl;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                PlageViewModel pl = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, element.departementPlageDAO, element.communePlageDAO);
                l.Add(pl);
            }
            return l;
        }



        public static void updatePlage(PlageViewModel pl)
        {
            PlageDAO.updatePlage(new PlageDAO(pl.idPlageProperty, pl.nomPlageProperty, pl.departementPlageProperty, pl.communePlageProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel pl)
        {
            PlageDAO.insertPlage(new PlageDAO(pl.idPlageProperty, pl.nomPlageProperty, pl.departementPlageProperty, pl.communePlageProperty));
        }
    }
}

