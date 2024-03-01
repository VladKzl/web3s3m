using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web3s3m.Blockchain;

namespace web3s3m.Servises
{
    public class SwapService : Web3Base
    {
        public SwapService(Web3Instance web3Base) : base(web3Base)
        {}
        public bool IsChainSupported(ChainName chainName, List<ChainName> supportedChains)
        {
            if(!supportedChains.Any(x => x == chainName))
            {
                throw new Exception(
                    $"SyncSwap не поддерживает сеть {chainName}\r\n" +
                    $"Кто нибудь, разбудите разработчика..");
            }
            return true;
        }
    }
}
