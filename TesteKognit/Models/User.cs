namespace TesteKognit.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }

        public User()
        {
            ID = 0;
            Nome = string.Empty;
            Nascimento = DateTime.MinValue;
            CPF = String.Empty;
        }
    }
}