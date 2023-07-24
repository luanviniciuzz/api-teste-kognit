namespace TesteKognit.Models
{
    public class Wallet
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public decimal ValorAtual { get; set; }
        public string Banco { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public Wallet()
        {
            ID = 0;
            UserId = 0;
            ValorAtual = decimal.Zero;
            Banco = string.Empty;
            UltimaAtualizacao = DateTime.MinValue;
        }
    }
}