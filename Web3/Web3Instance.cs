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
using static System.Net.Mime.MediaTypeNames;

namespace web3s3m
{
    public class Web3Instance
    {
        public string Key { get; set; }
        public ChainInfo ChainInfo { get; set; }
        public Account Account { get; set; }
        public Web3 Web3 { get; set; }
        public Web3Instance(ChainName chain, string privateKey)
        {
            Key = privateKey;
            ChainInfo = ChainProvider.GetChainInfo(chain);
            NewWeb3AndAccount();
            Web3.TransactionManager.UseLegacyAsDefault = true;
        }
        public void NewWeb3AndAccount()
        {
            Account = new Account(Key, ChainInfo.Id);
            Web3 = new Web3(Account, ChainInfo.Rpcs.First());
        }
    }
}
