using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class ZoneDAO
    {
        public int idZoneDAO;
        public string pointADAO;
        public string pointBDAO;
        public string pointCDAO;
        public string pointDDAO;
        public int superficieZoneDAO;
        public int idPlageZoneDAO;
        public int idEtudeZoneDAO;
        public int idPlageDAO;
        public string nomPlageDAO;
        public string titreEtudeDAO;

        public ZoneDAO(int idPlageDAO, string nomPlageDAO, int idZoneDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.idZoneDAO = idZoneDAO;
        }
        public ZoneDAO(int idZoneDAO, string pointADAO, string pointBDAO, string pointCDAO, string pointDDAO, int superficieZoneDAO, string nomPlageDAO, string titreEtudeDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.pointADAO = pointADAO;
            this.pointBDAO = pointBDAO;
            this.pointCDAO = pointCDAO;
            this.pointDDAO = pointDDAO;
            this.superficieZoneDAO = superficieZoneDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.titreEtudeDAO = titreEtudeDAO;
        }
        public ZoneDAO(int idZoneDAO, string pointADAO, string pointBDAO, string pointCDAO, string pointDDAO, int superficieZoneDAO, int idPlageZoneDAO, int idEtudeZoneDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.pointADAO = pointADAO;
            this.pointBDAO = pointBDAO;
            this.pointCDAO = pointCDAO;
            this.pointDDAO = pointDDAO;
            this.superficieZoneDAO = superficieZoneDAO;
            this.idPlageZoneDAO = idPlageZoneDAO;
            this.idEtudeZoneDAO = idEtudeZoneDAO;


        }

        public static ObservableCollection<ZoneDAO> listeZones()
        {
            ObservableCollection<ZoneDAO> liste = ZoneDAL.selectZones();
            return liste;
        }
        public static ObservableCollection<ZoneDAO> compteurZone()
        {
            ObservableCollection<ZoneDAO> liste = ZoneDAL.compteurZone();
            return liste;
        }
        public static ObservableCollection<ZoneDAO> listeAllZones()
        {
            ObservableCollection<ZoneDAO> liste = ZoneDAL.listeAllZones();
            return liste;
        }
        public static ZoneDAO getZone(int idZone)
        {
            ZoneDAO z = ZoneDAL.getZone(idZone);
            return z;
        }
        public static void updateEtude(ZoneDAO z)
        {
            ZoneDAL.updateZone(z);

        }
        public static void supprimerEtude(int id)
        {
            ZoneDAL.supprimerZone(id);

        }
        public static void insertEtude(ZoneDAO z)
        {
            ZoneDAL.insertZone(z);

        }
    }
}
