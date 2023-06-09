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
    public class SQLDataProviderPartenaire
    {
        public static List<Partenaire> GetPartenaire()
        {
            List<Partenaire> listPartenaire = new List<Partenaire>();
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire;";
            cmd.CommandType = CommandType.Text;

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                partenaire = new Partenaire
                {
          
                Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                     prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                     email = (string)data["email"]
               

                };

                listPartenaire.Add(partenaire);
            }
            connexion.Close();
            return listPartenaire;
        }

        public static Partenaire GetPartenaireById(int id)
        {
            
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire where idpartenaire=@id" ;
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "id",
                DbType = System.Data.DbType.Int32,
                Value = id
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();
          

            while (data.Read())
            {
                partenaire = new Partenaire
                {

                    Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                    prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                    email = (string)data["email"]


                };

               
            }

            connexion.Close();
            return partenaire;
        }
        public static List<Partenaire> GetPartenaireByNom(string nom)
        {
            List<Partenaire> listPartenaire = new List<Partenaire>();
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire where nom=@nom";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = nom
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {
                partenaire = new Partenaire
                {

                    Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                    prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                    email = (string)data["email"]


                };

                listPartenaire.Add(partenaire);
            }
            connexion.Close();
            return listPartenaire;
        }
        public static List<Partenaire> GetPartenaireByPrenom(string prenom)
        {
            List<Partenaire> listPartenaire = new List<Partenaire>();
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire where prenom=@prenom";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = prenom
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {
                partenaire = new Partenaire
                {

                    Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                    prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                    email = (string)data["email"]


                };

                listPartenaire.Add(partenaire);
            }
            connexion.Close();
            return listPartenaire;
        }
        public static List<Partenaire> GetPartenaireByEmail(string email)
        {
            List<Partenaire> listPartenaire = new List<Partenaire>();
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire where email=@email";
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "email",
                DbType = System.Data.DbType.String,
                Value = email
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {
                partenaire = new Partenaire
                {

                    Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                    prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                    email = (string)data["email"]


                };

                listPartenaire.Add(partenaire);
            }
            connexion.Close();
            return listPartenaire;
        }
        public static List<Partenaire> GetPartenaireByTelephone(string telephone)
        {
            List<Partenaire> listPartenaire = new List<Partenaire>();
            Partenaire partenaire = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from partenaire where telephone=@telephone" ;
            cmd.CommandType = CommandType.Text;
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "telephone",
                DbType = System.Data.DbType.String,
                Value = telephone
            };
            cmd.Parameters.Add(param);
            data = cmd.ExecuteReader();

            while (data.Read())
            {
                partenaire = new Partenaire
                {

                    Id = (int)data["idpartenaire"],
                    nom = (string)data["nom"],
                    prenom = (string)data["prenom"],
                    telephone = (string)data["telephone"],
                    email = (string)data["email"]


                };

                listPartenaire.Add(partenaire);
            }
            connexion.Close();
            return listPartenaire;
        }
        public static bool AddPartenaire(Partenaire partenaire)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "INSERT INTO partenaire(nom, prenom,telephone,email)" +
                                       "VALUES (@nom,@prenom,@telephone,@email)";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = partenaire.nom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = partenaire.prenom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "telephone",
                DbType = System.Data.DbType.String,
                Value = partenaire.telephone
            }; 
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "email",
                DbType = System.Data.DbType.String,
                Value = partenaire.email
            };

            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool ModifierPartenaire(Partenaire partenaire)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "UPDATE partenaire SET nom=@nom,prenom=@prenom,telephone=@telephone,email=@email WHERE idpartenaire=@idpartenaire";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = partenaire.nom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = partenaire.prenom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "telephone",
                DbType = System.Data.DbType.String,
                Value = partenaire.telephone
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "email",
                DbType = System.Data.DbType.String,
                Value = partenaire.email
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "idpartenaire",
                DbType = System.Data.DbType.Int32,
                Value = partenaire.Id
            };


            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
        }

        public static bool DeletePartenaire(int id)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "DELETE FROM partenaire WHERE idpartenaire=@idpartenaire";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "idpartenaire",
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
