using IfroceanOFF.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfroceanOFF.DAO
{
    public class PersonneDAO
    {
        public int idPersonneDAO;
        public string nomPersonneDAO;
        public string prenomPersonneDAO;
        public int etudePersonneDAO;
        public int isAdminPersonneDAO;

        public PersonneDAO(int idPersonneDAO, string nomPersonneDAO, string prenomPersonneDAO, int etudePersonneDAO, int isAdminPersonneDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.nomPersonneDAO = nomPersonneDAO;
            this.prenomPersonneDAO = prenomPersonneDAO;
            this.etudePersonneDAO = etudePersonneDAO;
            this.isAdminPersonneDAO = isAdminPersonneDAO;
        }

        public static ObservableCollection<PersonneDAO> listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }
        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}
