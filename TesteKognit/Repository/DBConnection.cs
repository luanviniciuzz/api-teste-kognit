using TesteKognit.Models;

namespace TesteKognit.Repository
{
    public class DBConnection
    {
        public static string CadeiaDeConexao
        {
            get { return @"Server=localhost;Database=TesteKognit;Trusted_Connection=True"; }
         
        }
    }
}
