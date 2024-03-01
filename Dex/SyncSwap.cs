using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web3s3m.Blockchain;
using web3s3m.Servises;

namespace web3s3m.Dex
{
    public class SyncSwap : SwapService
    {
        public static bool IsSwap = true;
        public static bool IsPool = true;
        public static bool IsBrige = false;
        public static List<ChainName> SupportedChains = new List<ChainName>()
        {
            ChainName.zkSynk, ChainName.Linea, ChainName.Scroll
        };
        public SyncSwap(Web3Instance web3Base) : base(web3Base)
        {
            IsChainSupported(ChainInfo.Name, SupportedChains);
        }
    }
}
