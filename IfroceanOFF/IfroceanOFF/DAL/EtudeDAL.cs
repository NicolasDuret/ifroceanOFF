using MySql.Data.MySqlClient;
using IfroceanOFF.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IfroceanOFF.DAL
{
    public class EtudeDAL
    {

        public EtudeDAL()
        {
        }
        public static ObservableCollection<EtudeDAO> selectEtudes()
        {
            ObservableCollection<EtudeDAO> liste = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * from etude;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdEtu.ExecuteNonQuery();
                MySqlDataReader reader = cmdEtu.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO e = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
                    liste.Add(e);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Etude La base de données n'est pas connectée" + e.Message);
            }
            return liste;
        }
        public static ObservableCollection<EtudeDAO> requeteEtudePlage()
        {
            ObservableCollection<EtudeDAO> requeteEtudePlage = new ObservableCollection<EtudeDAO>();
            string query = "SELECT etude.idEtude, etude.titre, etude.dateCrea, etude.dateFin, plage.nom, plage.departement " +
                "FROM etude " +
                "JOIN zone on zone.Etude_idEtude1=etude.idEtude " +
                "JOIN plage on plage.idPlage=zone.Plage_idPlage;";
            MySqlCommand cmdRequetePlage = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdRequetePlage.ExecuteNonQuery();
                MySqlDataReader reader = cmdRequetePlage.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO e = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetString(4), reader.GetString(5));
                    requeteEtudePlage.Add(e);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Etude La base de données n'est pas connectée" + e.Message);
            }
            return requeteEtudePlage;
        }

        public static void updateEtude(EtudeDAO e)
        {
            string query = "UPDATE etude set titreEtude=\"" + e.titreEtudeDAO + "\",  dateCreationEtude = \"" + e.dateCreationEtudeDAO + "\", dateFinEtude = \"" + e.dateFinEtudeDAO + ";";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEtu);
            cmdEtu.ExecuteNonQuery();
        }
        public static void insertEtude(EtudeDAO e)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO etude VALUES (\"" + id + "\",\"" + e.titreEtudeDAO + "\",\"" + e.dateCreationEtudeDAO + "\",\"" + e.dateFinEtudeDAO + "\");";
            MySqlCommand cmd2Etu = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Etu);
            cmd2Etu.ExecuteNonQuery();
        }

        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEtu);
            cmdEtu.ExecuteNonQuery();
        }
        public static int getMaxIdEtude()
        {
            string query = "SELECT MAX(idEtude) FROM etude;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdEtu.ExecuteNonQuery();

            MySqlDataReader reader = cmdEtu.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM etude WHERE idEtude=" + idEtude + ";";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdEtu.ExecuteNonQuery();
            MySqlDataReader reader = cmdEtu.ExecuteReader();
            reader.Read();
            EtudeDAO etu = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
            reader.Close();
            return etu;
        }
    }
}
