using TesteKognit.Models;
using TesteKognit.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesteKognit.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletRepository _walletRepository;

        public WalletController()
        {
            _walletRepository = new WalletRepository();
        }

        [HttpGet("wallet/listing")]
        public ActionResult<IEnumerable<Wallet>> Get()
        {
            var wallets = _walletRepository.GetAllWallets;

            if (wallets == null)
                return NotFound();

            return wallets;
        }

        [HttpGet("wallet/by-user-id/id={id}")]
        public ActionResult<IEnumerable<Wallet>> GetByUsers(int id)
        {
            var wallets = _walletRepository.GetWalletsByUser(id);

            if (wallets == null)
                return NotFound();

            return wallets;
        }

        [HttpGet("wallet/by-id/id={id}")]
        public ActionResult<Wallet> GetById(int id)
        {
            var wallet = _walletRepository.GetWalletById(id);

            if (wallet == null)
                return NotFound();

            return wallet;
        }

        [HttpPost("wallet/create")]
        public ActionResult Create([FromBody] Wallet wallet)
        {
            if (wallet == null)
                return NotFound();

            _walletRepository.InserirWallet(wallet);

            return NoContent();
        }

    }
}