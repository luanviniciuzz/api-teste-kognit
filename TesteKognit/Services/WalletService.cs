using TesteKognit.Models;
using System.Data.SqlClient;
using System.Data;


namespace TesteKognit.Services
{
    public class WalletService
    {
        string conexao = Repository.DBConnection.CadeiaDeConexao;

        public List<Wallet> GetAllWallets()
        {
            List<Wallet> wallets = new List<Wallet>();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Wallet", connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var wallet = new Wallet();
                                wallet.ID = Convert.ToInt32(reader["ID"]);
                                wallet.UserId = Convert.ToInt32(reader["UserID"]);
                                wallet.ValorAtual = Convert.ToDecimal(reader["ValorAtual"]);
                                wallet.UltimaAtualizacao = Convert.ToDateTime(reader["UltimaAtualizacao"]);

                                wallets.Add(wallet);
                            }
                        }
                    }
                }
            }

            return wallets;
        }

        public List<Wallet> GetWalletsByUser(int id)
        {
            List<Wallet> wallets = new List<Wallet>();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Wallet WHERE UserID = @UserID", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var wallet = new Wallet();
                                wallet.ID = Convert.ToInt32(reader["ID"]);
                                wallet.UserId = Convert.ToInt32(reader["UserID"]);
                                wallet.ValorAtual = Convert.ToDecimal(reader["ValorAtual"]);
                                wallet.Banco = reader["Banco"].ToString();
                                wallet.UltimaAtualizacao = Convert.ToDateTime(reader["UltimaAtualizacao"]);

                                wallets.Add(wallet);
                            }
                        }
                    }
                }
            }

            return wallets;
        }

        public Wallet GetWalletById(int id)
        {
            Wallet wallet = new Wallet();

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tb_Wallet WHERE ID = @ID", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                wallet.ID = Convert.ToInt32(reader["ID"]);
                                wallet.UserId = Convert.ToInt32(reader["UserID"]);
                                wallet.ValorAtual = Convert.ToDecimal(reader["ValorAtual"]);
                                wallet.Banco = reader["Banco"].ToString();
                                wallet.UltimaAtualizacao = Convert.ToDateTime(reader["UltimaAtualizacao"]);
                            }
                        }
                    }
                }
            }

            return wallet;
        }

        public void InsertWallet(Wallet wallet)
        {
            using (SqlConnection connection = new SqlConnection(conexao))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_Wallet (UserID, ValorAtual, Banco, UltimaAtualizacao) VALUES(@UserID, @ValorAtual, @Banco, @UltimaAtualizacao)", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", wallet.ID);
                    cmd.Parameters.AddWithValue("@UserID", wallet.UserId);
                    cmd.Parameters.AddWithValue("@ValorAtual", wallet.ValorAtual);
                    cmd.Parameters.AddWithValue("@Banco", wallet.Banco);
                    cmd.Parameters.AddWithValue("@UltimaAtualizacao", wallet.UltimaAtualizacao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}