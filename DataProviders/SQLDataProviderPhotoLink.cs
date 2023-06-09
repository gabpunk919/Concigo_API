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
    public class SQLDataProviderPhotoLink
    {
        public static List<PhotoLink> GetPhotoLink(int id_evenement)
        {
            List<PhotoLink> listPhotoLink = new List<PhotoLink>();
            PhotoLink photoLink = null;

            DbConnection connexion = new MySqlConnection();
            DbDataReader data;

            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();

            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;
            cmd.CommandText = "Select * from photoLink where Evenement_idEvenement ="+id_evenement;
            cmd.CommandType = CommandType.Text;

            data = cmd.ExecuteReader();

            while (data.Read())
            {
                photoLink = new PhotoLink
                {
                    Id = (int)data["idphotoLink"],
                    link = (string)data["link"],
                  
                };

                listPhotoLink.Add(photoLink);
            }
            connexion.Close();
            return listPhotoLink;
        }



         public static bool AddPhotoLink(PhotoLink photoLink,int id_evenement)
         {
             DbConnection connexion = new MySqlConnection();
             connexion.ConnectionString = Config.CONNECTION_STRING;
             connexion.Open();
             DbCommand cmd = connexion.CreateCommand();
             cmd.Connection = connexion;

             cmd.CommandText = "INSERT INTO photoLink(link, Evenement_idEvenement)" +
                                        "VALUES (@link,@Evenement_idEvenement)";
             DbParameter param;
             param = new MySqlParameter
             {
                 ParameterName = "link",
                 DbType = System.Data.DbType.String,
                 Value = photoLink.link
             };
             cmd.Parameters.Add(param);
             param = new MySqlParameter
             {
                 ParameterName = "Evenement_idEvenement",
                 DbType = System.Data.DbType.Int32,
                 Value = id_evenement
             };
             
             cmd.Parameters.Add(param);
             bool res = cmd.ExecuteNonQuery() > 0;
             connexion.Close();
             return res;
         }

         public static bool ModifierPhotoLink(PhotoLink photoLink)
         {
             DbConnection connexion = new MySqlConnection();
             connexion.ConnectionString = Config.CONNECTION_STRING;
             connexion.Open();
             DbCommand cmd = connexion.CreateCommand();
             cmd.Connection = connexion;

             cmd.CommandText = "UPDATE photoLink SET link=@link WHERE idphotoLink=@idphotoLink";
             DbParameter param;
             param = new MySqlParameter
             {
                 ParameterName = "link",
                 DbType = System.Data.DbType.String,
                 Value = photoLink.link
             }; cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "idphotoLink",
                DbType = System.Data.DbType.Int32,
                Value = photoLink.Id
            };


            cmd.Parameters.Add(param);
             bool res = cmd.ExecuteNonQuery() > 0;
             connexion.Close();
             return res;
         }

         public static bool DeletePhotoLink(int id)
         {
             DbConnection connexion = new MySqlConnection();
             connexion.ConnectionString = Config.CONNECTION_STRING;
             connexion.Open();
             DbCommand cmd = connexion.CreateCommand();
             cmd.Connection = connexion;

             cmd.CommandText = "DELETE FROM photoLink WHERE idphotoLink=" + id;
             DbParameter param;
             param = new MySqlParameter
             {
                 ParameterName = "idphotoLink",
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


