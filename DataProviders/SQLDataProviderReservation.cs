using Concigo_API.Model;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;

namespace Concigo_API.DataProviders
{
    public class SQLDataProviderReservation
    {
        public static List<Reservation> GetReservation()
        {
            List<Reservation> listReservation = new List<Reservation>();
            Reservation reservation = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM reservation;";
            cmd.CommandType = CommandType.Text;

            data = cmd.ExecuteReader();
      
            while (data.Read())
            {


                reservation = new Reservation
                {
                    Id = (int)data["idresevation"],
                    date = (DateTime)data["date"],
                    nombrePersonne = (int)data["nombrePersonne"],
                    disponibilite = SQLDataProviderDisponibilite.GetDisponibiliteById((int)data["disponibilite_iddisponibilite"])
                };
                reservation.evenement = SQLDataProviderEvenement.GetEvenementById((int)data["disponibilite_Evenement_idEvenement"]);
                listReservation.Add(reservation);
            }
            connexion.Close();
            return listReservation;
        }

        public static Reservation GetReservationById(int id)
        {
            Reservation reservation = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM reservation WHERE idresevation=@id";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {


                reservation = new Reservation
                {
                    Id = (int)data["idresevation"],
                    date = (DateTime)data["date"],
                    nombrePersonne = (int)data["nombrePersonne"],
                    disponibilite = SQLDataProviderDisponibilite.GetDisponibiliteById((int)data["disponibilite_iddisponibilite"])

                };
                reservation.evenement = SQLDataProviderEvenement.GetEvenementById((int)data["disponibilite_Evenement_idEvenement"]);
              
            }

            connexion.Close();
            return reservation;
        }
        public static Reservation GetReservationByIdUser(int id)
        {
            Reservation reservation = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM reservation WHERE user_idchauffeur=@id";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {


                reservation = new Reservation
                {
                    Id = (int)data["idresevation"],
                    date = (DateTime)data["date"],
                    nombrePersonne = (int)data["nombrePersonne"],

                };
                reservation.evenement = SQLDataProviderEvenement.GetEvenementById((int)data["disponibilite_Evenement_idEvenement"]);

            }

            connexion.Close();
            return reservation;
        }
        public static bool AddReservation(Reservation reservation, int userId)
        {
            List< Disponibilite> dispoList = new List<Disponibilite>();
            Disponibilite dispo = new Disponibilite();
            dispo=reservation.disponibilite;
           

           
            

            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            SQLDataProviderDisponibilite.AddDisponibilite(reservation.disponibilite,reservation.evenement.Id);
            List<Disponibilite> liste = new List<Disponibilite>();
            liste = SQLDataProviderDisponibilite.GetDisponibilites();
            dispo=liste.Last();
            cmd.CommandText = "INSERT INTO reservation (date, nombrePersonne, disponibilite_iddisponibilite, disponibilite_Evenement_idEvenement,user_idchauffeur) " +
                              "VALUES (@date, @nombrePersonne, @disponibilite_iddisponibilite, @disponibilite_Evenement_idEvenement,@user_idchauffeur)";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "date",
                DbType = DbType.DateTime,
                Value = reservation.date
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "nombrePersonne",
                DbType = DbType.Int32,
                Value = reservation.nombrePersonne
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "disponibilite_iddisponibilite",
                DbType = DbType.Int32,
                Value = dispo.Id
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "disponibilite_Evenement_idEvenement",
                DbType = DbType.Int32,
                Value = reservation.evenement.Id
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "user_idchauffeur",
                DbType = DbType.Int32,
                Value = userId
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            if (res)
            {
                dispo.estDispo = false;
                SQLDataProviderDisponibilite.ModifierDisponibilite(dispo);
            }
            else
            {
                return false;
            }
            connexion.Close();
            return res;
        }

        public static bool ModifierReservation(Reservation reservation)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
           
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "UPDATE reservation SET nombrePersonne=@nombrePersonne WHERE idresevation=@id";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "nombrePersonne",
                DbType = DbType.Int32,
                Value = reservation.nombrePersonne
            };

            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = reservation.Id
            };
            cmd.Parameters.Add(param);
            
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool DeleteReservation(int id)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "DELETE FROM reservation WHERE idresevation=@id";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = id
            };

         
            Reservation reserve=GetReservationById(id);
            
             
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;

            SQLDataProviderDisponibilite.DeleteDisponibilite(reserve.disponibilite.Id);


            connexion.Close();
            return res;

        }
    }
}
