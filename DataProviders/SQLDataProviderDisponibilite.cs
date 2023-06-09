using Concigo_API.DataProviders;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using Concigo_API.Model;
using MySqlX.XDevAPI;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Concigo_API.DataProviders
{
    public class SQLDataProviderDisponibilite
    {
        public static List<Disponibilite> GetDisponibilites()
        {
            List<Disponibilite> listDisponibilites = new List<Disponibilite>();
            Disponibilite disponibilite = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM disponibilite;";
            cmd.CommandType = CommandType.Text;

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                bool b = false;
                if ((SByte)data["estDispo"]==1)
                {
                    b= true;
                }
                disponibilite = new Disponibilite
                {
                    Id = (int)data["iddisponibilite"],
                    date = (DateTime)data["date"],
                    estDispo = b,
                    nombrePersonneMax = (int)data["nombrePersonneMax"]
                };

                listDisponibilites.Add(disponibilite);
            }
            connexion.Close();
            return listDisponibilites;
        }
        public static List<Disponibilite> GetDisponibilitesByIdEvenement(int evenementID)
        {
            List<Disponibilite> listDisponibilites = new List<Disponibilite>();
            Disponibilite disponibilite = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM disponibilite WHERE Evenement_idEvenement=@id ";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = evenementID
            };
            cmd.Parameters.Add(param);
      

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                bool b = false;
                if ((SByte)data["estDispo"] == 1)
                {
                    b = true;
                }
                disponibilite = new Disponibilite
                {
                    Id = (int)data["iddisponibilite"],
                    date = (DateTime)data["date"],
                    estDispo = b,
                    nombrePersonneMax = (int)data["nombrePersonneMax"]
                };

                listDisponibilites.Add(disponibilite);
            }
            connexion.Close();
            return listDisponibilites;
        }
        public static Disponibilite GetDisponibiliteById(int id)
        {
            Disponibilite disponibilite = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "SELECT * FROM disponibilite WHERE iddisponibilite=@id";
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
                bool b = false;
                if ((SByte)data["estDispo"] == 1)
                {
                    b = true;
                }
                disponibilite = new Disponibilite
                {
                    Id = (int)data["iddisponibilite"],
                    date = (DateTime)data["date"],
                    estDispo = b,
                    nombrePersonneMax = (int)data["nombrePersonneMax"]
                };
            }

            connexion.Close();
            return disponibilite;
        }
        public static bool AddDisponibilite(Disponibilite disponibilite,int idEvenement)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "INSERT INTO disponibilite (date, Evenement_idEvenement, estDispo, nombrePersonneMax) " +
                              "VALUES (@date, @evenementId, @estDispo, @nombrePersonneMax)";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "date",
                DbType = DbType.DateTime,
                Value = disponibilite.date 
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "evenementId",
                DbType = DbType.Int32,
                Value = idEvenement
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "estDispo",
                DbType = DbType.Boolean,
                Value = disponibilite.estDispo 
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "nombrePersonneMax",
                DbType = DbType.Int32,
                Value = disponibilite.nombrePersonneMax 
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool ModifierDisponibilite(Disponibilite disponibilite)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "UPDATE disponibilite SET date=@date, estDispo=@estDispo, " +
                              "nombrePersonneMax=@nombrePersonneMax WHERE iddisponibilite=@id";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "date",
                DbType = DbType.DateTime,
                Value = disponibilite.date
            };
       
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "estDispo",
                DbType = DbType.Boolean,
                Value = disponibilite.estDispo
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "nombrePersonneMax",
                DbType = DbType.Int32,
                Value = disponibilite.nombrePersonneMax
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = disponibilite.Id
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool DeleteDisponibilite(int id)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "DELETE FROM disponibilite WHERE iddisponibilite=@id";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = DbType.Int32,
                Value = id
            };
            
           
            cmd.Parameters.Add(param);

            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;

        }
}
}
