using TesteKognit.Models;
using TesteKognit.Services;

namespace TesteKognit.Repository
{
    public class WalletRepository
    {
        private readonly WalletService _wallet;

        public WalletRepository()
        {
            _wallet = new WalletService();
        }

        public List<Wallet> GetAllWallets
        {
            get
            {
                return _wallet.GetAllWallets();
            }
        }

        public List<Wallet> GetWalletsByUser(int id)
        {
            return _wallet.GetWalletsByUser(id);
        }

        public Wallet GetWalletById(int id)
        {
            return _wallet.GetWalletById(id);
        }

        public void InserirWallet(Wallet wallet)
        {
            _wallet.InsertWallet(wallet);
        }

    }
}