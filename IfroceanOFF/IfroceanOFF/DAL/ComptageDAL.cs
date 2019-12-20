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
    public class ComptageDAL
    {
        public ComptageDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
        }
        public static ObservableCollection<ComptageDAO> selectComptages()
        {
            ObservableCollection<ComptageDAO> l = new ObservableCollection<ComptageDAO>();
            string query = "SELECT * FROM comptage;";
            MySqlCommand cmd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComptageDAO cp = new ComptageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));
                    l.Add(cp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("comptage La base de données n'est pas connectée" + e.Message);
            }
            return l;
        }
        public static void insertComptage(ComptageDAO cp)
        {
            int id = getMaxIdComptage() + 1;
            string query = "INSERT INTO comptage VALUES (\"" + id + "\",\"" + cp.idZoneComptageDAO + "\",\"" + cp.idEspeceComptageDAO + "\",\"" + cp.populationComptageDAO + "\");";
            MySqlCommand cmd2Comp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Comp);
            cmd2Comp.ExecuteNonQuery();
        }

        public static void updateComptage(ComptageDAO cp)
        {
            string query = "UPDATE comptage set populationComptage=\"" + cp.populationComptageDAO;
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdComp);
            cmdComp.ExecuteNonQuery();
        }

        public static void supprimerComptage(int id)
        {
            string query = "DELETE FROM comptage WHERE idComptage = \"" + id + "\";";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdComp);
            cmdComp.ExecuteNonQuery();
        }
        public static int getMaxIdComptage()
        {
            string query = "SELECT MAX(idComptage) FROM comptage;";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdComp.ExecuteNonQuery();

            MySqlDataReader reader = cmdComp.ExecuteReader();
            reader.Read();
            int maxIdComptage = reader.GetInt32(0);
            reader.Close();
            return maxIdComptage;
        }

        public static ComptageDAO getComptage(int idComptage)
        {
            string query = "SELECT * FROM comptage WHERE id=" + idComptage + ";";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdComp.ExecuteNonQuery();
            MySqlDataReader reader = cmdComp.ExecuteReader();
            reader.Read();
            ComptageDAO comptage = new ComptageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));
            reader.Close();
            return comptage;
        }


    }
}
