using TesteKognit.Models;
using System.Data;
using System.Data.SqlClient;


namespace TesteKognit.Services
{
    public class UserService
    {
        string conexao =  Repository.DBConnection.CadeiaDeConexao;

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_User", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.ID = Convert.ToInt32(reader["ID"]);
                                user.Nome = reader["Nome"].ToString();
                                user.Nascimento = Convert.ToDateTime(reader["Nascimento"]);
                                user.CPF = reader["CPF"].ToString();
                                users.Add(user);
                            }
                        }
                    }
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_User WHERE ID = @ID", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                user.ID = Convert.ToInt32(reader["ID"]);
                                user.Nome = reader["Nome"].ToString();
                                user.Nascimento = Convert.ToDateTime(reader["Nascimento"]);
                                user.CPF = reader["CPF"].ToString();
                            }
                        }
                    }
                }
            }

            return user;
        }

        public void InsertUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_User (Nome, Nascimento, CPF) VALUES(@Nome, @Nascimento, @CPF)", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@Nome", user.Nome);
                    cmd.Parameters.AddWithValue("@Nascimento", user.Nascimento);
                    cmd.Parameters.AddWithValue("@CPF", user.CPF);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void Delete(int id)
        //{
        //    using (SqlConnection conn = new SqlConnection(conexao))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("DELETE FROM tb_User WHERE ID = @ID", conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@ID", id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Update(User user)
        //{
        //    using (SqlConnection conn = new SqlConnection(conexao))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("UPDATE tb_User SET NOME = @Nome, Nascimento = @Nascimento, CPF = @CPF WHERE ID = @ID", conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@ID", user.ID);
        //            cmd.Parameters.AddWithValue("@Nome", user.Nome);
        //            cmd.Parameters.AddWithValue("@Nascimento", user.Nascimento);
        //            cmd.Parameters.AddWithValue("@CPF", user.CPF);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}