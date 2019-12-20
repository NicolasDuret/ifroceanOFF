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
    public class ZoneORM
    {
        public static ZoneViewModel getZone(int idZone)
        {
            ZoneDAO zDAO = ZoneDAO.getZone(idZone);
            ZoneViewModel z = new ZoneViewModel(zDAO.idZoneDAO, zDAO.pointADAO, zDAO.pointBDAO, zDAO.pointCDAO, zDAO.pointDDAO, zDAO.superficieZoneDAO, PlageORM.getPlage(zDAO.idPlageZoneDAO), EtudeORM.getEtude(zDAO.idEtudeZoneDAO));
            return z;
        }

        public static ObservableCollection<ZoneViewModel> listeZones()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.listeZones();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach (ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idZoneDAO, element.pointADAO, element.pointBDAO, element.pointCDAO, element.pointDDAO, element.superficieZoneDAO, PlageORM.getPlage(element.idPlageZoneDAO), EtudeORM.getEtude(element.idEtudeZoneDAO));
                liste.Add(z);
            }
            return liste;
        }
        public static ObservableCollection<ZoneViewModel> listeAllZones()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.listeAllZones();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach (ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idZoneDAO, element.pointADAO, element.pointBDAO, element.pointCDAO, element.pointDDAO, element.superficieZoneDAO, element.nomPlageDAO, element.titreEtudeDAO);
                liste.Add(z);
            }
            return liste;
        }
        public static ObservableCollection<ZoneViewModel> compteurZone()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.compteurZone();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach (ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idPlageDAO, element.nomPlageDAO, element.idZoneDAO);
                liste.Add(z);
            }
            return liste;
        }

        public static void updateZone(ZoneViewModel z)
        {
            ZoneDAO.updateEtude(new ZoneDAO(z.idZoneProperty, z.pointAProperty, z.pointBProperty, z.pointCProperty, z.pointDProperty, z.superficieZoneProperty, z.PlageProperty.idPlageProperty, z.idEtudeProperty.idEtudeProperty));
        }
        public static void supprimerZone(int id)
        {
            ZoneDAO.supprimerEtude(id);
        }
        public static void insertZone(ZoneViewModel z)
        {
            ZoneDAO.insertEtude(new ZoneDAO(z.idZoneProperty, z.pointAProperty, z.pointBProperty,
                z.pointCProperty, z.pointDProperty, z.superficieZoneProperty, z.PlageProperty.idPlageProperty, z.idEtudeProperty.idEtudeProperty));
        }
    }
}
