using Nethereum.Contracts;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using web3s3m.Blockchain;
using System.Numerics;
using Nethereum.Contracts.Extensions;
using Nethereum.ABI.Util;
using Nethereum.RPC.Eth.DTOs;
using System.Security.Claims;

namespace web3s3m.Servises
{
    public class WalletService : Web3Base
    {
        public WalletService(Web3Instance web3Instance) : base(web3Instance)
        {}
        protected void GetDecimals()
        {

        }
    }
}
