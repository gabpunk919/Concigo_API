using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Concigo_API.Model;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Concigo_API.DataProviders
{
    public class SQLDataProviderUser
    {
        public static List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user";
                    command.CommandType = CommandType.Text;

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }

        public static User GetUserById(int id)
        {
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE idchauffeur = @id";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "id";
                    parameter.DbType = DbType.Int32;
                    parameter.Value = id;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };
                        }
                    }
                }
            }

            return user;
        }
        public static User GetUserByEmailAndMdp(string email, string mdp)
        {
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE email = @email AND mdp=@mdp";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "email";
                    parameter.DbType = DbType.String;
                    parameter.Value = email;
                    DbParameter parameter2 = command.CreateParameter();
                    parameter2.ParameterName = "mdp";
                    parameter2.DbType = DbType.String;
                    parameter2.Value = mdp;
                    command.Parameters.Add(parameter);
                    command.Parameters.Add(parameter2);
                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };
                        }
                    }
                }
            }

            return user;
        }
        public static List<User> GetUsersByNom(string nom)
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE nom = @nom";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "nom";
                    parameter.DbType = DbType.String;
                    parameter.Value = nom;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }
        public static List<User> GetUsersByPrenom(string prenom)
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE prenom = @prenom";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "prenom";
                    parameter.DbType = DbType.String;
                    parameter.Value = prenom;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }
        public static List<User> GetUserByEmail(string email)
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE email = @email";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "email";
                    parameter.DbType = DbType.String;
                    parameter.Value = email;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }
        public static List<User> GetUserByTelephone(string telephone)
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE telephone = @telephone";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "telephone";
                    parameter.DbType = DbType.String;
                    parameter.Value = telephone;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }
        public static List<User> GetUserByMdp(string mdp)
        {
            List<User> userList = new List<User>();
            User user = null;

            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM user WHERE mdp = @mdp";
                    command.CommandType = CommandType.Text;

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "mdp";
                    parameter.DbType = DbType.String;
                    parameter.Value = mdp;
                    command.Parameters.Add(parameter);

                    using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            user = new User
                            {
                                Id = (int)dataReader["idchauffeur"],
                                nom = (string)dataReader["nom"],
                                prenom = (string)dataReader["prenom"],
                                telephone = (string)dataReader["telephone"],
                                email = (string)dataReader["email"],
                                mdp = (string)dataReader["mdp"]
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }
        public static bool AddUser(User user)
        {
            DbConnection connexion = new MySqlConnection();
            connexion.ConnectionString = Config.CONNECTION_STRING;
            connexion.Open();
            DbCommand cmd = connexion.CreateCommand();
            cmd.Connection = connexion;

            cmd.CommandText = "INSERT INTO user(nom, prenom, telephone, email, mdp) " +
                                          "VALUES(@nom,@prenom,@telephone,@email,@mdp)";
            DbParameter param;
            param = new MySqlParameter
            {
                ParameterName = "nom",
                DbType = System.Data.DbType.String,
                Value = user.nom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "prenom",
                DbType = System.Data.DbType.String,
                Value = user.prenom
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "telephone",
                DbType = System.Data.DbType.String,
                Value = user.telephone
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "email",
                DbType = System.Data.DbType.String,
                Value = user.email
            };
            cmd.Parameters.Add(param);
            param = new MySqlParameter
            {
                ParameterName = "mdp",
                DbType = System.Data.DbType.String,
                Value = user.mdp
            };
            cmd.Parameters.Add(param);
            bool res = cmd.ExecuteNonQuery() > 0;
            connexion.Close();
            return res;
           
        }

        public static bool UpdateUser(User user)
        {
            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE user SET nom = @nom, prenom = @prenom, " +
                                          "telephone = @telephone, email = @email, mdp = @mdp " +
                                          "WHERE idchauffeur = @idchauffeur";

                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(CreateParameter("nom", DbType.String, user.nom));
                    command.Parameters.Add(CreateParameter("prenom", DbType.String, user.prenom));
                    command.Parameters.Add(CreateParameter("telephone", DbType.String, user.telephone));
                    command.Parameters.Add(CreateParameter("email", DbType.String, user.email));
                    command.Parameters.Add(CreateParameter("mdp", DbType.String, user.mdp));
                    command.Parameters.Add(CreateParameter("idchauffeur", DbType.Int32, user.Id));

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public static bool DeleteUser(int id)
        {
            using (DbConnection connection = new MySqlConnection(Config.CONNECTION_STRING))
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM user WHERE idchauffeur = @idchauffeur";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(CreateParameter("idchauffeur", DbType.Int32, id));

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private static DbParameter CreateParameter(string name, DbType type, object value)
        {
            DbParameter parameter = new MySqlParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Value = value;

            return parameter;
        }
    }
}
