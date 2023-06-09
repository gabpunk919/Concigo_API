using Concigo_API.Model;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace Concigo_API.DataProviders
{
    public class SQLDataProviderEvenement
    {
        public static List<Evenement> GetEvenements()
        {
            List<PhotoLink> listephoto;
            List<Evenement> listEvenements = new List<Evenement>();
            Evenement evenement = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM Evenement";
            cmd.CommandType = CommandType.Text;

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                 listephoto= SQLDataProviderPhotoLink.GetPhotoLink((int)data["idEvenement"]);
                evenement = new Evenement
                {

                    Id = (int)data["idEvenement"],
                    Nom = (string)data["nom"],
                    Description = (string)data["description"],
                    Prix = (double)data["prix"],
                    TypeEvenement = (string)data["typeEvenement"],
                    photos = listephoto
                };

                listEvenements.Add(evenement);
            }

            connexion.Close();
            return listEvenements;
        }

        public static Evenement GetEvenementById(int id)
        {
            Evenement evenement = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM Evenement WHERE idEvenement=@id";
            cmd.CommandType = CommandType.Text;

            DbParameter param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = System.Data.DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                evenement = new Evenement
                {
                    Id = (int)data["idEvenement"],
                    Nom = (string)data["nom"],
                    Description = (string)data["description"],
                    Prix = (double)data["prix"],
                    TypeEvenement = (string)data["typeEvenement"]
                };
            }

            connexion.Close();
            return evenement;
        }
        public static Evenement GetEvenementByNom(string nom)
        {
            Evenement evenement = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM Evenement WHERE nom=@nom";
            cmd.CommandType = CommandType.Text;

            DbParameter param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = nom
            };
            cmd.Parameters.Add(param);

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                evenement = new Evenement
                {
                    Id = (int)data["idEvenement"],
                    Nom = (string)data["nom"],
                    Description = (string)data["description"],
                    Prix = (double)data["prix"],
                    TypeEvenement = (string)data["typeEvenement"]
                };
            }

            connexion.Close();
            return evenement;
        }
        public static List<Evenement> GetEvenementByPrix(double prix)
        {
            Evenement evenement = null;

            List<Evenement> listEvenements = new List<Evenement>();
            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM Evenement WHERE prix=@prix";
            cmd.CommandType = CommandType.Text;

            DbParameter param = new MySqlParameter
            {
                ParameterName = "prix",
                DbType = System.Data.DbType.Double,
                Value = prix
            };
            cmd.Parameters.Add(param);

            data = cmd.ExecuteReader();
            while (data.Read())
            {
                evenement = new Evenement
                {
                    Id = (int)data["idEvenement"],
                    Nom = (string)data["nom"],
                    Description = (string)data["description"],
                    Prix = (double)data["prix"],
                    TypeEvenement = (string)data["typeEvenement"]
                };

                listEvenements.Add(evenement);
            }

            connexion.Close();
            return listEvenements;
        }
        public static Evenement GetEvenementByDescription(string description)
        {
            Evenement evenement = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM Evenement WHERE description=@description";
            cmd.CommandType = CommandType.Text;

            DbParameter param = new MySqlParameter
            {
                ParameterName = "description",
                DbType = System.Data.DbType.String,
                Value = description
            };
            cmd.Parameters.Add(param);

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                evenement = new Evenement
                {
                    Id = (int)data["idEvenement"],
                    Nom = (string)data["nom"],
                    Description = (string)data["description"],
                    Prix = (double)data["prix"],
                    TypeEvenement = (string)data["typeEvenement"]
                };
            }

            connexion.Close();
            return evenement;
        }
        public static bool AddEvenement(Evenement evenement)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "INSERT INTO Evenement (nom, description, prix, typeEvenement) " +
                               "VALUES (@nom, @description, @prix, @typeEvenement)";
            DbParameter param;

            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = evenement.Nom
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "description",
                DbType = System.Data.DbType.String,
                Value = evenement.Description
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "prix",
                DbType = System.Data.DbType.Double,
                Value = evenement.Prix
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "typeEvenement",
                DbType = System.Data.DbType.String,
                Value = evenement.TypeEvenement
            };
            cmd.Parameters.Add(param);

            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool ModifierEvenement(Evenement evenement)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "UPDATE Evenement SET nom=@nom, description=@description, prix=@prix, typeEvenement=@typeEvenement " +
                               "WHERE idEvenement=@idEvenement";
            DbParameter param;

            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = evenement.Nom
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "description",
                DbType = System.Data.DbType.String,
                Value = evenement.Description
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "prix",
                DbType = System.Data.DbType.Double,
                Value = evenement.Prix
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "typeEvenement",
                DbType = System.Data.DbType.String,
                Value = evenement.TypeEvenement
            };
            cmd.Parameters.Add(param);

            param = new MySqlParameter
            {
                ParameterName = "idEvenement",
                DbType = System.Data.DbType.Int32,
                Value = evenement.Id
            };
            cmd.Parameters.Add(param);

            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool DeleteEvenement(int id)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "DELETE FROM Evenement WHERE idEvenement=@idEvenement";
            DbParameter param = new MySqlParameter
            {
                ParameterName = "idEvenement",
                DbType = System.Data.DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);

            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

    }
}
